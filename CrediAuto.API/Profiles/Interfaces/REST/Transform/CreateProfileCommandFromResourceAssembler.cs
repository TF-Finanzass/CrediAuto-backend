using CrediAuto.API.Profiles.Domain.Model.Commands;
using CrediAuto.API.Profiles.Interfaces.REST.Resources;

namespace CrediAuto.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Street,
            resource.Number,
            resource.City,
            resource.PostalCode,
            resource.Country,
            resource.UserId
        );
    }
}
