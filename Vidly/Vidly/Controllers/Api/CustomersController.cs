using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyContext _context;
        public CustomersController()
        {
            _context = new VidlyContext();
        }
        //GET api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDto = _context.Customer
                .Include(m => m.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDto);
        }
        //GET api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customerInDB = _context.Customer.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto>(customerInDB);
        }
        //POST api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);

            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerdto.CustomerId = customer.CustomerId;

            return customerdto;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customer.SingleOrDefault(c => c.CustomerId == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerdto, customerInDB);

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerIdDB = _context.Customer.SingleOrDefault(c => c.CustomerId == id);

            if (customerIdDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customer.Remove(customerIdDB);
            _context.SaveChanges();
        }

    }
}
