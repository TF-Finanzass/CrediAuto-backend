using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CrediAuto.API.Schedules.Domain.Model.Aggregates;

public partial class CreditOperationAudit : IEntityWithCreatedUpdatedDate
{
    [Column("Created")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("Updated")] public DateTimeOffset? UpdatedDate { get; set; }
}