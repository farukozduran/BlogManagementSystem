namespace BlogManagementSystem.Application.DTOs.Blog
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string AuthorEmail { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
