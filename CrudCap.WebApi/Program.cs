using CrudCap.CrossCutting.SettingsApp;
using CrudCap.WebApi.Filters;
using CrudCap.WebApi.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appSettings = builder.Configuration.Get<AppSettings>() ?? new AppSettings();

builder.Services.AddSingleton(appSettings);

builder.Services.AddControllers(filter =>
{
    filter.Filters.Add<DomainValidationFilter>();
    filter.Filters.Add<GlobalExceptionsFilter>();
    filter.Filters.Add<ModelStateValidateFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseContext(appSettings);

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
