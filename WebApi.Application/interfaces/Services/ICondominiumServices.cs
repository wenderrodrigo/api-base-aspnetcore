using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Application.Interfaces
{
    public interface ICondominiumServices
    {
        Task<Condominium?> GetCondominiumByIdAsync(int id);

        Task<List<Condominium>> GetCondominiumsByUserAsync(int idUser);

        Task<Condominium> RegisterCondominiumAsync(CondominiumDTO condominiumDTO);

        Task<Condominium> ChangeCondominiumAsync(CondominiumDTO condominiumDTO);

        Task<Condominium> DeleteCondominiumAsync(CondominiumDTO condominiumDTO);
    }
}
