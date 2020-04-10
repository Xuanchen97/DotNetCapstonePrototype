using Microsoft.VisualStudio.TestTools.UnitTesting;
using WL_CapstonePrototype.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WL_CapstonePrototype.Models;

namespace WL_CapstonePrototype.Controllers.Tests
{
    [TestClass()]
    public class GarbageSetsControllerTests
    {
        [TestMethod()]
        public void DetailsAction_Returns_GarbageData()
        {
            //Arrange
            GarbageSetsController controller = new GarbageSetsController();
            string expectedType = "Recycle";

            //Act
            ViewResult actualResult = controller.Details(1) as ViewResult;
            GarbageSet actualGarbageType = actualResult.Model as GarbageSet;
            string actualType = actualGarbageType.GarbageName;

            //Assert
            Assert.AreEqual(expectedType, actualType);
        }

    }
}