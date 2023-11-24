using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;
using WebApiServicos.Context;

namespace WebApi.Infrastructure.Repositories
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly AppDbContext _db;

        public CondominiumRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Condominium?> GetCondominiumByIdAsync(int? id)
        {
            Condominium? condominium = await _db.Condominiums
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();

            //item ??= new Item();

            return condominium;
        }

        public async Task<List<Condominium>> GetCondominiumsByUserAsync(int idUser)
        {
            return await _db.Condominiums
                .Where(x => x.UserCondominiums.Any(u=>u.IdUser == idUser))
                .ToListAsync();
        }
        public async Task<List<Condominium>> GetCondominiumsAllAsync()
        {
            return await _db.Condominiums
                .ToListAsync();
        }

        public async Task<Condominium> RegisterCondominiumAsync(Condominium condominium)
        {
            var condominiumCreated = new Condominium
            {
                Name = condominium.Name,
                Cnpj = condominium.Cnpj,
                DateRegister = DateTime.Now,
                StatusId = StatusType.Ativo,
                DateChange = DateTime.Now
            };

            await _db.Condominiums.AddAsync(condominiumCreated);
            await _db.SaveChangesAsync();
            return condominiumCreated;
        }

        public async Task<Condominium> ChangeCondominiumAsync(Condominium condominium)
        {
            var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.Condominiums.Update(condominium);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

                return condominium;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Problema ao salvar os dados no banco");
            }
        }

        public async Task<Condominium> DeleteCondominiumAsync(Condominium condominium)
        {
            _db.Condominiums.Remove(condominium);
            await _db.SaveChangesAsync();
            return condominium;
        }

    }
}
