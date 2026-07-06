using CrediAuto.API.IAM.Application.Internal.CommandServices;
using CrediAuto.API.IAM.Application.Internal.OutboundServices;
using CrediAuto.API.IAM.Application.Internal.QueryServices;
using CrediAuto.API.IAM.Domain.Repositories;
using CrediAuto.API.IAM.Domain.Services;
using CrediAuto.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using CrediAuto.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using CrediAuto.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using CrediAuto.API.IAM.Infrastructure.Tokens.JWT.Services;
using CrediAuto.API.IAM.Interfaces.ACL;
using CrediAuto.API.IAM.Interfaces.ACL.Services;
using CrediAuto.API.Profiles.Application.Internal.CommandServices;
using CrediAuto.API.Profiles.Application.Internal.QueryServices;
using CrediAuto.API.Profiles.Domain.Repositories;
using CrediAuto.API.Profiles.Domain.Services;
using CrediAuto.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using CrediAuto.API.Shared.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CrediAuto.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Cortex.Mediator.Commands;
using CrediAuto.API.Cars.Application.Internal.CommandServices;
using CrediAuto.API.Cars.Application.Internal.QueryServices;
using CrediAuto.API.Cars.Domain.Repositories;
using CrediAuto.API.Cars.Domain.Services;
using CrediAuto.API.Cars.Infrastructure.Persistence.EFC.Repositories;
using CrediAuto.API.Clients.Application.Internal.CommandServices;
using CrediAuto.API.Clients.Application.Internal.QueryServices;
using CrediAuto.API.Clients.Domain.Repositories;
using CrediAuto.API.Clients.Domain.Services;
using CrediAuto.API.Clients.Infrastructure.Persistence.EFC.Repositories;
using CrediAuto.API.Simulations.Application.Internal.CommandServices;
using CrediAuto.API.Simulations.Application.Internal.QueryServices;
using CrediAuto.API.Simulations.Domain.Repositories;
using CrediAuto.API.Simulations.Domain.Services;
using CrediAuto.API.Simulations.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Cortex.Mediator.DependencyInjection;
using CrediAuto.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using CrediAuto.API.Schedules.Application.Internal.CommandServices;
using CrediAuto.API.Schedules.Application.Internal.QueryServices;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Schedules.Domain.Services;
using CrediAuto.API.Schedules.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "CrediAuto.API",
            Version = "v1",
            Description = "Backend CrediAuto API",
            TermsOfService = new Uri("https://crediauto.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "ACME Studios",
                Email = "contact@acme.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    options.EnableAnnotations();
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profile
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

// Cars
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarCommandService, CarCommandService>();
builder.Services.AddScoped<ICarQueryService, CarQueryService>();

// Clients
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientCommandService, ClientCommandService>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();

// IAM
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Schedules
builder.Services.AddScoped<ICreditOperationRepository, CreditOperationRepository>();
builder.Services.AddScoped<ICreditOperationCommandService, CreditOperationCommandService>();
builder.Services.AddScoped<ICreditOperationQueryService, CreditOperationQueryService>();

// Simulations
builder.Services.AddScoped<ISimulationRepository, SimulationRepository>();
builder.Services.AddScoped<ISimulationCommandService, SimulationCommandService>();
builder.Services.AddScoped<ISimulationQueryService, SimulationQueryService>();

builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)], configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    });


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();