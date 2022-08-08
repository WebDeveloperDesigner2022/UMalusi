using System;
using System.Collections.Generic;
using System.Text;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services.Interfaces
{
    public interface IDataCache
    {
        bool IsAuthenticated { get; set; }

        Farmer AuthenticatedFarmer { get; set; }
    }
}
