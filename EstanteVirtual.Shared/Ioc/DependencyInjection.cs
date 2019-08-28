using Microsoft.Extensions.DependencyInjection;
using EstanteVirtual.Bo;
using EstanteVirtual.Bo.Interfaces;
using EstanteVirtual.Repository;
using EstanteVirtual.Repository.Interfaces;
using EstanteVirtual.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EstanteVirtual.Shared.Ioc
{
    public static class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            InjectBo(services);
            InjectDao(services);
        }

        public static void ConfigureDatabase(IServiceCollection services, string connection)
        {
            services.AddDbContext<BaseContext>
                (options => options.UseSqlServer(connection));
        }

        private static void InjectBo(IServiceCollection services)
        {
            services.AddScoped<IAuthorBo, AuthorBo>();
            services.AddScoped<IBookBo, BookBo>();
            services.AddScoped<ILoginBo, LoginBo>();
            services.AddScoped<IUserBookBo, UserBookBo>();
        }

        private static void InjectDao(IServiceCollection services)
        {
            services.AddScoped<IAuthorDao, AuthorDao>();
            services.AddScoped<IBookDao, BookDao>();
            services.AddScoped<IUserDao, UserDao>();
            services.AddScoped<IUserBookDao, UserBookDao>();
        }
    }
}
