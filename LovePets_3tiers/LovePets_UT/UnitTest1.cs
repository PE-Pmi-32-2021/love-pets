

namespace LovePets_UT
{
    using System.Collections.Generic;
    using LovePets_BLL;
    using NUnit.Framework;

    public class Tests
    {
        private Dictionary<string, int> results_dict;
        private int expected;
        private LovePetsBLL bll;

        [SetUp]
        public void Setup()
        {
            results_dict = new Dictionary<string, int>(5)
            {
                { "dogs", 0 },
                { "cats", 0 },
                { "rodents", 0 },
                { "reptiles", 0 },
                { "birds", 0 }
            };

            bll = new LovePetsBLL();
        }

        [Test]
        public void TestChooseAnimal()
        {
            expected = 1;
            results_dict["dogs"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));

            expected = 2;
            results_dict["cats"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));

            expected = 3;
            results_dict["rodents"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));

            expected = 4;
            results_dict["reptiles"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));

            expected = 5;
            results_dict["birds"] = expected;
            Assert.AreEqual(expected, bll.ChosenAnimal(results_dict));
        }

        [Test]
        public void TestNegativeChooseAnimal()
        {
            expected = 4;
            results_dict["birds"] = expected;
            Assert.AreNotEqual(expected, bll.ChosenAnimal(results_dict));

            expected = 2;
            results_dict["cats"] = expected;
            Assert.AreNotEqual(expected, bll.ChosenAnimal(results_dict));
        }
    }
}