using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface ICondominiumNotificationRepository
    {
        Task<CondominiumNotification?> GetCondominiumNotificationByIdAsync(int? id);

        Task<CondominiumNotification?> GetCondominiumNotificationUserByIdAsync(int? id);

        Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAsync(int idCondominium);

        Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(int idCondominium, int idTypeUser, int? idUser);

        Task<List<CondominiumNotification>> GetCondominiumNotificationsAllAsync();

        Task<CondominiumNotification> RegisterCondominiumNotificationAsync(CondominiumNotification notification);

        Task<CondominiumNotification> DeleteCondominiumNotificationAsync(CondominiumNotification notification);
    }
}
