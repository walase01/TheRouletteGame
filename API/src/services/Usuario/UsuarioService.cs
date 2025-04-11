using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;
using services.Dto;

namespace services.Usuario
{
    public class UsuarioService : IUsuario
    {
        private readonly UserDBContext userDBContext;

        public UsuarioService(UserDBContext _userDBContext)
        {
            userDBContext = _userDBContext;
        }

        public async Task<string> AddUser(UserDto userInfo)
        {

            var userExists = await userDBContext.Usuarios.FirstOrDefaultAsync(u => u.Nombre.Equals(userInfo.User));

            if (userExists is not null)
            {
                userExists.Monto += userInfo.Amount;
                userDBContext.Update(userExists);
                userDBContext.SaveChanges();
                return $"Se agrego el monto de {userInfo.Amount} al usuario {userInfo.User}";
            }
            else
            {
                await userDBContext.AddAsync(new Persistence.Models.Usuario { Nombre = userInfo.User, Monto = userInfo.Amount });
                await userDBContext.SaveChangesAsync();
                return $"Nuevo usuario agregado {userInfo.User}";
            }
        }

    }
}
