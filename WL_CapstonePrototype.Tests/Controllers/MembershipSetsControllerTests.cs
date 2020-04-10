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
    public class MembershipSetsControllerTests
    {

        [TestMethod()]
        public void DetailsAction_Returns_MembershipData()
        {
            //Arrange
            MembershipSetsController controller = new MembershipSetsController();
            string expectedType = "Gold";

            //Act
            ViewResult actualResult = controller.Details(1) as ViewResult;
            MembershipSet actualMembershio = actualResult.Model as MembershipSet;
            string actualType = actualMembershio.MembershipType;

            //Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod()]
        public void Add_New_User_Test()
        {
            //Arrange
            MembershipSetsController controller = new MembershipSetsController();
            MembershipSet membership = new MembershipSet()
            {
                MembershipFee = "100",
                MembershipType = "VVIP"


            };
            string expectedViewName = "Index";
            //Act   
            RedirectToRouteResult result = controller.Create(membership) as RedirectToRouteResult;
            string actualViewName = result.RouteValues["Action"].ToString();

            //Assert
            Assert.AreEqual(expectedViewName, actualViewName);
        }
    }
}