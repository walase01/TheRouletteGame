using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.Dto;

namespace services.Usuario
{
    public interface IUsuario
    {
        Task<string> AddUser(UserDto userInfo);
    }
}
