using BlogManagementSystem.Application.DTOs.Blog;
using BlogManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("my")]
        [Authorize]
        public async Task<IActionResult> GetMyBlogs()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var blogs = await _blogService.GetMyBlogsAsync(Guid.Parse(userId!));
            return Ok(blogs);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BlogCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var blogId = await _blogService.CreateAsync(dto, Guid.Parse(userId!));
            return Ok(new { blogId });
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            var success = await _blogService.DeleteAsync(id, Guid.Parse(userId!), role!);
            if (!success)
            {
                return Forbid("Bu işlemi gerçekleştirme yetkiniz yok!");
            }

            return NoContent();
        }
    }
}
