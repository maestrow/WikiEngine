using System.Collections.Generic;

namespace WikiEngine.Dto.Page
{
    public class GetPagesOutput
    {
        public IEnumerable<PageInList> Items { get; set; }
        public int Count { get; set; }
    }
}