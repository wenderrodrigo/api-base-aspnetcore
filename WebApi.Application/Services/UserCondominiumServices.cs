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
    public class UserCondominiumServices : IUserCondominiumServices
    {
        private readonly IMapper _mapper;
        private readonly IUserCondominiumRepository _userCondominiumRepository;

        public UserCondominiumServices(IUserCondominiumRepository userCondominiumRepository, IMapper mapper)
        {
            _userCondominiumRepository = userCondominiumRepository;
            _mapper = mapper;
        }


        public async Task<UserCondominium?> GetUserCondominiumByIdAsync(int id)
        {
            return await _userCondominiumRepository.GetUserCondominiumByIdAsync(id);
        }

        public async Task<List<UserCondominium>> GetUsersCondominiumByCondominiumAsync(int idCondominium)
        {
            return await _userCondominiumRepository.GetUsersCondominiumByCondominiumAsync(idCondominium);
        }

        public async Task<List<UserCondominium>> GetUsersCondominiumAllAsync()
        {
            return await _userCondominiumRepository.GetUsersCondominiumAllAsync();
        }

        public async Task<UserCondominium> RegisterUserCondominiumAsync(UserCondominiumDTO userCondominiumDTO)
        {
            var userCondominium = _mapper.Map<UserCondominium>(userCondominiumDTO);

            return await _userCondominiumRepository.RegisterUserCondominiumAsync(userCondominium);
        }

        public async Task<UserCondominium> ChangeUserCondominiumAsync(UserCondominiumDTO userCondominiumDTO)
        {
            UserCondominium? userCondominiumChanged = await _userCondominiumRepository.GetUserCondominiumByIdAsync(userCondominiumDTO.Id) ?? throw new Exception("Usuário não encontrado para o Cpf informado.");

            // Atualizando os dados do usuário
            userCondominiumChanged.IdCondominium = userCondominiumDTO.IdCondominium;
            userCondominiumChanged.IdUser = userCondominiumDTO.IdUser;

            // Atualizando o usuário
            return await _userCondominiumRepository.ChangeUserCondominiumAsync(userCondominiumChanged);
        }


        public async Task<UserCondominium> DeleteUserCondominiumAsync(UserCondominiumDTO userCondominiumDTO)
        {
            var userCondominium = _mapper.Map<UserCondominium>(userCondominiumDTO);

            return await _userCondominiumRepository.DeleteUserCondominiumAsync(userCondominium);
        }
    }
}
