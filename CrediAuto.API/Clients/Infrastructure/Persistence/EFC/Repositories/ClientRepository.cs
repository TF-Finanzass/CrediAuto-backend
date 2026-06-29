using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Clients.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context)
    : BaseRepository<Client>(context), IClientRepository
{
    public async Task<Client?> FindByDniAsync(string dni)
        => await Context.Set<Client>().FirstOrDefaultAsync(c => c.Dni == dni);

    public async Task<Client?> FindByUserIdAsync(int userId)
        => await Context.Set<Client>().FirstOrDefaultAsync(c => c.UserId == userId);
}