using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using WikiEngine.Dal.Models;

namespace ConsoleDemo.Actions
{
    public class PagedListWithView
    {
        WikiEngineContext db = new WikiEngineContext();
        public string GetFiles()
        {
            IEnumerable<File> q = db.Set<File>().OrderBy(f => f.Name);

            q = q.ToPagedList(3, 10);
            
            return q
                .Select(f => string.Format("{0}", f.Name))
                .Aggregate((a, b) => string.Format("{0}{1}{2}", a, Environment.NewLine, b));
        }

        public string GetFiles2()
        {
            IEnumerable<File> q = db.Set<File>().Select(f => f);

            q = q.OrderBy(file => file.Name);

            q = q.ToPagedList(3, 10);

            return q
                .Select(f => string.Format("{0}", f.Name))
                .Aggregate((a, b) => string.Format("{0}{1}{2}", a, Environment.NewLine, b));
        }
    }
}
