﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Infrastructure.Database.Configuration;

public class CondominiumConfig : IEntityTypeConfiguration<Condominium>
{
    public void Configure(EntityTypeBuilder<Condominium> builder)
    {
        builder.ToTable("condominium");
        builder.HasKey(c => c.Id); // Definição da chave primária

        builder.Property(c => c.Name).HasMaxLength(255).IsRequired();
        builder.Property(c => c.Cnpj).HasMaxLength(20).IsRequired();
        builder.Property(c => c.DateRegister).IsRequired();
        builder.Property(c => c.DateChange).IsRequired(false);
        builder.Property(c => c.StatusId).IsRequired().HasDefaultValue(StatusType.Ativo); // Definindo o valor padrão para StatusId
    }
}
