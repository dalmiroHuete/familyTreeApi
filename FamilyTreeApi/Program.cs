using FamilyTreeApi.Data;
using FamilyTreeApi.Middleware;
using FamilyTreeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// TODO : THIS CODE IS HERE BECAUSE IS NOT A REAL APP FOR PROD REMOVE THE ALLOW_ALL AND CREATE A WHITE_LIST
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


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
app.UseCors("AllowAll");

app.UseMiddleware<ClientIdMiddleware>();

app.MapControllers();
app.Run();
