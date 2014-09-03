using System;

namespace WikiEngine.Dto.Page
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