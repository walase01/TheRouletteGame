using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.Dto;
using services.Response;

namespace services.Usuario
{
    public interface IUsuario
    {
        Task<AppResponse<string>> AddUser(UserDto userInfo);
        Task<AppResponse<string>> AddUserUsingSPA(UserDto userInfo);
        Task<AppResponse<UserDto>> GetUserByName(string name);
    }
}
