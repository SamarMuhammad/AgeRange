using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ComponentModel;
using Common.Framework;
using Common.Models;
using Service.Host;
using App.BusinessService.Interfaces;
using System.Collections.ObjectModel;

namespace Service.Implement
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PersonFacade : IPersonFacade
    {
        // Dependency Injection
        public IPersonBusinessService objIPersonBusinessService { get { return UnityManager.Resolve<IPersonBusinessService>(); } }

        public Collection<Person> GetPersonFacade(RESTInput objRESTInput)
        {
            try
            {
                return objIPersonBusinessService.GetPersonBusinessService(objRESTInput);
            }
            catch (Exception ex)
            {
                // Write exception in log file
                throw ex;
            }
        }

        public bool AddPersonFacade(Person objPerson)
        {
            try
            {
                return objIPersonBusinessService.AddPersonBusinessService(objPerson);
            }
            catch (Exception ex)
            {
                // Write exception in log file
                throw ex;
            }
        }

        public bool UpdatePersonFacade(Person objPerson)
        {
            try
            {
                return objIPersonBusinessService.AddPersonBusinessService(objPerson);
            }
            catch (Exception ex)
            {
                // Write exception in log file
                throw ex;
            }
        }

        public Collection<Person> SearchPersonFacade(RESTInput objRESTInput)
        {
            try
            {
                return objIPersonBusinessService.SearchPersonBusinessService(objRESTInput);
            }
            catch (Exception ex)
            {
                // Write exception in log file
                throw ex;
            }
        }

    }
}