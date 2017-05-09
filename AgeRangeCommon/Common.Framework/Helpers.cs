/**************************************************************************************
**************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Common.Framework
{
	/// <summary>
	/// This singleton class has methods that perform
	/// string manipulations and mathematical operations on the given input
	/// </summary>
	public static class Helpers
	{       		
		/// <summary>
		/// Serializes an Object into a Json
		/// </summary>
		/// <param name="value"></param>
		/// <returns>int</returns>
		public static string JsonSerialization(Object value)
		{
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = 86753090; 
            return javaScriptSerializer.Serialize(value);           
		}
		/// <summary>
		/// Deserializes a Json to an Object
		/// </summary>
		/// <param name="input"></param>
		/// <returns>int</returns>
		public static T JsonDeserialization<T>(string input)
		{
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = 86753090;
            return javaScriptSerializer.Deserialize<T>(input);
		}
		/// <summary>
		/// This method is used to form the value for the combo box in JqGrid
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sessionValue"></param>
		/// <param name="key"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static string GetData<T>(object sessionValue, string key, string name)
		{
			string value = "";
			foreach (T element in (Collection<T>)sessionValue)
			{
				string keyValue = string.Empty;
				string keyName = string.Empty;
				foreach (PropertyInfo pinfo in typeof(T).GetProperties())
				{
					if (pinfo.Name == key)
					{
						keyValue = (string)Convert.ChangeType(pinfo.GetValue(element, null), typeof(string));
					}
					if (pinfo.Name == name)
					{
						keyName = (string)Convert.ChangeType(pinfo.GetValue(element, null), typeof(string));
					}
				}
				value = value + keyValue + ":" + keyName + ";";
			}
			value = value.Substring(0, value.Length - 1);
			return value;
		}
		
		/// <summary>
		/// to check the whether the DB value is null
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dataRow"></param>
		/// <param name="columnName"></param>
		/// <returns></returns>
		public static T Get<T>(this DataRow dataRow, string columnName)
		{
			T nullValue = default(T);
			if (Nullable.GetUnderlyingType(typeof(T)) != null)
			{
				return dataRow.IsNull(columnName) ? nullValue : (T)Convert.ChangeType(dataRow[columnName], Nullable.GetUnderlyingType(typeof(T)));
			}
			else
			{
				return dataRow.IsNull(columnName) ? nullValue : (T)Convert.ChangeType(dataRow[columnName], typeof(T));
			}
		}
		
	}
}
