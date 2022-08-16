using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int? id)
        {
            Category category = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task CreateCategoryAsync(CategoryDto category)
        {
            Category categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task UpdateCategoryAsync(CategoryDto category)
        {
            Category categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task DeleteCategoryAsync(int? id)
        {
            Category category = _categoryRepository.GetCategoryByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(category);
        }
    }
}
