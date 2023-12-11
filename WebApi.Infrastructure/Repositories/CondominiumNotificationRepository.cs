using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;
using WebApiServicos.Context;

namespace WebApi.Infrastructure.Repositories
{
    public class CondominiumNotificationRepository : ICondominiumNotificationRepository
    {
        private readonly AppDbContext _db;

        public CondominiumNotificationRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<CondominiumNotification?> GetCondominiumNotificationByIdAsync(int? id)
        {
            CondominiumNotification? notification = await _db.CondominiumNotifications
                            .Where(n => n.Id == id)
                            .Select(n => new CondominiumNotification
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Message = n.Message,
                                DateRegister = n.DateRegister,
                                Condominium = n.Condominium,
                                CondominiumNotificationFiles = n.CondominiumNotificationFiles,
                                UserCreate = n.UserCreate,
                                IdTypeReceiving = n.IdTypeReceiving,
                            })
                            .FirstOrDefaultAsync();

            return notification;
        }

        public async Task<CondominiumNotification?> GetCondominiumNotificationUserByIdAsync(int? id)
        {
            CondominiumNotification? notification = await _db.CondominiumNotifications
                            .Where(n=>n.IdUserCreate == id)
                            .Select(n => new CondominiumNotification
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Message = n.Message,
                                DateRegister = n.DateRegister,
                                Condominium = n.Condominium,
                                NotificationUsers = n.NotificationUsers,
                                UserCreate = n.UserCreate,
                                IdTypeReceiving = n.IdTypeReceiving,
                            })
                            .FirstOrDefaultAsync();

            return notification;
        }

        public async Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAsync(int idCondominium)
        {
            List<CondominiumNotification> notification = await _db.CondominiumNotifications
                            .Where(n => n.IdCondominium == idCondominium)
                            .Select(n => new CondominiumNotification
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Message = n.Message,
                                DateRegister = n.DateRegister,
                                Condominium = n.Condominium,
                                IdTypeReceiving = n.IdTypeReceiving,
                            })
                            .ToListAsync();

            return notification;
        }

        public async Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(int idCondominium, int idTypeUser, int? idUser)
        {
            List<CondominiumNotification> notification = await _db.CondominiumNotifications
                            .Where(n => n.IdCondominium == idCondominium &&
                            ((idTypeUser == 4 && ((int)n.IdTypeReceiving == 1 || (int)n.IdTypeReceiving == 2 || (int)n.IdTypeReceiving == 3)))
                             || (idTypeUser == 5 && ((int)n.IdTypeReceiving == 1 || (int)n.IdTypeReceiving == 3))
                             || (idTypeUser == 5 && ((int)n.IdTypeReceiving == 1 || (int)n.IdTypeReceiving == 3))
                             || idTypeUser == 1 || idTypeUser == 2 || idTypeUser == 3
                             || ((int)n.IdTypeReceiving == 4 && n.NotificationUsers.Any(u=>u.User.Id == idUser))
                             )
                            .Select(n => new CondominiumNotification
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Message = n.Message,
                                DateRegister = n.DateRegister,
                                Condominium = n.Condominium,
                                IdTypeReceiving = n.IdTypeReceiving,
                            })
                            .ToListAsync();

            return notification;
        }
        
        public async Task<List<CondominiumNotification>> GetCondominiumNotificationsAllAsync()
        {
            return await _db.CondominiumNotifications
                .ToListAsync();
        }

        public async Task<CondominiumNotification> RegisterCondominiumNotificationAsync(CondominiumNotification notification)
        {

            var condominiumCreated = new CondominiumNotification
            {
                Title = notification.Title,
                Message = notification.Message,
                DateRegister = DateTime.Now,
                CondominiumNotificationFiles = notification.CondominiumNotificationFiles,
                NotificationUsers = notification.NotificationUsers,
                Condominium = notification.Condominium,
                IdTypeReceiving = notification.IdTypeReceiving,
                UserCreate = notification.UserCreate,
            };

            await _db.CondominiumNotifications.AddAsync(condominiumCreated);
            await _db.SaveChangesAsync();
            return condominiumCreated;
        }

        public async Task<CondominiumNotification> DeleteCondominiumNotificationAsync(CondominiumNotification notification)
        {
            _db.CondominiumNotifications.Remove(notification);
            await _db.SaveChangesAsync();
            return notification;
        }

    }
}
