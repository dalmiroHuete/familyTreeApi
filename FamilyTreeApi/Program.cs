using FamilyTreeApi.Data;
using FamilyTreeApi.Middleware;
using FamilyTreeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PeopleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<ClientIdMiddleware>();
app.MapControllers();
app.Run();
