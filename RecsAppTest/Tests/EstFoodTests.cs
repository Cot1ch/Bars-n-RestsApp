using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecsApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecsAppTest
{
    [TestClass]
    public class EstFoodTests
    {
        [TestMethod]
        public void Test1()
        {
            EstFood estFood = new EstFood();

            Assert.IsNotNull(estFood.Ests);
            Assert.IsNotNull(estFood.Questionnaires);
            Assert.AreEqual(0, estFood.Ests.Count);
            Assert.AreEqual(0, estFood.Questionnaires.Count);
        }
    }
}