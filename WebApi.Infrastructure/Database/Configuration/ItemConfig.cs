using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration;

public class ItemConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("item");
        //builder.Property(a => a.Id).IsUnique();
        builder.Property(a => a.Name).HasMaxLength(20).IsRequired();
        builder.Property(a => a.Description).HasMaxLength(200).IsRequired();
        builder.Property(a => a.Price).HasMaxLength(11).IsRequired();
        builder.Property(a => a.Image).HasMaxLength(200).IsRequired(false);
        builder.Property(a => a.IdUser).IsRequired();
        builder.Property(a => a.DateRegister).IsRequired();
        builder.Property(a => a.DateChange).IsRequired(false);

        //builder.Ignore(a => a.TurmaAtual);
    }
}
