using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Infrastructure.Database.Configuration;

public class UserCondominiumConfig : IEntityTypeConfiguration<UserCondominium>
{
    public void Configure(EntityTypeBuilder<UserCondominium> builder)
    {
        builder.ToTable("user_condominium");
        builder.HasKey(u => u.Id); // Definição da chave primária

        builder.Property(u => u.IdCondominium).HasMaxLength(11).IsRequired();
        builder.Property(u => u.IdUser).HasMaxLength(11).IsRequired();
        builder.Property(u => u.StatusId).IsRequired();

        builder.HasMany(cn => cn.UsersResidences)
                   .WithOne(nu => nu.UserCondominium)
                   .HasForeignKey(nu => nu.UserIdCondominium);
    }
}
