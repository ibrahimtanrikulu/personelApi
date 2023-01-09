using Application.Abstract;
using Application.Abstract.Storage;
using Infrastructure.Services;
using Infrastructure.Storage.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection service)
        {
            service.AddScoped<IToken, TokenService>();

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        //gelen tokende hangi değerlere bakıcagını söylüyoruz
                        ValidateAudience = true, //nedir:hangi sitelerin kullanıcagını belirleriz
                        ValidateIssuer = true,  //tokeni kimin dağıttıgını ifade eder
                        ValidateLifetime = true,    //oluışturulan token değerinin süresini kontrol etsinmi
                        ValidateIssuerSigningKey = true, //üretilin token değerinin uygulamaya ait oldugunu ifade eden değer

                        ValidAudience = "www.deneme.com",
                        ValidIssuer = "www.test.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ibrahim tanrıkulu")),
                        //LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.Now : false,

                        NameClaimType = ClaimTypes.Name //jwt üzerinde name karsılık gelen değeri name propertisinden elde edebliriz
                    };
                });
        }
        public static void AddStorage(this IServiceCollection services)
        {
            //services.AddScoped<IStorage, T>();
            services.AddScoped<IStorage, LocalStorage>();
        }
    }
}
