using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }


        [TestMethod()]
        public void ActionSetConversionTest()
        {
            
        }

        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            List<Devise> devises = new List<Devise>();
            devises.AddRange(new List<Devise>
            {
                new Devise(1,"Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 120)
            });
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurEuro.LesDevises);
            CollectionAssert.AreEqual(devises, convertisseurEuro.LesDevises);
            //CollectionAssert.AreEqual()
        }
    }
}