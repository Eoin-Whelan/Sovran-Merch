using Microsoft.OpenApi.Models;
using PaymentService.Business;
using Sovran.Logger;
using Stripe;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Stripe client initialization
StripeConfiguration.ApiKey = builder.Configuration.GetSection("StripeApiKey").Value;
StripeConfiguration.ClientId = builder.Configuration.GetSection("StripeClientId").Value;


// Dependency Injection

builder.Services.AddScoped<IPaymentAccountCreator, PaymentAccountCreator>();
//  Logger setup
builder.Services.AddScoped<ISovranLogger, SovranLogger>(x => new SovranLogger(
    "Catalog",
    builder.Configuration.GetConnectionString("mongoDb"),
    builder.Configuration.GetConnectionString("loggerSql")
    )
);

//  Add SwaggerGen
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Payment Service API",
        Description =
            "<h2>Payment Service is an API for all Payment service business logic.</h2><br>" +
            "This functionality extends to:<ul>" +
            "<li> Generating a Stripe onboarding URL(Registration flow)" +
            "<li> Mocking a test payment to an existing, verified Stripe account.",
        Contact = new OpenApiContact
        {
            Name = "Eoin Whelan (Farrell)",
            Email = "C00164354@itcarlow.ie",
        }

    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
