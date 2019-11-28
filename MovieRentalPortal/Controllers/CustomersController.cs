using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalPortal.Models;
using MovieRentalPortal.ViewModels;
using System.Data.Entity;

namespace MovieRentalPortal.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Customers")]
        [Route("Customers/Index")]
        public ActionResult Index()
        {
            CustomerViewModel customerVM = new CustomerViewModel();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            customerVM.CustomerList = customers;

            return View(customerVM);
        }

        [Route("Customers/Details/{customerId}")]
        public ActionResult GetCustomerDetail(int customerId)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(id => id.CustomerId == customerId);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Route("Customers/New")]
        public ActionResult New()
        {
            CustomerFormViewModel newCustVM = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", newCustVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var custVM = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", custVM);
            }
            if (customer.CustomerId == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);

                customerInDB.CustomerName = customer.CustomerName;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedForNewsLetter = customer.IsSubscribedForNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Route("Customers/Edit/{customerId}")]
        public ActionResult Edit(int customerId)
        {
            CustomerFormViewModel editCustVM = new CustomerFormViewModel()
            {
                Customer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", editCustVM);
        }
    }
}