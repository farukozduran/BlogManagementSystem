namespace BlogManagementSystem.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Navigation
        public ICollection<Blog>? Blogs { get; set; }
    }
}
