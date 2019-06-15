using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using Vidly2.Dtos;
using AutoMapper;

namespace Vidly2.Controllers
{
    [AllowAnonymous]
    public class CustomersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private List<Customer> customers;
        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            if (!User.IsInRole("CanManageMovies"))
                return View("ReadOnlyList");

            return View();
        }
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult CustomerDetails(int? Id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Id)))
            {
                CustomerDto viewModel = new CustomerDto();
                return View(viewModel);
            }
            else
            {
                customers = db.Customer.Include(c => c.MembershipType).ToList();
                var customer = customers.FirstOrDefault(x => x.CustomerId == Id);
                if (customer == null)
                {
                    CustomerDto viewModel = new CustomerDto();
                    return View(viewModel);
                }
                else
                {
                    CustomerDto dto = new CustomerDto();
                    var viewModel = customers.FirstOrDefault(x => x.CustomerId == Id);
                    Mapper.Map(viewModel, dto);
                    return View(dto);
                }
            }
        }

        public ActionResult SaveorUpdateCustomer()
        {
            return View("CustomerDetails");
        }
    }
}