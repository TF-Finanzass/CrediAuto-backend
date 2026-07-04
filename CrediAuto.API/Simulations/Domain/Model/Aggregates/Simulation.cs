using CrediAuto.API.Schedules.Domain.Model.ValueObjects;
using CrediAuto.API.Simulations.Domain.Model.Commands;

namespace CrediAuto.API.Simulations.Domain.Model.Aggregates;

public partial class Simulation : SimulationAudit
{
    public int Id { get; }

    // --- Entrada: cliente / vehículo / condiciones del crédito ---
    public int ClientId { get; private set; }
    public int CarId { get; private set; }
    public string Currency { get; private set; }

    public decimal VehiclePrice { get; private set; }
    public decimal DownPaymentPercent { get; private set; }
    public string RateType { get; private set; }
    public decimal AnnualRate { get; private set; }
    public string Capitalization { get; private set; }
    public string PaymentFrequency { get; private set; }
    public int TermMonths { get; private set; }

    public bool UseAutoFinalInstallment { get; private set; }
    public decimal FinalInstallmentPercent { get; private set; }

    public int GraceTotalMonths { get; private set; }
    public int GracePartialMonths { get; private set; }

    public InitialCosts InitialCosts { get; private set; }
    public PeriodicCharges PeriodicCharges { get; private set; }
    public decimal DesgravamenInsurancePercent { get; private set; }
    public decimal RiskInsurancePercent { get; private set; }

    public decimal DiscountRateInput { get; private set; } // COK anual en % (entrada, ej. 10)

    // --- Salida: resultado calculado por FrenchAmortizationService ---
    public decimal DownPaymentAmount { get; private set; }
    public decimal InitialCostsTotal { get; private set; }
    public decimal LoanAmount { get; private set; }
    public decimal FinalInstallmentAmount { get; private set; }
    public decimal NetFinancedBalance { get; private set; }

    public decimal PeriodicRate { get; private set; }
    public decimal Tea { get; private set; }
    public decimal InstallmentAmount { get; private set; }
    public int TotalPeriods { get; private set; }
    public int GraceTotalPeriods { get; private set; }
    public int GracePartialPeriods { get; private set; }

    public decimal Van { get; private set; }
    public decimal Tir { get; private set; }
    public decimal DiscountRate { get; private set; } // decimal anual, ej. 0.10 (salida)

    protected Simulation()
    {
        Currency = string.Empty;
        RateType = string.Empty;
        Capitalization = string.Empty;
        PaymentFrequency = string.Empty;
        InitialCosts = new InitialCosts(0, 0, 0, 0, 0);
        PeriodicCharges = new PeriodicCharges(0, 0, 0);
    }

    public Simulation(CreateSimulationCommand command)
    {
        ClientId = command.ClientId;
        CarId = command.CarId;
        Currency = command.Currency;

        VehiclePrice = command.VehiclePrice;
        DownPaymentPercent = command.DownPaymentPercent;
        RateType = command.RateType;
        AnnualRate = command.AnnualRate;
        Capitalization = command.Capitalization;
        PaymentFrequency = command.PaymentFrequency;
        TermMonths = command.TermMonths;

        UseAutoFinalInstallment = command.UseAutoFinalInstallment;
        FinalInstallmentPercent = command.FinalInstallmentPercent;

        GraceTotalMonths = command.GraceTotalMonths;
        GracePartialMonths = command.GracePartialMonths;

        InitialCosts = command.InitialCosts;
        PeriodicCharges = command.PeriodicCharges;
        DesgravamenInsurancePercent = command.DesgravamenInsurancePercent;
        RiskInsurancePercent = command.RiskInsurancePercent;

        DiscountRateInput = command.DiscountRateInput;

        DownPaymentAmount = command.DownPaymentAmount;
        InitialCostsTotal = command.InitialCostsTotal;
        LoanAmount = command.LoanAmount;
        FinalInstallmentAmount = command.FinalInstallmentAmount;
        NetFinancedBalance = command.NetFinancedBalance;

        PeriodicRate = command.PeriodicRate;
        Tea = command.Tea;
        InstallmentAmount = command.InstallmentAmount;
        TotalPeriods = command.TotalPeriods;
        GraceTotalPeriods = command.GraceTotalPeriods;
        GracePartialPeriods = command.GracePartialPeriods;

        Van = command.Van;
        Tir = command.Tir;
        DiscountRate = command.DiscountRate;
    }
}