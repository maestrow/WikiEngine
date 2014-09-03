using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGenerator.Infrastructure;
using TestDataGenerator.Types;
using FileIO = System.IO.File;
using WikiEngine.Dal.Models;

namespace TestDataGenerator.Generators
{
    public class Files : IGenerator
    {
        private static readonly string tplDir = Helper.AssemblyDirectory + @"\Templates";
        private string main;
        private string statement;

        private CityRu cityRu = new CityRu();
        private LoremIpsum loremIpsum = new LoremIpsum();

        public Files()
        {
            init();
        }

        public int Count { get; set; }

        public string Get()
        {
            string statements = Enumerable.Range(1, Count)
                .Select(i => spawn())
                .Select(i => ToString(i))
                .Aggregate((a, b) => string.Format("{0}\r\n{1}", a, b));
            return main.Replace("{statements}", statements);
        }

        private void init()
        {
            main = FileIO.ReadAllText(tplDir + @"\main.sql");
            statement = FileIO.ReadAllText(tplDir + @"\statement.sql");
        }

        private File spawn()
        {
            return new File()
            {
                Name = cityRu.Next() + ".txt",
                File_stream = Encoding.UTF8.GetBytes(loremIpsum.Next())
            };
        }

        private string ToString(File file)
        {
            string s = statement;
            s = s.Replace("{name}", file.Name);
            s = s.Replace("{content}", Encoding.UTF8.GetString(file.File_stream));
            return s;
        }

    }
}
