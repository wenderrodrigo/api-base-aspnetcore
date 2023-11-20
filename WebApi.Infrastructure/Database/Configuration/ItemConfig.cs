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
        builder.HasKey(a => a.Id); // Definição da chave primária

        builder.Property(a => a.Name).HasMaxLength(20).IsRequired();
        builder.Property(a => a.Description).HasMaxLength(200).IsRequired();
        builder.Property(a => a.Price).HasColumnType("decimal(9,2)").IsRequired(); // Ajuste para decimal

        // Ajustando o tamanho e permitindo valores nulos para Image
        builder.Property(a => a.Image).HasMaxLength(200);

        builder.Property(a => a.IdUser).IsRequired();
        builder.Property(a => a.DateRegister).IsRequired();

        // Permitindo valores nulos para DateChange
        builder.Property(a => a.DateChange).IsRequired(false);
    }
}
