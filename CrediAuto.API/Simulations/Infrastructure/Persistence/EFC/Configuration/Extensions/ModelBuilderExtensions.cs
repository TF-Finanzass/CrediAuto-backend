using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Simulations.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySimulationsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Simulation>().HasKey(s => s.Id);
        builder.Entity<Simulation>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Simulation>().Property(s => s.ClientId).IsRequired();
        builder.Entity<Simulation>().Property(s => s.CarId).IsRequired();
        builder.Entity<Simulation>().Property(s => s.Currency).IsRequired();

        builder.Entity<Simulation>().Property(s => s.VehiclePrice).IsRequired();
        builder.Entity<Simulation>().Property(s => s.DownPaymentPercent).IsRequired();
        builder.Entity<Simulation>().Property(s => s.RateType).IsRequired();
        builder.Entity<Simulation>().Property(s => s.AnnualRate).IsRequired();
        builder.Entity<Simulation>().Property(s => s.Capitalization).IsRequired();
        builder.Entity<Simulation>().Property(s => s.PaymentFrequency).IsRequired();
        builder.Entity<Simulation>().Property(s => s.TermMonths).IsRequired();

        builder.Entity<Simulation>().Property(s => s.UseAutoFinalInstallment).IsRequired();
        builder.Entity<Simulation>().Property(s => s.FinalInstallmentPercent).IsRequired();

        builder.Entity<Simulation>().Property(s => s.GraceTotalMonths).IsRequired();
        builder.Entity<Simulation>().Property(s => s.GracePartialMonths).IsRequired();

        builder.Entity<Simulation>().Property(s => s.DesgravamenInsurancePercent).IsRequired();
        builder.Entity<Simulation>().Property(s => s.RiskInsurancePercent).IsRequired();

        builder.Entity<Simulation>().Property(s => s.DiscountRateInput).IsRequired();

        builder.Entity<Simulation>().Property(s => s.DownPaymentAmount).IsRequired();
        builder.Entity<Simulation>().Property(s => s.InitialCostsTotal).IsRequired();
        builder.Entity<Simulation>().Property(s => s.LoanAmount).IsRequired();
        builder.Entity<Simulation>().Property(s => s.FinalInstallmentAmount).IsRequired();
        builder.Entity<Simulation>().Property(s => s.NetFinancedBalance).IsRequired();

        builder.Entity<Simulation>().Property(s => s.PeriodicRate).IsRequired();
        builder.Entity<Simulation>().Property(s => s.Tea).IsRequired();
        builder.Entity<Simulation>().Property(s => s.InstallmentAmount).IsRequired();
        builder.Entity<Simulation>().Property(s => s.TotalPeriods).IsRequired();
        builder.Entity<Simulation>().Property(s => s.GraceTotalPeriods).IsRequired();
        builder.Entity<Simulation>().Property(s => s.GracePartialPeriods).IsRequired();

        builder.Entity<Simulation>().Property(s => s.Van).IsRequired();
        builder.Entity<Simulation>().Property(s => s.Tir).IsRequired();
        builder.Entity<Simulation>().Property(s => s.DiscountRate).IsRequired();

        builder.Entity<Simulation>().OwnsOne(s => s.InitialCosts, ic =>
        {
            ic.Property(p => p.Notarial).IsRequired().HasColumnName("InitialCosts_Notarial");
            ic.Property(p => p.Registration).IsRequired().HasColumnName("InitialCosts_Registration");
            ic.Property(p => p.Appraisal).IsRequired().HasColumnName("InitialCosts_Appraisal");
            ic.Property(p => p.StudyFee).IsRequired().HasColumnName("InitialCosts_StudyFee");
            ic.Property(p => p.ActivationFee).IsRequired().HasColumnName("InitialCosts_ActivationFee");
        });

        builder.Entity<Simulation>().OwnsOne(s => s.PeriodicCharges, pc =>
        {
            pc.Property(p => p.Gps).IsRequired().HasColumnName("PeriodicCharges_Gps");
            pc.Property(p => p.Postage).IsRequired().HasColumnName("PeriodicCharges_Postage");
            pc.Property(p => p.AdministrativeFee).IsRequired().HasColumnName("PeriodicCharges_AdministrativeFee");
        });
    }
}