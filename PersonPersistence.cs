using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using SimpleRestServer.Models;
using System.Globalization;
using System.Collections;


namespace SimpleRestServer
{
    public class PersonPersistence
    {

        //public static string _connString = @"Data Source=DESKTOP-A4D5MRT;Initial Catalog=SalmansWeb_Live;Integrated Security=True";
        private System.Data.SqlClient.SqlConnection conn;

        public PersonPersistence()
        {
            string myConnectionString;
            myConnectionString = @"Data Source=Stevens;Initial Catalog=EmployeeDb;Integrated Security=True";

            try
            {
                conn = new System.Data.SqlClient.SqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                throw;
            }

        }

        public ArrayList getPersons()
        {
            ArrayList personArray = new ArrayList();
            
            System.Data.SqlClient.SqlDataReader sqlReader = null;
            String sqlString = "SELECT * FROM Personnel";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                Person p = new Person();
                p.Id = sqlReader.GetInt32(0);
                p.FirstName = sqlReader.GetString(1);
                p.LastName = sqlReader.GetString(2);
                p.PayRate = sqlReader.GetDecimal(3);
                p.StartDate = sqlReader.GetDateTime(4);
                p.EndDate = sqlReader.GetDateTime(5);
                personArray.Add(p);
            }
            return personArray;

        }

        public Person getPerson(int ID)
        {
            Person p = new Person();
            System.Data.SqlClient.SqlDataReader sqlReader = null;
            String sqlString = "SELECT * FROM Personnel WHERE ID =" + ID.ToString();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                p.Id = sqlReader.GetInt32(0);
                p.FirstName = sqlReader.GetString(1);
                p.LastName = sqlReader.GetString(2);
                p.PayRate = sqlReader.GetDecimal(3);
                p.StartDate = sqlReader.GetDateTime(4);
                p.EndDate = sqlReader.GetDateTime(5);
                return p;
            }
            else
            {
                return null;
            }
            
        }

        public int savePerson(Person personToSave)
        {
            String sqlString = "INSERT INTO personnel(FirstName,LastName,PayRate,StartDate,EndDate) VALUES('" + personToSave.FirstName + "','" + personToSave.LastName + "','" +
                                +personToSave.PayRate + "','" + personToSave.StartDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) +
                                "','" + personToSave.EndDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "')SELECT SCOPE_IDENTITY()";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            //cmd.ExecuteNonQuery();
            //long id = cmd.;
            //int lastId = (int)command.ExecuteScalar();
            int Id = Convert.ToInt32(cmd.ExecuteScalar());
            //int id = (int)cmd.ExecuteScalar();
            //int Id = (int)cmd.ExecuteScalar();
            return Id;


        }

    }
}