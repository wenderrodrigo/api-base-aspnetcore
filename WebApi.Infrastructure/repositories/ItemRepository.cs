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
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Item?> GetItemByIdAsync(int? id)
        {
            Item? item = await _db.Items
                            .Where(item => item.Id == id)
                            .Select(item => new Item
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Price = item.Price,
                                Category = item.Category,
                                User = item.User,
                                ItemImages = item.ItemImages
                            })
                            .FirstOrDefaultAsync();

            //item ??= new Item();

            return item;
        }

        public async Task<List<Item>> GetItemsByUserAsync(int idUser)
        {
            return await _db.Items
                        .Where(item => item.IdUser == idUser)
                        .OrderByDescending(item => item.DateRegister)
                        .Select(item => new Item
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description,
                            Price = item.Price,
                            Category = item.Category,
                            User = item.User,
                            ItemImages = item.ItemImages
                        })
                        .ToListAsync();
        }

        public async Task<List<Item>> GetItemsByCategoryAsync(int idCategory)
        {
            return await _db.Items
                        .Where(item => item.Category.Id == idCategory)
                        .OrderByDescending(item => item.DateRegister)
                        .Select(item => new Item
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description,
                            Price = item.Price,
                            Category = item.Category,
                            User = item.User,
                            ItemImages = item.ItemImages
                        })
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsAllAsync()
        {
            var items = await _db.Items
                .OrderByDescending(item => item.DateRegister)
                .Select(item => new Item
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Category = item.Category,
                    User = item.User,
                    ItemImages = item.ItemImages
                })
                .ToListAsync();

            return items;
        }


        public async Task<Item> RegisterItemAsync(Item item)
        {
            var itemCreated = new Item
            {
                Name = item.Name,
                Description = item.Description,
                Category = item.Category,
                User = item.User,
                Price = item.Price,
                ItemImages = item.ItemImages,
                DateRegister = DateTime.Now,
                DateChange = DateTime.Now
            };
            

            await _db.Items.AddAsync(itemCreated);
            await _db.SaveChangesAsync();
            return itemCreated;
        }


        public async Task<Item> ChangeItemAsync(Item item)
        {
            var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.Items.Update(item);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

                return item;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Problema ao salvar os dados no banco");
            }
        }

        public async Task<Item> DeleteItemAsync(Item item)
        {
            _db.Items.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }

    }
}
