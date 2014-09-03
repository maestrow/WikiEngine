using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDemo.Actions;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var action = new PagedListWithView();
            Console.WriteLine(action.GetFiles2());
            Console.ReadLine();
        }
    }
}
