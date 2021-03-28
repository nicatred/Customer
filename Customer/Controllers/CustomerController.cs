using Customer.Data.Entities;
using Customer.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [Route("GetAll")]
        [HttpGet]
        public List<Customers> GetAllCustomers()
        {
            return _customerServices.GetAllCustomers();
        }
        [Route("Create")]
        [HttpPost]
        public Customers CreateCustomer(Customers customers)
        {
            return _customerServices.CreateCustomer(customers);
        }

        [HttpDelete("Delete/{Id}")]
        [Route("Delete")]
        public void DeleteCustomer(int Id)
        {
            _customerServices.DeleteCustomer(Id);
        }
        [HttpGet("GetId/{Id}")]
        [Route("GetId")]
        public Customers GetId(int Id)
        {
            return _customerServices.GetCustomerById(Id);
        }
        [HttpPut("Update/{customers}")]
        [Route("Update")]
        public Customers Update(Customers customers)
        {
          return  _customerServices.UpdateCustomer(customers);
        }
    }
}
