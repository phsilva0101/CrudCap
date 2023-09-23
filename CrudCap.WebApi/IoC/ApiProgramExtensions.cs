using CrudCap.CrossCutting.SettingsApp;
using CrudCap.Domain.Interfaces;
using CrudCap.Domain.Interfaces.Base;
using CrudCap.Domain.Interfaces.Propertie;
using CrudCap.Persistence;
using CrudCap.Persistence.Repositories.Base;
using CrudCap.Persistence.Repositories.Propertie;
using CrudCap.Services.Interfaces;
using CrudCap.Services.Interfaces.Propertie;
using CrudCap.Services.Services;
using CrudCap.Services.Services.Propertie;
using Microsoft.EntityFrameworkCore;

namespace CrudCap.WebApi.IoC
{
    public static class ApiProgramExtensions
    {
        public static void AddDatabaseContext(this IServiceCollection services, AppSettings settings)
        {
            if (settings.ConnectionStrings.SQL != null)
                services.AddDbContext<CrudCapContext>(options => options.UseSqlServer(settings.ConnectionStrings.SQL));
            else if (settings.ConnectionStrings.MySQL != null)
                services.AddDbContext<CrudCapContext>(options => options.UseMySql(settings.ConnectionStrings.MySQL, MySqlServerVersion.AutoDetect(settings.ConnectionStrings.MySQL)));
            else if (settings.ConnectionStrings.PostgreSQL != null)
                services.AddDbContext<CrudCapContext>(options => options.UseNpgsql(settings.ConnectionStrings.PostgreSQL));
            else if (settings.ConnectionStrings.Oracle != null)
                services.AddDbContext<CrudCapContext>(options => options.UseOracle(settings.ConnectionStrings.Oracle));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRealStateRepository, RealEstateRepository>();
            //services.AddScoped<IAddressRepository, AddressRepository>();
            //services.AddScoped<ICityRepository, CityRepository>();
            //services.AddScoped<ICountryRepository, CountryRepository>();
            //services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IPropertiesRepository, PropertiesRepository>();
            //services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRealEstateService, RealEstateService>();
            //services.AddScoped<IAddressService, AddressService>();
            //services.AddScoped<ICityService, CityService>();
            //services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<IStateService, StateService>();
            services.AddTransient<IPropertiesService, PropertiesService>();
            //services.AddScoped<IPropertyTypeService, PropertyTypeService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDomainValidationService, DomainValidationService>();
        }


    }
}
