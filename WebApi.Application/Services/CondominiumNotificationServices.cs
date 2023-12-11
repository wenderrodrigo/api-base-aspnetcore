using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Application.services
{
    public class CondominiumNotificationServices : ICondominiumNotificationServices
    {
        private readonly IMapper _mapper;
        private readonly ICondominiumNotificationRepository _condominiumNotificationRepository;
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IUserRepository _userRepository;

        public CondominiumNotificationServices(
            ICondominiumNotificationRepository condominiumNotificationRepository,
            ICondominiumRepository condominiumRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _condominiumNotificationRepository = condominiumNotificationRepository;
            _condominiumRepository = condominiumRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<CondominiumNotification?> GetCondominiumNotificationByIdAsync(int? id)
        {
            return await _condominiumNotificationRepository.GetCondominiumNotificationByIdAsync(id);
        }

        public async Task<CondominiumNotification?> GetCondominiumNotificationUserByIdAsync(int? id)
        {
            return await _condominiumNotificationRepository.GetCondominiumNotificationUserByIdAsync(id);
        }

        public async Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAsync(int idCondominium)
        {
            return await _condominiumNotificationRepository.GetCondominiumNotificationByIdCondominumAsync(idCondominium);
        }

        public async Task<List<CondominiumNotification>> GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(int idCondominium, int idTypeUser, int? idUser)
        {
            return await _condominiumNotificationRepository.GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(idCondominium, idTypeUser, idUser);
        }

        public async Task<List<CondominiumNotification>> GetCondominiumNotificationsAllAsync()
        {
            return await _condominiumNotificationRepository.GetCondominiumNotificationsAllAsync();
        }

        public async Task<CondominiumNotification> RegisterCondominiumNotificationAsync(CondominiumNotificationDTO notificationDTO)
        {

            var condominio = await _condominiumRepository.GetCondominiumByIdAsync(notificationDTO.IdCondominium);
            var userCreate = await _userRepository.GetUserByIdAsync(notificationDTO.IdUser);

            var notification = _mapper.Map<CondominiumNotification>(notificationDTO);

            List<NotificationUser> notificationUsers = new List<NotificationUser>();

            if (notificationDTO.NotificationUsers != null)
            {
                foreach (var item in notificationDTO.NotificationUsers)
                {
                    var userReceiving = await _userRepository.GetUserByIdAsync(item.IdUser);

                    var notificationUser = new NotificationUser
                    {
                        User = userReceiving,
                        Read = false,
                    };

                    notificationUsers.Add(notificationUser);
                }
            }

            var notificationCreate = new CondominiumNotification
            {
                Title = notification.Title,
                Message = notification.Message,
                DateRegister = DateTime.Now,
                CondominiumNotificationFiles = notification.CondominiumNotificationFiles,
                Condominium = condominio,
                IdTypeReceiving = notification.IdTypeReceiving,
                NotificationUsers = notificationUsers,
                UserCreate = userCreate,
            };

            return await _condominiumNotificationRepository.RegisterCondominiumNotificationAsync(notificationCreate);
        }

        public async Task<CondominiumNotification> DeleteCondominiumNotificationAsync(CondominiumNotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<CondominiumNotification>(notificationDTO);

            return await _condominiumNotificationRepository.DeleteCondominiumNotificationAsync(notification);
        }

    }
}
