using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Schedules.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySchedulesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Schedule>().HasKey(s => s.Id);
        builder.Entity<Schedule>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Schedule>().Property(s => s.OperacionId).IsRequired();
        builder.Entity<Schedule>().Property(s => s.NumCuotas).IsRequired();
        builder.Entity<Schedule>().Property(s => s.MontoTotal).IsRequired();
        builder.Entity<Schedule>().Property(s => s.Tcea).IsRequired();
    }
}