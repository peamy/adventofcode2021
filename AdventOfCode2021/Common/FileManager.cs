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
        public static string basedir = "..\\..\\..\\..\\AdventOfCode2021\\";

        public static string[] Load(string filepath)
        {
            return File.ReadAllLines(filepath);
        }

        public static string[] LoadPuzzle(string file, int puzzlenr)
        {
            return File.ReadAllLines($"{basedir}Solutions\\{puzzlenr}\\Data\\{file}");
        }
    }
}
