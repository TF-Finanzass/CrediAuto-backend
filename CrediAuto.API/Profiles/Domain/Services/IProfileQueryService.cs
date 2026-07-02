using System.Collections.Generic;
using System.Threading.Tasks;
using CrediAuto.API.Profiles.Domain.Model.Aggregates;
using CrediAuto.API.Profiles.Domain.Model.Queries;

namespace CrediAuto.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);

    Task<Profile?> Handle(GetProfileByEmailQuery query);
    
    Task<Profile?> Handle(GetProfileByIdQuery query);
}