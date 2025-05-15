using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecsApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecsAppTest
{
    [TestClass]
    public class EstTypeTests
    {
        [TestMethod]
        public void Test2()
        {
            Questionnaire questionnaire = new Questionnaire();

            Assert.IsNotNull(questionnaire.Est_Types);
            Assert.IsNotNull(questionnaire.Est_Categories);
            Assert.IsNotNull(questionnaire.Est_Foods);
            Assert.IsNotNull(questionnaire.Est_Average);
            Assert.AreEqual(0, questionnaire.Est_Types.Count);
            Assert.AreEqual(0, questionnaire.Est_Categories.Count);
            Assert.AreEqual(0, questionnaire.Est_Foods.Count);
            Assert.AreEqual(0, questionnaire.Est_Average.Count);
        }

        [TestMethod]
        public void Test3()
        {
            Questionnaire questionnaire = new Questionnaire();
            var testId = Guid.NewGuid();

            questionnaire.user_Id = testId;

            Assert.AreEqual(testId, questionnaire.user_Id);
        }

        [TestMethod]
        public void Test4()
        {
            Questionnaire questionnaire = new Questionnaire();

            Assert.IsNotNull(questionnaire.Est_Types);
            Assert.IsNotNull(questionnaire.Est_Categories);
            Assert.IsNotNull(questionnaire.Est_Foods);
            Assert.IsNotNull(questionnaire.Est_Average);
            Assert.AreEqual(0, questionnaire.Est_Types.Count);
            Assert.AreEqual(0, questionnaire.Est_Categories.Count);
            Assert.AreEqual(0, questionnaire.Est_Foods.Count);
            Assert.AreEqual(0, questionnaire.Est_Average.Count);
        }
    }
}