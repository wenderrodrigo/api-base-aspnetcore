using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface ICondominiumNotificationServices
    {
        Task<CondominiumNotification?> GetCondominiumNotificationByIdAsync(int? id);

        Task<CondominiumNotification?> GetCondominiumNotificationUserByIdAsync(int? id);

        Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAsync(int idCondominium);

        Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(int idCondominium, int idTypeUser, int? idUser);

        Task<List<CondominiumNotification>> GetCondominiumNotificationsAllAsync();

        Task<CondominiumNotification> RegisterCondominiumNotificationAsync(CondominiumNotificationDTO notification);

        Task<CondominiumNotification> DeleteCondominiumNotificationAsync(CondominiumNotificationDTO notification);
    }
}
