using Microsoft.VisualStudio.TestTools.UnitTesting;
using WL_CapstonePrototype.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL_CapstonePrototype.Models;
using System.Web.Mvc;
using System.Net;

namespace WL_CapstonePrototype.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        [TestMethod()]
        public void Add_New_User_Test()
        {
            //Arrange
            UsersController controller = new UsersController();
            Users user = new Users()
            {
                FirstName = "Haoyue",
                LastName = "Wang",
                Gender = "Female",
                Phone = "647906123",
                Email = "Zoe@gmail.com",
                AddressId = 1,
                Membership_Id = 1
                
            };
            string expectedViewName = "Index";
            //Act   
            RedirectToRouteResult result = controller.Create(user) as RedirectToRouteResult;
            string actualViewName = result.RouteValues["Action"].ToString();
            
            //Assert
            Assert.AreEqual(expectedViewName, actualViewName);
        }

        [TestMethod()]
        public void IndexAction_Returns_IndexView()
        {
            //Arrange
            UsersController controller = new UsersController();

            string expectedViewName = "";

            //Act
            ViewResult actualView = controller.Index() as ViewResult;
            string actualViewName = actualView.ViewName;

            //Assert
            Assert.AreEqual(expectedViewName, actualViewName);
        }

        [TestMethod()]
        public void DetailsAction_InvalidId_NotFound()
        {
            //Arrange
            UsersController controller = new UsersController();
            HttpStatusCodeResult httpStatusCode = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            int expectedStatusCode = httpStatusCode.StatusCode;

            //Act
            httpStatusCode = controller.Details(-1) as HttpStatusCodeResult;
            int actualStatusCode = httpStatusCode.StatusCode;

            //Assert
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }


        [TestMethod()]
        public void DetailsAction_LocalRepoReturns_UserData()
        {
            //Arrange
            UsersController controller = new UsersController();
            string expectedFirstName = "Xuanchen";

            //Act
            ViewResult actualResult = controller.Details(5) as ViewResult;
            Users actualUser = actualResult.Model as Users;
            string actualFirstName = actualUser.FirstName;

            //Assert
            Assert.AreEqual(expectedFirstName, actualFirstName);
        }

    }
}