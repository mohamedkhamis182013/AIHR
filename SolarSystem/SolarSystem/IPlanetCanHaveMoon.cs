using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem.SolarSystem
{
    public interface IPlanetCanHaveMoon
    {
        public bool HasMoons { get; set; }
        public int MoonsCount { get; set; }
        public List<Moon> Moons{get; set;}
    }
}
