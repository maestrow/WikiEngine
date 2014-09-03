using System;

namespace WikiEngine.Dal.Models
{
    public class Page
    {
        public Page()
        {
            LastEditAt = CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime LastEditAt { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}