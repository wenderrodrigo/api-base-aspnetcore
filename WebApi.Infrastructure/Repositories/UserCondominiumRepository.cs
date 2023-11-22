using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Entities;
using WebApiServicos.Context;

namespace WebApi.Infrastructure.Repositories
{
    public class UserCondominiumRepository : IUserCondominiumRepository
    {
        private readonly AppDbContext _db;

        public UserCondominiumRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserCondominium?> GetUserCondominiumByIdAsync(int? id)
        {
            UserCondominium? userCondominium = await _db.UsersCondominiums
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            //item ??= new Item();

            return userCondominium;
        }

        public async Task<List<UserCondominium>> GetUsersCondominiumByCondominiumAsync(int idCondominium)
        {
            return await _db.UsersCondominiums
                .Where(u => u.IdCondominium == idCondominium)
                .ToListAsync();
        }

        public async Task<List<UserCondominium>> GetUsersCondominiumAllAsync()
        {
            return await _db.UsersCondominiums
                .ToListAsync();
        }

        public async Task<UserCondominium> RegisterUserCondominiumAsync(UserCondominium userCondominium)
        {
            await _db.UsersCondominiums.AddAsync(userCondominium);
            await _db.SaveChangesAsync();
            return userCondominium;
        }

        public async Task<UserCondominium> ChangeUserCondominiumAsync(UserCondominium userCondominium)
        {
            var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.UsersCondominiums.Update(userCondominium);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

                return userCondominium;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Problema ao salvar os dados no banco");
            }
        }

        public async Task<UserCondominium> DeleteUserCondominiumAsync(UserCondominium userCondominium)
        {
            _db.UsersCondominiums.Remove(userCondominium);
            await _db.SaveChangesAsync();
            return userCondominium;
        }

    }
}
