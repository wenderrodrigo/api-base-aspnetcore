using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface ICondominiumRepository
    {
        Task<Condominium> GetCondominiumByIdAsync(int? id);

        Task<List<Condominium>> GetCondominiumsByUserAsync(int idUser);

        Task<List<Condominium>> GetCondominiumsAllAsync();

        Task<Condominium> RegisterCondominiumAsync(Condominium condominium);

        Task<Condominium> ChangeCondominiumAsync(Condominium condominium);

        Task<Condominium> DeleteCondominiumAsync(Condominium condominium);
    }
}
