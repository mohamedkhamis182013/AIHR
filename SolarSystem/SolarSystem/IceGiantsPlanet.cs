using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem.SolarSystem
{
    public class IceGiantsPlanet:IPlanet,IPlanetCanHaveMoon
    {
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int DistanceFromSun { get; set; }
        public int OrbitalPeriod { get; set; }
        public int Mass { get; set; }
        public bool CanSustainLife { get; set; }
        public bool CanBeTerraformed { get; set; }
        public bool HasSatelliteMoon { get; set; }
        public bool HasMoons { get; set; }
        public int MoonsCount { get; set; }
        public List<Moon> Moons { get; set; }

    }
}
