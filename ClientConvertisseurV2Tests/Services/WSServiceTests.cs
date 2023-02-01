using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        private static WSService? service;

        public WSServiceTests()
        {
            service = new WSService("https://localhost:7038/api/");
        }

        [TestMethod()]
        public void WSServiceTest()
        {

        }


        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            var result = service.GetDevisesAsync("devises");
            Thread.Sleep(1000);


            List<Devise> listdevises = new List<Devise>();
            listdevises.AddRange(new List<Devise>
            {
                new Devise(1,"Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 120)
            });


            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(listdevises, (System.Collections.ICollection)result.Result);
        }

    }
}
