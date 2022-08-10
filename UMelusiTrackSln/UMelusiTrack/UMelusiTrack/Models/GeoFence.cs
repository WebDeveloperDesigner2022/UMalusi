using System;
using System.Collections.Generic;
using System.Text;

namespace UMelusiTrack.Models
{
    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Properties
    {
    }

    public class GeoFence
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }



}
