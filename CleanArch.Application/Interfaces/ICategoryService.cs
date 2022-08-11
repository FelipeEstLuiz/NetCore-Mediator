using CleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int? id);
        Task CreateCategoryAsync(CategoryDto category);
        Task UpdateCategoryAsync(CategoryDto category);
        Task DeleteCategoryAsync(int? id);
    }
}
