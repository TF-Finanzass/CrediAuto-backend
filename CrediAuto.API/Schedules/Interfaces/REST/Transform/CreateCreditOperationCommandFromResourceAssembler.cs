using System.Linq;
using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;

namespace CrediAuto.API.Schedules.Interfaces.REST.Transform;

public static class CreateCreditOperationCommandFromResourceAssembler
{
    public static CreateCreditOperationCommand ToCommandFromResource(CreateCreditOperationResource resource) =>
        new CreateCreditOperationCommand(
            resource.ClientId,
            resource.CarId,
            resource.ClientName,
            resource.CarLabel,
            resource.FinancedAmount,
            resource.Tea,
            resource.PeriodicRate,
            resource.InstallmentAmount,
            resource.TotalPeriods,
            resource.GracePeriods,
            resource.Van,
            resource.Tir,
            resource.DiscountRate,
            resource.Schedule.Select(i => new InstallmentData(
                i.Number,
                i.DueDate,
                i.IsGracePeriod,
                i.InitialBalance,
                i.Interest,
                i.Amortization,
                i.Insurance,
                i.InstallmentAmount,
                i.FinalBalance
            )).ToList()
        );
}