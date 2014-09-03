using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiEngine.Dto
{
    public class PageInList
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime LastEditAt { get; set; }

        public string Title { get; set; }

        public string Excerpt { get; set; }
    }
}