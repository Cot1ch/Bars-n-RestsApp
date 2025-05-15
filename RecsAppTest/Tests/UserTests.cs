using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecsApp;
using System;
using System.Collections.Generic;

namespace RecsAppTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Test10()
        {
            User user = new User();

            Assert.AreNotEqual(Guid.Empty, user.user_Id);
            Assert.IsNotNull(user.Favourite);
            Assert.IsInstanceOfType(user.Favourite, typeof(List<Establishment>));
            Assert.IsNotNull(user.Hidden);
            Assert.IsInstanceOfType(user.Hidden, typeof(List<Establishment>));
            Assert.IsNull(user.Questionnaire);
        }



        [TestMethod]
        public void Test11()
        {
            User user = new User();
            Establishment establishment = new Establishment { Name = "Semen1" };

            user.Favourite.Add(establishment);

            Assert.AreEqual(1, user.Favourite.Count);
        }

        [TestMethod]
        public void Test12()
        {
            User user = new User();
            Establishment establishment = new Establishment { Name = "Semen2" };

            user.Hidden.Add(establishment);

            Assert.AreEqual(1, user.Hidden.Count);
        }

        [TestMethod]
        public void Test13()
        {
            User user = new User();
            string validName = "Semen3";
            
            user.name = validName;

            Assert.AreEqual(validName, user.name);
        }

        [TestMethod]
        public void Test14()
        {
            User user = new User();
            string validUsername = "Semen4";
            
            user.username = validUsername;
            
            Assert.AreEqual(validUsername, user.username);
        }

        [TestMethod]
        public void Test15()
        {
            User user = new User();
            string validPasswordHash = "Semen5";
            
            user.password_hash = validPasswordHash;
            
            Assert.AreEqual(validPasswordHash, user.password_hash);
        }
    }
}