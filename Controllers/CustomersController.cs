using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VidlyMVC.Context;
using VidlyMVC.Models;
using VidlyMVC.ViewModels;

namespace VidlyMVC.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyDBContext _context;
        public CustomersController()
        {
            _context = new VidlyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var ViewModel = new CustomerFromViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFromViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var cusById = _context.Customers.Single(c => c.Id == customer.Id);
                cusById.Name = customer.Name;
                cusById.Dob = customer.Dob;
                cusById.IsSubscribed = customer.IsSubscribed;
                cusById.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFromViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

            /*
             Here is how we can implement Viewbag.
             Code snippet at Person controller's GetEmployeeDetails action method.
            public ActionResult GetEmployeeDetails()  
            {  
                Employee empdetails = new Employee();  
                empdetails._name = "Shridhar Sharma";  
                empdetails._age = 25;  
                empdetails._email = "ishriss@c-sharpcorner.com";  
                empdetails._city = "New Delhi";  
                //ViewData["Employeedetails"] = empdetails;  
                ViewBag.Employeedetails = empdetails;  
                return View("employeeview",empdetails);  
            }

            */
        }
        //detail refrence is removed 
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }

}
