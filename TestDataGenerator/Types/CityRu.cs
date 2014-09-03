using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestDataGenerator.Infrastructure;

namespace TestDataGenerator.Types
{
    public class CityRu: TypeBase<string>
    {
        public CityRu()
        {
            init();
        }
        
        private void init()
        {
            var content = File.ReadAllText(Helper.AssemblyDirectory + dataDir + @"\Cities-Ru.txt");
            Items = content.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Reset();
        }
    }
}
