using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using services.Dto;
using services.Response;

namespace services.Usuario
{
    public class UsuarioService(UserDBContext _userDBContext, ILogger<UsuarioService> logger) : IUsuario
    {
        private readonly UserDBContext userDBContext = _userDBContext;
        private readonly ILogger<UsuarioService> _logger = logger;

        public async Task<AppResponse<string>> AddUser(UserDto userInfo)
        {

            try
            {
                var userExists = await userDBContext.Usuarios.FirstOrDefaultAsync(u => u.Nombre.Equals(userInfo.User));

                if (userExists is not null)
                {
                    userExists.Monto += userInfo.Amount;
                    userDBContext.Update(userExists);
                    userDBContext.SaveChanges();
                    return AppResponse.Success($"Se agrego el monto de {userInfo.Amount} al usuario {userInfo.User}");
                }
                else
                {
                    await userDBContext.AddAsync(new Persistence.Models.Usuario { Nombre = userInfo.User, Monto = userInfo.Amount });
                    await userDBContext.SaveChangesAsync();
                    return AppResponse.Success($"Nuevo usuario agregado {userInfo.User}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar usuario con nombre: {User}", userInfo.User);

                return AppResponse.Fail<string>(
                    "Ocurrió un error al agregar el usuario",
                    [new Error(HttpStatusCode.InternalServerError, ex.Message)]
                );
            }
        }

        public async Task<AppResponse<string>> AddUserUsingSPA(UserDto userInfo)
        {
            try
            {
                var user = new Persistence.Models.Usuario
                {
                    Nombre = userInfo.User.ToUpper().TrimEnd(),
                    Monto = userInfo.Amount
                };

                await userDBContext.Usuarios.AddAsync(user);
                await userDBContext.SaveChangesAsync();

                return AppResponse.Success("Usuario agregado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar usuario con nombre: {User}", userInfo.User);

                return AppResponse.Fail<string>(
                    "Ocurrió un error al agregar el usuario",
                    [new Error(HttpStatusCode.InternalServerError, ex.Message)]
                );
            }

        }

        public async Task<AppResponse<UserDto>> GetUserByName(string name)
        {
            name = name.ToUpper().TrimEnd();
            try
            {
                var user = await userDBContext.Usuarios
                                .Where(u => u.Nombre == name)
                                .Select(u => new UserDto
                                {
                                    User = u.Nombre,
                                    Amount = u.Monto
                                })
                                .FirstOrDefaultAsync();

                if (user == null)
                {
                    return AppResponse.Fail<UserDto>("Usuario no encontrado");
                }

                return AppResponse.Success(user, "Usuario encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar usuario por nombre: {Name}", name);

                return AppResponse.Fail<UserDto>(
                    "Ocurrió un error interno",
                    [new Error(HttpStatusCode.InternalServerError, ex.Message)]);
            }
        }
    }
}
