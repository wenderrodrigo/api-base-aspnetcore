using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface IUserCondominiumRepository
    {
        Task<UserCondominium> GetUserCondominiumByIdAsync(int? id);

        Task<List<UserCondominium>> GetUsersCondominiumByCondominiumAsync(int idCondominium);

        Task<List<UserCondominium>> GetUsersCondominiumAllAsync();

        Task<UserCondominium> RegisterUserCondominiumAsync(UserCondominium userCondominium);

        Task<UserCondominium> ChangeUserCondominiumAsync(UserCondominium userCondominium);

        Task<UserCondominium> DeleteUserCondominiumAsync(UserCondominium userCondominium);
    }
}
