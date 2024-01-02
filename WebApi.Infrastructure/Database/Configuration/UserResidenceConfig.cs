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

public class UserResidenceConfig : IEntityTypeConfiguration<UserResidence>
{
    public void Configure(EntityTypeBuilder<UserResidence> builder)
    {
        builder.ToTable("user_residence");
        builder.HasKey(ur => ur.Id);

        builder.Property(ur => ur.BlockOrStreet).HasMaxLength(20).IsRequired();
        builder.Property(ur => ur.Number).HasMaxLength(11).IsRequired();
        builder.Property(u => u.UserType).IsRequired().HasDefaultValue(UserType.Inquilino);

        //builder.HasOne(ur => ur.UserCondominium)
        //    .WithMany()
        //    .HasForeignKey(ur => ur.UserIdCondominium)
        //    .OnDelete(DeleteBehavior.Restrict);

    }
}
