using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration;

public class NotificationUserConfig : IEntityTypeConfiguration<NotificationUser>
{
    public void Configure(EntityTypeBuilder<NotificationUser> builder)
    {
        builder.ToTable("notification_user");
        builder.HasKey(nu => nu.Id); // Definição da chave primária

        builder.Property(nu => nu.IdCondominiumNotification);
        builder.Property(nu => nu.IdUser).IsRequired();
        builder.Property(nu => nu.Read).IsRequired();
        builder.Property(nu => nu.DateRead);

        // Definindo as chaves estrangeiras
        builder.HasOne(nu => nu.User)
                   .WithMany(cn => cn.NotificationUsers)
                   .HasForeignKey(nu => nu.IdUser)
                   .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(nu => nu.CondominiumNotification)
                   .WithMany(cn => cn.NotificationUsers)
                   .HasForeignKey(nu => nu.IdCondominiumNotification)
                   .OnDelete(DeleteBehavior.Restrict);
    }
}
