﻿using Core.AutoMapper.DTOs;
using Core.Intefaces.Repositories;
using Core.Intefaces.Services;
using Core.Intefaces.UnitOfWorks;
using Core.Models;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : Service<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository, ICategoryRepository categoryRepository) : base(unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<CategoryDto>> GetCategoryWithTasksByIdAsync(int categoryId)
        {
            var result = await _categoryRepository.GetCategoryWithTasksByIdAsync(categoryId);
            return Response<CategoryDto>.Success(result, 200);
        }
    }
}
