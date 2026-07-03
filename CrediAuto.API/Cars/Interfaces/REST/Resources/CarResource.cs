using System;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record CarResource(
    int Id,
    string Brand,
    string Model,
    int Year,
    decimal Price,
    string Detail,
    CarStatus Status,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
);