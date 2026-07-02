using System.Threading.Tasks;
using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Commands;

namespace CrediAuto.API.Schedules.Domain.Services;

public interface ICreditOperationCommandService
{
    Task<CreditOperation?> Handle(CreateCreditOperationCommand command);
    Task<bool> Handle(DeleteCreditOperationCommand command);
}