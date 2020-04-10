using Microsoft.VisualStudio.TestTools.UnitTesting;
using WL_CapstonePrototype.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL_CapstonePrototype.Models;
using System.Web.Mvc;

namespace WL_CapstonePrototype.Controllers.Tests
{
    [TestClass()]
    public class ScanSetsControllerTests
    {
        [TestMethod()]
        public void Scan_Garbage()
        {
            //Arrange
            ScanSetsController controller = new ScanSetsController();
            ScanSet scan = new ScanSet()
            {
                 ScanTime = "20/03/2020",
                GarbageId = 1,
                AddressId = 1,
                UsersId = 6


            };
            string expectedViewName = "Index";
            //Act   
            RedirectToRouteResult result = controller.Create(scan) as RedirectToRouteResult;
            string actualViewName = result.RouteValues["Action"].ToString();

            //Assert
            Assert.AreEqual(expectedViewName, actualViewName);
        }
    }
}