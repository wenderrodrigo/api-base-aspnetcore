using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface IItemImageServices
    {
        Task<ItemImage?> GetItemImageByIdAsync(int id);

        Task<List<ItemImage>> GetItemImagesAllAsync();

        //Task<string> SaveImageAsync(byte[] imageData, string fileName);

        Task<ItemImage> RegisterItemImageAsync(ItemImageDTO itemImageDTO);

        Task<ItemImage> ChangeItemImageAsync(ItemImageDTO itemImageDTO);

        Task<ItemImage> DeleteItemImageAsync(int idItem);
    }
}
