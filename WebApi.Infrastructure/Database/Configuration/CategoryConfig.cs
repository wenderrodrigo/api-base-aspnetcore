using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");
        builder.HasKey(c => c.Id); // Definição da chave primária

        builder.Property(c => c.Name).HasMaxLength(45).IsRequired();
        builder.Property(c => c.StatusId).IsRequired().HasDefaultValue(1); // Definindo o valor padrão para StatusId
    }
}
