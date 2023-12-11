using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration;

public class CondominiumNotificationConfig : IEntityTypeConfiguration<CondominiumNotification>
{
    public void Configure(EntityTypeBuilder<CondominiumNotification> builder)
    {
        builder.ToTable("condominium_notification");
        builder.HasKey(cn => cn.Id);

        builder.Property(cn => cn.IdCondominium).IsRequired();
        builder.Property(cn => cn.IdTypeReceiving).IsRequired();
        builder.Property(cn => cn.Title).HasMaxLength(40).IsRequired();
        builder.Property(cn => cn.Message).IsRequired();
        builder.Property(cn => cn.IdUserCreate).IsRequired();
        builder.Property(cn => cn.DateRegister).IsRequired();

        builder.HasMany(cn => cn.NotificationUsers)
                   .WithOne(nu => nu.CondominiumNotification)
                   .HasForeignKey(nu => nu.IdCondominiumNotification);

        builder.HasMany(cn => cn.CondominiumNotificationFiles)
                   .WithOne(nu => nu.CondominiumNotification)
                   .HasForeignKey(nu => nu.IdCondominiumNotification);

    }
}
