using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(int? id);

        Task<List<Item>> GetItemsByUserAsync(int idUser);

        Task<Item> RegisterItemAsync(Item item);

        Task<Item> ChangeItemAsync(Item item);

        Task<Item> DeleteItemAsync(Item item);
    }
}
