using NUnit.Framework;
using LovePets_BLL;
using System.Collections.Generic;

namespace LovePets_UT
{
    public class Tests
    {
        private Dictionary<string, int> results_dict = new Dictionary<string, int>(5);
        private int expected;
        private LovePetsBLL bll;
        [SetUp]
        public void Setup()
        {
            results_dict.Clear();
            results_dict.Add("dogs", 0);
            results_dict.Add("cats", 0);
            results_dict.Add("rodents", 0);
            results_dict.Add("reptiles", 0);
            results_dict.Add("birds", 0);
            bll = new LovePetsBLL();
        }

        [Test]
        public void Test1()
        {
            expected = 1;
            results_dict["dogs"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));
        }
        [Test]
        public void Test2()
        {
            expected = 2;
            results_dict["cats"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));
        }
        [Test]
        public void Test3()
        {
            expected = 3;
            results_dict["rodents"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));
        }
        [Test]
        public void Test4()
        {
            expected = 4;
            results_dict["reptiles"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));
        }
        [Test]
        public void Test5()
        {
            expected = 5;
            results_dict["birds"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));
        }
        [Test]
        public void Test6()
        {
            expected = 4;
            results_dict["birds"] = expected;
            Assert.AreNotEqual(expected, bll.ChosenAnimal(results_dict));
        }
        [Test]
        public void Test7()
        {
            expected = 5;
            results_dict["birds"] = expected;
            Assert.IsTrue(expected == bll.ChosenAnimal(results_dict));
        }
    }
}