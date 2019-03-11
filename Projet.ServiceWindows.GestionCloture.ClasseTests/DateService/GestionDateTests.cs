using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionDateTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDateTest.Tests
{
    [TestClass()]
    public class GestionDateTests
    {
        [TestMethod()]
        public void GetMoisPrecedentTest()
        {
            Assert.AreEqual("02" , GestionDate.GetMoisPrecedent());
        }

        [TestMethod()]
        public void GetMoisPrecedentTest1()
        {
            Assert.AreEqual("09", GestionDate.GetMoisPrecedent(new DateTime(2019,10,20)));
        }

        [TestMethod()]
        public void GetMoisSuivantTest()
        {
            Assert.AreEqual("04", GestionDate.GetMoisSuivant());
        }

        [TestMethod()]
        public void GetMoisSuivantTest1()
        {
            Assert.AreEqual("01", GestionDate.GetMoisSuivant(new DateTime(2019 , 12,20)));
        }

        [TestMethod()]
        public void IsEntreTest()
        {
            Assert.AreEqual(true, GestionDate.IsEntre(10,20));   
        }

        [TestMethod()]
        public void IsEntreTest1()
        {
            Assert.AreEqual(true, GestionDate.IsEntre(1, 20 , new DateTime(2019,9, 21)));
        }

        [TestMethod()]
        public void FormatNumberTest()
        {
            Assert.AreEqual("05", GestionDate.FormatNumber(5));
        }
    }
}