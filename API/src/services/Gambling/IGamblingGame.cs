using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.Gambling.Dto;
using services.Response;

namespace services.Gambling
{
    public interface IGamblingGame
    {
        AppResponse<WinInfoByUser> Gambling(GamblingRequest request);
    }
}
