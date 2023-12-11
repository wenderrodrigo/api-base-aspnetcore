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

public class CondominiumNotificationFileConfig : IEntityTypeConfiguration<CondominiumNotificationFile>
{
    public void Configure(EntityTypeBuilder<CondominiumNotificationFile> builder)
    {
        builder.ToTable("condominium_notification_file");
        builder.HasKey(cnf => cnf.Id);

        builder.Property(cnf => cnf.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(cnf => cnf.IdCondominiumNotification)
            .HasColumnName("id_condominium_notification")
            .IsRequired();

        builder.Property(cnf => cnf.PathFile)
            .HasColumnName("path_file")
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(nu => nu.CondominiumNotification)
                   .WithMany(cn => cn.CondominiumNotificationFiles)
                   .HasForeignKey(nu => nu.IdCondominiumNotification);

    }
}
