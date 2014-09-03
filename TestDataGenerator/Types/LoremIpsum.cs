using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestDataGenerator.Infrastructure;

namespace TestDataGenerator.Types
{
    public class LoremIpsum: TypeBase<string>
    {
        private string splitter = "\r\n\r\n";
        private Random rnd = new Random();

        public LoremIpsum()
        {
            init();
            ParagraphCountMin = 1;
            ParagraphCountMax = 8;
        }

        public int ParagraphCountMin { get; set; }
        public int ParagraphCountMax { get; set; }

        public override string Next()
        {
            var count = rnd.Next(ParagraphCountMin, ParagraphCountMax);
            List<string> block = Enumerable.Range(1, count).Select(i => base.Next()).ToList();
            return block.Aggregate((a, b) => string.Format("{0}{1}{2}", a, splitter, b));
        }

        private void init()
        {
            var content = File.ReadAllText(Helper.AssemblyDirectory + dataDir + @"\LoremIpsum20.txt");
            Items = content.Split(new []{splitter}, StringSplitOptions.RemoveEmptyEntries).ToList();
            Reset();
        }
    }
}
