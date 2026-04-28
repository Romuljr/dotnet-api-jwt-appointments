using API02.Infra.Contexts;
using API02.Infra.Contracts;
using API02.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API02.Presentation.Configurations
{
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework
            (IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("API02BD")));

            service.AddTransient<IUsuarioRepository, UsuarioRepository>();
            service.AddTransient<ICompromissoRepository, CompromissoRepository>();
        }
    }
}
