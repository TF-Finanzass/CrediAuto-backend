using CrediAuto.API.Profiles.Domain.Model.Aggregates;
using CrediAuto.API.Profiles.Domain.Model.Commands;
using CrediAuto.API.Profiles.Domain.Repositories;
using CrediAuto.API.Profiles.Domain.Services;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(
    IProfileRepository profileRepository, 
    IUnitOfWork unitOfWork) 
    : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            return null;
        }
    }
}