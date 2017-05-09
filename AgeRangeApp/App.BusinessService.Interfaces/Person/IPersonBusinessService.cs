using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Models;
using System.Collections.ObjectModel;

namespace App.BusinessService.Interfaces
{
    public interface IPersonBusinessService
    {
        Collection<Person> GetPersonBusinessService(RESTInput objRESTInput);
        bool AddPersonBusinessService(Person objPerson);
        bool UpdatePersonBusinessService(Person objPerson);
        Collection<Person> SearchPersonBusinessService(RESTInput objRESTInput);
    }
}
