using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Domain.Model.ValueObjects;

namespace CrediAuto.API.Schedules.Domain.Model.Aggregates;

public partial class CreditOperation : CreditOperationAudit
{
    public int Id { get; }
    public int ClientId { get; private set; }
    public int CarId { get; private set; }
    public string ClientName { get; private set; }
    public string CarLabel { get; private set; }
    public string Currency { get; private set; }

    public decimal LoanAmount { get; private set; }
    public decimal FinalInstallmentAmount { get; private set; }
    public decimal NetFinancedBalance { get; private set; }

    public decimal Tea { get; private set; }
    public decimal PeriodicRate { get; private set; }
    public decimal InstallmentAmount { get; private set; }
    public int TotalPeriods { get; private set; }
    public int GraceTotalPeriods { get; private set; }
    public int GracePartialPeriods { get; private set; }

    public InitialCosts InitialCosts { get; private set; }
    public PeriodicCharges PeriodicCharges { get; private set; }
    public decimal DesgravamenInsurancePercent { get; private set; }
    public decimal RiskInsurancePercent { get; private set; }

    public decimal Van { get; private set; }
    public decimal Tir { get; private set; }
    public decimal DiscountRate { get; private set; }

    public List<Installment> Schedule { get; private set; }

    protected CreditOperation()
    {
        ClientName = string.Empty;
        CarLabel = string.Empty;
        Currency = string.Empty;
        InitialCosts = new InitialCosts(0, 0, 0, 0, 0);
        PeriodicCharges = new PeriodicCharges(0, 0, 0);
        Schedule = new List<Installment>();
    }

    public CreditOperation(CreateCreditOperationCommand command)
    {
        ClientId = command.ClientId;
        CarId = command.CarId;
        ClientName = command.ClientName;
        CarLabel = command.CarLabel;
        Currency = command.Currency;

        LoanAmount = command.LoanAmount;
        FinalInstallmentAmount = command.FinalInstallmentAmount;
        NetFinancedBalance = command.NetFinancedBalance;

        Tea = command.Tea;
        PeriodicRate = command.PeriodicRate;
        InstallmentAmount = command.InstallmentAmount;
        TotalPeriods = command.TotalPeriods;
        GraceTotalPeriods = command.GraceTotalPeriods;
        GracePartialPeriods = command.GracePartialPeriods;

        InitialCosts = command.InitialCosts;
        PeriodicCharges = command.PeriodicCharges;
        DesgravamenInsurancePercent = command.DesgravamenInsurancePercent;
        RiskInsurancePercent = command.RiskInsurancePercent;

        Van = command.Van;
        Tir = command.Tir;
        DiscountRate = command.DiscountRate;

        Schedule = command.Schedule.Select(i => new Installment(i)).ToList();
    }
}