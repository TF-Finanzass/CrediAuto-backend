using CrediAuto.API.Cars.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrediAuto.API.Clients.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrediAuto.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrediAuto.API.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrediAuto.API.Schedules.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrediAuto.API.Simulations.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
   
   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Profiles Context
        builder.ApplyProfilesConfiguration();
        
        // IAM Context
        builder.ApplyIamConfiguration();
        
        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();
        
        // Clients Context
        builder.ApplyClientsConfiguration();
    
        // Cars Context
        builder.ApplyCarsConfiguration();
    
        // Schedules Context
        builder.ApplyCreditOperationsConfiguration();
    
        // Simulations Context
        builder.ApplySimulationsConfiguration();
    }
}