using eDnevnik;
using eDnevnik.Filters;
using eDnevnik.Model.Requests;
using eDnevnik.Services;
using eDnevnik.Services.DogadjajiStateMachine;
using eDnevnik.Services.IServices;
using eDnevnik.Services.KorisnikStateMachine;
using eDnevnik.Services.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

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
builder.Services.AddTransient<IDogadjajiService, DogadjajiService>();
builder.Services.AddTransient<IKorisnikDogadjajService, KorisnikDogadjajService>();
builder.Services.AddTransient<IZakljucnaOcjenaService, ZakljucnaOcjenaService>();

builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialPredmetState>();
builder.Services.AddTransient<ActivePredmetState>();
builder.Services.AddTransient<DraftPredmetState>();

builder.Services.AddTransient<BaseStateDogadjaji>();
builder.Services.AddTransient<InitialDogadjajiState>();
builder.Services.AddTransient<ActiveDogadjajiState>();
builder.Services.AddTransient<DraftDogadjajiState>();


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


string hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitMQ";
string username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
string password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
string virtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/";

var factory = new ConnectionFactory
{
    HostName = hostname,
    UserName = username,
    Password = password,
    VirtualHost = virtualHost,
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "poruka_added",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);

    var insertRequest = JsonSerializer.Deserialize<PorukaInsertRequest>(message);
    using (var scope = app.Services.CreateScope())
    {
        var porukeService = scope.ServiceProvider.GetRequiredService<IPorukeService>();

        if (insertRequest != null)
        {
            try
            {
                var result = await porukeService.Insert(insertRequest);
                if (result != null)
                {
                    Console.WriteLine("Poruka uspješno dodata.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error handling contact addition: {e.Message}");
            }
        }
    }
};

channel.BasicConsume(queue: "poruka_added", autoAck: true, consumer: consumer);


app.Run();
