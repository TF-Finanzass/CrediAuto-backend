using CrediAuto.API.Payments.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Payments.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPaymentsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.CronogramaId).IsRequired();
        builder.Entity<Payment>().Property(p => p.Numero).IsRequired();
        builder.Entity<Payment>().Property(p => p.FechaVencimiento).IsRequired();
        builder.Entity<Payment>().Property(p => p.Monto).IsRequired();
        builder.Entity<Payment>().Property(p => p.EstadoPago).IsRequired();
    }
}