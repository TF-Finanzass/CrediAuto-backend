using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Payments.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context)
    : BaseRepository<Payment>(context), IPaymentRepository
{
    public async Task<IEnumerable<Payment>> FindByCronogramaIdAsync(int cronogramaId)
        => await Context.Set<Payment>().Where(p => p.CronogramaId == cronogramaId).ToListAsync();
}