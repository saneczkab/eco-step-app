using System.Text;
using EcoStepBackend.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace EcoStepBackend;

internal static class Program
{
    private static WebApplicationBuilder _builder = null!;

    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.File("Logs/survey_access.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        _builder = WebApplication.CreateBuilder(args);
        _builder.Host.UseSerilog();

        BuildAuth();
        BuildServices();
        RunApp();
    }

    private static void BuildAuth()
    {
        var configuration = _builder.Configuration;

        _builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var jwtKey = configuration["Jwt:Key"];
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
        });
    }

    private static void BuildServices()
    {
        _builder.Services.AddDbContext<AppDbContext>();

        // TODO: Убрать AllowAnyOrigin
        _builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        _builder.Services.AddControllers();
        _builder.Services.AddEndpointsApiExplorer();
        BuildSwagger();
        BuildValidators();
    }

    private static void BuildSwagger()
    {
        _builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcoStep API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    private static void BuildValidators()
    {
        _builder.Services.AddScoped<ISurveyDataValidator<FoodData>, FoodDataValidator>();
        _builder.Services.AddScoped<ISurveyDataValidator<ResourceData>, ResourceDataValidator>();
        _builder.Services.AddScoped<ISurveyDataValidator<TransportData>, TransportDataValidator>();
        _builder.Services.AddScoped<ISurveyDataValidator<WasteData>, WasteDataValidator>();
    }

    private static void RunApp()
    {
        _builder.Services.AddSwaggerGen();
        _builder.WebHost.ConfigureKestrel(options => { options.ListenAnyIP(5000); });

        var app = _builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors();

        RunFrontend(app);

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    private static void RunFrontend(WebApplication app)
    {
        var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Front");

        app.UseDefaultFiles(new DefaultFilesOptions
        {
            FileProvider = new PhysicalFileProvider(staticFilesPath),
            DefaultFileNames = new List<string> { "main.html" }
        });

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(staticFilesPath),
            RequestPath = ""
        });

    }
}
