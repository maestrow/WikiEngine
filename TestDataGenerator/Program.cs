using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGenerator.Generators;
using TestDataGenerator.Infrastructure;

namespace TestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new Files() { Count = 100};
            var sql = files.Get();
            File.WriteAllText(Helper.AssemblyDirectory + @"\File_MockData.sql", sql);
        }
    }
}
