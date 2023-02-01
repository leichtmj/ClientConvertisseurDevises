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
    public class ConvertisseurDeviseViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurDeviseViewModel convertisseurEuro = new ConvertisseurDeviseViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }


        [TestMethod()]
        public void ActionSetConversionTest()
        {

            ConvertisseurDeviseViewModel convertisseurEuro = new ConvertisseurDeviseViewModel();

            convertisseurEuro.Input = 50;


            Devise d = new Devise(1, "Mora", 1.08);



            convertisseurEuro.SelectedDevise = d;

            convertisseurEuro.ActionSetConversion();

            Assert.AreEqual(46.3, convertisseurEuro.Resultat);

        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_API_Non_Démarré()
        {
            //Arrange
            ConvertisseurDeviseViewModel convertisseurEuro = new ConvertisseurDeviseViewModel();
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
            Assert.IsNull(convertisseurEuro.LesDevises);
            CollectionAssert.AreNotEqual(devises, convertisseurEuro.LesDevises);
            //CollectionAssert.AreEqual()


        }



        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurDeviseViewModel convertisseurEuro = new ConvertisseurDeviseViewModel();
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