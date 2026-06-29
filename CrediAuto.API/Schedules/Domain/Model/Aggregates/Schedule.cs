using CrediAuto.API.Schedules.Domain.Model.Commands;

namespace CrediAuto.API.Schedules.Domain.Model.Aggregates;

public partial class Schedule : ScheduleAudit
{
    public int Id { get; }
    public int OperacionId { get; private set; }
    public int NumCuotas { get; private set; }
    public decimal MontoTotal { get; private set; }
    public decimal Tcea { get; private set; }

    protected Schedule()
    {
        OperacionId = 0;
        NumCuotas = 0;
        MontoTotal = 0;
        Tcea = 0;
    }

    public Schedule(CreateScheduleCommand command)
    {
        OperacionId = command.OperacionId;
        NumCuotas = command.NumCuotas;
        MontoTotal = command.MontoTotal;
        Tcea = command.Tcea;
    }
}