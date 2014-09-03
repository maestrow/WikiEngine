using System;

namespace WikiEngine.Dto.Page
{
    public class PageDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime LastEditAt { get; set; }

        public string Content { get; set; }
    }
}