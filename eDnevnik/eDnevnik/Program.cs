using eDnevnik.Services;
using eDnevnik.Services.IServices;
using eDnevnik.Services.KorisnikStateMachine;
using eDnevnik.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IPredmetService, PredmetService>();
builder.Services.AddTransient<IOdjeljenjeService, OdjeljenjeService>();

builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialKorisnikState>();
builder.Services.AddTransient<ActiveKorisnikState>();
builder.Services.AddTransient<DraftKorisnikState>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(IKorisnikService));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eDnevnikDBContext>(options=>options.UseSqlServer(connectionString));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
