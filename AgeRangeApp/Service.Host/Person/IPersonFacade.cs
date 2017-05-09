using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using Common.Models;
using System.Collections.ObjectModel;

namespace Service.Host
{
    [ServiceContract]
    public interface IPersonFacade
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPerson", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Collection<Person> GetPersonFacade(RESTInput objRESTInput);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddPerson", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool AddPersonFacade(Person objPerson);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdatePerson", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdatePersonFacade(Person objPerson);

        [OperationContract]
        [WebInvoke(UriTemplate = "/SearchPerson", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Collection<Person> SearchPersonFacade(RESTInput objRESTInput);
    }
}
