using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PY2ZY;

namespace PY2ZY
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">fullfilename to convert, isShowYinDiaoYi</param>
        static void Main(string[] args)
        {
            if (null == args ||
                args.Length > 2)
                throw new ArgumentOutOfRangeException("Please use /help to show usage.");
            if (args[0] == "/help")
            {
                Console.WriteLine(@"
Usage:
    PinYin2ZhuYin.Console.exe fileFullNameToConvert isShowYinDiaoYiOrNot
    By default, isShowYinDiaoYiOrNot is false.

Actual example:
    PinYin2ZhuYin.Console.exe fileFullNameToConvert true
    PinYin2ZhuYin.Console.exe fileFullNameToConvert false
    PinYin2ZhuYin.Console.exe fileFullNameToConvert

Help Usage:
    PinYin2ZhuYin.Console.exe /help
    File should be unicode8 encoded.
");
                return;
            }

            string fileToConvert = args[0];
            bool isShowYinDiaoYi = false;
            if (args.Length == 2)
                bool.TryParse(args[1], out isShowYinDiaoYi);

            string resultFileName = PinYin2ZhuYin.ConvertFile(fileToConvert, isShowYinDiaoYi);

        }
    }
}
