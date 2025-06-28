using AutoMapper;
using BlogManagementSystem.Application.DTOs.Blog;
using BlogManagementSystem.Application.Interfaces;
using BlogManagementSystem.Domain.Entities;
using BlogManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagementSystem.Infrastructure.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(BlogCreateDto dto, Guid userId)
        {
            var blog = new Blog
            {
                Title = dto.Title,
                Content = dto.Content,
                CategoryId = dto.CategoryId,
                UserId = userId
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog.Id;
        }

        public async Task<List<BlogDto>> GetAllAsync()
        {
            var blogs = await _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.User)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                AuthorEmail = b.User?.Email ?? "",
                CategoryName = b.Category?.Name ?? "",
                CreatedAt = b.CreatedAt
            }).ToList();
        }

        public async Task<List<BlogDto>> GetMyBlogsAsync(Guid userId)
        {
            var blogs = await _context.Blogs
                .Where(b => b.UserId == userId)
                .Include(b => b.Category)
                .ToListAsync();

            return blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                AuthorEmail = "",
                CategoryName = b.Category?.Name ?? "",
                CreatedAt = b.CreatedAt
            }).ToList();
        }

        public async Task<bool> DeleteAsync(Guid blogId, Guid userId, string userRole)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if(blog == null)
            {
                return false;
            }

            if(userRole != "Admin" && blog.UserId != userId)
            {
                return false;
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
