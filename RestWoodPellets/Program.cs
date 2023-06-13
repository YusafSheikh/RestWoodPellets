using WoodPelletLib;
using RestWoodPellets.Repository;
using RestWoodPellets.Controllers;

const string policyName = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                              });
    options.AddPolicy(name: "OnlyGET",
        policy =>
        {
            policy.AllowAnyOrigin()
            .WithMethods("GET")
            .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<WoodPelletRepository>(new WoodPelletRepository()); // singleton

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

