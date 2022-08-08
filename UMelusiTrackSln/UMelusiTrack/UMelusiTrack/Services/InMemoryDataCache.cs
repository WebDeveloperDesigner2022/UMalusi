using System;
using System.Collections.Generic;
using System.Text;
using UMelusiTrack.Services.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services
{
    public static class InMemoryDataCache 
    {
        public static bool IsAuthenticated { get; set; }
        public static Farmer AuthenticatedFarmer { get; set; }
    }
}
