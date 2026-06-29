using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Simulations.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySimulationsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Simulation>().HasKey(s => s.Id);
        builder.Entity<Simulation>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Simulation>().Property(s => s.Monto).IsRequired();
        builder.Entity<Simulation>().Property(s => s.TasaTea).IsRequired();
        builder.Entity<Simulation>().Property(s => s.NumCuotas).IsRequired();
        builder.Entity<Simulation>().Property(s => s.MontoCuota).IsRequired();
        builder.Entity<Simulation>().Property(s => s.Fecha).IsRequired();
    }
}