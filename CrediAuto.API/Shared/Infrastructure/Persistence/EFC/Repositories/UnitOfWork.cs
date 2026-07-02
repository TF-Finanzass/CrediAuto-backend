using System.Threading.Tasks;
using CrediAuto.API.Shared.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}