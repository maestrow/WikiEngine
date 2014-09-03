using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGenerator.Infrastructure
{
    public static class IntExtensions
    {
        public static void RepeatAction(this int i, Action action)
        {
            Helper.RepeatAction(i, action);
        }
    }
}
