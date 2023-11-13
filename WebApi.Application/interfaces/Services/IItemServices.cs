using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface IItemServices
    {
        Task<Item> GetItemByIdAsync(int id);

        Task<List<Item>> GetItemsByUserAsync(int idUser);

        Task<Item> RegisterItemAsync(ItemDTO itemDTO);

        Task<Item> ChangeItemAsync(ItemDTO itemDTO);

        Task<Item> DeleteItemAsync(ItemDTO itemDTO);
    }
}
