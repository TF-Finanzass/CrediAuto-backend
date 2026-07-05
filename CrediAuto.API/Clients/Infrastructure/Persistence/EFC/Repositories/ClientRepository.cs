using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Model.ValueObjects;
using CrediAuto.API.Clients.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Clients.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context)
    : BaseRepository<Client>(context), IClientRepository
{
    public async Task<Client?> FindByDocumentNumberAsync(string documentNumber)
        => await Context.Set<Client>().FirstOrDefaultAsync(c => c.DocumentNumber == documentNumber);

    public async Task<Client?> FindByUserIdAsync(int userId)
        => await Context.Set<Client>().FirstOrDefaultAsync(c => c.UserId == userId);
    
    public async Task<IEnumerable<Client>> FindByStatusAsync(ClientStatus status)
        => await Context.Set<Client>().Where(c => c.Status == status).ToListAsync();
}