using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Models;
using System.Collections.ObjectModel;

namespace App.DataService.Interfaces
{
    public interface IPersonDataService
    {
        Collection<Person> GetPersonDataService(RESTInput objRESTInput);
        bool AddPersonDataService(Person objPerson);
        bool UpdatePersonDataService(Person objPerson);
        Collection<Person> SearchPersonDataService(RESTInput objRESTInput);
    }
}
