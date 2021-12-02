using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Common
{
    public class FileManager
    {
        public static string p2dir = "D:\\Programming\\adventofcode\\adventofcode2021\\AdventOfCode2021\\Solutions\\2\\Data\\";
        public static string[] Load(string filepath)
        {
            return File.ReadAllLines(filepath);
        }

        public static string[] LoadP2(string filepath)
        {
            return File.ReadAllLines(p2dir + filepath);
        }
    }
}
