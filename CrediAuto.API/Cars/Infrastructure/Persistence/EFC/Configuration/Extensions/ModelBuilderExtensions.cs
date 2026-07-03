using CrediAuto.API.Cars.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Cars.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCarsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Car>().HasKey(c => c.Id);
        builder.Entity<Car>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(c => c.Brand).IsRequired();
        builder.Entity<Car>().Property(c => c.Model).IsRequired();
        builder.Entity<Car>().Property(c => c.Year).IsRequired();
        builder.Entity<Car>().Property(c => c.Price).IsRequired();
        builder.Entity<Car>().Property(c => c.Detail);
        builder.Entity<Car>()
            .Property(c => c.Status)
            .HasConversion<string>();
    }
}