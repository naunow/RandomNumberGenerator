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
        public void TestCreateNumber()
        {
            NumberGenerator random = new NumberGenerator();

            Assert.IsTrue(random.number is int);
        }

        [TestMethod()]
        public void TestSumRandomNumbers()
        {
            RandomNumber augend = NumberGenerator.Augend();
            RandomNumber addend = NumberGenerator.Addend();

            RandomNumber sum = augend.Plus(addend);

            // フィールドに直接アクセスしているのはちょっといやな匂いがする……
            Assert.AreEqual(sum.Result, augend.Augend + addend.Addend);
        }
    }
}

namespace RandomNumberGeneratorTests.Controllers
{
    class HomeControllerTests
    {
    }
}
