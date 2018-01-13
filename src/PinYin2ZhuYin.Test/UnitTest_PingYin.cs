using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PY2ZY;

namespace PinYin2ZhuYin.Test
{
    /// <summary>
    /// UnitTest_PingYin 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest_PingYin
    {
        public void DictAdd(Dictionary<string, string> dict, string key, string value)
        {
            if (dict.ContainsKey(key))
            {
                //Console.WriteLine("Duplicate dict key:{0},{1}", key, value);
            }
            else
            {
                dict.Add(key, value);
            }
        }

        [TestMethod]
        public void TestMethod01()
        {
            //rén zhī chū xìng 
            PingYin result = new PingYin("xìng");
            Assert.AreEqual<int>(4, result.YinDiaoNum);
            Assert.AreEqual<string>("xing", result.PinYinWuDiao);
            Assert.AreEqual<string>("xìng", result.PinYin);
            Assert.AreEqual<string>("ì", result.YinDiaoChar);
            Assert.AreEqual<string>("ˋ", result.DiaoChar);
            Assert.AreEqual<string>("ㄒㄧㄥˋ", result.ZhuYin);


        }

        [TestMethod]
        public void TestMethod02()
        {
            Assert.AreEqual<string>("ㄖㄣˊ", new PingYin("rén").ZhuYin);
            Assert.AreEqual<string>("ㄓˉ", new PingYin("zhī", true).ZhuYin);
            Assert.AreEqual<string>("ㄔㄨˉ", new PingYin("chū", true).ZhuYin);
            Assert.AreEqual<string>("ㄩㄢˇ", new PingYin("yuǎn").ZhuYin);
            //ㄓ zhī ㄓˉ
            Assert.AreEqual<string>("ㄓˉ", new PingYin("zhī", true).ZhuYin);
            Assert.AreEqual<string>("ㄓ", new PingYin("zhī", false).ZhuYin);
        }

        [TestMethod]
        public void TestMethod03()
        {
            Assert.AreEqual<string>("ㄓˉ", new PingYin("zhī", true).ZhuYin);
            Assert.AreEqual<string>("ㄓ", new PingYin("ZHI").ZhuYin);
            Assert.AreEqual<string>("ㄓ", new PingYin("ZHi").ZhuYin);

            Dictionary<string, string> zyPY = new Dictionary<string, string> 
            { 
                {"ㄔ","chi"},
                {"ㄕ","shi"},
                {"ㄖ","ri"},
                {"ㄗ","zi"},
                {"ㄘ","ci"},
                {"ㄙ","si"},
                {"ㄚ","a"},
                {"ㄛ","o"},
                {"ㄜ","e"},
                {"ㄞ","ai"},
                {"ㄟ","ei"},
                {"ㄠ","ao"},
                {"ㄡ","ou"},
                {"ㄢ","an"},
                {"ㄣ","en"},
                {"ㄤ","ang"},
                {"ㄥ","eng"},
                {"ㄦ","er"},
                {"ㄧ","yi"},
                {"ㄨ","wu"},
                {"ㄩ","yu"},
            };

            foreach (var item in zyPY)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
                Assert.AreEqual<string>(item.Key, new PingYin(item.Value).ZhuYin);
            }
        }

        /// <summar>
        /// TODO {"ㄝ","ê"},
        /// TODO ㄧㄚ yai ㄧㄞ
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestMethod04()
        {
            Assert.AreEqual<string>("ㄝ", new PingYin("ê").ZhuYin);
        }

        [TestMethod]
        public void TestMethod05()
        {
            #region dataDict
            Dictionary<string, string> dataDict = new Dictionary<string, string> 
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

            foreach (var item in dataDict)
            {
                //Console.WriteLine("{0}:{1}", item.Key, item.Value);
                string actualValue = new PingYin(item.Key).ZhuYin;
                if (0 != string.Compare(item.Value, actualValue))
                {
                    Console.WriteLine("{0} {1} {2}", item.Value, item.Key, actualValue);
                }
                Assert.AreEqual<string>(item.Value, new PingYin(item.Key).ZhuYin);
            }
        }

        [TestMethod]
        public void TestMethod06_http_ctext_org()
        {
            #region dataDict
            Dictionary<string, string> dataDict = new Dictionary<string, string> 
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
                {"LU","ㄌㄨ"},
                {"Luan","ㄌㄨㄢ"},
                {"lue","ㄌㄩㄝ"},
                {"Lun","ㄌㄨㄣ"},
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
                {"nuan","ㄋㄨㄢ"},
                {"nun","ㄋㄨㄣ"},
                {"nuo","ㄋㄨㄛ"},
                {"NU","ㄋㄨ"},
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

            foreach (var item in dataDict)
            {
                //Console.WriteLine("{0}:{1}", item.Key, item.Value);
                string actualValue = new PingYin(item.Key).ZhuYin;
                if (0 != string.Compare(item.Value, actualValue))
                {
                    Console.WriteLine("{0} {1} {2}", item.Value, item.Key, actualValue);
                }
                Assert.AreEqual<string>(item.Value, new PingYin(item.Key).ZhuYin);
            }
        }


        [TestMethod]
        public void TestMethod07_SanZiJing()
        {
            #region dataDict
            Dictionary<string, string> dataDict = new Dictionary<string, string> { };
            DictAdd(dataDict, "rén", "ㄖㄣˊ");
            DictAdd(dataDict, "zhī", "ㄓ");
            DictAdd(dataDict, "chū", "ㄔㄨ");
            DictAdd(dataDict, "xìng", "ㄒㄧㄥˋ");
            DictAdd(dataDict, "běn", "ㄅㄣˇ");
            DictAdd(dataDict, "shàn", "ㄕㄢˋ");
            DictAdd(dataDict, "xiāng", "ㄒㄧㄤ");
            DictAdd(dataDict, "xiàng", "ㄒㄧㄤˋ");
            DictAdd(dataDict, "jìn", "ㄐㄧㄣˋ");
            DictAdd(dataDict, "xí", "ㄒㄧˊ");
            DictAdd(dataDict, "yuǎn", "ㄩㄢˇ");
            DictAdd(dataDict, "gǒu", "ㄍㄡˇ");
            DictAdd(dataDict, "bù", "ㄅㄨˋ");
            DictAdd(dataDict, "fǒu", "ㄈㄡˇ");
            DictAdd(dataDict, "jiào", "ㄐㄧㄠˋ");
            DictAdd(dataDict, "jiāo", "ㄐㄧㄠ");
            DictAdd(dataDict, "nǎi", "ㄋㄞˇ");
            DictAdd(dataDict, "qiān", "ㄑㄧㄢ");
            DictAdd(dataDict, "dào", "ㄉㄠˋ");
            DictAdd(dataDict, "guì", "ㄍㄨㄟˋ");
            DictAdd(dataDict, "yǐ", "ㄧˇ");
            DictAdd(dataDict, "zhuān", "ㄓㄨㄢ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "mèng", "ㄇㄥˋ");
            DictAdd(dataDict, "mǔ", "ㄇㄨˇ");
            DictAdd(dataDict, "zé", "ㄗㄜˊ");
            DictAdd(dataDict, "zhái", "ㄓㄞˊ");
            DictAdd(dataDict, "lín", "ㄌㄧㄣˊ");
            DictAdd(dataDict, "chǔ", "ㄔㄨˇ");
            DictAdd(dataDict, "zǐ", "ㄗˇ");
            DictAdd(dataDict, "xué", "ㄒㄩㄝˊ");
            DictAdd(dataDict, "duàn", "ㄉㄨㄢˋ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "zhù", "ㄓㄨˋ");
            DictAdd(dataDict, "dòu", "ㄉㄡˋ");
            DictAdd(dataDict, "yàn", "ㄧㄢˋ");
            DictAdd(dataDict, "yān", "ㄧㄢ");
            DictAdd(dataDict, "shān", "ㄕㄢ");
            DictAdd(dataDict, "yǒu", "ㄧㄡˇ");
            DictAdd(dataDict, "yòu", "ㄧㄡˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "fāng", "ㄈㄤ");
            DictAdd(dataDict, "wǔ", "ㄨˇ");
            DictAdd(dataDict, "míng", "ㄇㄧㄥˊ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "yáng", "ㄧㄤˊ");
            DictAdd(dataDict, "yǎng", "ㄧㄤˇ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "fǔ", "ㄈㄨˇ");
            DictAdd(dataDict, "guò", "ㄍㄨㄛˋ");
            DictAdd(dataDict, "yán", "ㄧㄢˊ");
            DictAdd(dataDict, "shī", "ㄕ");
            DictAdd(dataDict, "duò", "ㄉㄨㄛˋ");
            DictAdd(dataDict, "fēi", "ㄈㄟ");
            DictAdd(dataDict, "suǒ", "ㄙㄨㄛˇ");
            DictAdd(dataDict, "yí", "ㄧˊ");
            DictAdd(dataDict, "yòu", "ㄧㄡˋ");
            DictAdd(dataDict, "lǎo", "ㄌㄠˇ");
            DictAdd(dataDict, "hé", "ㄏㄜˊ");
            DictAdd(dataDict, "hē", "ㄏㄜ");
            DictAdd(dataDict, "hè", "ㄏㄜˋ");
            DictAdd(dataDict, "wéi", "ㄨㄟˊ");
            DictAdd(dataDict, "wèi", "ㄨㄟˋ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "zhuó", "ㄓㄨㄛˊ");
            DictAdd(dataDict, "zuó", "ㄗㄨㄛˊ");
            DictAdd(dataDict, "chéng", "ㄔㄥˊ");
            DictAdd(dataDict, "qì", "ㄑㄧˋ");
            DictAdd(dataDict, "zhī", "ㄓ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "shǎo", "ㄕㄠˇ");
            DictAdd(dataDict, "shào", "ㄕㄠˋ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "qīn", "ㄑㄧㄣ");
            DictAdd(dataDict, "qìng", "ㄑㄧㄥˋ");
            DictAdd(dataDict, "yǒu", "ㄧㄡˇ");
            DictAdd(dataDict, "lǐ", "ㄌㄧˇ");
            DictAdd(dataDict, "yí", "ㄧˊ");
            DictAdd(dataDict, "xiāng", "ㄒㄧㄤ");
            DictAdd(dataDict, "jiǔ", "ㄐㄧㄡˇ");
            DictAdd(dataDict, "líng", "ㄌㄧㄥˊ");
            DictAdd(dataDict, "néng", "ㄋㄥˊ");
            DictAdd(dataDict, "nài", "ㄋㄞˋ");
            DictAdd(dataDict, "wēn", "ㄨㄣ");
            DictAdd(dataDict, "xí", "ㄒㄧˊ");
            DictAdd(dataDict, "xiào", "ㄒㄧㄠˋ");
            DictAdd(dataDict, "yú", "ㄩˊ");
            DictAdd(dataDict, "wū", "ㄨ");
            DictAdd(dataDict, "dāng", "ㄉㄤ");
            DictAdd(dataDict, "dàng", "ㄉㄤˋ");
            DictAdd(dataDict, "dǎng", "ㄉㄤˇ");
            DictAdd(dataDict, "zhí", "ㄓˊ");
            DictAdd(dataDict, "róng", "ㄖㄨㄥˊ");
            DictAdd(dataDict, "sì", "ㄙˋ");
            DictAdd(dataDict, "suì", "ㄙㄨㄟˋ");
            DictAdd(dataDict, "ràng", "ㄖㄤˋ");
            DictAdd(dataDict, "lí", "ㄌㄧˊ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "tì", "ㄊㄧˋ");
            DictAdd(dataDict, "tuí", "ㄊㄨㄟˊ");
            DictAdd(dataDict, "cháng", "ㄔㄤˊ");
            DictAdd(dataDict, "zhǎng", "ㄓㄤˇ");
            DictAdd(dataDict, "xiān", "ㄒㄧㄢ");
            DictAdd(dataDict, "shǒu", "ㄕㄡˇ");
            DictAdd(dataDict, "cì", "ㄘˋ");
            DictAdd(dataDict, "jiàn", "ㄐㄧㄢˋ");
            DictAdd(dataDict, "xiàn", "ㄒㄧㄢˋ");
            DictAdd(dataDict, "wén", "ㄨㄣˊ");
            DictAdd(dataDict, "mǒu", "ㄇㄡˇ");
            DictAdd(dataDict, "shù", "ㄕㄨˋ");
            DictAdd(dataDict, "shǔ", "ㄕㄨˇ");
            DictAdd(dataDict, "shuò", "ㄕㄨㄛˋ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "wén", "ㄨㄣˊ");
            DictAdd(dataDict, "yī", "ㄧ");
            DictAdd(dataDict, "ér", "ㄦˊ");
            DictAdd(dataDict, "bǎi", "ㄅㄞˇ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "qiān", "ㄑㄧㄢ");
            DictAdd(dataDict, "wàn", "ㄨㄢˋ");
            DictAdd(dataDict, "sān", "ㄙㄢ");
            DictAdd(dataDict, "cái", "ㄘㄞˊ");
            DictAdd(dataDict, "zhě", "ㄓㄜˇ");
            DictAdd(dataDict, "tiān", "ㄊㄧㄢ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "de", "ㄉㄜ");
            DictAdd(dataDict, "guāng", "ㄍㄨㄤ");
            DictAdd(dataDict, "rì", "ㄖˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "xīng", "ㄒㄧㄥ");
            DictAdd(dataDict, "gāng", "ㄍㄤ");
            DictAdd(dataDict, "jūn", "ㄐㄩㄣ");
            DictAdd(dataDict, "chén", "ㄔㄣˊ");
            DictAdd(dataDict, "fū", "ㄈㄨ");
            DictAdd(dataDict, "fú", "ㄈㄨˊ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "shùn", "ㄕㄨㄣˋ");
            DictAdd(dataDict, "yuē", "ㄩㄝ");
            DictAdd(dataDict, "chūn", "ㄔㄨㄣ");
            DictAdd(dataDict, "xià", "ㄒㄧㄚˋ");
            DictAdd(dataDict, "qiū", "ㄑㄧㄡ");
            DictAdd(dataDict, "dōng", "ㄉㄨㄥ");
            DictAdd(dataDict, "cǐ", "ㄘˇ");
            DictAdd(dataDict, "yùn", "ㄩㄣˋ");
            DictAdd(dataDict, "qióng", "ㄑㄩㄥˊ");
            DictAdd(dataDict, "nán", "ㄋㄢˊ");
            DictAdd(dataDict, "nā", "ㄋㄚ");
            DictAdd(dataDict, "běi", "ㄅㄟˇ");
            DictAdd(dataDict, "bèi", "ㄅㄟˋ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "dōng", "ㄉㄨㄥ");
            DictAdd(dataDict, "yīng", "ㄧㄥ");
            DictAdd(dataDict, "yìng", "ㄧㄥˋ");
            DictAdd(dataDict, "hū", "ㄏㄨ");
            DictAdd(dataDict, "zhōng", "ㄓㄨㄥ");
            DictAdd(dataDict, "zhòng", "ㄓㄨㄥˋ");
            DictAdd(dataDict, "shuǐ", "ㄕㄨㄟˇ");
            DictAdd(dataDict, "huǒ", "ㄏㄨㄛˇ");
            DictAdd(dataDict, "mù", "ㄇㄨˋ");
            DictAdd(dataDict, "jīn", "ㄐㄧㄣ");
            DictAdd(dataDict, "tǔ", "ㄊㄨˇ");
            DictAdd(dataDict, "háng", "ㄏㄤˊ");
            DictAdd(dataDict, "xíng", "ㄒㄧㄥˊ");
            DictAdd(dataDict, "rén", "ㄖㄣˊ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "xìn", "ㄒㄧㄣˋ");
            DictAdd(dataDict, "shēn", "ㄕㄣ");
            DictAdd(dataDict, "cháng", "ㄔㄤˊ");
            DictAdd(dataDict, "róng", "ㄖㄨㄥˊ");
            DictAdd(dataDict, "wěn", "ㄨㄣˇ");
            DictAdd(dataDict, "dào", "ㄉㄠˋ");
            DictAdd(dataDict, "liáng", "ㄌㄧㄤˊ");
            DictAdd(dataDict, "shū", "ㄕㄨ");
            DictAdd(dataDict, "mài", "ㄇㄞˋ");
            DictAdd(dataDict, "shǔ", "ㄕㄨˇ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "liù", "ㄌㄧㄡˋ");
            DictAdd(dataDict, "lù", "ㄌㄨˋ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "gòu", "ㄍㄡˋ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "sì", "ㄙˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "mǎ", "ㄇㄚˇ");
            DictAdd(dataDict, "niú", "ㄋㄧㄡˊ");
            DictAdd(dataDict, "yáng", "ㄧㄤˊ");
            DictAdd(dataDict, "xiáng", "ㄒㄧㄤˊ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "quǎn", "ㄑㄩㄢˇ");
            DictAdd(dataDict, "shǐ", "ㄕˇ");
            DictAdd(dataDict, "xù", "ㄒㄩˋ");
            DictAdd(dataDict, "chù", "ㄔㄨˋ");
            DictAdd(dataDict, "sì", "ㄙˋ");
            DictAdd(dataDict, "xǐ", "ㄒㄧˇ");
            DictAdd(dataDict, "nù", "ㄋㄨˋ");
            DictAdd(dataDict, "āi", "ㄞ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "ài", "ㄞˋ");
            DictAdd(dataDict, "è", "ㄜˋ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "ě", "ㄜˇ");
            DictAdd(dataDict, "wū", "ㄨ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "qī", "ㄑㄧ");
            DictAdd(dataDict, "qíng", "ㄑㄧㄥˊ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "páo", "ㄆㄠˊ");
            DictAdd(dataDict, "gé", "ㄍㄜˊ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "dàn", "ㄉㄢˋ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "zhú", "ㄓㄨˊ");
            DictAdd(dataDict, "bā", "ㄅㄚ");
            DictAdd(dataDict, "yīn", "ㄧㄣ");
            DictAdd(dataDict, "gāo", "ㄍㄠ");
            DictAdd(dataDict, "zēng", "ㄗㄥ");
            DictAdd(dataDict, "céng", "ㄘㄥˊ");
            DictAdd(dataDict, "zǔ", "ㄗㄨˇ");
            DictAdd(dataDict, "shēn", "ㄕㄣ");
            DictAdd(dataDict, "sūn", "ㄙㄨㄣ");
            DictAdd(dataDict, "xùn", "ㄒㄩㄣˋ");
            DictAdd(dataDict, "zì", "ㄗˋ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "xuán", "ㄒㄩㄢˊ");
            DictAdd(dataDict, "zú", "ㄗㄨˊ");
            DictAdd(dataDict, "lún", "ㄌㄨㄣˊ");
            DictAdd(dataDict, "ēn", "ㄣ");
            DictAdd(dataDict, "cóng", "ㄘㄨㄥˊ");
            DictAdd(dataDict, "zòng", "ㄗㄨㄥˋ");
            DictAdd(dataDict, "xiōng", "ㄒㄩㄥ");
            DictAdd(dataDict, "zé", "ㄗㄜˊ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "tì", "ㄊㄧˋ");
            DictAdd(dataDict, "tuí", "ㄊㄨㄟˊ");
            DictAdd(dataDict, "gōng", "ㄍㄨㄥ");
            DictAdd(dataDict, "xù", "ㄒㄩˋ");
            DictAdd(dataDict, "péng", "ㄆㄥˊ");
            DictAdd(dataDict, "jìng", "ㄐㄧㄥˋ");
            DictAdd(dataDict, "zhōng", "ㄓㄨㄥ");
            DictAdd(dataDict, "tóng", "ㄊㄨㄥˊ");
            DictAdd(dataDict, "tòng", "ㄊㄨㄥˋ");
            DictAdd(dataDict, "fán", "ㄈㄢˊ");
            DictAdd(dataDict, "xùn", "ㄒㄩㄣˋ");
            DictAdd(dataDict, "mēng", "ㄇㄥ");
            DictAdd(dataDict, "méng", "ㄇㄥˊ");
            DictAdd(dataDict, "měng", "ㄇㄥˇ");
            DictAdd(dataDict, "xū", "ㄒㄩ");
            DictAdd(dataDict, "jiǎng", "ㄐㄧㄤˇ");
            DictAdd(dataDict, "jiū", "ㄐㄧㄡ");
            DictAdd(dataDict, "xiáng", "ㄒㄧㄤˊ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "míng", "ㄇㄧㄥˊ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "gōu", "ㄍㄡ");
            DictAdd(dataDict, "dú", "ㄉㄨˊ");
            DictAdd(dataDict, "bì", "ㄅㄧˋ");
            DictAdd(dataDict, "xiǎo", "ㄒㄧㄠˇ");
            DictAdd(dataDict, "zhōng", "ㄓㄨㄥ");
            DictAdd(dataDict, "shū", "ㄕㄨ");
            DictAdd(dataDict, "lùn", "ㄌㄨㄣˋ");
            DictAdd(dataDict, "lún", "ㄌㄨㄣˊ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "èr", "ㄦˋ");
            DictAdd(dataDict, "piān", "ㄆㄧㄢ");
            DictAdd(dataDict, "qún", "ㄑㄩㄣˊ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "yán", "ㄧㄢˊ");
            DictAdd(dataDict, "zhǐ", "ㄓˇ");
            DictAdd(dataDict, "dé", "ㄉㄜˊ");
            DictAdd(dataDict, "shuō", "ㄕㄨㄛ");
            DictAdd(dataDict, "shuì", "ㄕㄨㄟˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "zuò", "ㄗㄨㄛˋ");
            DictAdd(dataDict, "yōng", "ㄩㄥ");
            DictAdd(dataDict, "kǒng", "ㄎㄨㄥˇ");
            DictAdd(dataDict, "jí", "ㄐㄧˊ");
            DictAdd(dataDict, "piān", "ㄆㄧㄢ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "dà", "ㄉㄚˋ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "tài", "ㄊㄞˋ");
            DictAdd(dataDict, "xiū", "ㄒㄧㄡ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "zhāi", "ㄓㄞ");
            DictAdd(dataDict, "píng", "ㄆㄧㄥˊ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "jīng", "ㄐㄧㄥ");
            DictAdd(dataDict, "tōng", "ㄊㄨㄥ");
            DictAdd(dataDict, "shú", "ㄕㄨˊ");
            DictAdd(dataDict, "rú", "ㄖㄨˊ");
            DictAdd(dataDict, "shǐ", "ㄕˇ");
            DictAdd(dataDict, "kě", "ㄎㄜˇ");
            DictAdd(dataDict, "kè", "ㄎㄜˋ");
            DictAdd(dataDict, "dú", "ㄉㄨˊ");
            DictAdd(dataDict, "shī", "ㄕ");
            DictAdd(dataDict, "hào", "ㄏㄠˋ");
            DictAdd(dataDict, "qiú", "ㄑㄧㄡˊ");
            DictAdd(dataDict, "lián", "ㄌㄧㄢˊ");
            DictAdd(dataDict, "guī", "ㄍㄨㄟ");
            DictAdd(dataDict, "cáng", "ㄘㄤˊ");
            DictAdd(dataDict, "zàng", "ㄗㄤˋ");
            DictAdd(dataDict, "zhōu", "ㄓㄡ");
            DictAdd(dataDict, "diǎn", "ㄉㄧㄢˇ");
            DictAdd(dataDict, "mó", "ㄇㄛˊ");
            DictAdd(dataDict, "gào", "ㄍㄠˋ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "mìng", "ㄇㄧㄥˋ");
            DictAdd(dataDict, "ào", "ㄠˋ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "wǒ", "ㄨㄛˇ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "gōng", "ㄍㄨㄥ");
            DictAdd(dataDict, "zhù", "ㄓㄨˋ");
            DictAdd(dataDict, "zhuó", "ㄓㄨㄛˊ");
            DictAdd(dataDict, "zhe", "ㄓㄜ");
            DictAdd(dataDict, "cún", "ㄘㄨㄣˊ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "zhù", "ㄓㄨˋ");
            DictAdd(dataDict, "shù", "ㄕㄨˋ");
            DictAdd(dataDict, "shèng", "ㄕㄥˋ");
            DictAdd(dataDict, "lè", "ㄌㄜˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "yào", "ㄧㄠˋ");
            DictAdd(dataDict, "lào", "ㄌㄠˋ");
            DictAdd(dataDict, "bèi", "ㄅㄟˋ");
            DictAdd(dataDict, "guó", "ㄍㄨㄛˊ");
            DictAdd(dataDict, "fēng", "ㄈㄥ");
            DictAdd(dataDict, "fěng", "ㄈㄥˇ");
            DictAdd(dataDict, "yǎ", "ㄧㄚˇ");
            DictAdd(dataDict, "sòng", "ㄙㄨㄥˋ");
            DictAdd(dataDict, "fěng", "ㄈㄥˇ");
            DictAdd(dataDict, "yǒng", "ㄩㄥˇ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "wáng", "ㄨㄤˊ");
            DictAdd(dataDict, "wú", "ㄨˊ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "bāo", "ㄅㄠ");
            DictAdd(dataDict, "biǎn", "ㄅㄧㄢˇ");
            DictAdd(dataDict, "bié", "ㄅㄧㄝˊ");
            DictAdd(dataDict, "biè", "ㄅㄧㄝˋ");
            DictAdd(dataDict, "è", "ㄜˋ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "ě", "ㄜˇ");
            DictAdd(dataDict, "wū", "ㄨ");
            DictAdd(dataDict, "chuán", "ㄔㄨㄢˊ");
            DictAdd(dataDict, "zhuàn", "ㄓㄨㄢˋ");
            DictAdd(dataDict, "zuǒ", "ㄗㄨㄛˇ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "zhī", "ㄓ");
            DictAdd(dataDict, "liáng", "ㄌㄧㄤˊ");
            DictAdd(dataDict, "cuō", "ㄘㄨㄛ");
            DictAdd(dataDict, "zuǒ", "ㄗㄨㄛˇ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "yào", "ㄧㄠˋ");
            DictAdd(dataDict, "yāo", "ㄧㄠ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "xún", "ㄒㄩㄣˊ");
            DictAdd(dataDict, "yáng", "ㄧㄤˊ");
            DictAdd(dataDict, "jí", "ㄐㄧˊ");
            DictAdd(dataDict, "zhuāng", "ㄓㄨㄤ");
            DictAdd(dataDict, "zhū", "ㄓㄨ");
            DictAdd(dataDict, "shǐ", "ㄕˇ");
            DictAdd(dataDict, "kǎo", "ㄎㄠˇ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "xì", "ㄒㄧˋ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "nóng", "ㄋㄨㄥˊ");
            DictAdd(dataDict, "huáng", "ㄏㄨㄤˊ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "huáng", "ㄏㄨㄤˊ");
            DictAdd(dataDict, "jū", "ㄐㄩ");
            DictAdd(dataDict, "shàng", "ㄕㄤˋ");
            DictAdd(dataDict, "shǎng", "ㄕㄤˇ");
            DictAdd(dataDict, "táng", "ㄊㄤˊ");
            DictAdd(dataDict, "yú", "ㄩˊ");
            DictAdd(dataDict, "yī", "ㄧ");
            DictAdd(dataDict, "xùn", "ㄒㄩㄣˋ");
            DictAdd(dataDict, "chēng", "ㄔㄥ");
            DictAdd(dataDict, "chèn", "ㄔㄣˋ");
            DictAdd(dataDict, "chèng", "ㄔㄥˋ");
            DictAdd(dataDict, "shèng", "ㄕㄥˋ");
            DictAdd(dataDict, "chéng", "ㄔㄥˊ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "shāng", "ㄕㄤ");
            DictAdd(dataDict, "tāng", "ㄊㄤ");
            DictAdd(dataDict, "shāng", "ㄕㄤ");
            DictAdd(dataDict, "wǔ", "ㄨˇ");
            DictAdd(dataDict, "wáng", "ㄨㄤˊ");
            DictAdd(dataDict, "wàng", "ㄨㄤˋ");
            DictAdd(dataDict, "chuán", "ㄔㄨㄢˊ");
            DictAdd(dataDict, "zhuàn", "ㄓㄨㄢˋ");
            DictAdd(dataDict, "jiā", "ㄐㄧㄚ");
            DictAdd(dataDict, "jia", "ㄐㄧㄚ");
            DictAdd(dataDict, "jie", "ㄐㄧㄝ");
            DictAdd(dataDict, "xià", "ㄒㄧㄚˋ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "shè", "ㄕㄜˋ");
            DictAdd(dataDict, "fá", "ㄈㄚˊ");
            DictAdd(dataDict, "zhòu", "ㄓㄡˋ");
            DictAdd(dataDict, "zhū", "ㄓㄨ");
            DictAdd(dataDict, "zuì", "ㄗㄨㄟˋ");
            DictAdd(dataDict, "cháng", "ㄔㄤˊ");
            DictAdd(dataDict, "zhǎng", "ㄓㄤˇ");
            DictAdd(dataDict, "jiǔ", "ㄐㄧㄡˇ");
            DictAdd(dataDict, "zhé", "ㄓㄜˊ");
            DictAdd(dataDict, "zhuì", "ㄓㄨㄟˋ");
            DictAdd(dataDict, "chěng", "ㄔㄥˇ");
            DictAdd(dataDict, "gān", "ㄍㄢ");
            DictAdd(dataDict, "gàn", "ㄍㄢˋ");
            DictAdd(dataDict, "gē", "ㄍㄜ");
            DictAdd(dataDict, "shàng", "ㄕㄤˋ");
            DictAdd(dataDict, "yóu", "ㄧㄡˊ");
            DictAdd(dataDict, "shuō", "ㄕㄨㄛ");
            DictAdd(dataDict, "shuì", "ㄕㄨㄟˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "zhàn", "ㄓㄢˋ");
            DictAdd(dataDict, "bà", "ㄅㄚˋ");
            DictAdd(dataDict, "qiáng", "ㄑㄧㄤˊ");
            DictAdd(dataDict, "qiǎng", "ㄑㄧㄤˇ");
            DictAdd(dataDict, "jiàng", "ㄐㄧㄤˋ");
            DictAdd(dataDict, "xióng", "ㄒㄩㄥˊ");
            DictAdd(dataDict, "chū", "ㄔㄨ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "qín", "ㄑㄧㄣˊ");
            DictAdd(dataDict, "jiān", "ㄐㄧㄢ");
            DictAdd(dataDict, "bìng", "ㄅㄧㄥˋ");
            DictAdd(dataDict, "bīng", "ㄅㄧㄥ");
            DictAdd(dataDict, "chǔ", "ㄔㄨˇ");
            DictAdd(dataDict, "hàn", "ㄏㄢˋ");
            DictAdd(dataDict, "zhēng", "ㄓㄥ");
            DictAdd(dataDict, "xīng", "ㄒㄧㄥ");
            DictAdd(dataDict, "yè", "ㄧㄝˋ");
            DictAdd(dataDict, "jiàn", "ㄐㄧㄢˋ");
            DictAdd(dataDict, "mǎng", "ㄇㄤˇ");
            DictAdd(dataDict, "cuàn", "ㄘㄨㄢˋ");
            DictAdd(dataDict, "nián", "ㄋㄧㄢˊ");
            DictAdd(dataDict, "xiàn", "ㄒㄧㄢˋ");
            DictAdd(dataDict, "wèi", "ㄨㄟˋ");
            DictAdd(dataDict, "shǔ", "ㄕㄨˇ");
            DictAdd(dataDict, "wú", "ㄨˊ");
            DictAdd(dataDict, "dǐng", "ㄉㄧㄥˇ");
            DictAdd(dataDict, "qì", "ㄑㄧˋ");
            DictAdd(dataDict, "liǎng", "ㄌㄧㄤˇ");
            DictAdd(dataDict, "jìn", "ㄐㄧㄣˋ");
            DictAdd(dataDict, "sòng", "ㄙㄨㄥˋ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "chén", "ㄔㄣˊ");
            DictAdd(dataDict, "chéng", "ㄔㄥˊ");
            DictAdd(dataDict, "zhāo", "ㄓㄠ");
            DictAdd(dataDict, "cháo", "ㄔㄠˊ");
            DictAdd(dataDict, "dū", "ㄉㄨ");
            DictAdd(dataDict, "dōu", "ㄉㄡ");
            DictAdd(dataDict, "líng", "ㄌㄧㄥˊ");
            DictAdd(dataDict, "yuán", "ㄩㄢˊ");
            DictAdd(dataDict, "fēn", "ㄈㄣ");
            DictAdd(dataDict, "fèn", "ㄈㄣˋ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "suí", "ㄙㄨㄟˊ");
            DictAdd(dataDict, "duò", "ㄉㄨㄛˋ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "shī", "ㄕ");
            DictAdd(dataDict, "tǒng", "ㄊㄨㄥˇ");
            DictAdd(dataDict, "xù", "ㄒㄩˋ");
            DictAdd(dataDict, "qǐ", "ㄑㄧˇ");
            DictAdd(dataDict, "chú", "ㄔㄨˊ");
            DictAdd(dataDict, "luàn", "ㄌㄨㄢˋ");
            DictAdd(dataDict, "chuàng", "ㄔㄨㄤˋ");
            DictAdd(dataDict, "chuāng", "ㄔㄨㄤ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "miè", "ㄇㄧㄝˋ");
            DictAdd(dataDict, "gǎi", "ㄍㄞˇ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "jiē", "ㄐㄧㄝ");
            DictAdd(dataDict, "yóu", "ㄧㄡˊ");
            DictAdd(dataDict, "yán", "ㄧㄢˊ");
            DictAdd(dataDict, "shòu", "ㄕㄡˋ");
            DictAdd(dataDict, "shàn", "ㄕㄢˋ");
            DictAdd(dataDict, "chán", "ㄔㄢˊ");
            DictAdd(dataDict, "hùn", "ㄏㄨㄣˋ");
            DictAdd(dataDict, "hún", "ㄏㄨㄣˊ");
            DictAdd(dataDict, "quán", "ㄑㄩㄢˊ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "zī", "ㄗ");
            DictAdd(dataDict, "cí", "ㄘˊ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "shuāi", "ㄕㄨㄞ");
            DictAdd(dataDict, "cuī", "ㄘㄨㄟ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "lù", "ㄌㄨˋ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "jīn", "ㄐㄧㄣ");
            DictAdd(dataDict, "ruò", "ㄖㄨㄛˋ");
            DictAdd(dataDict, "rě", "ㄖㄜˇ");
            DictAdd(dataDict, "mù", "ㄇㄨˋ");
            DictAdd(dataDict, "kǒu", "ㄎㄡˇ");
            DictAdd(dataDict, "sòng", "ㄙㄨㄥˋ");
            DictAdd(dataDict, "xīn", "ㄒㄧㄣ");
            DictAdd(dataDict, "wéi", "ㄨㄟˊ");
            DictAdd(dataDict, "zhāo", "ㄓㄠ");
            DictAdd(dataDict, "cháo", "ㄔㄠˊ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "zhòng", "ㄓㄨㄥˋ");
            DictAdd(dataDict, "ní", "ㄋㄧˊ");
            DictAdd(dataDict, "xiàng", "ㄒㄧㄤˋ");
            DictAdd(dataDict, "tuó", "ㄊㄨㄛˊ");
            DictAdd(dataDict, "xián", "ㄒㄧㄢˊ");
            DictAdd(dataDict, "qín", "ㄑㄧㄣˊ");
            DictAdd(dataDict, "zhào", "ㄓㄠˋ");
            DictAdd(dataDict, "líng", "ㄌㄧㄥˊ");
            DictAdd(dataDict, "lǐng", "ㄌㄧㄥˇ");
            DictAdd(dataDict, "lìng", "ㄌㄧㄥˋ");
            DictAdd(dataDict, "lǔ", "ㄌㄨˇ");
            DictAdd(dataDict, "bǐ", "ㄅㄧˇ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "qiě", "ㄑㄧㄝˇ");
            DictAdd(dataDict, "jū", "ㄐㄩ");
            DictAdd(dataDict, "pī", "ㄆㄧ");
            DictAdd(dataDict, "pú", "ㄆㄨˊ");
            DictAdd(dataDict, "biān", "ㄅㄧㄢ");
            DictAdd(dataDict, "xiāo", "ㄒㄧㄠ");
            DictAdd(dataDict, "xuē", "ㄒㄩㄝ");
            DictAdd(dataDict, "jiǎn", "ㄐㄧㄢˇ");
            DictAdd(dataDict, "wú", "ㄨˊ");
            DictAdd(dataDict, "miǎn", "ㄇㄧㄢˇ");
            DictAdd(dataDict, "tóu", "ㄊㄡˊ");
            DictAdd(dataDict, "xuán", "ㄒㄩㄢˊ");
            DictAdd(dataDict, "zhuī", "ㄓㄨㄟ");
            DictAdd(dataDict, "cì", "ㄘˋ");
            DictAdd(dataDict, "cī", "ㄘ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "kǔ", "ㄎㄨˇ");
            DictAdd(dataDict, "náng", "ㄋㄤˊ");
            DictAdd(dataDict, "nāng", "ㄋㄤ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "yìng", "ㄧㄥˋ");
            DictAdd(dataDict, "xuě", "ㄒㄩㄝˇ");
            DictAdd(dataDict, "suī", "ㄙㄨㄟ");
            DictAdd(dataDict, "pín", "ㄆㄧㄣˊ");
            DictAdd(dataDict, "chuò", "ㄔㄨㄛˋ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "xīn", "ㄒㄧㄣ");
            DictAdd(dataDict, "guà", "ㄍㄨㄚˋ");
            DictAdd(dataDict, "jiǎo", "ㄐㄧㄠˇ");
            DictAdd(dataDict, "jué", "ㄐㄩㄝˊ");
            DictAdd(dataDict, "láo", "ㄌㄠˊ");
            DictAdd(dataDict, "yóu", "ㄧㄡˊ");
            DictAdd(dataDict, "zhuó", "ㄓㄨㄛˊ");
            DictAdd(dataDict, "sū", "ㄙㄨ");
            DictAdd(dataDict, "quán", "ㄑㄩㄢˊ");
            DictAdd(dataDict, "fā", "ㄈㄚ");
            DictAdd(dataDict, "fèn", "ㄈㄣˋ");
            DictAdd(dataDict, "jí", "ㄐㄧˊ");
            DictAdd(dataDict, "huǐ", "ㄏㄨㄟˇ");
            DictAdd(dataDict, "chí", "ㄔˊ");
            DictAdd(dataDict, "ěr", "ㄦˇ");
            DictAdd(dataDict, "shēng", "ㄕㄥ");
            DictAdd(dataDict, "zǎo", "ㄗㄠˇ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "sāi", "ㄙㄞ");
            DictAdd(dataDict, "hào", "ㄏㄠˋ");
            DictAdd(dataDict, "duì", "ㄉㄨㄟˋ");
            DictAdd(dataDict, "tíng", "ㄊㄧㄥˊ");
            DictAdd(dataDict, "kuí", "ㄎㄨㄟˊ");
            DictAdd(dataDict, "duō", "ㄉㄨㄛ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "zhòng", "ㄓㄨㄥˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "lì", "ㄌㄧˋ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "yǐng", "ㄧㄥˇ");
            DictAdd(dataDict, "mì", "ㄇㄧˋ");
            DictAdd(dataDict, "bì", "ㄅㄧˋ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "yǐng", "ㄧㄥˇ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "xiào", "ㄒㄧㄠˋ");
            DictAdd(dataDict, "cài", "ㄘㄞˋ");
            DictAdd(dataDict, "biàn", "ㄅㄧㄢˋ");
            DictAdd(dataDict, "qín", "ㄑㄧㄣˊ");
            DictAdd(dataDict, "xiè", "ㄒㄧㄝˋ");
            DictAdd(dataDict, "yùn", "ㄩㄣˋ");
            DictAdd(dataDict, "yín", "ㄧㄣˊ");
            DictAdd(dataDict, "nǚ", "ㄋㄩˇ");
            DictAdd(dataDict, "rǔ", "ㄖㄨˇ");
            DictAdd(dataDict, "cōng", "ㄘㄨㄥ");
            DictAdd(dataDict, "mǐn", "ㄇㄧㄣˇ");
            DictAdd(dataDict, "nán", "ㄋㄢˊ");
            DictAdd(dataDict, "jǐng", "ㄐㄧㄥˇ");
            DictAdd(dataDict, "liú", "ㄌㄧㄡˊ");
            DictAdd(dataDict, "jǔ", "ㄐㄩˇ");
            DictAdd(dataDict, "yàn", "ㄧㄢˋ");
            DictAdd(dataDict, "shén", "ㄕㄣˊ");
            DictAdd(dataDict, "tóng", "ㄊㄨㄥˊ");
            DictAdd(dataDict, "zhèng", "ㄓㄥˋ");
            DictAdd(dataDict, "zhēng", "ㄓㄥ");
            DictAdd(dataDict, "zì", "ㄗˋ");
            DictAdd(dataDict, "yǐ", "ㄧˇ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "shǒu", "ㄕㄡˇ");
            DictAdd(dataDict, "yè", "ㄧㄝˋ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "chén", "ㄔㄣˊ");
            DictAdd(dataDict, "hé", "ㄏㄜˊ");
            DictAdd(dataDict, "cán", "ㄘㄢˊ");
            DictAdd(dataDict, "tǔ", "ㄊㄨˇ");
            DictAdd(dataDict, "tù", "ㄊㄨˋ");
            DictAdd(dataDict, "fēng", "ㄈㄥ");
            DictAdd(dataDict, "niàng", "ㄋㄧㄤˋ");
            DictAdd(dataDict, "niáng", "ㄋㄧㄤˊ");
            DictAdd(dataDict, "mì", "ㄇㄧˋ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "zhuàng", "ㄓㄨㄤˋ");
            DictAdd(dataDict, "zé", "ㄗㄜˊ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "mín", "ㄇㄧㄣˊ");
            DictAdd(dataDict, "shēng", "ㄕㄥ");
            DictAdd(dataDict, "xiǎn", "ㄒㄧㄢˇ");
            DictAdd(dataDict, "qián", "ㄑㄧㄢˊ");
            DictAdd(dataDict, "chuí", "ㄔㄨㄟˊ");
            DictAdd(dataDict, "hòu", "ㄏㄡˋ");
            DictAdd(dataDict, "yí", "ㄧˊ");
            DictAdd(dataDict, "mǎn", "ㄇㄢˇ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "gōng", "ㄍㄨㄥ");
            DictAdd(dataDict, "xì", "ㄒㄧˋ");
            DictAdd(dataDict, "hū", "ㄏㄨ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "jiè", "ㄐㄧㄝˋ");
            DictAdd(dataDict, "zāi", "ㄗㄞ");
            DictAdd(dataDict, "lì", "ㄌㄧˋ");
            #endregion

            VerifyDataDict(dataDict);
        }

        /// <summary>
        /// TODO not start
        /// </summary>
        [TestMethod][Ignore]
        public void TestMethod07_BaiJaiXing()
        {
            #region dataDict
            Dictionary<string, string> dataDict = new Dictionary<string, string> { };
            DictAdd(dataDict, "rén", "ㄖㄣˊ");
            DictAdd(dataDict, "zhī", "ㄓ");
            DictAdd(dataDict, "chū", "ㄔㄨ");
            DictAdd(dataDict, "xìng", "ㄒㄧㄥˋ");
            DictAdd(dataDict, "běn", "ㄅㄣˇ");
            DictAdd(dataDict, "shàn", "ㄕㄢˋ");
            DictAdd(dataDict, "xiāng", "ㄒㄧㄤ");
            DictAdd(dataDict, "xiàng", "ㄒㄧㄤˋ");
            DictAdd(dataDict, "jìn", "ㄐㄧㄣˋ");
            DictAdd(dataDict, "xí", "ㄒㄧˊ");
            DictAdd(dataDict, "yuǎn", "ㄩㄢˇ");
            DictAdd(dataDict, "gǒu", "ㄍㄡˇ");
            DictAdd(dataDict, "bù", "ㄅㄨˋ");
            DictAdd(dataDict, "fǒu", "ㄈㄡˇ");
            DictAdd(dataDict, "jiào", "ㄐㄧㄠˋ");
            DictAdd(dataDict, "jiāo", "ㄐㄧㄠ");
            DictAdd(dataDict, "nǎi", "ㄋㄞˇ");
            DictAdd(dataDict, "qiān", "ㄑㄧㄢ");
            DictAdd(dataDict, "dào", "ㄉㄠˋ");
            DictAdd(dataDict, "guì", "ㄍㄨㄟˋ");
            DictAdd(dataDict, "yǐ", "ㄧˇ");
            DictAdd(dataDict, "zhuān", "ㄓㄨㄢ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "mèng", "ㄇㄥˋ");
            DictAdd(dataDict, "mǔ", "ㄇㄨˇ");
            DictAdd(dataDict, "zé", "ㄗㄜˊ");
            DictAdd(dataDict, "zhái", "ㄓㄞˊ");
            DictAdd(dataDict, "lín", "ㄌㄧㄣˊ");
            DictAdd(dataDict, "chǔ", "ㄔㄨˇ");
            DictAdd(dataDict, "zǐ", "ㄗˇ");
            DictAdd(dataDict, "xué", "ㄒㄩㄝˊ");
            DictAdd(dataDict, "duàn", "ㄉㄨㄢˋ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "zhù", "ㄓㄨˋ");
            DictAdd(dataDict, "dòu", "ㄉㄡˋ");
            DictAdd(dataDict, "yàn", "ㄧㄢˋ");
            DictAdd(dataDict, "yān", "ㄧㄢ");
            DictAdd(dataDict, "shān", "ㄕㄢ");
            DictAdd(dataDict, "yǒu", "ㄧㄡˇ");
            DictAdd(dataDict, "yòu", "ㄧㄡˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "fāng", "ㄈㄤ");
            DictAdd(dataDict, "wǔ", "ㄨˇ");
            DictAdd(dataDict, "míng", "ㄇㄧㄥˊ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "yáng", "ㄧㄤˊ");
            DictAdd(dataDict, "yǎng", "ㄧㄤˇ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "fǔ", "ㄈㄨˇ");
            DictAdd(dataDict, "guò", "ㄍㄨㄛˋ");
            DictAdd(dataDict, "yán", "ㄧㄢˊ");
            DictAdd(dataDict, "shī", "ㄕ");
            DictAdd(dataDict, "duò", "ㄉㄨㄛˋ");
            DictAdd(dataDict, "fēi", "ㄈㄟ");
            DictAdd(dataDict, "suǒ", "ㄙㄨㄛˇ");
            DictAdd(dataDict, "yí", "ㄧˊ");
            DictAdd(dataDict, "yòu", "ㄧㄡˋ");
            DictAdd(dataDict, "lǎo", "ㄌㄠˇ");
            DictAdd(dataDict, "hé", "ㄏㄜˊ");
            DictAdd(dataDict, "hē", "ㄏㄜ");
            DictAdd(dataDict, "hè", "ㄏㄜˋ");
            DictAdd(dataDict, "wéi", "ㄨㄟˊ");
            DictAdd(dataDict, "wèi", "ㄨㄟˋ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "zhuó", "ㄓㄨㄛˊ");
            DictAdd(dataDict, "zuó", "ㄗㄨㄛˊ");
            DictAdd(dataDict, "chéng", "ㄔㄥˊ");
            DictAdd(dataDict, "qì", "ㄑㄧˋ");
            DictAdd(dataDict, "zhī", "ㄓ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "shǎo", "ㄕㄠˇ");
            DictAdd(dataDict, "shào", "ㄕㄠˋ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "qīn", "ㄑㄧㄣ");
            DictAdd(dataDict, "qìng", "ㄑㄧㄥˋ");
            DictAdd(dataDict, "yǒu", "ㄧㄡˇ");
            DictAdd(dataDict, "lǐ", "ㄌㄧˇ");
            DictAdd(dataDict, "yí", "ㄧˊ");
            DictAdd(dataDict, "xiāng", "ㄒㄧㄤ");
            DictAdd(dataDict, "jiǔ", "ㄐㄧㄡˇ");
            DictAdd(dataDict, "líng", "ㄌㄧㄥˊ");
            DictAdd(dataDict, "néng", "ㄋㄥˊ");
            DictAdd(dataDict, "nài", "ㄋㄞˋ");
            DictAdd(dataDict, "wēn", "ㄨㄣ");
            DictAdd(dataDict, "xí", "ㄒㄧˊ");
            DictAdd(dataDict, "xiào", "ㄒㄧㄠˋ");
            DictAdd(dataDict, "yú", "ㄩˊ");
            DictAdd(dataDict, "wū", "ㄨ");
            DictAdd(dataDict, "dāng", "ㄉㄤ");
            DictAdd(dataDict, "dàng", "ㄉㄤˋ");
            DictAdd(dataDict, "dǎng", "ㄉㄤˇ");
            DictAdd(dataDict, "zhí", "ㄓˊ");
            DictAdd(dataDict, "róng", "ㄖㄨㄥˊ");
            DictAdd(dataDict, "sì", "ㄙˋ");
            DictAdd(dataDict, "suì", "ㄙㄨㄟˋ");
            DictAdd(dataDict, "ràng", "ㄖㄤˋ");
            DictAdd(dataDict, "lí", "ㄌㄧˊ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "tì", "ㄊㄧˋ");
            DictAdd(dataDict, "tuí", "ㄊㄨㄟˊ");
            DictAdd(dataDict, "cháng", "ㄔㄤˊ");
            DictAdd(dataDict, "zhǎng", "ㄓㄤˇ");
            DictAdd(dataDict, "xiān", "ㄒㄧㄢ");
            DictAdd(dataDict, "shǒu", "ㄕㄡˇ");
            DictAdd(dataDict, "cì", "ㄘˋ");
            DictAdd(dataDict, "jiàn", "ㄐㄧㄢˋ");
            DictAdd(dataDict, "xiàn", "ㄒㄧㄢˋ");
            DictAdd(dataDict, "wén", "ㄨㄣˊ");
            DictAdd(dataDict, "mǒu", "ㄇㄡˇ");
            DictAdd(dataDict, "shù", "ㄕㄨˋ");
            DictAdd(dataDict, "shǔ", "ㄕㄨˇ");
            DictAdd(dataDict, "shuò", "ㄕㄨㄛˋ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "wén", "ㄨㄣˊ");
            DictAdd(dataDict, "yī", "ㄧ");
            DictAdd(dataDict, "ér", "ㄦˊ");
            DictAdd(dataDict, "bǎi", "ㄅㄞˇ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "qiān", "ㄑㄧㄢ");
            DictAdd(dataDict, "wàn", "ㄨㄢˋ");
            DictAdd(dataDict, "sān", "ㄙㄢ");
            DictAdd(dataDict, "cái", "ㄘㄞˊ");
            DictAdd(dataDict, "zhě", "ㄓㄜˇ");
            DictAdd(dataDict, "tiān", "ㄊㄧㄢ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "de", "ㄉㄜ");
            DictAdd(dataDict, "guāng", "ㄍㄨㄤ");
            DictAdd(dataDict, "rì", "ㄖˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "xīng", "ㄒㄧㄥ");
            DictAdd(dataDict, "gāng", "ㄍㄤ");
            DictAdd(dataDict, "jūn", "ㄐㄩㄣ");
            DictAdd(dataDict, "chén", "ㄔㄣˊ");
            DictAdd(dataDict, "fū", "ㄈㄨ");
            DictAdd(dataDict, "fú", "ㄈㄨˊ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "shùn", "ㄕㄨㄣˋ");
            DictAdd(dataDict, "yuē", "ㄩㄝ");
            DictAdd(dataDict, "chūn", "ㄔㄨㄣ");
            DictAdd(dataDict, "xià", "ㄒㄧㄚˋ");
            DictAdd(dataDict, "qiū", "ㄑㄧㄡ");
            DictAdd(dataDict, "dōng", "ㄉㄨㄥ");
            DictAdd(dataDict, "cǐ", "ㄘˇ");
            DictAdd(dataDict, "yùn", "ㄩㄣˋ");
            DictAdd(dataDict, "qióng", "ㄑㄩㄥˊ");
            DictAdd(dataDict, "nán", "ㄋㄢˊ");
            DictAdd(dataDict, "nā", "ㄋㄚ");
            DictAdd(dataDict, "běi", "ㄅㄟˇ");
            DictAdd(dataDict, "bèi", "ㄅㄟˋ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "dōng", "ㄉㄨㄥ");
            DictAdd(dataDict, "yīng", "ㄧㄥ");
            DictAdd(dataDict, "yìng", "ㄧㄥˋ");
            DictAdd(dataDict, "hū", "ㄏㄨ");
            DictAdd(dataDict, "zhōng", "ㄓㄨㄥ");
            DictAdd(dataDict, "zhòng", "ㄓㄨㄥˋ");
            DictAdd(dataDict, "shuǐ", "ㄕㄨㄟˇ");
            DictAdd(dataDict, "huǒ", "ㄏㄨㄛˇ");
            DictAdd(dataDict, "mù", "ㄇㄨˋ");
            DictAdd(dataDict, "jīn", "ㄐㄧㄣ");
            DictAdd(dataDict, "tǔ", "ㄊㄨˇ");
            DictAdd(dataDict, "háng", "ㄏㄤˊ");
            DictAdd(dataDict, "xíng", "ㄒㄧㄥˊ");
            DictAdd(dataDict, "rén", "ㄖㄣˊ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "xìn", "ㄒㄧㄣˋ");
            DictAdd(dataDict, "shēn", "ㄕㄣ");
            DictAdd(dataDict, "cháng", "ㄔㄤˊ");
            DictAdd(dataDict, "róng", "ㄖㄨㄥˊ");
            DictAdd(dataDict, "wěn", "ㄨㄣˇ");
            DictAdd(dataDict, "dào", "ㄉㄠˋ");
            DictAdd(dataDict, "liáng", "ㄌㄧㄤˊ");
            DictAdd(dataDict, "shū", "ㄕㄨ");
            DictAdd(dataDict, "mài", "ㄇㄞˋ");
            DictAdd(dataDict, "shǔ", "ㄕㄨˇ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "liù", "ㄌㄧㄡˋ");
            DictAdd(dataDict, "lù", "ㄌㄨˋ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "gòu", "ㄍㄡˋ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "sì", "ㄙˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "mǎ", "ㄇㄚˇ");
            DictAdd(dataDict, "niú", "ㄋㄧㄡˊ");
            DictAdd(dataDict, "yáng", "ㄧㄤˊ");
            DictAdd(dataDict, "xiáng", "ㄒㄧㄤˊ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "quǎn", "ㄑㄩㄢˇ");
            DictAdd(dataDict, "shǐ", "ㄕˇ");
            DictAdd(dataDict, "xù", "ㄒㄩˋ");
            DictAdd(dataDict, "chù", "ㄔㄨˋ");
            DictAdd(dataDict, "sì", "ㄙˋ");
            DictAdd(dataDict, "xǐ", "ㄒㄧˇ");
            DictAdd(dataDict, "nù", "ㄋㄨˋ");
            DictAdd(dataDict, "āi", "ㄞ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "ài", "ㄞˋ");
            DictAdd(dataDict, "è", "ㄜˋ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "ě", "ㄜˇ");
            DictAdd(dataDict, "wū", "ㄨ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "qī", "ㄑㄧ");
            DictAdd(dataDict, "qíng", "ㄑㄧㄥˊ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "páo", "ㄆㄠˊ");
            DictAdd(dataDict, "gé", "ㄍㄜˊ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "dàn", "ㄉㄢˋ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "zhú", "ㄓㄨˊ");
            DictAdd(dataDict, "bā", "ㄅㄚ");
            DictAdd(dataDict, "yīn", "ㄧㄣ");
            DictAdd(dataDict, "gāo", "ㄍㄠ");
            DictAdd(dataDict, "zēng", "ㄗㄥ");
            DictAdd(dataDict, "céng", "ㄘㄥˊ");
            DictAdd(dataDict, "zǔ", "ㄗㄨˇ");
            DictAdd(dataDict, "shēn", "ㄕㄣ");
            DictAdd(dataDict, "sūn", "ㄙㄨㄣ");
            DictAdd(dataDict, "xùn", "ㄒㄩㄣˋ");
            DictAdd(dataDict, "zì", "ㄗˋ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "xuán", "ㄒㄩㄢˊ");
            DictAdd(dataDict, "zú", "ㄗㄨˊ");
            DictAdd(dataDict, "lún", "ㄌㄨㄣˊ");
            DictAdd(dataDict, "ēn", "ㄣ");
            DictAdd(dataDict, "cóng", "ㄘㄨㄥˊ");
            DictAdd(dataDict, "zòng", "ㄗㄨㄥˋ");
            DictAdd(dataDict, "xiōng", "ㄒㄩㄥ");
            DictAdd(dataDict, "zé", "ㄗㄜˊ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "tì", "ㄊㄧˋ");
            DictAdd(dataDict, "tuí", "ㄊㄨㄟˊ");
            DictAdd(dataDict, "gōng", "ㄍㄨㄥ");
            DictAdd(dataDict, "xù", "ㄒㄩˋ");
            DictAdd(dataDict, "péng", "ㄆㄥˊ");
            DictAdd(dataDict, "jìng", "ㄐㄧㄥˋ");
            DictAdd(dataDict, "zhōng", "ㄓㄨㄥ");
            DictAdd(dataDict, "tóng", "ㄊㄨㄥˊ");
            DictAdd(dataDict, "tòng", "ㄊㄨㄥˋ");
            DictAdd(dataDict, "fán", "ㄈㄢˊ");
            DictAdd(dataDict, "xùn", "ㄒㄩㄣˋ");
            DictAdd(dataDict, "mēng", "ㄇㄥ");
            DictAdd(dataDict, "méng", "ㄇㄥˊ");
            DictAdd(dataDict, "měng", "ㄇㄥˇ");
            DictAdd(dataDict, "xū", "ㄒㄩ");
            DictAdd(dataDict, "jiǎng", "ㄐㄧㄤˇ");
            DictAdd(dataDict, "jiū", "ㄐㄧㄡ");
            DictAdd(dataDict, "xiáng", "ㄒㄧㄤˊ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "míng", "ㄇㄧㄥˊ");
            DictAdd(dataDict, "jù", "ㄐㄩˋ");
            DictAdd(dataDict, "gōu", "ㄍㄡ");
            DictAdd(dataDict, "dú", "ㄉㄨˊ");
            DictAdd(dataDict, "bì", "ㄅㄧˋ");
            DictAdd(dataDict, "xiǎo", "ㄒㄧㄠˇ");
            DictAdd(dataDict, "zhōng", "ㄓㄨㄥ");
            DictAdd(dataDict, "shū", "ㄕㄨ");
            DictAdd(dataDict, "lùn", "ㄌㄨㄣˋ");
            DictAdd(dataDict, "lún", "ㄌㄨㄣˊ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "èr", "ㄦˋ");
            DictAdd(dataDict, "piān", "ㄆㄧㄢ");
            DictAdd(dataDict, "qún", "ㄑㄩㄣˊ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "yán", "ㄧㄢˊ");
            DictAdd(dataDict, "zhǐ", "ㄓˇ");
            DictAdd(dataDict, "dé", "ㄉㄜˊ");
            DictAdd(dataDict, "shuō", "ㄕㄨㄛ");
            DictAdd(dataDict, "shuì", "ㄕㄨㄟˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "zuò", "ㄗㄨㄛˋ");
            DictAdd(dataDict, "yōng", "ㄩㄥ");
            DictAdd(dataDict, "kǒng", "ㄎㄨㄥˇ");
            DictAdd(dataDict, "jí", "ㄐㄧˊ");
            DictAdd(dataDict, "piān", "ㄆㄧㄢ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "dà", "ㄉㄚˋ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "tài", "ㄊㄞˋ");
            DictAdd(dataDict, "xiū", "ㄒㄧㄡ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "zhāi", "ㄓㄞ");
            DictAdd(dataDict, "píng", "ㄆㄧㄥˊ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "jīng", "ㄐㄧㄥ");
            DictAdd(dataDict, "tōng", "ㄊㄨㄥ");
            DictAdd(dataDict, "shú", "ㄕㄨˊ");
            DictAdd(dataDict, "rú", "ㄖㄨˊ");
            DictAdd(dataDict, "shǐ", "ㄕˇ");
            DictAdd(dataDict, "kě", "ㄎㄜˇ");
            DictAdd(dataDict, "kè", "ㄎㄜˋ");
            DictAdd(dataDict, "dú", "ㄉㄨˊ");
            DictAdd(dataDict, "shī", "ㄕ");
            DictAdd(dataDict, "hào", "ㄏㄠˋ");
            DictAdd(dataDict, "qiú", "ㄑㄧㄡˊ");
            DictAdd(dataDict, "lián", "ㄌㄧㄢˊ");
            DictAdd(dataDict, "guī", "ㄍㄨㄟ");
            DictAdd(dataDict, "cáng", "ㄘㄤˊ");
            DictAdd(dataDict, "zàng", "ㄗㄤˋ");
            DictAdd(dataDict, "zhōu", "ㄓㄡ");
            DictAdd(dataDict, "diǎn", "ㄉㄧㄢˇ");
            DictAdd(dataDict, "mó", "ㄇㄛˊ");
            DictAdd(dataDict, "gào", "ㄍㄠˋ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "mìng", "ㄇㄧㄥˋ");
            DictAdd(dataDict, "ào", "ㄠˋ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "wǒ", "ㄨㄛˇ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "gōng", "ㄍㄨㄥ");
            DictAdd(dataDict, "zhù", "ㄓㄨˋ");
            DictAdd(dataDict, "zhuó", "ㄓㄨㄛˊ");
            DictAdd(dataDict, "zhe", "ㄓㄜ");
            DictAdd(dataDict, "cún", "ㄘㄨㄣˊ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "zhù", "ㄓㄨˋ");
            DictAdd(dataDict, "shù", "ㄕㄨˋ");
            DictAdd(dataDict, "shèng", "ㄕㄥˋ");
            DictAdd(dataDict, "lè", "ㄌㄜˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "yào", "ㄧㄠˋ");
            DictAdd(dataDict, "lào", "ㄌㄠˋ");
            DictAdd(dataDict, "bèi", "ㄅㄟˋ");
            DictAdd(dataDict, "guó", "ㄍㄨㄛˊ");
            DictAdd(dataDict, "fēng", "ㄈㄥ");
            DictAdd(dataDict, "fěng", "ㄈㄥˇ");
            DictAdd(dataDict, "yǎ", "ㄧㄚˇ");
            DictAdd(dataDict, "sòng", "ㄙㄨㄥˋ");
            DictAdd(dataDict, "fěng", "ㄈㄥˇ");
            DictAdd(dataDict, "yǒng", "ㄩㄥˇ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "wáng", "ㄨㄤˊ");
            DictAdd(dataDict, "wú", "ㄨˊ");
            DictAdd(dataDict, "yù", "ㄩˋ");
            DictAdd(dataDict, "bāo", "ㄅㄠ");
            DictAdd(dataDict, "biǎn", "ㄅㄧㄢˇ");
            DictAdd(dataDict, "bié", "ㄅㄧㄝˊ");
            DictAdd(dataDict, "biè", "ㄅㄧㄝˋ");
            DictAdd(dataDict, "è", "ㄜˋ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "ě", "ㄜˇ");
            DictAdd(dataDict, "wū", "ㄨ");
            DictAdd(dataDict, "chuán", "ㄔㄨㄢˊ");
            DictAdd(dataDict, "zhuàn", "ㄓㄨㄢˋ");
            DictAdd(dataDict, "zuǒ", "ㄗㄨㄛˇ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "zhī", "ㄓ");
            DictAdd(dataDict, "liáng", "ㄌㄧㄤˊ");
            DictAdd(dataDict, "cuō", "ㄘㄨㄛ");
            DictAdd(dataDict, "zuǒ", "ㄗㄨㄛˇ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "yào", "ㄧㄠˋ");
            DictAdd(dataDict, "yāo", "ㄧㄠ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "xún", "ㄒㄩㄣˊ");
            DictAdd(dataDict, "yáng", "ㄧㄤˊ");
            DictAdd(dataDict, "jí", "ㄐㄧˊ");
            DictAdd(dataDict, "zhuāng", "ㄓㄨㄤ");
            DictAdd(dataDict, "zhū", "ㄓㄨ");
            DictAdd(dataDict, "shǐ", "ㄕˇ");
            DictAdd(dataDict, "kǎo", "ㄎㄠˇ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "xì", "ㄒㄧˋ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "nóng", "ㄋㄨㄥˊ");
            DictAdd(dataDict, "huáng", "ㄏㄨㄤˊ");
            DictAdd(dataDict, "dì", "ㄉㄧˋ");
            DictAdd(dataDict, "huáng", "ㄏㄨㄤˊ");
            DictAdd(dataDict, "jū", "ㄐㄩ");
            DictAdd(dataDict, "shàng", "ㄕㄤˋ");
            DictAdd(dataDict, "shǎng", "ㄕㄤˇ");
            DictAdd(dataDict, "táng", "ㄊㄤˊ");
            DictAdd(dataDict, "yú", "ㄩˊ");
            DictAdd(dataDict, "yī", "ㄧ");
            DictAdd(dataDict, "xùn", "ㄒㄩㄣˋ");
            DictAdd(dataDict, "chēng", "ㄔㄥ");
            DictAdd(dataDict, "chèn", "ㄔㄣˋ");
            DictAdd(dataDict, "chèng", "ㄔㄥˋ");
            DictAdd(dataDict, "shèng", "ㄕㄥˋ");
            DictAdd(dataDict, "chéng", "ㄔㄥˊ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "shāng", "ㄕㄤ");
            DictAdd(dataDict, "tāng", "ㄊㄤ");
            DictAdd(dataDict, "shāng", "ㄕㄤ");
            DictAdd(dataDict, "wǔ", "ㄨˇ");
            DictAdd(dataDict, "wáng", "ㄨㄤˊ");
            DictAdd(dataDict, "wàng", "ㄨㄤˋ");
            DictAdd(dataDict, "chuán", "ㄔㄨㄢˊ");
            DictAdd(dataDict, "zhuàn", "ㄓㄨㄢˋ");
            DictAdd(dataDict, "jiā", "ㄐㄧㄚ");
            DictAdd(dataDict, "jia", "ㄐㄧㄚ");
            DictAdd(dataDict, "jie", "ㄐㄧㄝ");
            DictAdd(dataDict, "xià", "ㄒㄧㄚˋ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "shè", "ㄕㄜˋ");
            DictAdd(dataDict, "fá", "ㄈㄚˊ");
            DictAdd(dataDict, "zhòu", "ㄓㄡˋ");
            DictAdd(dataDict, "zhū", "ㄓㄨ");
            DictAdd(dataDict, "zuì", "ㄗㄨㄟˋ");
            DictAdd(dataDict, "cháng", "ㄔㄤˊ");
            DictAdd(dataDict, "zhǎng", "ㄓㄤˇ");
            DictAdd(dataDict, "jiǔ", "ㄐㄧㄡˇ");
            DictAdd(dataDict, "zhé", "ㄓㄜˊ");
            DictAdd(dataDict, "zhuì", "ㄓㄨㄟˋ");
            DictAdd(dataDict, "chěng", "ㄔㄥˇ");
            DictAdd(dataDict, "gān", "ㄍㄢ");
            DictAdd(dataDict, "gàn", "ㄍㄢˋ");
            DictAdd(dataDict, "gē", "ㄍㄜ");
            DictAdd(dataDict, "shàng", "ㄕㄤˋ");
            DictAdd(dataDict, "yóu", "ㄧㄡˊ");
            DictAdd(dataDict, "shuō", "ㄕㄨㄛ");
            DictAdd(dataDict, "shuì", "ㄕㄨㄟˋ");
            DictAdd(dataDict, "yuè", "ㄩㄝˋ");
            DictAdd(dataDict, "zhàn", "ㄓㄢˋ");
            DictAdd(dataDict, "bà", "ㄅㄚˋ");
            DictAdd(dataDict, "qiáng", "ㄑㄧㄤˊ");
            DictAdd(dataDict, "qiǎng", "ㄑㄧㄤˇ");
            DictAdd(dataDict, "jiàng", "ㄐㄧㄤˋ");
            DictAdd(dataDict, "xióng", "ㄒㄩㄥˊ");
            DictAdd(dataDict, "chū", "ㄔㄨ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "qín", "ㄑㄧㄣˊ");
            DictAdd(dataDict, "jiān", "ㄐㄧㄢ");
            DictAdd(dataDict, "bìng", "ㄅㄧㄥˋ");
            DictAdd(dataDict, "bīng", "ㄅㄧㄥ");
            DictAdd(dataDict, "chǔ", "ㄔㄨˇ");
            DictAdd(dataDict, "hàn", "ㄏㄢˋ");
            DictAdd(dataDict, "zhēng", "ㄓㄥ");
            DictAdd(dataDict, "xīng", "ㄒㄧㄥ");
            DictAdd(dataDict, "yè", "ㄧㄝˋ");
            DictAdd(dataDict, "jiàn", "ㄐㄧㄢˋ");
            DictAdd(dataDict, "mǎng", "ㄇㄤˇ");
            DictAdd(dataDict, "cuàn", "ㄘㄨㄢˋ");
            DictAdd(dataDict, "nián", "ㄋㄧㄢˊ");
            DictAdd(dataDict, "xiàn", "ㄒㄧㄢˋ");
            DictAdd(dataDict, "wèi", "ㄨㄟˋ");
            DictAdd(dataDict, "shǔ", "ㄕㄨˇ");
            DictAdd(dataDict, "wú", "ㄨˊ");
            DictAdd(dataDict, "dǐng", "ㄉㄧㄥˇ");
            DictAdd(dataDict, "qì", "ㄑㄧˋ");
            DictAdd(dataDict, "liǎng", "ㄌㄧㄤˇ");
            DictAdd(dataDict, "jìn", "ㄐㄧㄣˋ");
            DictAdd(dataDict, "sòng", "ㄙㄨㄥˋ");
            DictAdd(dataDict, "jì", "ㄐㄧˋ");
            DictAdd(dataDict, "chén", "ㄔㄣˊ");
            DictAdd(dataDict, "chéng", "ㄔㄥˊ");
            DictAdd(dataDict, "zhāo", "ㄓㄠ");
            DictAdd(dataDict, "cháo", "ㄔㄠˊ");
            DictAdd(dataDict, "dū", "ㄉㄨ");
            DictAdd(dataDict, "dōu", "ㄉㄡ");
            DictAdd(dataDict, "líng", "ㄌㄧㄥˊ");
            DictAdd(dataDict, "yuán", "ㄩㄢˊ");
            DictAdd(dataDict, "fēn", "ㄈㄣ");
            DictAdd(dataDict, "fèn", "ㄈㄣˋ");
            DictAdd(dataDict, "yǔ", "ㄩˇ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "suí", "ㄙㄨㄟˊ");
            DictAdd(dataDict, "duò", "ㄉㄨㄛˋ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "shī", "ㄕ");
            DictAdd(dataDict, "tǒng", "ㄊㄨㄥˇ");
            DictAdd(dataDict, "xù", "ㄒㄩˋ");
            DictAdd(dataDict, "qǐ", "ㄑㄧˇ");
            DictAdd(dataDict, "chú", "ㄔㄨˊ");
            DictAdd(dataDict, "luàn", "ㄌㄨㄢˋ");
            DictAdd(dataDict, "chuàng", "ㄔㄨㄤˋ");
            DictAdd(dataDict, "chuāng", "ㄔㄨㄤ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "miè", "ㄇㄧㄝˋ");
            DictAdd(dataDict, "gǎi", "ㄍㄞˇ");
            DictAdd(dataDict, "dài", "ㄉㄞˋ");
            DictAdd(dataDict, "jiē", "ㄐㄧㄝ");
            DictAdd(dataDict, "yóu", "ㄧㄡˊ");
            DictAdd(dataDict, "yán", "ㄧㄢˊ");
            DictAdd(dataDict, "shòu", "ㄕㄡˋ");
            DictAdd(dataDict, "shàn", "ㄕㄢˋ");
            DictAdd(dataDict, "chán", "ㄔㄢˊ");
            DictAdd(dataDict, "hùn", "ㄏㄨㄣˋ");
            DictAdd(dataDict, "hún", "ㄏㄨㄣˊ");
            DictAdd(dataDict, "quán", "ㄑㄩㄢˊ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "zī", "ㄗ");
            DictAdd(dataDict, "cí", "ㄘˊ");
            DictAdd(dataDict, "zài", "ㄗㄞˋ");
            DictAdd(dataDict, "shuāi", "ㄕㄨㄞ");
            DictAdd(dataDict, "cuī", "ㄘㄨㄟ");
            DictAdd(dataDict, "shí", "ㄕˊ");
            DictAdd(dataDict, "lù", "ㄌㄨˋ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "jīn", "ㄐㄧㄣ");
            DictAdd(dataDict, "ruò", "ㄖㄨㄛˋ");
            DictAdd(dataDict, "rě", "ㄖㄜˇ");
            DictAdd(dataDict, "mù", "ㄇㄨˋ");
            DictAdd(dataDict, "kǒu", "ㄎㄡˇ");
            DictAdd(dataDict, "sòng", "ㄙㄨㄥˋ");
            DictAdd(dataDict, "xīn", "ㄒㄧㄣ");
            DictAdd(dataDict, "wéi", "ㄨㄟˊ");
            DictAdd(dataDict, "zhāo", "ㄓㄠ");
            DictAdd(dataDict, "cháo", "ㄔㄠˊ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "xī", "ㄒㄧ");
            DictAdd(dataDict, "zhòng", "ㄓㄨㄥˋ");
            DictAdd(dataDict, "ní", "ㄋㄧˊ");
            DictAdd(dataDict, "xiàng", "ㄒㄧㄤˋ");
            DictAdd(dataDict, "tuó", "ㄊㄨㄛˊ");
            DictAdd(dataDict, "xián", "ㄒㄧㄢˊ");
            DictAdd(dataDict, "qín", "ㄑㄧㄣˊ");
            DictAdd(dataDict, "zhào", "ㄓㄠˋ");
            DictAdd(dataDict, "líng", "ㄌㄧㄥˊ");
            DictAdd(dataDict, "lǐng", "ㄌㄧㄥˇ");
            DictAdd(dataDict, "lìng", "ㄌㄧㄥˋ");
            DictAdd(dataDict, "lǔ", "ㄌㄨˇ");
            DictAdd(dataDict, "bǐ", "ㄅㄧˇ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "qiě", "ㄑㄧㄝˇ");
            DictAdd(dataDict, "jū", "ㄐㄩ");
            DictAdd(dataDict, "pī", "ㄆㄧ");
            DictAdd(dataDict, "pú", "ㄆㄨˊ");
            DictAdd(dataDict, "biān", "ㄅㄧㄢ");
            DictAdd(dataDict, "xiāo", "ㄒㄧㄠ");
            DictAdd(dataDict, "xuē", "ㄒㄩㄝ");
            DictAdd(dataDict, "jiǎn", "ㄐㄧㄢˇ");
            DictAdd(dataDict, "wú", "ㄨˊ");
            DictAdd(dataDict, "miǎn", "ㄇㄧㄢˇ");
            DictAdd(dataDict, "tóu", "ㄊㄡˊ");
            DictAdd(dataDict, "xuán", "ㄒㄩㄢˊ");
            DictAdd(dataDict, "zhuī", "ㄓㄨㄟ");
            DictAdd(dataDict, "cì", "ㄘˋ");
            DictAdd(dataDict, "cī", "ㄘ");
            DictAdd(dataDict, "gǔ", "ㄍㄨˇ");
            DictAdd(dataDict, "kǔ", "ㄎㄨˇ");
            DictAdd(dataDict, "náng", "ㄋㄤˊ");
            DictAdd(dataDict, "nāng", "ㄋㄤ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "yìng", "ㄧㄥˋ");
            DictAdd(dataDict, "xuě", "ㄒㄩㄝˇ");
            DictAdd(dataDict, "suī", "ㄙㄨㄟ");
            DictAdd(dataDict, "pín", "ㄆㄧㄣˊ");
            DictAdd(dataDict, "chuò", "ㄔㄨㄛˋ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "xīn", "ㄒㄧㄣ");
            DictAdd(dataDict, "guà", "ㄍㄨㄚˋ");
            DictAdd(dataDict, "jiǎo", "ㄐㄧㄠˇ");
            DictAdd(dataDict, "jué", "ㄐㄩㄝˊ");
            DictAdd(dataDict, "láo", "ㄌㄠˊ");
            DictAdd(dataDict, "yóu", "ㄧㄡˊ");
            DictAdd(dataDict, "zhuó", "ㄓㄨㄛˊ");
            DictAdd(dataDict, "sū", "ㄙㄨ");
            DictAdd(dataDict, "quán", "ㄑㄩㄢˊ");
            DictAdd(dataDict, "fā", "ㄈㄚ");
            DictAdd(dataDict, "fèn", "ㄈㄣˋ");
            DictAdd(dataDict, "jí", "ㄐㄧˊ");
            DictAdd(dataDict, "huǐ", "ㄏㄨㄟˇ");
            DictAdd(dataDict, "chí", "ㄔˊ");
            DictAdd(dataDict, "ěr", "ㄦˇ");
            DictAdd(dataDict, "shēng", "ㄕㄥ");
            DictAdd(dataDict, "zǎo", "ㄗㄠˇ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "sāi", "ㄙㄞ");
            DictAdd(dataDict, "hào", "ㄏㄠˋ");
            DictAdd(dataDict, "duì", "ㄉㄨㄟˋ");
            DictAdd(dataDict, "tíng", "ㄊㄧㄥˊ");
            DictAdd(dataDict, "kuí", "ㄎㄨㄟˊ");
            DictAdd(dataDict, "duō", "ㄉㄨㄛ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "zhòng", "ㄓㄨㄥˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "lì", "ㄌㄧˋ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "yǐng", "ㄧㄥˇ");
            DictAdd(dataDict, "mì", "ㄇㄧˋ");
            DictAdd(dataDict, "bì", "ㄅㄧˋ");
            DictAdd(dataDict, "fù", "ㄈㄨˋ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "yǐng", "ㄧㄥˇ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "qí", "ㄑㄧˊ");
            DictAdd(dataDict, "jī", "ㄐㄧ");
            DictAdd(dataDict, "xiào", "ㄒㄧㄠˋ");
            DictAdd(dataDict, "cài", "ㄘㄞˋ");
            DictAdd(dataDict, "biàn", "ㄅㄧㄢˋ");
            DictAdd(dataDict, "qín", "ㄑㄧㄣˊ");
            DictAdd(dataDict, "xiè", "ㄒㄧㄝˋ");
            DictAdd(dataDict, "yùn", "ㄩㄣˋ");
            DictAdd(dataDict, "yín", "ㄧㄣˊ");
            DictAdd(dataDict, "nǚ", "ㄋㄩˇ");
            DictAdd(dataDict, "rǔ", "ㄖㄨˇ");
            DictAdd(dataDict, "cōng", "ㄘㄨㄥ");
            DictAdd(dataDict, "mǐn", "ㄇㄧㄣˇ");
            DictAdd(dataDict, "nán", "ㄋㄢˊ");
            DictAdd(dataDict, "jǐng", "ㄐㄧㄥˇ");
            DictAdd(dataDict, "liú", "ㄌㄧㄡˊ");
            DictAdd(dataDict, "jǔ", "ㄐㄩˇ");
            DictAdd(dataDict, "yàn", "ㄧㄢˋ");
            DictAdd(dataDict, "shén", "ㄕㄣˊ");
            DictAdd(dataDict, "tóng", "ㄊㄨㄥˊ");
            DictAdd(dataDict, "zhèng", "ㄓㄥˋ");
            DictAdd(dataDict, "zhēng", "ㄓㄥ");
            DictAdd(dataDict, "zì", "ㄗˋ");
            DictAdd(dataDict, "yǐ", "ㄧˇ");
            DictAdd(dataDict, "zhì", "ㄓˋ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "shǒu", "ㄕㄡˇ");
            DictAdd(dataDict, "yè", "ㄧㄝˋ");
            DictAdd(dataDict, "sī", "ㄙ");
            DictAdd(dataDict, "chén", "ㄔㄣˊ");
            DictAdd(dataDict, "hé", "ㄏㄜˊ");
            DictAdd(dataDict, "cán", "ㄘㄢˊ");
            DictAdd(dataDict, "tǔ", "ㄊㄨˇ");
            DictAdd(dataDict, "tù", "ㄊㄨˋ");
            DictAdd(dataDict, "fēng", "ㄈㄥ");
            DictAdd(dataDict, "niàng", "ㄋㄧㄤˋ");
            DictAdd(dataDict, "niáng", "ㄋㄧㄤˊ");
            DictAdd(dataDict, "mì", "ㄇㄧˋ");
            DictAdd(dataDict, "wù", "ㄨˋ");
            DictAdd(dataDict, "zhuàng", "ㄓㄨㄤˋ");
            DictAdd(dataDict, "zé", "ㄗㄜˊ");
            DictAdd(dataDict, "shì", "ㄕˋ");
            DictAdd(dataDict, "mín", "ㄇㄧㄣˊ");
            DictAdd(dataDict, "shēng", "ㄕㄥ");
            DictAdd(dataDict, "xiǎn", "ㄒㄧㄢˇ");
            DictAdd(dataDict, "qián", "ㄑㄧㄢˊ");
            DictAdd(dataDict, "chuí", "ㄔㄨㄟˊ");
            DictAdd(dataDict, "hòu", "ㄏㄡˋ");
            DictAdd(dataDict, "yí", "ㄧˊ");
            DictAdd(dataDict, "mǎn", "ㄇㄢˇ");
            DictAdd(dataDict, "yíng", "ㄧㄥˊ");
            DictAdd(dataDict, "gōng", "ㄍㄨㄥ");
            DictAdd(dataDict, "xì", "ㄒㄧˋ");
            DictAdd(dataDict, "hū", "ㄏㄨ");
            DictAdd(dataDict, "yì", "ㄧˋ");
            DictAdd(dataDict, "jiè", "ㄐㄧㄝˋ");
            DictAdd(dataDict, "zāi", "ㄗㄞ");
            DictAdd(dataDict, "lì", "ㄌㄧˋ");
            #endregion

            VerifyDataDict(dataDict);
        }

        //test all pinyin collection


        private void VerifyDataDict(Dictionary<string, string> dataDict)
        {
            foreach (var item in dataDict)
            {
                //Console.WriteLine("{0}:{1}", item.Key, item.Value);
                string actualValue = new PingYin(item.Key, false).ZhuYin;
                if (0 != string.Compare(item.Value, actualValue))
                {
                    Console.WriteLine("{0} {1} {2}", item.Value, item.Key, actualValue);
                }
                Assert.AreEqual<string>(item.Value, new PingYin(item.Key).ZhuYin);
            }

        }
    }
}
