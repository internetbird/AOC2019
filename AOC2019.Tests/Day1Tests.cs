using AOC2019.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2019.Tests
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void TestSpacecraftFuelCalculator1()
        {
            int fuel = SpacecraftFuelCalculator.CalculateFuelForMassWithFuel(14);

            Assert.AreEqual(fuel, 2);
        }

        [TestMethod]
        public void TestSpacecraftFuelCalculator2()
        {
            int fuel = SpacecraftFuelCalculator.CalculateFuelForMassWithFuel(1969);

            Assert.AreEqual(fuel, 966);
        }

        [TestMethod]
        public void TestSpacecraftFuelCalculator3()
        {
            int fuel = SpacecraftFuelCalculator.CalculateFuelForMassWithFuel(100756);

            Assert.AreEqual(fuel, 50346);
        }
    }
}
