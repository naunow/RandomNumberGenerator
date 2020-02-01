using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomNumberGenerator.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumberGenerator.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void TestSumNumber()
        {
            RandomNumber randomNumber = new RandomNumber
            {
                Augend = 2,
                Addend = 3,
            };

            Assert.AreEqual(5, randomNumber.Result);

        }

    }
}

namespace RandomNumberGeneratorTests.Controllers
{
    class HomeControllerTests
    {
    }
}
