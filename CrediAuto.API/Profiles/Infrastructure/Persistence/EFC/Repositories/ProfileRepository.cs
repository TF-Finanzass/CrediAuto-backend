using System.Linq;
using System.Threading.Tasks;
using CrediAuto.API.Profiles.Domain.Model.Aggregates;
using CrediAuto.API.Profiles.Domain.Model.ValueObjects;
using CrediAuto.API.Profiles.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CrediAuto.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) 
    : BaseRepository<Profile>(context), IProfileRepository
{
    public async Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().FirstOrDefault(p => p.Email == email);
    }
}