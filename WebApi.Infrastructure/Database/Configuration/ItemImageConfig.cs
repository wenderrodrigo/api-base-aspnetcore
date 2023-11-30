using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration;

public class ItemImageConfig : IEntityTypeConfiguration<ItemImage>
{
    public void Configure(EntityTypeBuilder<ItemImage> builder)
    {
        builder.ToTable("image_item");
        builder.HasKey(a => a.Id); // Definição da chave primária

        builder.Property(a => a.PathImagem).HasMaxLength(255).IsRequired();
        builder.Property(u => u.IdItem).HasMaxLength(11).IsRequired();

        builder.Property(a => a.DateRegister).IsRequired();
    }
}
