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
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Application.services
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IUserCondominiumRepository _userCondominiumRepository;

        public UserServices(IUserRepository userRepository,
            ICondominiumRepository condominiumRepository,
            IUserCondominiumRepository userCondominiumRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _condominiumRepository = condominiumRepository;
            _userCondominiumRepository = userCondominiumRepository;
            _mapper = mapper;
        }


        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<List<User>> GetUsersByCondominiumAsync(int idCondominium)
        {
            return await _userRepository.GetUsersByCondominiumAsync(idCondominium);
        }

        public async Task<List<User>> GetUsersAllAsync()
        {
            return await _userRepository.GetUsersAllAsync();
        }

        public async Task<User> RegisterUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            return await _userRepository.RegisterUserAsync(user);
        }

        public async Task<User> ChangeUserAsync(UserDTO userDTO)
        {
            User userChanged = await _userRepository.GetUserByIdAsync(userDTO.Id) ?? throw new Exception("Usuário não encontrado para o Cpf informado.");

            // Atualizando os dados do usuário
            userChanged.Name = userDTO.Name;
            userChanged.CpfCnpj = userDTO.CpfCnpj;
            userChanged.Phone = userDTO.Phone;
            userChanged.Email = userDTO.Email;
            userChanged.PasswordHash = userDTO.PasswordHash;
            userChanged.StatusId = userDTO.StatusId;
            userChanged.UserType = userDTO.UserType;
            userChanged.DateChange = DateTime.Now;

            // Verifica se o usuário possui associação com condomínio
            if (userDTO.IdUserCondominium != 0)
            {
                Condominium condominiumChanged = await _condominiumRepository.GetCondominiumByIdAsync(userDTO.IdUserCondominium) ?? throw new Exception("Condomínio não encontrado.");

                // Verifica se o usuário já possui associação com esse condomínio
                bool userHasCondominium = userChanged.UserCondominiums.Any(x => x.IdCondominium == condominiumChanged.Id);

                if (!userHasCondominium)
                {
                    // Criando e associando o UserCondominium
                    UserCondominium userCondominium = new UserCondominium
                    {
                        IdCondominium = condominiumChanged.Id,
                        IdUser = userDTO.Id,
                        StatusId = userDTO.StatusId // Se necessário
                    };

                    userChanged.UserCondominiums.Add(userCondominium);
                }
            }
            else
            {
                // Remove todas as associações de condomínio do usuário
                userChanged.UserCondominiums.Clear();
            }

            // Atualizando o usuário
            return await _userRepository.ChangeUserAsync(userChanged);
        }



        public async Task<User> DeleteUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            return await _userRepository.DeleteUserAsync(user);
        }
    }
}
