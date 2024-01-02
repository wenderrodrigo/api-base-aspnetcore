using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Domain.Entities;

namespace WebApiServicos.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("portaltechdb");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Condominium> Condominiums { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCondominium> UsersCondominiums { get; set; }
    public DbSet<UserResidence> UsersResidences { get; set; }
    public DbSet<ItemImage> ItemImages { get; set; }
    public DbSet<CondominiumNotification> CondominiumNotifications { get; set; }
    public DbSet<CondominiumNotificationFile> CondominiumNotificationFiles { get; set; }
    public DbSet<NotificationUser> NotificationsUser { get; set; }
}
