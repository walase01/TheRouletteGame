using services.RandomNumber;
using services.Usuario;
namespace roulettegame_api.ServiceLifetimes
{
    public static class Services
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRandomNumber, RandomNumberService>();
            services.AddScoped<IUsuario, UsuarioService>();
            return services;
        }
    }
}
