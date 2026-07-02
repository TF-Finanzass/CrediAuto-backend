using System.Threading.Tasks;
using CrediAuto.API.Profiles.Domain.Model.Aggregates;
using CrediAuto.API.Profiles.Domain.Model.ValueObjects;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}