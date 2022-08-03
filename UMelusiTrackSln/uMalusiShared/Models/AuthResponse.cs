using System;
using System.Collections.Generic;
using System.Text;

namespace UMelusiTrackApi.Models
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public Farmer AuthenticatedFarmer { get; set; }

        public AuthResponse()
        {
            Authenticated = false;
            AuthenticatedFarmer = null;
        }
    }
}
