using BlogManagementSystem.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagementSystem.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<int> CreateAsync(CategoryCreateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, CategoryCreateDto dto);
    }
}
