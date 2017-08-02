using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectApp.ServiceReference1;
using MvcProjectApp.Models;

namespace MvcProjectApp.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client ur = new ServiceReference1.Service1Client();
        // GET: Home
        public ActionResult Index()
        {
            List<CustomerDetail> lstRecord = new List<CustomerDetail>();

            var lst = ur.GetAllCustomers();

            foreach(var item in lst)
            {
                CustomerDetail usr = new CustomerDetail();
                usr.CustomerId = item.CustomerId;
                usr.CustorName = item.CustorName;
                usr.Address = item.Address;
                lstRecord.Add(usr);
            }
            return View(lstRecord);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CustomerDetail mdl)
        {
            CustomerDetail usr = new CustomerDetail();
            usr.CustomerId = mdl.CustomerId;
            usr.CustorName = mdl.CustorName;
            usr.Address = mdl.Address;
            ur.AddCustomer(usr.CustomerId, usr.CustorName, usr.Address);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int CustomerId)
        {
            int retval = ur.DeleteUserById(CustomerId);
          //  if(retval > 0)
           // {
           //     return RedirectToAction("Index", "Home");
           // }
            return View();
        }

        public ActionResult Edit(int CustomerId)
        {
            var lst = ur.GetAllCustomerById(CustomerId);
            CustomerDetail usr = new CustomerDetail();
            usr.CustomerId = lst.CustomerId;
            usr.CustorName = lst.CustorName;
            usr.Address = lst.Address;
            return View(usr);  
        }

        [HttpPost]
        public ActionResult Edit(CustomerDetail mdl)
        {
            CustomerDetail usr = new CustomerDetail();
            usr.CustomerId = mdl.CustomerId;
            usr.CustorName = mdl.CustorName;
            usr.Address = mdl.Address;

            int Retval = ur.UpdateCustomer(usr.CustomerId, usr.CustorName, usr.Address);
            if(Retval > 0)
            {
               return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}