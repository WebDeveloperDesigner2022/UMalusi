using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UMelusiTrack.Services.Interfaces
{
    public interface IAuthentication
    {
        Task<bool> Authenticate(string username, string password);
    }
}
