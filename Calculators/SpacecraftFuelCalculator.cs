using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Calculators
{
    public static class SpacecraftFuelCalculator
    {
        public static int CalculateFuelForMass(int mass)
        {
            return ((mass / 3) - 2);
        }

        public static int CalculateFuelForMassWithFuel(int mass)
        {
            int totalFuel = 0;

            int fuelForMass = CalculateFuelForMass(mass);

            do
            {
                totalFuel += fuelForMass;
                fuelForMass = CalculateFuelForMass(fuelForMass);

            } while (fuelForMass > 0);

            return totalFuel;
        }
    }
}
