using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Customer.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace Customer.Data.Services
{

    public interface ICustomerServices
    {
         List<Customers> GetAllCustomers();
        Customers GetCustomerById(int id);
        Customers CreateCustomer(Customers customer);
        Customers UpdateCustomer(Customers customer);
        void DeleteCustomer(int id);
    }
    public class CustomerServices : ICustomerServices
    {
        private IConfiguration _configuration;
        public CustomerServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Customers> GetAllCustomers()
        {
            SqlUtils sqlUtils = SqlUtils.GetIntance();
            DataTable dt = sqlUtils.Select(_configuration);
            List<Customers> customers = new List<Customers>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Customers customers1 = new Customers();
                customers1.Id = Convert.ToInt16(dt.Rows[i]["Id"]);
                customers1.Name = dt.Rows[i]["Name"].ToString();
                customers1.SureName = dt.Rows[i]["SureName"].ToString();
                customers1.date = Convert.ToDateTime( dt.Rows[i]["date"]);
                customers.Add(customers1);
            }
            return customers;
        }
        
        public Customers CreateCustomer(Customers customer)
        {
            SqlUtils sqlUtils = SqlUtils.GetIntance();
            return sqlUtils.Insert(_configuration, customer); 
        }

        public void DeleteCustomer(int id)
        {
            SqlUtils sqlUtils = SqlUtils.GetIntance();
             sqlUtils.Delete(_configuration, id);
        }

      

        public Customers GetCustomerById(int id)
        {
            SqlUtils sqlUtils = SqlUtils.GetIntance();
            DataTable dt = sqlUtils.SelectId(_configuration,id);       
                Customers customers = new Customers();
                customers.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                customers.Name = dt.Rows[0]["Name"].ToString();
                customers.SureName = dt.Rows[0]["SureName"].ToString();
                customers.date = Convert.ToDateTime(dt.Rows[0]["date"]);
               
            
            return customers;
        }

        public Customers UpdateCustomer(Customers customer)
        {
            SqlUtils sqlUtils = SqlUtils.GetIntance();
           return sqlUtils.Update(_configuration, customer);
        }

      
    }
}
