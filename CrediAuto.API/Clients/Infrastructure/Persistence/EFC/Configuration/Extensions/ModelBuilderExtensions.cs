using CrediAuto.API.Clients.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Clients.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyClientsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(c => c.Nombre).IsRequired();
        builder.Entity<Client>().Property(c => c.Dni).IsRequired();
        builder.Entity<Client>().HasIndex(c => c.Dni).IsUnique();
        builder.Entity<Client>().Property(c => c.Email).IsRequired();
        builder.Entity<Client>().Property(c => c.Telefono).IsRequired();
        builder.Entity<Client>().Property(c => c.UserId).IsRequired();
    }
}