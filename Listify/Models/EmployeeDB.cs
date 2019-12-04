using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Listify.Models
{
    public class EmployeeDB
    {
        string cs = ConfigurationManager.ConnectionStrings["winAuth"].ConnectionString;

        public List<Employee> ListAll()
        {
            List<Employee> lst = new List<Employee>();
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(new Employee
                    {
                        EmployeeID=Convert.ToInt32(reader["EmployeeID"]),
                        Name=reader["Name"].ToString(),
                        Age=Convert.ToInt32(reader["Age"]),
                        State=reader["State"].ToString(),
                        Country=reader["Country"].ToString(),
                    });
                }
                return lst;
            }
        }
    }
}