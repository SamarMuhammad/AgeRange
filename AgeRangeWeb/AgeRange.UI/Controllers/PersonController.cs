using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using AgeRange.ExternalService;
using Common.Models;
using System.Collections.ObjectModel;
using Kendo.Mvc.Extensions;

namespace AgeRange.UI.Controllers
{
    public class PersonController : Controller
    {
        #region " *** Initialization *** "
        PersonDetailRestService objPersonDetailRestService = new PersonDetailRestService();
        #endregion

        public ActionResult Index()
        {            
            return View();
        }

        #region " *** Grid Events *** "

        public ActionResult LoadPersonList([DataSourceRequest]DataSourceRequest request)
        {
            Collection<Person> oPerson;
            try 
            { 
                oPerson = GetPersonList();            
            }
            catch (Exception ex) {
                // write exception into log file
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(oPerson.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
           
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertPerson([DataSourceRequest]DataSourceRequest request, Person obj)
        {
            Collection<Person> oPerson;
            bool result;
            try
            {
                result = objPersonDetailRestService.AddPersonDataService(obj);
                oPerson = GetPersonList(); // Reload Grid Data
            }
            catch (Exception ex)
            {
                // write exception into log file
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(oPerson.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
     
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdatePerson([DataSourceRequest]DataSourceRequest request, Person obj)
        {
            Collection<Person> oPerson = GetPersonList();
            return Json(oPerson.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletePerson([DataSourceRequest]DataSourceRequest request, Person obj)
        {
            Collection<Person> oPerson = GetPersonList();
            return Json(oPerson.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchPerson([DataSourceRequest]DataSourceRequest request, Person obj)
        {
            Collection<Person> oPerson;
            try
            {
                RESTInput objRESTInput = new RESTInput();
                                
                // We can put field validation check here.
                objRESTInput.FirstName = obj.FirstName;
                objRESTInput.LastName = obj.LastName;
                
                // calling external service
                oPerson = objPersonDetailRestService.GetPersonDataService(objRESTInput);
            }
            catch (Exception ex)
            {
                // write exception into log file
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(oPerson.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region " *** Customize Functions *** "

        public Collection<Person> GetPersonList()
        {
            Collection<Person>  oPerson;
            try
            {
                RESTInput objRESTInput = new RESTInput();
                objRESTInput.PersonId = 0;
                // calling external service
                oPerson = objPersonDetailRestService.GetPersonDataService(objRESTInput);
                
            }
            catch (Exception ex)
            {
                // We can write log in file or database
                throw ex;
            }
            return oPerson;
        }

        #endregion
    }
}
