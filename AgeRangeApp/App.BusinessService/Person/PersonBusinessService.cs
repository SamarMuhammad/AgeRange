using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Framework;
using Common.Models;
using System.Threading;
using App.BusinessService.Interfaces;
using App.DataService.Interfaces;
using System.Collections.ObjectModel;

namespace App.BusinessService
{
    public class PersonBusinessService : IPersonBusinessService
    {
        private IPersonDataService objIPersonDataService { get { return UnityManager.Resolve<IPersonDataService>(); } }

        public Collection<Person> GetPersonBusinessService(RESTInput objRESTInput)
        {
            return objIPersonDataService.GetPersonDataService(objRESTInput);
        }

        public bool AddPersonBusinessService(Person objPerson)
        {
            objIPersonDataService.AddPersonDataService(objPerson);  
            return true;
        }

        public bool UpdatePersonBusinessService(Person objPerson)
        {
            objIPersonDataService.AddPersonDataService(objPerson);
            return true;
        }

        public Collection<Person> SearchPersonBusinessService(RESTInput objRESTInput)
        {
            return objIPersonDataService.SearchPersonDataService(objRESTInput);
        }
    }   
}
