using CrediAuto.API.Profiles.Domain.Model.ValueObjects;

namespace CrediAuto.API.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);