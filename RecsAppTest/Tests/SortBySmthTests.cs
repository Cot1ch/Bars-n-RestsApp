using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecsApp;
using System;
using System.Collections.Generic;

namespace RecsAppTest
{
    [TestClass]
    public class SortBySmthTests
    {
        private Establishment establishment1;
        private Establishment establishment2;
        private Establishment establishment3;

        [TestInitialize]
        public void Setup()
        {
            establishment1 = new Establishment
            {
                Name = "Cafe A",
                Type = new EstType { Title = "Cafe" },
                Rating = 4.5,
                CountVisits = 100,
                Average = new EstAverageCheck { Title = "$$" },
                Categories = new List<EstCategory>(),
                Foods = new List<EstFood>()
            };

            establishment2 = new Establishment
            {
                Name = "Restaurant B",
                Type = new EstType { Title = "Restaurant" },
                Rating = 4.8,
                CountVisits = 200,
                Average = new EstAverageCheck { Title = "$$$" },
                Categories = new List<EstCategory>(),
                Foods = new List<EstFood>()
            };

            establishment3 = new Establishment
            {
                Name = "Bar C",
                Type = new EstType { Title = "Bar" },
                Rating = 3.9,
                CountVisits = 50,
                Average = new EstAverageCheck { Title = "$" },
                Categories = new List<EstCategory>(),
                Foods = new List<EstFood>()
            };
        }

        [TestMethod]
        public void Test5()
        {
            SortBySmth comparer = new SortBySmth { SortMode = "name" };

            Assert.IsTrue(comparer.Compare(establishment1, establishment2) < 0);
            Assert.IsTrue(comparer.Compare(establishment2, establishment3) > 0); 
            Assert.AreEqual(0, comparer.Compare(establishment1, establishment1));
        }

        [TestMethod]
        public void Test6()
        {
            SortBySmth comparer = new SortBySmth { SortMode = "type" };

            Assert.IsTrue(comparer.Compare(establishment1, establishment2) < 0);
            Assert.IsTrue(comparer.Compare(establishment2, establishment3) > 0);
        }

        [TestMethod]
        public void Test7()
        {
            SortBySmth comparer = new SortBySmth { SortMode = "rating" };

            Assert.IsTrue(comparer.Compare(establishment1, establishment2) > 0);
            Assert.IsTrue(comparer.Compare(establishment2, establishment3) < 0);
        }

        [TestMethod]
        public void Test8()
        {
            SortBySmth comparer = new SortBySmth { SortMode = "visits" };

            Assert.IsTrue(comparer.Compare(establishment1, establishment2) > 0);
            Assert.IsTrue(comparer.Compare(establishment3, establishment1) < 0);
        }

        [TestMethod]
        public void Test9()
        {
            SortBySmth comparer = new SortBySmth { SortMode = "" };

            Assert.IsTrue(comparer.Compare(establishment1, establishment2) > 0);
            Assert.IsTrue(comparer.Compare(establishment3, establishment1) < 0);
        }
    }
}