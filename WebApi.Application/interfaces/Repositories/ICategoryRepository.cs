using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(int? id);

        Task<List<Category>> GetCategoriesAllAsync();

        Task<Category> GetCategoryByItemAsync(int idItem);

        Task<Category> RegisterCategoryAsync(Category category);

        Task<Category> ChangeCategoryAsync(Category category);

        Task<Category> DeleteCategoryAsync(Category category);
    }
}
