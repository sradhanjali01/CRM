using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class AppController : Controller
    {
        CustomerDAL obj = new CustomerDAL();
        
        public ActionResult Index()
        {
            return View(obj.GetCustomers());
        }
        public ViewResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newcustomer(CRMCustomer customer,string txtUserid)
        {
            obj.Addcustomer(customer,txtUserid);
            return RedirectToAction("Index");
        }
        public ActionResult customerDetails(int id)
        {
            CRMCustomer customer = obj.GetCustomer(id);
            return View(customer);
        }
        public ActionResult Setting()
        {
            return View();
        }
    }
}