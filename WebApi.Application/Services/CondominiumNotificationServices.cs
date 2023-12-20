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
        private readonly string _imageStoragePath = "C:\\Program Files\\VertrigoServ\\www\\YourFileStorageDirectory\\"; // Caminho onde as imagens serão armazenadas

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
            var userCreate = await _userRepository.GetUserByIdAsync(notificationDTO.IdUserCreate
                );

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
                CondominiumNotificationFiles = new List<CondominiumNotificationFile>(),
                Condominium = condominio,
                IdTypeReceiving = notification.IdTypeReceiving,
                NotificationUsers = notificationUsers,
                UserCreate = userCreate,
            };

            foreach (var item in notificationDTO.CondominiumNotificationFiles)
            {
                CondominiumNotificationFile condominiumNotificationFile = new CondominiumNotificationFile();
                condominiumNotificationFile.PathFile = item.NameFile;
                notificationCreate.CondominiumNotificationFiles.Add(condominiumNotificationFile);
            }

            CondominiumNotification notificationRetorno = await _condominiumNotificationRepository.RegisterCondominiumNotificationAsync(notificationCreate);

            foreach (var item in notificationDTO.CondominiumNotificationFiles)
            {
                if (notificationRetorno.CondominiumNotificationFiles.Count > 0)
                    item.IdCondominiumNotification = notificationRetorno.CondominiumNotificationFiles.FirstOrDefault().IdCondominiumNotification;
            }

            if (notificationDTO.CondominiumNotificationFiles != null)
                await SaveFilesAsync(notificationDTO.CondominiumNotificationFiles, condominio.Id);

            return notificationRetorno;
        }

        public async Task<CondominiumNotification> DeleteCondominiumNotificationAsync(CondominiumNotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<CondominiumNotification>(notificationDTO);

            return await _condominiumNotificationRepository.DeleteCondominiumNotificationAsync(notification);
        }

        public async Task<string> SaveFileAsync(string fileStoragePath, dynamic fileData, int condominioId, int idItem, string fileName)
        {
            string imagePath = string.Empty;
            try
            {
                byte[] fileConvertData = null;

                // Verifica se fileData já é um array de bytes
                if (fileData is byte[])
                {
                    fileConvertData = (byte[])fileData;
                }
                else
                {
                    // Se não for um array de bytes, tenta converter de base64 para bytes
                    try
                    {
                        fileConvertData = Convert.FromBase64String(fileData.ToString());
                    }
                    catch (FormatException ex)
                    {
                        // Lidere com exceção se a conversão falhar
                        Console.WriteLine($"Erro na conversão de base64 para bytes: {ex.Message}");
                        // Aqui você pode decidir como lidar com a falha na conversão, talvez fornecer um valor padrão para fileConvertData
                    }
                }

                if (fileConvertData != null)
                {
                    string condominiumPath = Path.Combine(fileStoragePath, condominioId.ToString());
                    string itemPath = Path.Combine(condominiumPath, idItem.ToString());
                    imagePath = Path.Combine(itemPath, fileName);

                    // Verifica se o diretório de armazenamento de imagens existe, senão, cria-o
                    if (!Directory.Exists(condominiumPath))
                    {
                        Directory.CreateDirectory(condominiumPath);
                    }

                    // Verifica se o diretório de armazenamento de imagens existe, senão, cria-o
                    if (!Directory.Exists(itemPath))
                    {
                        Directory.CreateDirectory(itemPath);
                    }

                    // Salva a imagem no disco
                    try
                    {
                        await File.WriteAllBytesAsync(imagePath, fileConvertData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao salvar a imagem: {ex.Message}");
                    }
                }


                return imagePath; // Retorna o caminho onde a imagem foi armazenada
            }
            catch (Exception ex)
            {
                // Trate o erro de maneira apropriada para o seu caso
                throw new Exception("Erro ao salvar o arquivo", ex);
            }
        }

        private async Task<List<string>> SaveFilesAsync(List<CondominiumNotificationFileDTO> files, int condominioId = 0)
        {
            List<string> filePaths = new List<string>();

            foreach (var file in files)
            {
                // Salvar a imagem em um local e obter o caminho, por exemplo:
                var filePath = await SaveFileAsync(_imageStoragePath, file.PathFile, condominioId, file.IdCondominiumNotification, file.NameFile);
                //// Onde ImageStorageService é um serviço que lida com o armazenamento das imagens

                //// Adicionar o caminho da imagem à lista de caminhos
                filePaths.Add(filePath);
            }

            return filePaths;
        }

    }
}
