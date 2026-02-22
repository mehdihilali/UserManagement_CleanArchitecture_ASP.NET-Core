using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Application.Features.Users.Commands;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Infrastructure.Persistence;
using UserManagementSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly)
);

// Controllers
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- AJOUT : Initialisation de la base de données ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        // Crée la base et les tables si elles n'existent pas
        context.Database.EnsureCreated();
        Console.WriteLine("Base de données et tables vérifiées/créées avec succès.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors de l'initialisation de la DB : {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optionnel : Commenter cette ligne si tu as toujours l'alerte "Failed to determine https port"
// app.UseHttpsRedirection(); 

app.UseCors("AllowAll");
app.MapControllers();

app.Run();

