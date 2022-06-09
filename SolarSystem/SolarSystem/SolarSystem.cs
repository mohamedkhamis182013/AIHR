using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem.SolarSystem
{
    public class SolarSystem
    {
        public List<IPlanet> Planets { get; set; }
        public readonly Sun Sun;

        public SolarSystem()
        {
            Planets.Add( 
                new TerrestialPlanet 
                { 
                    Name= "Mercury" ,
                    HasMoons = true, 
                    MoonsCount = 1 , 
                    Moons = new List<Moon> { new Moon { Name= "moon"} }
                });

            Planets.Add(
                new GasGiantsPlanet 
                {
                    Name = "Jupiter",
                    CanSustainLife = false,
                    HasMoons = true,
                    MoonsCount = 1,
                    Moons = new List<Moon> { new Moon { Name = "moon" } }
                }
                );
            Planets.Add(
                new IceGiantsPlanet
                {
                    Name = "Uranos",
                    CanSustainLife = false,
                    HasMoons = true,
                    MoonsCount = 1,
                    Moons = new List<Moon> { new Moon { Name = "moon" } }
                }
                );
            Planets.Add(
                new DwarfPlanet
                {
                    Name = "ceres",
                    CanSustainLife = false

                }
                );

        }
    }
}
