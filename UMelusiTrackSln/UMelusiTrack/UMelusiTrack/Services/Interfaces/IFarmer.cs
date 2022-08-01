using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services.Interfaces
{
    public interface IFarmer
    {
        Task<Farmer> Farmer(string names, string surname, string username, string password, string azureMapId, int authenticationId);
    }
}
