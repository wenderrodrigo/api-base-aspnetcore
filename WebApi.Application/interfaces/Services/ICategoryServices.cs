using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface ICategoryServices
    {
        Task<Category> GetCategoryByIdAsync(int id);

        Task<Category?> GetCategoryByItemAsync(int idItem);

        Task<List<Category>> GetCategoriesAllAsync();

        Task<Category> RegisterCategoryAsync(CategoryDTO categoryDTO);

        Task<Category> ChangeCategoryAsync(CategoryDTO categoryDTO);

        Task<Category> DeleteCategoryAsync(CategoryDTO categoryDTO);
    }
}
