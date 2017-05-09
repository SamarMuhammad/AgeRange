using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Models;
using App.DataService.Interfaces;
using System.Collections.ObjectModel;
using Common.Framework;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace App.DataService
{
    public class PersonDataService : IPersonDataService
    {
        #region " *** Initialization *** "
        SQLiteConnection objConnection;
        SQLiteCommand command;
        SQLiteDataReader dataReader;
        Collection<Person> oPerson = new Collection<Person>();
        #endregion

        #region " *** Person Data *** "

        public Collection<Person> GetPersonDataService(RESTInput objRESTInput)
        {                                        
            try
            {
                objConnection = DatabaseConnection;
                objConnection.Open();

                string selectSQL = "SELECT P.*, AG.Description FROM Person P INNER JOIN AgeGroup AG ON P.Age BETWEEN AG.MinAge AND AG.MaxAge";  // Using direct query to save time otherwise I can use SP or Entity Framework.
                command = new SQLiteCommand(selectSQL, objConnection);
                dataReader = command.ExecuteReader();
                DataTable dtPerson = new DataTable("Table");
                dtPerson.Load(dataReader);
                
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                if (dtPerson != null && dtPerson.Rows.Count > 0)
                {
                    oPerson = new Collection<Person>(dtPerson.AsEnumerable().Select(obj => new Person
                    {
                        Id = Helpers.Get<int>(obj, "Id"),
                        FirstName = Helpers.Get<string>(obj, "FirstName"),
                        LastName = Helpers.Get<string>(obj, "LastName"),
                        Age = Helpers.Get<int>(obj, "Age"),
                        Description = Helpers.Get<string>(obj, "Description")

                    }).ToList());
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {                
                objConnection.Close();                
            }

            return oPerson;
        }

        public bool AddPersonDataService(Person objPerson)
        {
            try
            {
                objConnection = DatabaseConnection;
                objConnection.Open();

                string selectSQL = this.InsertQuery(objPerson);  // Using direct queries to save time.
                command = new SQLiteCommand(selectSQL, objConnection);
                dataReader = command.ExecuteReader();
                DataTable dtPerson = new DataTable("Table");
                dtPerson.Load(dataReader);

                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                if (dtPerson != null && dtPerson.Rows.Count > 0)
                {
                    oPerson = new Collection<Person>(dtPerson.AsEnumerable().Select(obj => new Person
                    {
                        Id = Helpers.Get<int>(obj, "Id"),
                        FirstName = Helpers.Get<string>(obj, "FirstName"),
                        LastName = Helpers.Get<string>(obj, "LastName"),
                        Age = Helpers.Get<int>(obj, "Age")
                    }).ToList());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConnection.Close();
            }
            return true;
        }

        public bool UpdatePersonDataService(Person objPerson)
        {
            // Update logic will be same as add person in database
            return true;
        }

        public Collection<Person> SearchPersonDataService(RESTInput objRESTInput)
        {
            try
            {
                objConnection = DatabaseConnection;
                objConnection.Open();

                string selectSQL = "SELECT * FROM Person";  // Using direct query to save time otherwise I can use SP or Entity Framework.
                command = new SQLiteCommand(selectSQL, objConnection);
                dataReader = command.ExecuteReader();
                DataTable dtPerson = new DataTable("Table");
                dtPerson.Load(dataReader);

                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                if (dtPerson != null && dtPerson.Rows.Count > 0)
                {
                    oPerson = new Collection<Person>(dtPerson.AsEnumerable().Select(obj => new Person
                    {
                        Id = Helpers.Get<int>(obj, "Id"),
                        FirstName = Helpers.Get<string>(obj, "FirstName"),
                        LastName = Helpers.Get<string>(obj, "LastName"),
                        Age = Helpers.Get<int>(obj, "Age")
                    }).ToList());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConnection.Close();
            }

            return oPerson;
        }

        private SQLiteConnection DatabaseConnection
        {
            get
            {
                try
                {
                    string fullPath = ConfigurationManager.AppSettings["DBPath"];
                    SQLiteConnection conn = new SQLiteConnection("Data Source=" + fullPath);
                    return conn;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private string InsertQuery(Person obj)
        {
            try
            {
                string MyQuery = "Insert Into Person (FirstName, LastName, Age) Values (" + "'" + obj.FirstName + "'" + "," + "'" + obj.LastName + "'" + "," + obj.Age + ")";
                return MyQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
