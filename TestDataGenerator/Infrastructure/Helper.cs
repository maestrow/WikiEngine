using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestDataGenerator.Infrastructure
{
    public static class Helper
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// http://stackoverflow.com/questions/10675211/generate-random-numbers-with-no-repeat-in-c-sharp
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static List<int> UniqueRandomSequence(int minVal, int maxVal)
        {
            Random rand = new Random();
            SortedList<int, int> uniqueList = new SortedList<int, int>();
            for (int i = minVal; i <= maxVal; i++)
                uniqueList.Add(rand.Next(), i);

            return uniqueList.Values.ToList();
        }

        public static void RepeatAction(int repeatCount, Action action)
        {
            for (int i = 0; i < repeatCount; i++)
                action();
        }
    }
}
