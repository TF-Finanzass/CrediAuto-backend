using System.Threading.Tasks;
using CrediAuto.API.Profiles.Domain.Model.Aggregates;
using CrediAuto.API.Profiles.Domain.Model.Commands;

namespace CrediAuto.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}