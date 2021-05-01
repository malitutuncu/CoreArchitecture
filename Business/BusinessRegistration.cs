using Business.Concrete;
using Business.Services.UserService;
using Core.Business;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessRegistration
    {
        public static void AddBusinessConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessRegistration));
            services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudService<,,,>));

            services.AddTransient<IUserService, UserService>();

            AddDataAccessConfiguration(services);
        }

        public static void AddDataAccessConfiguration(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}