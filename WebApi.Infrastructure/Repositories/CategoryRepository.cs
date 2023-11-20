
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Entities;
using WebApiServicos.Context;

namespace WebApi.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Category?> GetCategoryByIdAsync(int? id)
        {
            Category? category = await _db.Categories
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            //category ??= new Category();

            return category;
        }

        public async Task<List<Category>> GetCategoriesAllAsync()
        {
            return await _db.Categories
                .Where(item => item.StatusId == 1)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByItemAsync(int idItem)
        {
            return await _db.Categories
                .FirstOrDefaultAsync(item => item.Items.Any(x => x.Id == idItem));
        }

        public async Task<Category> RegisterCategoryAsync(Category item)
        {
            var categoryCreated = new Category
            {
                Name = item.Name,
                StatusId = item.StatusId,
            };

            await _db.Categories.AddAsync(categoryCreated);
            await _db.SaveChangesAsync();
            return categoryCreated;
        }

        public async Task<Category> ChangeCategoryAsync(Category category)
        {
            var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return category;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Problema ao salvar os dados no banco");
            }
        }

        public async Task<Category> DeleteCategoryAsync(Category category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return category;
        }

    }
}
