using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int? id);

        Task<List<User>> GetUsersByCondominiumAsync(int idCondominium);

        Task<User> RegisterUserAsync(User user);

        Task<User> ChangeUserAsync(User user);

        Task<User> DeleteUserAsync(User user);
    }
}
