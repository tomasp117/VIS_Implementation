using handball_IS.Gateways;
using handball_IS.Modules;
using handball_IS.Modules.Actors.super;
using handball_IS.Services;
using handball_IS.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

var secretKey = builder.Configuration["JWT_SECRET"];
if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
{
    throw new InvalidOperationException("JWT_SECRET must be at least 32 characters long.");
}
var key = Encoding.UTF8.GetBytes(secretKey);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddSingleton<DatabaseConnectionFactory>();

builder.Services.AddScoped<TournamentTableGateway>();
builder.Services.AddScoped<TournamentModule>();
builder.Services.AddScoped<PersonTableGateway>();
builder.Services.AddScoped<PersonModule>();
builder.Services.AddScoped<CategoryModule>();
builder.Services.AddScoped<CategoryTableGateway>();
builder.Services.AddScoped<GroupModule>();
builder.Services.AddScoped<GroupTableGateway>();
builder.Services.AddScoped<TeamModule>();
builder.Services.AddScoped<TeamTableGateway>();
builder.Services.AddScoped<PlayerModule>();
builder.Services.AddScoped<PlayerTableGateway>();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // Validace Issuer (pro pokroèilejší scénáøe)
        ValidateAudience = false, // Validace Audience
        ValidateLifetime = true, // Kontrola exspirace tokenu
        ValidateIssuerSigningKey = true, // Kontrola podpisu
        IssuerSigningKey = new SymmetricSecurityKey(key) // Klíè pro ovìøení
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.WebHost.ConfigureKestrel(option =>
{
    option.ListenLocalhost(5000); // HTTP
    option.ListenLocalhost(5001, listenOptions => listenOptions.UseHttps()); // HTTPS
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();
app.Run();
