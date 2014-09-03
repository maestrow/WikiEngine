using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiEngine.Dto
{
    public class GetPagesOutput
    {
        public IEnumerable<PageInList> Items { get; set; }
        public int Count { get; set; }
    }
}