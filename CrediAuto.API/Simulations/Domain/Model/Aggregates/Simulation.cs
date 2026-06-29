using CrediAuto.API.Simulations.Domain.Model.Commands;

namespace CrediAuto.API.Simulations.Domain.Model.Aggregates;

public partial class Simulation : SimulationAudit
{
    public int Id { get; }
    public decimal Monto { get; private set; }
    public decimal TasaTea { get; private set; }
    public int NumCuotas { get; private set; }
    public decimal MontoCuota { get; private set; }
    public DateTimeOffset Fecha { get; private set; }

    protected Simulation()
    {
        Monto = 0;
        TasaTea = 0;
        NumCuotas = 0;
        MontoCuota = 0;
        Fecha = DateTimeOffset.UtcNow;
    }

    public Simulation(CreateSimulationCommand command)
    {
        Monto = command.Monto;
        TasaTea = command.TasaTea;
        NumCuotas = command.NumCuotas;
        MontoCuota = command.MontoCuota;
        Fecha = command.Fecha;
    }
}