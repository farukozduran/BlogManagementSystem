using BlogManagementSystem.Application.DTOs.Category;
using BlogManagementSystem.Application.Interfaces;
using BlogManagementSystem.Domain.Entities;
using BlogManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BlogManagementSystem.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CategoryCreateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, CategoryCreateDto dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return false;
            }

            category.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
