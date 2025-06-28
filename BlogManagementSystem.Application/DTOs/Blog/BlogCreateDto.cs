namespace BlogManagementSystem.Application.DTOs.Blog
{
    public class BlogCreateDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
