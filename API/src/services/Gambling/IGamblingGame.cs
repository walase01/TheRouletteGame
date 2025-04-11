using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.Gambling.Dto;

namespace services.Gambling
{
    public interface IGamblingGame
    {
        Task<WinInfoByUser> Gambling(GamblingRequest request);
    }
}
