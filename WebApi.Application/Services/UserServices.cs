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
        //private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)//, IMapper mapper)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
        }


        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<List<User>> GetUsersByCondominiumAsync(int idCondominium)
        {
            return await _userRepository.GetUsersByCondominiumAsync(idCondominium);
        }

        public async Task<User> RegisterUserAsync(UserDTO userDTO)
        {
            var user = new User();// _mapper.Map<User>(userDTO);

            return await _userRepository.RegisterUserAsync(user);
        }

        public async Task<User> ChangeUserAsync(UserDTO userDTO)
        {
            User? userChanged = await _userRepository.GetUserByIdAsync(userDTO.Id) ?? throw new Exception("Usuário não encontrado para o Cpf informado.");

            userChanged.Name = userDTO.Name;
            userChanged.CpfCnpj = userDTO.CpfCnpj;
            userChanged.Phone = userDTO.Phone;
            userChanged.Email = userDTO.Email;
            userChanged.StatusId = userDTO.StatusId;
            userChanged.DateChange = DateTime.Now;

            return await _userRepository.ChangeUserAsync(userChanged);
        }

        public async Task<User> DeleteUserAsync(UserDTO userDTO)
        {
            var user = new User();//_mapper.Map<User>(userDTO);

            return await _userRepository.DeleteUserAsync(user);
        }
    }
}
