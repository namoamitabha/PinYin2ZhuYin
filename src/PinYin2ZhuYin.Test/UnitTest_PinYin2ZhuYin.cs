using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PY2ZY;
using System.IO;

namespace PY2ZY.Test
{
    [TestClass]
    public class UnitTest_PinYin2ZhuYin
    {


        [TestMethod]
        public void TestMethod01()
        {
            Dictionary<string, string> dict = new Dictionary<string, string> { {"a","ㄚ"},
                        {"ai","ㄞ"}};
            Assert.AreEqual<string>("ㄚ", dict["a"]);
        }

        [TestMethod]
        public void TestMethod02()
        {
            Assert.AreEqual<string>("ㄖㄣˊ ㄓ ㄔㄨ", PinYin2ZhuYin.Convert("rén zhī chū"));
            Assert.AreEqual<string>("ㄖㄣˊ ㄓˉ ㄔㄨˉ", PinYin2ZhuYin.Convert("rén zhī chū", true));

            Assert.AreEqual<string>("ㄒㄧㄤˉ\\ㄒㄧㄤˋ", PinYin2ZhuYin.Convert("xiāng\\xiàng", true));
            Assert.AreEqual<string>("ㄒㄧㄤ\\ㄒㄧㄤˋ", PinYin2ZhuYin.Convert("xiāng\\xiàng"));
        }


        [TestMethod]
        public void TestMethod03()
        {
            #region init dict
            Dictionary<string, string> dict = new Dictionary<string, string> { };
            DictAdd(dict, "a", "ㄚ");
            DictAdd(dict, "ai", "ㄞ");
            DictAdd(dict, "an", "ㄢ");
            DictAdd(dict, "ang", "ㄤ");
            DictAdd(dict, "ao", "ㄠ");
            DictAdd(dict, "ba", "ㄅㄚ");
            DictAdd(dict, "bai", "ㄅㄞ");
            DictAdd(dict, "ban", "ㄅㄢ");
            DictAdd(dict, "bang", "ㄅㄤ");
            DictAdd(dict, "bao", "ㄅㄠ");
            DictAdd(dict, "bei", "ㄅㄟ");
            DictAdd(dict, "ben", "ㄅㄣ");
            DictAdd(dict, "beng", "ㄅㄥ");
            DictAdd(dict, "bi", "ㄅㄧ");
            DictAdd(dict, "bian", "ㄅㄧㄢ");
            DictAdd(dict, "biao", "ㄅㄧㄠ");
            DictAdd(dict, "bie", "ㄅㄧㄝ");
            DictAdd(dict, "bin", "ㄅㄧㄣ");
            DictAdd(dict, "bing", "ㄅㄧㄥ");
            DictAdd(dict, "bo", "ㄅㄛ");
            DictAdd(dict, "bu", "ㄅㄨ");
            DictAdd(dict, "ca", "ㄘㄚ");
            DictAdd(dict, "cai", "ㄘㄞ");
            DictAdd(dict, "can", "ㄘㄢ");
            DictAdd(dict, "cang", "ㄘㄤ");
            DictAdd(dict, "cao", "ㄘㄠ");
            DictAdd(dict, "ce", "ㄘㄜ");
            DictAdd(dict, "cen", "ㄘㄣ");
            DictAdd(dict, "ceng", "ㄘㄥ");
            DictAdd(dict, "cha", "ㄔㄚ");
            DictAdd(dict, "chai", "ㄔㄞ");
            DictAdd(dict, "chan", "ㄔㄢ");
            DictAdd(dict, "chang", "ㄔㄤ");
            DictAdd(dict, "chao", "ㄔㄠ");
            DictAdd(dict, "che", "ㄔㄜ");
            DictAdd(dict, "chen", "ㄔㄣ");
            DictAdd(dict, "cheng", "ㄔㄥ");
            DictAdd(dict, "chi", "ㄔ");
            DictAdd(dict, "chong", "ㄔㄨㄥ");
            DictAdd(dict, "chou", "ㄔㄡ");
            DictAdd(dict, "chu", "ㄔㄨ");
            DictAdd(dict, "chua", "ㄔㄨㄚ");
            DictAdd(dict, "chuai", "ㄔㄨㄞ");
            DictAdd(dict, "chuan", "ㄔㄨㄢ");
            DictAdd(dict, "chuang", "ㄔㄨㄤ");
            DictAdd(dict, "chui", "ㄔㄨㄟ");
            DictAdd(dict, "chun", "ㄔㄨㄣ");
            DictAdd(dict, "chuo", "ㄔㄨㄛ");
            DictAdd(dict, "qi", "ㄑㄧ");
            DictAdd(dict, "qia", "ㄑㄧㄚ");
            DictAdd(dict, "qian", "ㄑㄧㄢ");
            DictAdd(dict, "qiang", "ㄑㄧㄤ");
            DictAdd(dict, "qiao", "ㄑㄧㄠ");
            DictAdd(dict, "qie", "ㄑㄧㄝ");
            DictAdd(dict, "ci", "ㄘ");
            DictAdd(dict, "qin", "ㄑㄧㄣ");
            DictAdd(dict, "qing", "ㄑㄧㄥ");
            DictAdd(dict, "qiu", "ㄑㄧㄡ");
            DictAdd(dict, "cong", "ㄘㄨㄥ");
            DictAdd(dict, "cou", "ㄘㄡ");
            DictAdd(dict, "cu", "ㄘㄨ");
            DictAdd(dict, "cuan", "ㄘㄨㄢ");
            DictAdd(dict, "cui", "ㄘㄨㄟ");
            DictAdd(dict, "cun", "ㄘㄨㄣ");
            DictAdd(dict, "cuo", "ㄘㄨㄛ");
            DictAdd(dict, "qiong", "ㄑㄩㄥ");
            DictAdd(dict, "qu", "ㄑㄩ");
            DictAdd(dict, "quan", "ㄑㄩㄢ");
            DictAdd(dict, "que", "ㄑㄩㄝ");
            DictAdd(dict, "qun", "ㄑㄩㄣ");
            DictAdd(dict, "da", "ㄉㄚ");
            DictAdd(dict, "dai", "ㄉㄞ");
            DictAdd(dict, "dan", "ㄉㄢ");
            DictAdd(dict, "dang", "ㄉㄤ");
            DictAdd(dict, "dao", "ㄉㄠ");
            DictAdd(dict, "de", "ㄉㄜ");
            DictAdd(dict, "dei", "ㄉㄟ");
            DictAdd(dict, "den", "ㄉㄣ");
            DictAdd(dict, "deng", "ㄉㄥ");
            DictAdd(dict, "di", "ㄉㄧ");
            DictAdd(dict, "dian", "ㄉㄧㄢ");
            DictAdd(dict, "diang", "ㄉㄧㄤ");
            DictAdd(dict, "diao", "ㄉㄧㄠ");
            DictAdd(dict, "die", "ㄉㄧㄝ");
            DictAdd(dict, "ding", "ㄉㄧㄥ");
            DictAdd(dict, "diu", "ㄉㄧㄡ");
            DictAdd(dict, "dong", "ㄉㄨㄥ");
            DictAdd(dict, "dou", "ㄉㄡ");
            DictAdd(dict, "du", "ㄉㄨ");
            DictAdd(dict, "duan", "ㄉㄨㄢ");
            DictAdd(dict, "dui", "ㄉㄨㄟ");
            DictAdd(dict, "dun", "ㄉㄨㄣ");
            DictAdd(dict, "duo", "ㄉㄨㄛ");
            DictAdd(dict, "e", "ㄜ");
            DictAdd(dict, "e", "ㄝ");
            DictAdd(dict, "ei", "ㄟ");
            DictAdd(dict, "en", "ㄣ");
            DictAdd(dict, "eng", "ㄥ");
            DictAdd(dict, "er", "ㄦ");
            DictAdd(dict, "fa", "ㄈㄚ");
            DictAdd(dict, "fan", "ㄈㄢ");
            DictAdd(dict, "fang", "ㄈㄤ");
            DictAdd(dict, "fei", "ㄈㄟ");
            DictAdd(dict, "fen", "ㄈㄣ");
            DictAdd(dict, "fo", "ㄈㄛ");
            DictAdd(dict, "feng", "ㄈㄥ");
            DictAdd(dict, "fou", "ㄈㄡ");
            DictAdd(dict, "fu", "ㄈㄨ");
            DictAdd(dict, "ga", "ㄍㄚ");
            DictAdd(dict, "gai", "ㄍㄞ");
            DictAdd(dict, "gan", "ㄍㄢ");
            DictAdd(dict, "gang", "ㄍㄤ");
            DictAdd(dict, "gao", "ㄍㄠ");
            DictAdd(dict, "ge", "ㄍㄜ");
            DictAdd(dict, "gei", "ㄍㄟ");
            DictAdd(dict, "gen", "ㄍㄣ");
            DictAdd(dict, "geng", "ㄍㄥ");
            DictAdd(dict, "gong", "ㄍㄨㄥ");
            DictAdd(dict, "gou", "ㄍㄡ");
            DictAdd(dict, "gu", "ㄍㄨ");
            DictAdd(dict, "gua", "ㄍㄨㄚ");
            DictAdd(dict, "guai", "ㄍㄨㄞ");
            DictAdd(dict, "guan", "ㄍㄨㄢ");
            DictAdd(dict, "guang", "ㄍㄨㄤ");
            DictAdd(dict, "gui", "ㄍㄨㄟ");
            DictAdd(dict, "gun", "ㄍㄨㄣ");
            DictAdd(dict, "guo", "ㄍㄨㄛ");
            DictAdd(dict, "ha", "ㄏㄚ");
            DictAdd(dict, "hai", "ㄏㄞ");
            DictAdd(dict, "han", "ㄏㄢ");
            DictAdd(dict, "hang", "ㄏㄤ");
            DictAdd(dict, "hao", "ㄏㄠ");
            DictAdd(dict, "he", "ㄏㄜ");
            DictAdd(dict, "hei", "ㄏㄟ");
            DictAdd(dict, "hen", "ㄏㄣ");
            DictAdd(dict, "heng", "ㄏㄥ");
            DictAdd(dict, "hong", "ㄏㄨㄥ");
            DictAdd(dict, "hou", "ㄏㄡ");
            DictAdd(dict, "hu", "ㄏㄨ");
            DictAdd(dict, "hua", "ㄏㄨㄚ");
            DictAdd(dict, "huai", "ㄏㄨㄞ");
            DictAdd(dict, "huan", "ㄏㄨㄢ");
            DictAdd(dict, "huang", "ㄏㄨㄤ");
            DictAdd(dict, "hui", "ㄏㄨㄟ");
            DictAdd(dict, "hun", "ㄏㄨㄣ");
            DictAdd(dict, "huo", "ㄏㄨㄛ");
            DictAdd(dict, "zha", "ㄓㄚ");
            DictAdd(dict, "zhai", "ㄓㄞ");
            DictAdd(dict, "zhan", "ㄓㄢ");
            DictAdd(dict, "zhang", "ㄓㄤ");
            DictAdd(dict, "zhao", "ㄓㄠ");
            DictAdd(dict, "zhe", "ㄓㄜ");
            DictAdd(dict, "zhei", "ㄓㄟ");
            DictAdd(dict, "zhen", "ㄓㄣ");
            DictAdd(dict, "zheng", "ㄓㄥ");
            DictAdd(dict, "zhi", "ㄓ");
            DictAdd(dict, "zhong", "ㄓㄨㄥ");
            DictAdd(dict, "zhou", "ㄓㄡ");
            DictAdd(dict, "zhu", "ㄓㄨ");
            DictAdd(dict, "zhua", "ㄓㄨㄚ");
            DictAdd(dict, "zhuai", "ㄓㄨㄞ");
            DictAdd(dict, "zhuan", "ㄓㄨㄢ");
            DictAdd(dict, "zhuang", "ㄓㄨㄤ");
            DictAdd(dict, "zhui", "ㄓㄨㄟ");
            DictAdd(dict, "zhun", "ㄓㄨㄣ");
            DictAdd(dict, "zhuo", "ㄓㄨㄛ");
            DictAdd(dict, "ji", "ㄐㄧ");
            DictAdd(dict, "jia", "ㄐㄧㄚ");
            DictAdd(dict, "jian", "ㄐㄧㄢ");
            DictAdd(dict, "jiang", "ㄐㄧㄤ");
            DictAdd(dict, "jiao", "ㄐㄧㄠ");
            DictAdd(dict, "jie", "ㄐㄧㄝ");
            DictAdd(dict, "jin", "ㄐㄧㄣ");
            DictAdd(dict, "jing", "ㄐㄧㄥ");
            DictAdd(dict, "jiu", "ㄐㄧㄡ");
            DictAdd(dict, "juan", "ㄐㄩㄢ");
            DictAdd(dict, "jue", "ㄐㄩㄝ");
            DictAdd(dict, "jun", "ㄐㄩㄣ");
            DictAdd(dict, "jiong", "ㄐㄩㄥ");
            DictAdd(dict, "ju", "ㄐㄩ");
            DictAdd(dict, "ka", "ㄎㄚ");
            DictAdd(dict, "kai", "ㄎㄞ");
            DictAdd(dict, "kan", "ㄎㄢ");
            DictAdd(dict, "kang", "ㄎㄤ");
            DictAdd(dict, "kao", "ㄎㄠ");
            DictAdd(dict, "ke", "ㄎㄜ");
            DictAdd(dict, "ken", "ㄎㄣ");
            DictAdd(dict, "keng", "ㄎㄥ");
            DictAdd(dict, "kong", "ㄎㄨㄥ");
            DictAdd(dict, "kou", "ㄎㄡ");
            DictAdd(dict, "ku", "ㄎㄨ");
            DictAdd(dict, "kua", "ㄎㄨㄚ");
            DictAdd(dict, "kuai", "ㄎㄨㄞ");
            DictAdd(dict, "kuan", "ㄎㄨㄢ");
            DictAdd(dict, "kuang", "ㄎㄨㄤ");
            DictAdd(dict, "kui", "ㄎㄨㄟ");
            DictAdd(dict, "kun", "ㄎㄨㄣ");
            DictAdd(dict, "kuo", "ㄎㄨㄛ");
            DictAdd(dict, "la", "ㄌㄚ");
            DictAdd(dict, "lai", "ㄌㄞ");
            DictAdd(dict, "lan", "ㄌㄢ");
            DictAdd(dict, "lang", "ㄌㄤ");
            DictAdd(dict, "lao", "ㄌㄠ");
            DictAdd(dict, "le", "ㄌㄜ");
            DictAdd(dict, "lei", "ㄌㄟ");
            DictAdd(dict, "leng", "ㄌㄥ");
            DictAdd(dict, "li", "ㄌㄧ");
            DictAdd(dict, "lia", "ㄌㄧㄚ");
            DictAdd(dict, "lian", "ㄌㄧㄢ");
            DictAdd(dict, "liang", "ㄌㄧㄤ");
            DictAdd(dict, "liao", "ㄌㄧㄠ");
            DictAdd(dict, "lie", "ㄌㄧㄝ");
            DictAdd(dict, "lin", "ㄌㄧㄣ");
            DictAdd(dict, "ling", "ㄌㄧㄥ");
            DictAdd(dict, "liu", "ㄌㄧㄡ");
            DictAdd(dict, "lo", "ㄌㄛ");
            DictAdd(dict, "long", "ㄌㄨㄥ");
            DictAdd(dict, "lou", "ㄌㄡ");
            DictAdd(dict, "lu", "ㄌㄨ");
            DictAdd(dict, "luan", "ㄌㄨㄢ");
            DictAdd(dict, "lun", "ㄌㄨㄣ");
            DictAdd(dict, "luo", "ㄌㄨㄛ");
            DictAdd(dict, "LU", "ㄌㄩ");
            DictAdd(dict, "Luan", "ㄌㄩㄢ");
            DictAdd(dict, "lue", "ㄌㄩㄝ");
            DictAdd(dict, "Lun", "ㄌㄩㄣ");
            DictAdd(dict, "ma", "ㄇㄚ");
            DictAdd(dict, "mai", "ㄇㄞ");
            DictAdd(dict, "man", "ㄇㄢ");
            DictAdd(dict, "mang", "ㄇㄤ");
            DictAdd(dict, "mao", "ㄇㄠ");
            DictAdd(dict, "me", "ㄇㄜ");
            DictAdd(dict, "mei", "ㄇㄟ");
            DictAdd(dict, "men", "ㄇㄣ");
            DictAdd(dict, "meng", "ㄇㄥ");
            DictAdd(dict, "mi", "ㄇㄧ");
            DictAdd(dict, "mian", "ㄇㄧㄢ");
            DictAdd(dict, "miao", "ㄇㄧㄠ");
            DictAdd(dict, "mie", "ㄇㄧㄝ");
            DictAdd(dict, "min", "ㄇㄧㄣ");
            DictAdd(dict, "ming", "ㄇㄧㄥ");
            DictAdd(dict, "miu", "ㄇㄧㄡ");
            DictAdd(dict, "mo", "ㄇㄛ");
            DictAdd(dict, "mou", "ㄇㄡ");
            DictAdd(dict, "mu", "ㄇㄨ");
            DictAdd(dict, "na", "ㄋㄚ");
            DictAdd(dict, "nai", "ㄋㄞ");
            DictAdd(dict, "nan", "ㄋㄢ");
            DictAdd(dict, "nang", "ㄋㄤ");
            DictAdd(dict, "nao", "ㄋㄠ");
            DictAdd(dict, "ne", "ㄋㄜ");
            DictAdd(dict, "nei", "ㄋㄟ");
            DictAdd(dict, "nen", "ㄋㄣ");
            DictAdd(dict, "neng", "ㄋㄥ");
            DictAdd(dict, "ni", "ㄋㄧ");
            DictAdd(dict, "nia", "ㄋㄧㄚ");
            DictAdd(dict, "nian", "ㄋㄧㄢ");
            DictAdd(dict, "niang", "ㄋㄧㄤ");
            DictAdd(dict, "niao", "ㄋㄧㄠ");
            DictAdd(dict, "nie", "ㄋㄧㄝ");
            DictAdd(dict, "nin", "ㄋㄧㄣ");
            DictAdd(dict, "ning", "ㄋㄧㄥ");
            DictAdd(dict, "niu", "ㄋㄧㄡ");
            DictAdd(dict, "nong", "ㄋㄨㄥ");
            DictAdd(dict, "nou", "ㄋㄡ");
            DictAdd(dict, "nu", "ㄋㄨ");
            DictAdd(dict, "nuan", "ㄋㄨㄢ");
            DictAdd(dict, "nun", "ㄋㄨㄣ");
            DictAdd(dict, "nuo", "ㄋㄨㄛ");
            DictAdd(dict, "NU", "ㄋㄩ");
            DictAdd(dict, "nue", "ㄋㄩㄝ");
            DictAdd(dict, "o", "ㄛ");
            DictAdd(dict, "ou", "ㄡ");
            DictAdd(dict, "pa", "ㄆㄚ");
            DictAdd(dict, "pai", "ㄆㄞ");
            DictAdd(dict, "pan", "ㄆㄢ");
            DictAdd(dict, "pang", "ㄆㄤ");
            DictAdd(dict, "pao", "ㄆㄠ");
            DictAdd(dict, "pei", "ㄆㄟ");
            DictAdd(dict, "pen", "ㄆㄣ");
            DictAdd(dict, "peng", "ㄆㄥ");
            DictAdd(dict, "pi", "ㄆㄧ");
            DictAdd(dict, "pian", "ㄆㄧㄢ");
            DictAdd(dict, "piao", "ㄆㄧㄠ");
            DictAdd(dict, "pie", "ㄆㄧㄝ");
            DictAdd(dict, "pin", "ㄆㄧㄣ");
            DictAdd(dict, "ping", "ㄆㄧㄥ");
            DictAdd(dict, "po", "ㄆㄛ");
            DictAdd(dict, "pou", "ㄆㄡ");
            DictAdd(dict, "pu", "ㄆㄨ");
            DictAdd(dict, "ran", "ㄖㄢ");
            DictAdd(dict, "rang", "ㄖㄤ");
            DictAdd(dict, "rao", "ㄖㄠ");
            DictAdd(dict, "re", "ㄖㄜ");
            DictAdd(dict, "ren", "ㄖㄣ");
            DictAdd(dict, "reng", "ㄖㄥ");
            DictAdd(dict, "ri", "ㄖ");
            DictAdd(dict, "rong", "ㄖㄨㄥ");
            DictAdd(dict, "rou", "ㄖㄡ");
            DictAdd(dict, "ru", "ㄖㄨ");
            DictAdd(dict, "ruan", "ㄖㄨㄢ");
            DictAdd(dict, "rui", "ㄖㄨㄟ");
            DictAdd(dict, "run", "ㄖㄨㄣ");
            DictAdd(dict, "ruo", "ㄖㄨㄛ");
            DictAdd(dict, "sa", "ㄙㄚ");
            DictAdd(dict, "sai", "ㄙㄞ");
            DictAdd(dict, "san", "ㄙㄢ");
            DictAdd(dict, "sang", "ㄙㄤ");
            DictAdd(dict, "sao", "ㄙㄠ");
            DictAdd(dict, "se", "ㄙㄜ");
            DictAdd(dict, "sei", "ㄙㄟ");
            DictAdd(dict, "sen", "ㄙㄣ");
            DictAdd(dict, "seng", "ㄙㄥ");
            DictAdd(dict, "sha", "ㄕㄚ");
            DictAdd(dict, "shai", "ㄕㄞ");
            DictAdd(dict, "shan", "ㄕㄢ");
            DictAdd(dict, "shang", "ㄕㄤ");
            DictAdd(dict, "shao", "ㄕㄠ");
            DictAdd(dict, "she", "ㄕㄜ");
            DictAdd(dict, "shei", "ㄕㄟ");
            DictAdd(dict, "shen", "ㄕㄣ");
            DictAdd(dict, "sheng", "ㄕㄥ");
            DictAdd(dict, "shi", "ㄕ");
            DictAdd(dict, "shong", "ㄕㄨㄥ");
            DictAdd(dict, "shou", "ㄕㄡ");
            DictAdd(dict, "shu", "ㄕㄨ");
            DictAdd(dict, "shua", "ㄕㄨㄚ");
            DictAdd(dict, "shuai", "ㄕㄨㄞ");
            DictAdd(dict, "shuan", "ㄕㄨㄢ");
            DictAdd(dict, "shuang", "ㄕㄨㄤ");
            DictAdd(dict, "shui", "ㄕㄨㄟ");
            DictAdd(dict, "shun", "ㄕㄨㄣ");
            DictAdd(dict, "shuo", "ㄕㄨㄛ");
            DictAdd(dict, "xi", "ㄒㄧ");
            DictAdd(dict, "xia", "ㄒㄧㄚ");
            DictAdd(dict, "xian", "ㄒㄧㄢ");
            DictAdd(dict, "xiang", "ㄒㄧㄤ");
            DictAdd(dict, "xiao", "ㄒㄧㄠ");
            DictAdd(dict, "xie", "ㄒㄧㄝ");
            DictAdd(dict, "si", "ㄙ");
            DictAdd(dict, "xin", "ㄒㄧㄣ");
            DictAdd(dict, "xing", "ㄒㄧㄥ");
            DictAdd(dict, "xiu", "ㄒㄧㄡ");
            DictAdd(dict, "song", "ㄙㄨㄥ");
            DictAdd(dict, "sou", "ㄙㄡ");
            DictAdd(dict, "su", "ㄙㄨ");
            DictAdd(dict, "suan", "ㄙㄨㄢ");
            DictAdd(dict, "sui", "ㄙㄨㄟ");
            DictAdd(dict, "sun", "ㄙㄨㄣ");
            DictAdd(dict, "suo", "ㄙㄨㄛ");
            DictAdd(dict, "xiong", "ㄒㄩㄥ");
            DictAdd(dict, "xu", "ㄒㄩ");
            DictAdd(dict, "xuan", "ㄒㄩㄢ");
            DictAdd(dict, "xue", "ㄒㄩㄝ");
            DictAdd(dict, "xun", "ㄒㄩㄣ");
            DictAdd(dict, "ta", "ㄊㄚ");
            DictAdd(dict, "tai", "ㄊㄞ");
            DictAdd(dict, "tan", "ㄊㄢ");
            DictAdd(dict, "tang", "ㄊㄤ");
            DictAdd(dict, "tao", "ㄊㄠ");
            DictAdd(dict, "te", "ㄊㄜ");
            DictAdd(dict, "teng", "ㄊㄥ");
            DictAdd(dict, "ti", "ㄊㄧ");
            DictAdd(dict, "tian", "ㄊㄧㄢ");
            DictAdd(dict, "tiao", "ㄊㄧㄠ");
            DictAdd(dict, "tie", "ㄊㄧㄝ");
            DictAdd(dict, "ting", "ㄊㄧㄥ");
            DictAdd(dict, "tong", "ㄊㄨㄥ");
            DictAdd(dict, "tou", "ㄊㄡ");
            DictAdd(dict, "tu", "ㄊㄨ");
            DictAdd(dict, "tuan", "ㄊㄨㄢ");
            DictAdd(dict, "tui", "ㄊㄨㄟ");
            DictAdd(dict, "tun", "ㄊㄨㄣ");
            DictAdd(dict, "tuo", "ㄊㄨㄛ");
            DictAdd(dict, "wa", "ㄨㄚ");
            DictAdd(dict, "wai", "ㄨㄞ");
            DictAdd(dict, "wan", "ㄨㄢ");
            DictAdd(dict, "wang", "ㄨㄤ");
            DictAdd(dict, "wei", "ㄨㄟ");
            DictAdd(dict, "wen", "ㄨㄣ");
            DictAdd(dict, "wo", "ㄨㄛ");
            DictAdd(dict, "weng", "ㄨㄥ");
            DictAdd(dict, "wu", "ㄨ");
            DictAdd(dict, "ya", "ㄧㄚ");
            DictAdd(dict, "yai", "ㄧㄞ");
            DictAdd(dict, "yan", "ㄧㄢ");
            DictAdd(dict, "yang", "ㄧㄤ");
            DictAdd(dict, "yao", "ㄧㄠ");
            DictAdd(dict, "ye", "ㄧㄝ");
            DictAdd(dict, "yi", "ㄧ");
            DictAdd(dict, "yin", "ㄧㄣ");
            DictAdd(dict, "ying", "ㄧㄥ");
            DictAdd(dict, "yo", "ㄧㄛ");
            DictAdd(dict, "yong", "ㄩㄥ");
            DictAdd(dict, "you", "ㄧㄡ");
            DictAdd(dict, "yu", "ㄩ");
            DictAdd(dict, "yuan", "ㄩㄢ");
            DictAdd(dict, "yue", "ㄩㄝ");
            DictAdd(dict, "yun", "ㄩㄣ");
            DictAdd(dict, "za", "ㄗㄚ");
            DictAdd(dict, "zai", "ㄗㄞ");
            DictAdd(dict, "zan", "ㄗㄢ");
            DictAdd(dict, "zang", "ㄗㄤ");
            DictAdd(dict, "zao", "ㄗㄠ");
            DictAdd(dict, "ze", "ㄗㄜ");
            DictAdd(dict, "zei", "ㄗㄟ");
            DictAdd(dict, "zen", "ㄗㄣ");
            DictAdd(dict, "zeng", "ㄗㄥ");
            DictAdd(dict, "zi", "ㄗ");
            DictAdd(dict, "zong", "ㄗㄨㄥ");
            DictAdd(dict, "zou", "ㄗㄡ");
            DictAdd(dict, "zu", "ㄗㄨ");
            DictAdd(dict, "zuan", "ㄗㄨㄢ");
            DictAdd(dict, "zui", "ㄗㄨㄟ");
            DictAdd(dict, "zun", "ㄗㄨㄣ");
            DictAdd(dict, "zuo", "ㄗㄨㄛ");
            #endregion
            Assert.AreEqual<string>("ㄚ", dict["a"]);
        }

        #region OrignDict
        protected static Dictionary<string, string> ShengMuDict = new Dictionary<string, string> { 
                    {"ㄅ","b"},
                    {"ㄆ","p"},
                    {"ㄇ","m"},
                    {"ㄈ","f"},
                    {"ㄉ","d"},
                    {"ㄊ","t"},
                    {"ㄋ","n"},
                    {"ㄌ","l"},
                    {"ㄍ","g"},
                    {"ㄎ","k"},
                    {"ㄏ","h"},
                    {"ㄐㄧ","ji"},
                    {"ㄑㄧ","qi"},
                    {"ㄒㄧ","xi"},
                    {"ㄗ","z"},
                    {"ㄘ","c"},
                    {"ㄙ","s"},
                    {"ㄓ","zh"},
                    {"ㄔ","ch"},
                    {"ㄕ","sh"},
                    {"ㄖ","r"},};
        protected static Dictionary<string, string> YunMuDict = new Dictionary<string, string> { 
                    {"ㄚ","a"},
                    {"ㄜㄝ","e"},
                    {"ㄛ","o"},
                    {"ㄧ","i"},
                    {"ㄨ","u"},
                    {"ㄩ","v"},
                    {"ㄞ","ai"},
                    {"ㄢ","an"},
                    {"ㄠ","ao"},
                    {"ㄟ","ei"},
                    {"ㄣ","en"},
                    {"ㄡ","ou"},
                    {"ㄤ","ang"},
                    {"ㄥ","eng"},
                    {"ㄧㄣ","in"},
                    {"ㄧㄥ","ing"},
                    {"ㄨㄥ","ong"},
                    {"ㄩㄥ","iong"}};
        #endregion


        [TestMethod]
        public void TestMethod_File01()
        {
            #region file data
            String fileContent = @"xiāng\xiàng
bù\fǒu
jiào\jiāo
zé\zhái
yàn\yān
yǒu\yòu
fù\fǔ
hé\hē\hè";
            String fileToTestFileName = string.Format("PinYin2ZhuYin.TestFile_{0}.txt", DateTime.Now.ToFileTime());
            File.WriteAllText(fileToTestFileName, fileContent,Encoding.UTF8);

            PinYin2ZhuYin.ConvertFile(fileToTestFileName);
            string actualResultFileName = PinYin2ZhuYin.ConvertFile(fileToTestFileName);
            String fileActualContent = 
                File.ReadAllText(actualResultFileName, Encoding.UTF8);
            Console.WriteLine("FileToTestFileName:{0}, ActualFileName:{1}", fileToTestFileName, actualResultFileName);

            string fileExpectedContent = @"ㄒㄧㄤ\ㄒㄧㄤˋ
ㄅㄨˋ\ㄈㄡˇ
ㄐㄧㄠˋ\ㄐㄧㄠ
ㄗㄜˊ\ㄓㄞˊ
ㄧㄢˋ\ㄧㄢ
ㄧㄡˇ\ㄧㄡˋ
ㄈㄨˋ\ㄈㄨˇ
ㄏㄜˊ\ㄏㄜ\ㄏㄜˋ
";
            Assert.AreEqual<string>(fileExpectedContent, fileActualContent);

            #endregion

        }

        [TestMethod]
        public void TestMethod_File02_BackSplashSpliter()
        {
            #region file data
            String fileContent = @"xiāng\xiàng
bù\fǒu
jiào\jiāo
zé\zhái
yàn\yān
yǒu\yòu
fù\fǔ
hé\hē\hè";
            String fileToTestFileName = string.Format("PinYin2ZhuYin.TestFile_{0}.txt", DateTime.Now.ToFileTime());
            File.WriteAllText(fileToTestFileName, fileContent, Encoding.UTF8);

            PinYin2ZhuYin.ConvertFile(fileToTestFileName);
            string actualResultFileName = PinYin2ZhuYin.ConvertFile(fileToTestFileName, true);
            String fileActualContent =
                File.ReadAllText(actualResultFileName, Encoding.UTF8);
            Console.WriteLine("FileToTestFileName:{0}, ActualFileName:{1}", fileToTestFileName, actualResultFileName);

            string fileExpectedContent = @"ㄒㄧㄤˉ\ㄒㄧㄤˋ
ㄅㄨˋ\ㄈㄡˇ
ㄐㄧㄠˋ\ㄐㄧㄠˉ
ㄗㄜˊ\ㄓㄞˊ
ㄧㄢˋ\ㄧㄢˉ
ㄧㄡˇ\ㄧㄡˋ
ㄈㄨˋ\ㄈㄨˇ
ㄏㄜˊ\ㄏㄜˉ\ㄏㄜˋ
";
            Assert.AreEqual<string>(fileExpectedContent, fileActualContent);

            #endregion

        }

        [TestMethod]
        public void TestMethod_File03_BlankSpace_Splitter()
        {
            #region file data
            String fileContent = @"xiāng xiàng
bù fǒu
jiào jiāo
zé zhái
yàn yān
yǒu yòu
fù fǔ
hé hē hè";
            String fileToTestFileName = string.Format("PinYin2ZhuYin.TestFile_{0}.txt", DateTime.Now.ToFileTime());
            File.WriteAllText(fileToTestFileName, fileContent, Encoding.UTF8);

            PinYin2ZhuYin.ConvertFile(fileToTestFileName);
            string actualResultFileName = PinYin2ZhuYin.ConvertFile(fileToTestFileName, true);
            String fileActualContent =
                File.ReadAllText(actualResultFileName, Encoding.UTF8);
            Console.WriteLine("FileToTestFileName:{0}, ActualFileName:{1}", fileToTestFileName, actualResultFileName);

            string fileExpectedContent = @"ㄒㄧㄤˉ ㄒㄧㄤˋ
ㄅㄨˋ ㄈㄡˇ
ㄐㄧㄠˋ ㄐㄧㄠˉ
ㄗㄜˊ ㄓㄞˊ
ㄧㄢˋ ㄧㄢˉ
ㄧㄡˇ ㄧㄡˋ
ㄈㄨˋ ㄈㄨˇ
ㄏㄜˊ ㄏㄜˉ ㄏㄜˋ
";
            Assert.AreEqual<string>(fileExpectedContent, fileActualContent);

            #endregion

        }

        [TestMethod]
        public void TestMethod_File03_BlankLine()
        {
            #region file data
            String fileContent = @"xiāng xiàng
bù fǒu
jiào jiāo
zé zhái

   
yàn yān
yǒu yòu
fù fǔ
hé hē hè";
            String fileToTestFileName = string.Format("PinYin2ZhuYin.TestFile_{0}.txt", DateTime.Now.ToFileTime());
            File.WriteAllText(fileToTestFileName, fileContent, Encoding.UTF8);

            PinYin2ZhuYin.ConvertFile(fileToTestFileName);
            string actualResultFileName = PinYin2ZhuYin.ConvertFile(fileToTestFileName, true);
            String fileActualContent =
                File.ReadAllText(actualResultFileName, Encoding.UTF8);
            Console.WriteLine("FileToTestFileName:{0}, ActualFileName:{1}", fileToTestFileName, actualResultFileName);

            string fileExpectedContent = @"ㄒㄧㄤˉ ㄒㄧㄤˋ
ㄅㄨˋ ㄈㄡˇ
ㄐㄧㄠˋ ㄐㄧㄠˉ
ㄗㄜˊ ㄓㄞˊ

   
ㄧㄢˋ ㄧㄢˉ
ㄧㄡˇ ㄧㄡˋ
ㄈㄨˋ ㄈㄨˇ
ㄏㄜˊ ㄏㄜˉ ㄏㄜˋ
";
            Assert.AreEqual<string>(fileExpectedContent, fileActualContent);

            #endregion

        }

        public void DictAdd(Dictionary<string, string> dict, string key, string value)
        {
            if (dict.ContainsKey(key))
            {
                Console.WriteLine("{0},{1}", key, value);
            }
            else
            {
                dict.Add(key, value);
            }
        }
    }
}
