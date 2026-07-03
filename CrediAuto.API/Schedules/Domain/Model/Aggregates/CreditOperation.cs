using System.Collections.Generic;
using System.Linq;
using CrediAuto.API.Schedules.Domain.Model.Commands;

namespace CrediAuto.API.Schedules.Domain.Model.Aggregates;

public partial class CreditOperation : CreditOperationAudit
{
    public int Id { get; }
    public int ClientId { get; private set; }
    public int CarId { get; private set; }
    public string ClientName { get; private set; }
    public string CarLabel { get; private set; }
    public decimal FinancedAmount { get; private set; }
    public decimal Tea { get; private set; }
    public decimal PeriodicRate { get; private set; }
    public decimal InstallmentAmount { get; private set; }
    public int TotalPeriods { get; private set; }
    public int GracePeriods { get; private set; }
    public decimal Van { get; private set; }
    public decimal Tir { get; private set; }
    public decimal DiscountRate { get; private set; }
    public List<Installment> Schedule { get; private set; }

    protected CreditOperation()
    {
        ClientName = string.Empty;
        CarLabel = string.Empty;
        Schedule = new List<Installment>();
    }

    public CreditOperation(CreateCreditOperationCommand command)
    {
        ClientId = command.ClientId;
        CarId = command.CarId;
        ClientName = command.ClientName;
        CarLabel = command.CarLabel;
        FinancedAmount = command.FinancedAmount;
        Tea = command.Tea;
        PeriodicRate = command.PeriodicRate;
        InstallmentAmount = command.InstallmentAmount;
        TotalPeriods = command.TotalPeriods;
        GracePeriods = command.GracePeriods;
        Van = command.Van;
        Tir = command.Tir;
        DiscountRate = command.DiscountRate;
        Schedule = command.Schedule.Select(i => new Installment(i)).ToList();
    }
}