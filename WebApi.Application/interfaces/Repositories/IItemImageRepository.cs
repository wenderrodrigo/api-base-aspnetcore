using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface IItemImageRepository
    {
        Task<ItemImage> GetItemImageByIdAsync(int? id);

        Task<List<ItemImage>> GetItemImagesAllAsync();

        Task<ItemImage> RegisterItemImageAsync(ItemImage item);

        Task<ItemImage> ChangeItemImageAsync(ItemImage item);

        Task<ItemImage> DeleteItemImageAsync(ItemImage item);
    }
}
