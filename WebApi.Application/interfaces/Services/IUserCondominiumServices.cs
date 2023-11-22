using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface IUserCondominiumServices
    {
        Task<UserCondominium> GetUserCondominiumByIdAsync(int id);

        Task<List<UserCondominium>> GetUsersCondominiumByCondominiumAsync(int idCondominium);

        Task<List<UserCondominium>> GetUsersCondominiumAllAsync();

        Task<UserCondominium> RegisterUserCondominiumAsync(UserCondominiumDTO userCondominiumDTO);

        Task<UserCondominium> ChangeUserCondominiumAsync(UserCondominiumDTO userCondominiumDTO);

        Task<UserCondominium> DeleteUserCondominiumAsync(UserCondominiumDTO userCondominiumDTO);
    }
}
