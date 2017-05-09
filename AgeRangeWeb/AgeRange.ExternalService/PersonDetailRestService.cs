using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Models;
using System.Collections.ObjectModel;
using Common.Framework;
using System.Configuration;

namespace AgeRange.ExternalService
{
    public class PersonDetailRestService
    {
        HttpSend httpSend = new HttpSend();
        String webServerUrl = ConfigurationManager.AppSettings.Get("WebServerUrl");

        public Collection<Person> GetPersonDataService(RESTInput objRESTInput)
        {
            try
            {          
                // Calling REST API 
                Collection<Person> PersonList = httpSend.Send<RESTInput, Collection<Person>>("POST", string.Format(webServerUrl + "GetPerson"), objRESTInput, "application/json", "application/json");
                return PersonList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddPersonDataService(Person objPerson)
        {
            try
            {
                // Calling REST API
                bool result = httpSend.Send<Person, bool>("POST", string.Format(webServerUrl + "AddPerson"), objPerson, "application/json", "application/json");
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}