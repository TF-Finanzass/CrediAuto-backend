using CrediAuto.API.Schedules.Domain.Model.Commands;

namespace CrediAuto.API.Schedules.Domain.Model.Aggregates;

public class Installment
{
    public int Id { get; }
    public int CreditOperationId { get; private set; }

    public int Number { get; private set; }
    public DateTime DueDate { get; private set; }
    public string PeriodType { get; private set; }
    public bool IsGracePeriod { get; private set; }

    public decimal InitialBalance { get; private set; }
    public decimal Interest { get; private set; }
    public decimal Amortization { get; private set; }
    public decimal DesgravamenInsurance { get; private set; }
    public decimal InstallmentAmount { get; private set; }
    public decimal FinalBalance { get; private set; }

    public decimal RiskInsurance { get; private set; }
    public decimal Gps { get; private set; }
    public decimal Postage { get; private set; }
    public decimal AdministrativeFee { get; private set; }

    public decimal FinalInstallmentInitialBalance { get; private set; }
    public decimal FinalInstallmentInterest { get; private set; }
    public decimal FinalInstallmentAmortization { get; private set; }
    public decimal FinalInstallmentDesgravamenInsurance { get; private set; }
    public decimal FinalInstallmentFinalBalance { get; private set; }

    public decimal TotalCashOutflow { get; private set; }

    protected Installment()
    {
        PeriodType = "N";
    }

    public Installment(InstallmentData data)
    {
        Number = data.Number;
        DueDate = data.DueDate;
        PeriodType = data.PeriodType;
        IsGracePeriod = data.IsGracePeriod;

        InitialBalance = data.InitialBalance;
        Interest = data.Interest;
        Amortization = data.Amortization;
        DesgravamenInsurance = data.DesgravamenInsurance;
        InstallmentAmount = data.InstallmentAmount;
        FinalBalance = data.FinalBalance;

        RiskInsurance = data.RiskInsurance;
        Gps = data.Gps;
        Postage = data.Postage;
        AdministrativeFee = data.AdministrativeFee;

        FinalInstallmentInitialBalance = data.FinalInstallmentInitialBalance;
        FinalInstallmentInterest = data.FinalInstallmentInterest;
        FinalInstallmentAmortization = data.FinalInstallmentAmortization;
        FinalInstallmentDesgravamenInsurance = data.FinalInstallmentDesgravamenInsurance;
        FinalInstallmentFinalBalance = data.FinalInstallmentFinalBalance;

        TotalCashOutflow = data.TotalCashOutflow;
    }
}