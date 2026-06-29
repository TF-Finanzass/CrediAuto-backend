using CrediAuto.API.Cars.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Cars.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCarsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Car>().HasKey(c => c.Id);
        builder.Entity<Car>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(c => c.Marca).IsRequired();
        builder.Entity<Car>().Property(c => c.Modelo).IsRequired();
        builder.Entity<Car>().Property(c => c.Anio).IsRequired();
        builder.Entity<Car>().Property(c => c.Precio).IsRequired();
        builder.Entity<Car>().Property(c => c.EstadoAprobacion).IsRequired();
    }
}