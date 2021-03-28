using Customer.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Data
{
    
    public class SqlUtils 
    {
        private static IConfiguration _configuration;
        private static SqlUtils _sqlUtil;
        private SqlUtils()
        {
        }
        public static SqlUtils GetIntance()
        {
            if (_sqlUtil == null)
            {
                _sqlUtil = new SqlUtils();
            }
            return _sqlUtil;
        }
        public DataTable Select(IConfiguration configuration)
        {
            _configuration = configuration;
            string query = "select * from CUSTOMERS";
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("default"));
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public Customers Insert(IConfiguration configuration, Customers customers)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("default"));
                _configuration = configuration;
            string query = @$" Insert into CUSTOMERS(Name,SureName,date)
              values('{customers.Name.ToString()}','{customers.SureName.ToString()}','{customers.date.ToString()}');";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);    
                
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return customers;
            
        }

        public void Delete(IConfiguration configuration,int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("default"));
            _configuration = configuration;
            string query = @$"Delete from CUSTOMERS where id={Id}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public DataTable SelectId(IConfiguration configuration,int Id)
        {
            _configuration = configuration;
            string query = @$"select * from CUSTOMERS WHERE Id={Id}";
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("default"));
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public Customers Update(IConfiguration configuration,Customers customers)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("default"));
            _configuration = configuration;
            string query = @$"UPDATE CUSTOMERS 
        SET Name='{customers.Name}',SureName='{customers.SureName}',date='{customers.date}'
        WHERE Id={customers.Id}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return customers;
        }
    }
}
