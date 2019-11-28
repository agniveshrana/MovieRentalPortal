using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRentalPortal.Models;
using MovieRentalPortal.Dtos;
using AutoMapper;

namespace MovieRentalPortal.Controllers.API
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET --> /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return customers;
        }

        //GET --> /api/customer/1
        [HttpGet]
        [Route("api/Customers/{customerId}")]
        public IHttpActionResult GetCustomer(int customerId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST --> /api/customer
        [HttpPost]
        public IHttpActionResult AddNewCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;

            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);
        }

        //PUT --> modiy/update --> /api/customer/1
        [HttpPut]
        [Route("api/Customers/{customerId}")]
        public IHttpActionResult UpdateCustomer(int customerId, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.Single(c => c.CustomerId == customerId);

            if (customerInDb == null)
                return NotFound();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            //customerInDb.CustomerName = customer.CustomerName;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //customerInDb.IsSubscribedForNewsLetter = customer.IsSubscribedForNewsLetter;

            _context.SaveChanges();

            return Ok(customer);
        }

        //DELETE --> api/customer/1
        [HttpDelete]
        [Route("api/Customers/{customerId}")]
        public IHttpActionResult DeleteCustomer(int customerId)
        {
            var customerInDb = _context.Customers.Single(c => c.CustomerId == customerId);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }
    }
}
