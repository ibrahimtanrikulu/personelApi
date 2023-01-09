using Application.Abstract.Services.Departman;
using Application.Abstract.Services.Personel;
using Application.Abstract.Services;
using Application.Abstract.Services.User;
using Application.Repositories;
using Application.Repositories.Departman;
using Application.Repositories.Personel;
using Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.Departman;
using Persistence.Repositories.Personel;
using Persistence.Services.Departman;
using Persistence.Services.Personel;
using Persistence.Services.Sube;
using Persistence.Services.User;
using Application.UnitOfWork;
using Persistence.UnitOFWorks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection service)
        {
            service.AddDbContext<PersonelDbContext>(
               options =>
               options.UseSqlServer("Server=localhost;Database=PersonelDb;trusted_connection=true;"));
            
            //Identity ayarları
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<PersonelDbContext>();

            //Repository
            service.AddScoped<IDepartmanRepository, DepartmanRepository>();
            service.AddScoped<IPersonelRepository, PersonelRepository>();
            service.AddScoped<ISubeRepository, SubeRepository>();
            service.AddScoped<IDepartmanRolRepository, DepartmanRolRepository>();
            service.AddScoped<IPersonelDeneyimRepository, PersonelDeneyimRepository>();
            service.AddScoped<IPersonelIzinleriRepository, PersonelIzinleriRepository>();
            service.AddScoped<IPersonelKimlikRepository, PersonelKimlikRepository>();
            service.AddScoped<IPersonelSigortaRepository, PersonelSigortaRepository>();
            service.AddScoped<IUnitOfWork, UnitOFWork>();

            //Service
            service.AddScoped<IDepartmanService, DepartmanService>();
            service.AddScoped<IDepartmanRolService, DepartmanRolService>();
            service.AddScoped<IPersonelService, PersonelService>();
            service.AddScoped<IPersonelizinService, PersonelizinService>();
            service.AddScoped<IPersonelMaasService, PersonelMaasService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ISubeService, SubeService>();

        }
    }
}
