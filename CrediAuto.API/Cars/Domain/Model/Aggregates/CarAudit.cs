using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CrediAuto.API.Cars.Domain.Model.Aggregates;

public partial class CarAudit : IEntityWithCreatedUpdatedDate
{
    [Column("Created")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("Updated")] public DateTimeOffset? UpdatedDate { get; set; }
}