using AgeRange.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Kendo.Mvc.UI;
using Common.Models;
using System.Web.Mvc;

namespace AgeRangeTestProject
{
    
    
    /// <summary>
    ///This is a test class for PersonControllerTest and is intended
    ///to contain all PersonControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for InsertPerson
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\MyProject\\AgeRangeAssignmentComplete\\AgeRangeAssignment\\AgeRangeWeb\\AgeRange.UI", "/")]
        [UrlToTest("http://localhost:40736/")]
        public void InsertPersonTest()
        {
            PersonController target = new PersonController(); // TODO: Initialize to an appropriate value
            DataSourceRequest request = null; // TODO: Initialize to an appropriate value
            Person obj = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.InsertPerson(request, obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadPersonList
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\MyProject\\AgeRangeAssignmentComplete\\AgeRangeAssignment\\AgeRangeWeb\\AgeRange.UI", "/")]
        [UrlToTest("http://localhost:40736/")]
        public void LoadPersonListTest()
        {
            PersonController target = new PersonController(); // TODO: Initialize to an appropriate value
            DataSourceRequest request = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.LoadPersonList(request);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdatePerson
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\MyProject\\AgeRangeAssignmentComplete\\AgeRangeAssignment\\AgeRangeWeb\\AgeRange.UI", "/")]
        [UrlToTest("http://localhost:40736/")]
        public void UpdatePersonTest()
        {
            PersonController target = new PersonController(); // TODO: Initialize to an appropriate value
            DataSourceRequest request = null; // TODO: Initialize to an appropriate value
            Person obj = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.UpdatePerson(request, obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeletePerson
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\MyProject\\AgeRangeAssignmentComplete\\AgeRangeAssignment\\AgeRangeWeb\\AgeRange.UI", "/")]
        [UrlToTest("http://localhost:40736/")]
        public void DeletePersonTest()
        {
            PersonController target = new PersonController(); // TODO: Initialize to an appropriate value
            DataSourceRequest request = null; // TODO: Initialize to an appropriate value
            Person obj = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.DeletePerson(request, obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
