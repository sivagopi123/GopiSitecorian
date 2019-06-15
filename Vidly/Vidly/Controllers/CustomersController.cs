using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        VidlyContext db = new VidlyContext();
        private List<Customer> customers;
        // GET: Customers
        [Route("Customers/Index/")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Customers/Details/{id:regex(\\d)}")]
        public ActionResult Edit(int Id)
        {
            customers = db.Customer.Include(c => c.MembershipType).ToList();
            var customer = customers.FirstOrDefault(x => x.CustomerId == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customers.FirstOrDefault(x => x.CustomerId == Id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveorUpdateCustomer(CustomerFormViewModel customerViewModel)
        {
            if (customerViewModel.Customer.CustomerId == 0)
            {
                var newcustomer = new Customer();
                newcustomer.CustomerName = customerViewModel.Customer.CustomerName;
                newcustomer.CustomerBirthDate = customerViewModel.Customer.CustomerBirthDate;
                newcustomer.IsSubscribedToNewsletter = customerViewModel.Customer.IsSubscribedToNewsletter;
                newcustomer.MembershipType = customerViewModel.Customer.MembershipType;
                db.Customer.Add(newcustomer);
                db.SaveChanges();
                return View("CustomerDetails", newcustomer);
            }
            var customerInDB = db.Customer.FirstOrDefault(c => c.CustomerId == customerViewModel.Customer.CustomerId);
            if (customerInDB is null)
            {
                var newcustomer = new Customer();
                newcustomer.CustomerName = customerViewModel.Customer.CustomerName;
                newcustomer.CustomerBirthDate = customerViewModel.Customer.CustomerBirthDate;
                newcustomer.IsSubscribedToNewsletter = customerViewModel.Customer.IsSubscribedToNewsletter;
                newcustomer.MembershipType = customerViewModel.Customer.MembershipType;
                db.Customer.Add(newcustomer);
                db.SaveChanges();
            }
            else
            {
                customerInDB.CustomerName = customerViewModel.Customer.CustomerName;
                customerInDB.CustomerBirthDate = customerViewModel.Customer.CustomerBirthDate;
                customerInDB.IsSubscribedToNewsletter = customerViewModel.Customer.IsSubscribedToNewsletter;
                customerInDB.MembershipType = customerViewModel.Customer.MembershipType;
                db.SaveChanges();
            }

            return View("CustomerDetails", customerViewModel);
        }

        public ActionResult CustomerDetails(int? Id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Id)))
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel
                {
                    Customer = new Customer(),
                    MembershipTypes = db.MembershipType.ToList()
                };
                return View(viewModel);
            }
            else
            {
                customers = db.Customer.Include(c => c.MembershipType).ToList();
                var customer = customers.FirstOrDefault(x => x.CustomerId == Id);
                if (customer == null)
                {
                    CustomerFormViewModel viewModel = new CustomerFormViewModel
                    {
                        Customer = new Customer(),
                        MembershipTypes = db.MembershipType.ToList()
                    };
                    return View(viewModel);
                }
                else
                {
                    CustomerFormViewModel viewModel = new CustomerFormViewModel
                    {
                        Customer = customers.FirstOrDefault(x => x.CustomerId == Id),
                        MembershipTypes = db.MembershipType.ToList()
                    };
                    return View(viewModel);
                }
            }
        }
    }
}