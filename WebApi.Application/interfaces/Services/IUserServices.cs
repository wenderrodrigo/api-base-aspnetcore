using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(int id);

        Task<List<User>> GetUsersByCondominiumAsync(int idCondominium);

        Task<List<User>> GetUsersAllAsync();

        Task<User> RegisterUserAsync(UserDTO userDTO);

        Task<User> ChangeUserAsync(UserDTO userDTO);

        Task<User> DeleteUserAsync(UserDTO userDTO);
    }
}
