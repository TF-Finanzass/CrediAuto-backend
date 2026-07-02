using System;
using CrediAuto.API.Schedules.Domain.Model.Commands;

namespace CrediAuto.API.Schedules.Domain.Model.Aggregates;

public class Installment
{
    public int Id { get; }
    public int CreditOperationId { get; private set; }
    public int Number { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsGracePeriod { get; private set; }
    public decimal InitialBalance { get; private set; }
    public decimal Interest { get; private set; }
    public decimal Amortization { get; private set; }
    public decimal Insurance { get; private set; }
    public decimal InstallmentAmount { get; private set; }
    public decimal FinalBalance { get; private set; }

    protected Installment()
    {
    }

    public Installment(InstallmentData data)
    {
        Number = data.Number;
        DueDate = data.DueDate;
        IsGracePeriod = data.IsGracePeriod;
        InitialBalance = data.InitialBalance;
        Interest = data.Interest;
        Amortization = data.Amortization;
        Insurance = data.Insurance;
        InstallmentAmount = data.InstallmentAmount;
        FinalBalance = data.FinalBalance;
    }
}