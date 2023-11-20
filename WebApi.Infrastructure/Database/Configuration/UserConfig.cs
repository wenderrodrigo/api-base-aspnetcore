using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(u => u.Id); // Definição da chave primária

        builder.Property(u => u.Name).HasMaxLength(255).IsRequired();
        builder.Property(u => u.CpfCnpj).HasMaxLength(14).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Phone).HasMaxLength(11).IsRequired();
        builder.Property(u => u.PasswordHash).HasMaxLength(45).IsRequired();
        builder.Property(u => u.DateRegister).IsRequired();
        builder.Property(u => u.DateChange).IsRequired(false);
        builder.Property(u => u.StatusId).IsRequired();
        builder.Property(u => u.UserType).IsRequired().HasDefaultValue(2); // Definindo o valor padrão para TypeUser
    }
}
