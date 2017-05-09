using System;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.Http;
namespace Common.Framework
{
	public class HttpSend
	{
		const string ResponseContent = "HttpResponseContent";
		/// <summary>
		/// This is a generic Http send method which send the response
		/// object back to the caller
		/// </summary>
		/// <typeparam name="TRequest">Request type</typeparam>
		/// <typeparam name="TResponse">Response type</typeparam>
		/// <param name="httpMethod">HttpMethod type</param>
		/// <param name="uri">Uri of stubbed filename/Rest web service</param>
		/// <param name="obj">Request type object</param>
		/// <returns>Response type object</returns>
		public TResponse Send<TRequest, TResponse>(string httpMethod, string uri, TRequest obj,string responsetype,string requesttype)
		{
            HttpClient httpClient = new HttpClient();
            httpClient.TransportSettings.ConnectionTimeout = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["APP_CONNECTION_TIMEOUT"]));
			HttpResponseMessage response = new HttpResponseMessage();
			string xml = string.Empty;
			TResponse data = default(TResponse);
			try
			{
				switch (httpMethod)
				{
					case "GET":
					{
						response = httpClient.Get(uri);
						response.EnsureStatusIsSuccessful();
						data =getResponseType<TResponse>(responsetype,response);
						break;
					}
					case "POST":
					{
						if (requesttype == "application/json")
						response = httpClient.Post(uri, requesttype, HttpContentExtensions.CreateJsonDataContract<TRequest>(obj));
						else
						response = httpClient.Post(uri, requesttype, HttpContentExtensions.CreateXmlSerializable<TRequest>(obj));
						response.EnsureStatusIsSuccessful();
						data = getResponseType<TResponse>(responsetype, response);
						break;
					}
					case "PUT":
					{
						if (requesttype == "application/json")
						response = httpClient.Put(uri, requesttype, HttpContentExtensions.CreateJsonDataContract<TRequest>(obj));
						else
						response = httpClient.Put(uri, requesttype, HttpContentExtensions.CreateXmlSerializable<TRequest>(obj));
						response.EnsureStatusIsSuccessful();
						data =getResponseType<TResponse>(responsetype,response);
						break;
					}
					case "DELETE":
					{
						response = httpClient.Delete(uri);
						response.EnsureStatusIsSuccessful();
						data =getResponseType<TResponse>(responsetype,response);
						break;
					}
				}
				return data;
			}
			catch (Exception generalException)
			{
                if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var errorMessages = response.Headers.GetValues("CustomErrorMessage");
                    if (errorMessages != null)
                    {
                        throw new WebException(string.Join(";", errorMessages));
                    }
                }
				throw new WebException(generalException.Message);
			}
		}
		private TResponse getResponseType<TResponse>(string responsetype,HttpResponseMessage response)
		{
			TResponse retValue = default(TResponse);
			if (responsetype.Equals("application/xml"))
			{
				retValue = response.Content.ReadAsXmlSerializable<TResponse>();
			}
			else if (responsetype.Equals("application/json"))
			{
				string responseContent = response.Content.ReadAsString();
				retValue = Helpers.JsonDeserialization<TResponse>(responseContent);
			}
//			else
//			retValue = response.Content.ReadAsDataContract<TResponse>();
			return retValue;
		}
	}
}
