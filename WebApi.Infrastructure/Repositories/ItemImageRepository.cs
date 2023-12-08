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
using Microsoft.AspNetCore.Hosting;

namespace WebApi.Infrastructure.Repositories
{
    public class ItemImageRepository : IItemImageRepository
    {
        private readonly AppDbContext _db;

        public ItemImageRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ItemImage?> GetItemImageByIdAsync(int? id)
        {
            ItemImage? images = await _db.ItemImages
                            .Include(item => item.Item)
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            return images;
        }

        public async Task<List<ItemImage?>> GetItemImageByItemIdAsync(int? idItem)
        {
            List<ItemImage?> images = await _db.ItemImages
                            .Include(item => item.Item)
                            .Where(item => item.Item.Id == idItem)
                            .ToListAsync();

            return images;
        }

        public async Task<List<ItemImage>> GetItemImagesAllAsync()
        {
            return await _db.ItemImages
                        .Include(item => item.Item)
                        .OrderByDescending(item => item.DateRegister)
                .ToListAsync();
        }

        public async Task<ItemImage> RegisterItemImageAsync(ItemImage image)
        {
            var itemImageCreated = new ItemImage
            {
                PathImagem = image.PathImagem,
                Item = image.Item,
                DateRegister = DateTime.Now,
            };

            await _db.ItemImages.AddAsync(itemImageCreated);
            await _db.SaveChangesAsync();
            return itemImageCreated;
        }

        public async Task<ItemImage> ChangeItemImageAsync(ItemImage image)
        {
            var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.ItemImages.Update(image);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

                return image;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Problema ao salvar os dados no banco");
            }
        }

        public async Task<ItemImage> DeleteItemImageAsync(ItemImage image)
        {
            _db.ItemImages.Remove(image);
            await _db.SaveChangesAsync();
            return image;
        }

    }
}
