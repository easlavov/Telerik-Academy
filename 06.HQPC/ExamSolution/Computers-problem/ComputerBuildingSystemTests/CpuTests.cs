using ComputerComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildingSystemTests
{
    [TestClass]
    class CpuTests
    {
        [TestMethod]
        public void SquareRootShouldReturnCorrectValue()
        {
            Cpu cpu = new Cpu(32, CpuArchitecture._32bit);
        }
    }
}
