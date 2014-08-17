using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerComponents;

namespace ComputerBuildingSystemTests
{
    [TestClass]
    public class LaptopBatteryTests
    {
        [TestMethod]
        public void TestIfBatteryIsCreatedWithHalfCharge()
        {
            IBattery battery = new LaptopBattery();
            Assert.AreEqual(50, battery.PowerLeft);
        }

        [TestMethod]
        public void TestIfBatteryIsDischargedCompletely()
        {
            IBattery battery = new LaptopBattery();
            battery.Charge(-100);
            Assert.AreEqual(0, battery.PowerLeft);
        }

        [TestMethod]
        public void TestIfBatteryIsNotOvercharged()
        {
            IBattery battery = new LaptopBattery();
            battery.Charge(100);
            Assert.AreEqual(100, battery.PowerLeft);
        }
    }
}
