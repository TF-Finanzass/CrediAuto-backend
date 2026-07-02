using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Schedules.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCreditOperationsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<CreditOperation>().HasKey(o => o.Id);
        builder.Entity<CreditOperation>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CreditOperation>().Property(o => o.ClientId).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.CarId).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.ClientName).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.CarLabel).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.FinancedAmount).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.Tea).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.PeriodicRate).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.InstallmentAmount).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.TotalPeriods).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.GracePeriods).IsRequired();

        builder.Entity<Installment>().HasKey(i => i.Id);
        builder.Entity<Installment>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Installment>().Property(i => i.Number).IsRequired();
        builder.Entity<Installment>().Property(i => i.DueDate).IsRequired();
        builder.Entity<Installment>().Property(i => i.IsGracePeriod).IsRequired();
        builder.Entity<Installment>().Property(i => i.InitialBalance).IsRequired();
        builder.Entity<Installment>().Property(i => i.Interest).IsRequired();
        builder.Entity<Installment>().Property(i => i.Amortization).IsRequired();
        builder.Entity<Installment>().Property(i => i.Insurance).IsRequired();
        builder.Entity<Installment>().Property(i => i.InstallmentAmount).IsRequired();
        builder.Entity<Installment>().Property(i => i.FinalBalance).IsRequired();

        builder.Entity<CreditOperation>()
            .HasMany(o => o.Schedule)
            .WithOne()
            .HasForeignKey(i => i.CreditOperationId);
    }
}