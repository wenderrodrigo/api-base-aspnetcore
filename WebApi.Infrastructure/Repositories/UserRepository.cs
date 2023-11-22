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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetUserByIdAsync(int? id)
        {
            User? user = await _db.Users
                                .Where(item => item.Id == id)
                                .Include(item => item.UserCondominiums)
                                    .ThenInclude(uc => uc.Condominium) // Incluir o Condominium relacionado com o UserCondominium
                                .FirstOrDefaultAsync();

            return user;
        }


        public async Task<List<User>> GetUsersByCondominiumAsync(int idCondominium)
        {
            return await _db.Users
                .Where(u => u.UserCondominiums.Any(c => c.IdCondominium == idCondominium))
                .Include(item => item.UserCondominiums)
                    .ThenInclude(uc => uc.Condominium) // Incluir o Condominium relacionado com o UserCondominium
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersAllAsync()
        {
            return await _db.Users
                .Include(item => item.UserCondominiums)
                    .ThenInclude(uc => uc.Condominium) // Incluir o Condominium relacionado com o UserCondominium
                .ToListAsync();
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            var userCreated = new User
            {
                Name = user.Name,
                CpfCnpj = user.CpfCnpj,
                UserType = user.UserType,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Phone = user.Phone,
                UserCondominiums = user.UserCondominiums,
                StatusId = user.StatusId,
                DateRegister = DateTime.Now,
                DateChange = DateTime.Now
            };

            await _db.Users.AddAsync(userCreated);
            await _db.SaveChangesAsync();
            return userCreated;
        }

        public async Task<User> ChangeUserAsync(User user)
        {
            var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();

                return user;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Problema ao salvar os dados no banco");
            }
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }

    }
}
