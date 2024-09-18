using eDnevnik;
using eDnevnik.Filters;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using eDnevnik.Services.KorisnikStateMachine;
using eDnevnik.Services.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<IPredmetService, PredmetService>();
builder.Services.AddTransient<IOdjeljenjeService, OdjeljenjeService>();
builder.Services.AddTransient<IPorukeService, PorukeService>();
builder.Services.AddTransient<ICasoviService, CasoviService>();
builder.Services.AddTransient<IGodisnjiPlanProgramService, GodisnjiPlanProgramService>();
builder.Services.AddTransient<ISkolaService, SkolaService>();
builder.Services.AddTransient<IOdjeljenjePredmetService, OdjeljenjePredmetService>();
builder.Services.AddTransient<IOcjeneService, OcjeneService>();
builder.Services.AddTransient<ICasoviUceniciService, CasoviUceniciService>();

builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialPredmetState>();
builder.Services.AddTransient<ActivePredmetState>();
builder.Services.AddTransient<DraftPredmetState>();

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference{Type= ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[]{}
        }
    });
});

builder.Services.AddAutoMapper(typeof(IKorisnikService));
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eDnevnikDBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect root URL to Swagger UI
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }

    await next();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<eDnevnikDBContext>();
    var conn = dataContext.Database.GetConnectionString();
    dataContext.Database.Migrate();
}

app.Run();
