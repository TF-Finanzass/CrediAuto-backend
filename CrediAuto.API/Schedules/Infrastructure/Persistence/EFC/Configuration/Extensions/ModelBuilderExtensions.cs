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
        builder.Entity<CreditOperation>().Property(o => o.Currency).IsRequired();

        builder.Entity<CreditOperation>().Property(o => o.LoanAmount).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.FinalInstallmentAmount).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.NetFinancedBalance).IsRequired();

        builder.Entity<CreditOperation>().Property(o => o.Tea).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.PeriodicRate).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.InstallmentAmount).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.TotalPeriods).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.GraceTotalPeriods).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.GracePartialPeriods).IsRequired();

        builder.Entity<CreditOperation>().Property(o => o.DesgravamenInsurancePercent).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.RiskInsurancePercent).IsRequired();

        builder.Entity<CreditOperation>().Property(o => o.Van).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.Tir).IsRequired();
        builder.Entity<CreditOperation>().Property(o => o.DiscountRate).IsRequired();

        builder.Entity<CreditOperation>().OwnsOne(o => o.InitialCosts, ic =>
        {
            ic.Property(p => p.Notarial).IsRequired().HasColumnName("InitialCosts_Notarial");
            ic.Property(p => p.Registration).IsRequired().HasColumnName("InitialCosts_Registration");
            ic.Property(p => p.Appraisal).IsRequired().HasColumnName("InitialCosts_Appraisal");
            ic.Property(p => p.StudyFee).IsRequired().HasColumnName("InitialCosts_StudyFee");
            ic.Property(p => p.ActivationFee).IsRequired().HasColumnName("InitialCosts_ActivationFee");
        });

        builder.Entity<CreditOperation>().OwnsOne(o => o.PeriodicCharges, pc =>
        {
            pc.Property(p => p.Gps).IsRequired().HasColumnName("PeriodicCharges_Gps");
            pc.Property(p => p.Postage).IsRequired().HasColumnName("PeriodicCharges_Postage");
            pc.Property(p => p.AdministrativeFee).IsRequired().HasColumnName("PeriodicCharges_AdministrativeFee");
        });

        builder.Entity<Installment>().HasKey(i => i.Id);
        builder.Entity<Installment>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Installment>().Property(i => i.Number).IsRequired();
        builder.Entity<Installment>().Property(i => i.DueDate).IsRequired();
        builder.Entity<Installment>().Property(i => i.PeriodType).IsRequired().HasMaxLength(1);
        builder.Entity<Installment>().Property(i => i.IsGracePeriod).IsRequired();

        builder.Entity<Installment>().Property(i => i.InitialBalance).IsRequired();
        builder.Entity<Installment>().Property(i => i.Interest).IsRequired();
        builder.Entity<Installment>().Property(i => i.Amortization).IsRequired();
        builder.Entity<Installment>().Property(i => i.DesgravamenInsurance).IsRequired();
        builder.Entity<Installment>().Property(i => i.InstallmentAmount).IsRequired();
        builder.Entity<Installment>().Property(i => i.FinalBalance).IsRequired();

        builder.Entity<Installment>().Property(i => i.RiskInsurance).IsRequired();
        builder.Entity<Installment>().Property(i => i.Gps).IsRequired();
        builder.Entity<Installment>().Property(i => i.Postage).IsRequired();
        builder.Entity<Installment>().Property(i => i.AdministrativeFee).IsRequired();

        builder.Entity<Installment>().Property(i => i.FinalInstallmentInitialBalance).IsRequired();
        builder.Entity<Installment>().Property(i => i.FinalInstallmentInterest).IsRequired();
        builder.Entity<Installment>().Property(i => i.FinalInstallmentAmortization).IsRequired();
        builder.Entity<Installment>().Property(i => i.FinalInstallmentFinalBalance).IsRequired();

        builder.Entity<Installment>().Property(i => i.TotalCashOutflow).IsRequired();

        builder.Entity<CreditOperation>()
            .HasMany(o => o.Schedule)
            .WithOne()
            .HasForeignKey(i => i.CreditOperationId);
    }
}