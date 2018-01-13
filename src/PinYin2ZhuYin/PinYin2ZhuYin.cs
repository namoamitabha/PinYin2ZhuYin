using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PY2ZY
{
    public class SplitChar
    {
        public const char BLANK_SPACE = ' ';
        public const char BACK_SLASH = '\\';
    }
    /// <summary>
    /// 
    /// </summary>
    public class PinYin2ZhuYin
    {
        public PinYin2ZhuYin()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pyStr">PinYin string, can be splitted by space</param>
        /// <returns></returns>
        public static string Convert(string pyStr, bool isShowYinDiaoYi = false)
        {
            if (null == pyStr)
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(pyStr) || string.IsNullOrWhiteSpace(pyStr))
                return pyStr;

            char splitChar = Char.MinValue;
            if (pyStr.Contains(SplitChar.BLANK_SPACE))
                splitChar = SplitChar.BLANK_SPACE;
            else
                splitChar = SplitChar.BACK_SLASH;

            List<string> pyList = new List<string>(pyStr.Split(splitChar));
            StringBuilder strBuild = new StringBuilder();
            foreach (var item in pyList)
            {
                strBuild.AppendFormat("{0}{1}", 
                    new PingYin(item, isShowYinDiaoYi).ZhuYin,
                    splitChar.ToString());
            }
            
            return strBuild.ToString().Trim(splitChar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileFullPath">new converted file full name</param>
        /// <returns></returns>
        public static string ConvertFile(string fileFullPath, bool isShowYinDiaoYi = false)
        {
            if (string.IsNullOrEmpty(fileFullPath) || !File.Exists(fileFullPath))
                throw new ArgumentNullException("Invalid file name or path");

            List<string> lineList = new List<string>(File.ReadAllLines(fileFullPath, Encoding.UTF8));
            List<string> resultLineList = new List<string>();
            foreach (var line in lineList)
            {
                resultLineList.Add(Convert(line, isShowYinDiaoYi));
            }
            string resultFileName = string.Format("PinYin2ZhuYin_ConvertedFile_{0}.txt", 
                DateTime.Now.ToFileTime());

            File.WriteAllLines(resultFileName, resultLineList, Encoding.UTF8);
            return resultFileName;
        }
    }

    public class YinDiaoChar
    {
        public YinDiaoChar(string ch, int diao)
        {
            CharWuDiao = ch;
            DiaoNum = diao;
        }
        public string CharWuDiao;
        public string CharYouDiao;
        public int DiaoNum = 0;
        private static List<string> DiaoList = new List<string>{
            "", "ˉ", "ˊ", "ˇ", "ˋ"};
        public string DiaoChar
        {
            get
            {
                return DiaoList[DiaoNum];
            }
        }
    }

    public class PingYin
    {
        public PingYin(string strPY, bool isShowDiaoYi = false)
        {
            if (string.IsNullOrEmpty(strPY))
                return;

            this.isShowDiaoYi = isShowDiaoYi;

            CheckYinDiaoCha(strPY.ToLower());

        }

        #region dict data
        protected static Dictionary<string, string> SinglePYDict =
            new Dictionary<string, string>
        { 
                {"a","ㄚ"},
                {"ai","ㄞ"},
                {"an","ㄢ"},
                {"ang","ㄤ"},
                {"ao","ㄠ"},
                {"ba","ㄅㄚ"},
                {"bai","ㄅㄞ"},
                {"ban","ㄅㄢ"},
                {"bang","ㄅㄤ"},
                {"bao","ㄅㄠ"},
                {"bei","ㄅㄟ"},
                {"ben","ㄅㄣ"},
                {"beng","ㄅㄥ"},
                {"bi","ㄅㄧ"},
                {"bian","ㄅㄧㄢ"},
                {"biao","ㄅㄧㄠ"},
                {"bie","ㄅㄧㄝ"},
                {"bin","ㄅㄧㄣ"},
                {"bing","ㄅㄧㄥ"},
                {"bo","ㄅㄛ"},
                {"bu","ㄅㄨ"},
                {"ca","ㄘㄚ"},
                {"cai","ㄘㄞ"},
                {"can","ㄘㄢ"},
                {"cang","ㄘㄤ"},
                {"cao","ㄘㄠ"},
                {"ce","ㄘㄜ"},
                {"cen","ㄘㄣ"},
                {"ceng","ㄘㄥ"},
                {"cha","ㄔㄚ"},
                {"chai","ㄔㄞ"},
                {"chan","ㄔㄢ"},
                {"chang","ㄔㄤ"},
                {"chao","ㄔㄠ"},
                {"che","ㄔㄜ"},
                {"chen","ㄔㄣ"},
                {"cheng","ㄔㄥ"},
                {"chi","ㄔ"},
                {"chong","ㄔㄨㄥ"},
                {"chou","ㄔㄡ"},
                {"chu","ㄔㄨ"},
                {"chua","ㄔㄨㄚ"},
                {"chuai","ㄔㄨㄞ"},
                {"chuan","ㄔㄨㄢ"},
                {"chuang","ㄔㄨㄤ"},
                {"chui","ㄔㄨㄟ"},
                {"chun","ㄔㄨㄣ"},
                {"chuo","ㄔㄨㄛ"},
                {"qi","ㄑㄧ"},
                {"qia","ㄑㄧㄚ"},
                {"qian","ㄑㄧㄢ"},
                {"qiang","ㄑㄧㄤ"},
                {"qiao","ㄑㄧㄠ"},
                {"qie","ㄑㄧㄝ"},
                {"ci","ㄘ"},
                {"qin","ㄑㄧㄣ"},
                {"qing","ㄑㄧㄥ"},
                {"qiu","ㄑㄧㄡ"},
                {"cong","ㄘㄨㄥ"},
                {"cou","ㄘㄡ"},
                {"cu","ㄘㄨ"},
                {"cuan","ㄘㄨㄢ"},
                {"cui","ㄘㄨㄟ"},
                {"cun","ㄘㄨㄣ"},
                {"cuo","ㄘㄨㄛ"},
                {"qiong","ㄑㄩㄥ"},
                {"qu","ㄑㄩ"},
                {"quan","ㄑㄩㄢ"},
                {"que","ㄑㄩㄝ"},
                {"qun","ㄑㄩㄣ"},
                {"da","ㄉㄚ"},
                {"dai","ㄉㄞ"},
                {"dan","ㄉㄢ"},
                {"dang","ㄉㄤ"},
                {"dao","ㄉㄠ"},
                {"de","ㄉㄜ"},
                {"dei","ㄉㄟ"},
                {"den","ㄉㄣ"},
                {"deng","ㄉㄥ"},
                {"di","ㄉㄧ"},
                {"dian","ㄉㄧㄢ"},
                {"diang","ㄉㄧㄤ"},
                {"diao","ㄉㄧㄠ"},
                {"die","ㄉㄧㄝ"},
                {"ding","ㄉㄧㄥ"},
                {"diu","ㄉㄧㄡ"},
                {"dong","ㄉㄨㄥ"},
                {"dou","ㄉㄡ"},
                {"du","ㄉㄨ"},
                {"duan","ㄉㄨㄢ"},
                {"dui","ㄉㄨㄟ"},
                {"dun","ㄉㄨㄣ"},
                {"duo","ㄉㄨㄛ"},
                {"e","ㄜ"},
                {"ei","ㄟ"},
                {"en","ㄣ"},
                {"eng","ㄥ"},
                {"er","ㄦ"},
                {"fa","ㄈㄚ"},
                {"fan","ㄈㄢ"},
                {"fang","ㄈㄤ"},
                {"fei","ㄈㄟ"},
                {"fen","ㄈㄣ"},
                {"fo","ㄈㄛ"},
                {"feng","ㄈㄥ"},
                {"fou","ㄈㄡ"},
                {"fu","ㄈㄨ"},
                {"ga","ㄍㄚ"},
                {"gai","ㄍㄞ"},
                {"gan","ㄍㄢ"},
                {"gang","ㄍㄤ"},
                {"gao","ㄍㄠ"},
                {"ge","ㄍㄜ"},
                {"gei","ㄍㄟ"},
                {"gen","ㄍㄣ"},
                {"geng","ㄍㄥ"},
                {"gong","ㄍㄨㄥ"},
                {"gou","ㄍㄡ"},
                {"gu","ㄍㄨ"},
                {"gua","ㄍㄨㄚ"},
                {"guai","ㄍㄨㄞ"},
                {"guan","ㄍㄨㄢ"},
                {"guang","ㄍㄨㄤ"},
                {"gui","ㄍㄨㄟ"},
                {"gun","ㄍㄨㄣ"},
                {"guo","ㄍㄨㄛ"},
                {"ha","ㄏㄚ"},
                {"hai","ㄏㄞ"},
                {"han","ㄏㄢ"},
                {"hang","ㄏㄤ"},
                {"hao","ㄏㄠ"},
                {"he","ㄏㄜ"},
                {"hei","ㄏㄟ"},
                {"hen","ㄏㄣ"},
                {"heng","ㄏㄥ"},
                {"hong","ㄏㄨㄥ"},
                {"hou","ㄏㄡ"},
                {"hu","ㄏㄨ"},
                {"hua","ㄏㄨㄚ"},
                {"huai","ㄏㄨㄞ"},
                {"huan","ㄏㄨㄢ"},
                {"huang","ㄏㄨㄤ"},
                {"hui","ㄏㄨㄟ"},
                {"hun","ㄏㄨㄣ"},
                {"huo","ㄏㄨㄛ"},
                {"zha","ㄓㄚ"},
                {"zhai","ㄓㄞ"},
                {"zhan","ㄓㄢ"},
                {"zhang","ㄓㄤ"},
                {"zhao","ㄓㄠ"},
                {"zhe","ㄓㄜ"},
                {"zhei","ㄓㄟ"},
                {"zhen","ㄓㄣ"},
                {"zheng","ㄓㄥ"},
                {"zhi","ㄓ"},
                {"zhong","ㄓㄨㄥ"},
                {"zhou","ㄓㄡ"},
                {"zhu","ㄓㄨ"},
                {"zhua","ㄓㄨㄚ"},
                {"zhuai","ㄓㄨㄞ"},
                {"zhuan","ㄓㄨㄢ"},
                {"zhuang","ㄓㄨㄤ"},
                {"zhui","ㄓㄨㄟ"},
                {"zhun","ㄓㄨㄣ"},
                {"zhuo","ㄓㄨㄛ"},
                {"ji","ㄐㄧ"},
                {"jia","ㄐㄧㄚ"},
                {"jian","ㄐㄧㄢ"},
                {"jiang","ㄐㄧㄤ"},
                {"jiao","ㄐㄧㄠ"},
                {"jie","ㄐㄧㄝ"},
                {"jin","ㄐㄧㄣ"},
                {"jing","ㄐㄧㄥ"},
                {"jiu","ㄐㄧㄡ"},
                {"juan","ㄐㄩㄢ"},
                {"jue","ㄐㄩㄝ"},
                {"jun","ㄐㄩㄣ"},
                {"jiong","ㄐㄩㄥ"},
                {"ju","ㄐㄩ"},
                {"ka","ㄎㄚ"},
                {"kai","ㄎㄞ"},
                {"kan","ㄎㄢ"},
                {"kang","ㄎㄤ"},
                {"kao","ㄎㄠ"},
                {"ke","ㄎㄜ"},
                {"ken","ㄎㄣ"},
                {"keng","ㄎㄥ"},
                {"kong","ㄎㄨㄥ"},
                {"kou","ㄎㄡ"},
                {"ku","ㄎㄨ"},
                {"kua","ㄎㄨㄚ"},
                {"kuai","ㄎㄨㄞ"},
                {"kuan","ㄎㄨㄢ"},
                {"kuang","ㄎㄨㄤ"},
                {"kui","ㄎㄨㄟ"},
                {"kun","ㄎㄨㄣ"},
                {"kuo","ㄎㄨㄛ"},
                {"la","ㄌㄚ"},
                {"lai","ㄌㄞ"},
                {"lan","ㄌㄢ"},
                {"lang","ㄌㄤ"},
                {"lao","ㄌㄠ"},
                {"le","ㄌㄜ"},
                {"lei","ㄌㄟ"},
                {"leng","ㄌㄥ"},
                {"li","ㄌㄧ"},
                {"lia","ㄌㄧㄚ"},
                {"lian","ㄌㄧㄢ"},
                {"liang","ㄌㄧㄤ"},
                {"liao","ㄌㄧㄠ"},
                {"lie","ㄌㄧㄝ"},
                {"lin","ㄌㄧㄣ"},
                {"ling","ㄌㄧㄥ"},
                {"liu","ㄌㄧㄡ"},
                {"lo","ㄌㄛ"},
                {"long","ㄌㄨㄥ"},
                {"lou","ㄌㄡ"},
                {"lu","ㄌㄨ"},
                {"luan","ㄌㄨㄢ"},
                {"lun","ㄌㄨㄣ"},
                {"luo","ㄌㄨㄛ"},
                {"lue","ㄌㄩㄝ"},
                {"ma","ㄇㄚ"},
                {"mai","ㄇㄞ"},
                {"man","ㄇㄢ"},
                {"mang","ㄇㄤ"},
                {"mao","ㄇㄠ"},
                {"me","ㄇㄜ"},
                {"mei","ㄇㄟ"},
                {"men","ㄇㄣ"},
                {"meng","ㄇㄥ"},
                {"mi","ㄇㄧ"},
                {"mian","ㄇㄧㄢ"},
                {"miao","ㄇㄧㄠ"},
                {"mie","ㄇㄧㄝ"},
                {"min","ㄇㄧㄣ"},
                {"ming","ㄇㄧㄥ"},
                {"miu","ㄇㄧㄡ"},
                {"mo","ㄇㄛ"},
                {"mou","ㄇㄡ"},
                {"mu","ㄇㄨ"},
                {"na","ㄋㄚ"},
                {"nai","ㄋㄞ"},
                {"nan","ㄋㄢ"},
                {"nang","ㄋㄤ"},
                {"nao","ㄋㄠ"},
                {"ne","ㄋㄜ"},
                {"nei","ㄋㄟ"},
                {"nen","ㄋㄣ"},
                {"neng","ㄋㄥ"},
                {"ni","ㄋㄧ"},
                {"nia","ㄋㄧㄚ"},
                {"nian","ㄋㄧㄢ"},
                {"niang","ㄋㄧㄤ"},
                {"niao","ㄋㄧㄠ"},
                {"nie","ㄋㄧㄝ"},
                {"nin","ㄋㄧㄣ"},
                {"ning","ㄋㄧㄥ"},
                {"niu","ㄋㄧㄡ"},
                {"nong","ㄋㄨㄥ"},
                {"nou","ㄋㄡ"},
                {"nu","ㄋㄨ"},
                {"nü","ㄋㄩ"},
                {"nuan","ㄋㄨㄢ"},
                {"nun","ㄋㄨㄣ"},
                {"nuo","ㄋㄨㄛ"},
                {"nue","ㄋㄩㄝ"},
                {"o","ㄛ"},
                {"ou","ㄡ"},
                {"pa","ㄆㄚ"},
                {"pai","ㄆㄞ"},
                {"pan","ㄆㄢ"},
                {"pang","ㄆㄤ"},
                {"pao","ㄆㄠ"},
                {"pei","ㄆㄟ"},
                {"pen","ㄆㄣ"},
                {"peng","ㄆㄥ"},
                {"pi","ㄆㄧ"},
                {"pian","ㄆㄧㄢ"},
                {"piao","ㄆㄧㄠ"},
                {"pie","ㄆㄧㄝ"},
                {"pin","ㄆㄧㄣ"},
                {"ping","ㄆㄧㄥ"},
                {"po","ㄆㄛ"},
                {"pou","ㄆㄡ"},
                {"pu","ㄆㄨ"},
                {"ran","ㄖㄢ"},
                {"rang","ㄖㄤ"},
                {"rao","ㄖㄠ"},
                {"re","ㄖㄜ"},
                {"ren","ㄖㄣ"},
                {"reng","ㄖㄥ"},
                {"ri","ㄖ"},
                {"rong","ㄖㄨㄥ"},
                {"rou","ㄖㄡ"},
                {"ru","ㄖㄨ"},
                {"ruan","ㄖㄨㄢ"},
                {"rui","ㄖㄨㄟ"},
                {"run","ㄖㄨㄣ"},
                {"ruo","ㄖㄨㄛ"},
                {"sa","ㄙㄚ"},
                {"sai","ㄙㄞ"},
                {"san","ㄙㄢ"},
                {"sang","ㄙㄤ"},
                {"sao","ㄙㄠ"},
                {"se","ㄙㄜ"},
                {"sei","ㄙㄟ"},
                {"sen","ㄙㄣ"},
                {"seng","ㄙㄥ"},
                {"sha","ㄕㄚ"},
                {"shai","ㄕㄞ"},
                {"shan","ㄕㄢ"},
                {"shang","ㄕㄤ"},
                {"shao","ㄕㄠ"},
                {"she","ㄕㄜ"},
                {"shei","ㄕㄟ"},
                {"shen","ㄕㄣ"},
                {"sheng","ㄕㄥ"},
                {"shi","ㄕ"},
                {"shong","ㄕㄨㄥ"},
                {"shou","ㄕㄡ"},
                {"shu","ㄕㄨ"},
                {"shua","ㄕㄨㄚ"},
                {"shuai","ㄕㄨㄞ"},
                {"shuan","ㄕㄨㄢ"},
                {"shuang","ㄕㄨㄤ"},
                {"shui","ㄕㄨㄟ"},
                {"shun","ㄕㄨㄣ"},
                {"shuo","ㄕㄨㄛ"},
                {"xi","ㄒㄧ"},
                {"xia","ㄒㄧㄚ"},
                {"xian","ㄒㄧㄢ"},
                {"xiang","ㄒㄧㄤ"},
                {"xiao","ㄒㄧㄠ"},
                {"xie","ㄒㄧㄝ"},
                {"si","ㄙ"},
                {"xin","ㄒㄧㄣ"},
                {"xing","ㄒㄧㄥ"},
                {"xiu","ㄒㄧㄡ"},
                {"song","ㄙㄨㄥ"},
                {"sou","ㄙㄡ"},
                {"su","ㄙㄨ"},
                {"suan","ㄙㄨㄢ"},
                {"sui","ㄙㄨㄟ"},
                {"sun","ㄙㄨㄣ"},
                {"suo","ㄙㄨㄛ"},
                {"xiong","ㄒㄩㄥ"},
                {"xu","ㄒㄩ"},
                {"xuan","ㄒㄩㄢ"},
                {"xue","ㄒㄩㄝ"},
                {"xun","ㄒㄩㄣ"},
                {"ta","ㄊㄚ"},
                {"tai","ㄊㄞ"},
                {"tan","ㄊㄢ"},
                {"tang","ㄊㄤ"},
                {"tao","ㄊㄠ"},
                {"te","ㄊㄜ"},
                {"teng","ㄊㄥ"},
                {"ti","ㄊㄧ"},
                {"tian","ㄊㄧㄢ"},
                {"tiao","ㄊㄧㄠ"},
                {"tie","ㄊㄧㄝ"},
                {"ting","ㄊㄧㄥ"},
                {"tong","ㄊㄨㄥ"},
                {"tou","ㄊㄡ"},
                {"tu","ㄊㄨ"},
                {"tuan","ㄊㄨㄢ"},
                {"tui","ㄊㄨㄟ"},
                {"tun","ㄊㄨㄣ"},
                {"tuo","ㄊㄨㄛ"},
                {"wa","ㄨㄚ"},
                {"wai","ㄨㄞ"},
                {"wan","ㄨㄢ"},
                {"wang","ㄨㄤ"},
                {"wei","ㄨㄟ"},
                {"wen","ㄨㄣ"},
                {"wo","ㄨㄛ"},
                {"weng","ㄨㄥ"},
                {"wu","ㄨ"},
                {"ya","ㄧㄚ"},
                {"yan","ㄧㄢ"},
                {"yang","ㄧㄤ"},
                {"yao","ㄧㄠ"},
                {"ye","ㄧㄝ"},
                {"yi","ㄧ"},
                {"yin","ㄧㄣ"},
                {"ying","ㄧㄥ"},
                {"yo","ㄧㄛ"},
                {"yong","ㄩㄥ"},
                {"you","ㄧㄡ"},
                {"yu","ㄩ"},
                {"yuan","ㄩㄢ"},
                {"yue","ㄩㄝ"},
                {"yun","ㄩㄣ"},
                {"za","ㄗㄚ"},
                {"zai","ㄗㄞ"},
                {"zan","ㄗㄢ"},
                {"zang","ㄗㄤ"},
                {"zao","ㄗㄠ"},
                {"ze","ㄗㄜ"},
                {"zei","ㄗㄟ"},
                {"zen","ㄗㄣ"},
                {"zeng","ㄗㄥ"},
                {"zi","ㄗ"},
                {"zong","ㄗㄨㄥ"},
                {"zou","ㄗㄡ"},
                {"zu","ㄗㄨ"},
                {"zuan","ㄗㄨㄢ"},
                {"zui","ㄗㄨㄟ"},
                {"zun","ㄗㄨㄣ"},
                {"zuo","ㄗㄨㄛ"},
        };
        #endregion

        #region Diao data
        private Dictionary<string, YinDiaoChar> YinDiaoCharList =
            new Dictionary<string, YinDiaoChar> 
        { 
                {"ā",new YinDiaoChar("a",1)},
                {"á",new YinDiaoChar("a",2)},
                {"ǎ",new YinDiaoChar("a",3)},
                {"à",new YinDiaoChar("a",4)},
                {"ō",new YinDiaoChar("o",1)},
                {"ó",new YinDiaoChar("o",2)},
                {"ǒ",new YinDiaoChar("o",3)},
                {"ò",new YinDiaoChar("o",4)},
                {"ē",new YinDiaoChar("e",1)},
                {"é",new YinDiaoChar("e",2)},
                {"ě",new YinDiaoChar("e",3)},
                {"è",new YinDiaoChar("e",4)},
                {"ī",new YinDiaoChar("i",1)},
                {"í",new YinDiaoChar("i",2)},
                {"ǐ",new YinDiaoChar("i",3)},
                {"ì",new YinDiaoChar("i",4)},
                {"ū",new YinDiaoChar("u",1)},
                {"ú",new YinDiaoChar("u",2)},
                {"ǔ",new YinDiaoChar("u",3)},
                {"ù",new YinDiaoChar("u",4)},
                {"ǖ",new YinDiaoChar("ü",1)},
                {"ǘ",new YinDiaoChar("ü",2)},
                {"ǚ",new YinDiaoChar("ü",3)},
                {"ǜ",new YinDiaoChar("ü",4)},
                {"a",new YinDiaoChar("a",0)},
                {"o",new YinDiaoChar("o",0)},
                {"e",new YinDiaoChar("e",0)},
                {"i",new YinDiaoChar("i",0)},
                {"u",new YinDiaoChar("u",0)},
                {"ü",new YinDiaoChar("ü",0)},
        };
        #endregion

        private void CheckYinDiaoCha(string strPY)
        {
            pinYin = strPY;

            int i = 0;
            List<string> keys = new List<string>(YinDiaoCharList.Keys);

            for (; i < keys.Count; ++i)
            {
                YinDiaoChar item = YinDiaoCharList[keys[i]];
                if (strPY.Contains(keys[i]))
                {
                    yinDiaoNum = item.DiaoNum;
                    yinDiaoChar = keys[i];
                    pyWuDiao = strPY.Replace(yinDiaoChar, item.CharWuDiao);
                    diaoChar = item.DiaoChar;
                    if (SinglePYDict.ContainsKey(pyWuDiao))
                    {
                        zhuYin = SinglePYDict[pyWuDiao];
                    }
                    else
                    {
                        Console.WriteLine("Not valid pinyin:{0},{1}", strPY, pyWuDiao);
                    }
                    break;
                }
            }
        }

        
        private string pinYin;
        public string PinYin
        {
            get { return pinYin; }
        }

        private string pyWuDiao = string.Empty;
        public string PinYinWuDiao
        {
            get { return pyWuDiao; }
        }

        private int yinDiaoNum = -1;
        public int YinDiaoNum
        {
            get { return yinDiaoNum; }
        }

        private string yinDiaoChar = string.Empty;
        public string YinDiaoChar
        {
            get { return yinDiaoChar; }
        }

        private bool isShowDiaoYi;
        private string diaoChar;
        public string DiaoChar
        {
            get
            {
                if (yinDiaoNum.Equals(1) && !isShowDiaoYi)
                    return string.Empty;
                return diaoChar;
            }
        }

        private string zhuYin = string.Empty;
        public string ZhuYin
        {
            get { return zhuYin + DiaoChar; }
        }
    }


}
