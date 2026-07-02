using System;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CrediAuto.API.Clients.Domain.Model.Aggregates;

public partial class ClientAudit : IEntityWithCreatedUpdatedDate
{
    [Column("Created")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("Updated")] public DateTimeOffset? UpdatedDate { get; set; }
}