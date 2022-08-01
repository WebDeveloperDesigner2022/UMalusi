using System;
using System.Collections.Generic;
using System.Text;

namespace UMelusiTrackApi.Models
{
    public class LivestockMovement
    {
        public int LivestockId { get; set; }

        public string LivestockName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
