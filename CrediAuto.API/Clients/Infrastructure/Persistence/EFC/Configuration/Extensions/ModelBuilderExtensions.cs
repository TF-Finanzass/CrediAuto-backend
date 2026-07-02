using CrediAuto.API.Clients.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Clients.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyClientsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(c => c.FullName).IsRequired();
        builder.Entity<Client>().Property(c => c.LastName).IsRequired();
        builder.Entity<Client>().Property(c => c.DocumentNumber).IsRequired();
        builder.Entity<Client>().HasIndex(c => c.DocumentNumber).IsUnique();
        builder.Entity<Client>().Property(c => c.Email).IsRequired();
        builder.Entity<Client>().Property(c => c.Phone).IsRequired();
        builder.Entity<Client>().Property(c => c.MonthlyIncome).IsRequired();
        builder.Entity<Client>().Property(c => c.UserId).IsRequired();
        builder.Entity<Client>()
            .Property(c => c.Status)
            .HasConversion<string>();
    }
}