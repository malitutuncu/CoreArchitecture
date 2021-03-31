using Business.Services.KullaniciService;
using Core.Business;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessRegistration
    {
        public static void AddBusinessConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessRegistration));
            services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));

            services.AddTransient<IKullaniciService, KullaniciService>();

            AddDataAccessConfiguration(services);
        }

        public static void AddDataAccessConfiguration(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddTransient<IKullaniciRepository, KullaniciRepository>();
        }
    }
}