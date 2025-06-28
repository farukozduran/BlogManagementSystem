using BlogManagementSystem.Application.DTOs.Blog;

namespace BlogManagementSystem.Application.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogDto>> GetAllAsync();
        Task<List<BlogDto>> GetMyBlogsAsync(Guid userId);
        Task<Guid> CreateAsync(BlogCreateDto dto, Guid userId);
        Task<bool> DeleteAsync(Guid blogId, Guid userId, string userRole);
    }
}
