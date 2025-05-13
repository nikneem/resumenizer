using Resumenizer.Profiles.Data.Cosmos.ExtensionMethods;
using Resumenizer.Profiles.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults()
    .AddPersonalProfileServices()
    .WithCosmosDb();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
