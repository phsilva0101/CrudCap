using CrudCap.CrossCutting.SettingsApp;
using CrudCap.WebApi.Filters;
using CrudCap.WebApi.IoC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appSettings = builder.Configuration.Get<AppSettings>() ?? new AppSettings();

builder.Services.AddSingleton(appSettings);

builder.Services.AddControllers(filter =>
{
    filter.Filters.Add<GlobalExceptionsFilter>();
    filter.Filters.Add<ModelStateValidateFilter>();
    filter.Filters.Add<DomainValidationFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

}); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseContext(appSettings);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddCors(o => o.AddPolicy("AnyOriginPolicy", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseCors("AnyOriginPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
