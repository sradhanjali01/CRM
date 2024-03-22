using CRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class AccountController : Controller
    {
        UserDAL obj = new UserDAL();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtEmail)
        {
            CRMUser user = obj.GetUser(txtEmail);
            string id = user.ID.ToString();
            string name = user.Name;
            Session["ID"] = id;
            Session["Name"] = name;

            return RedirectToAction("Index","App");
        }
        [HttpGet]
        public ActionResult Signin()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Signin(CRMUser user)
        {

         CRMUser User = obj.Adduser(user);
           string name = User.Name;
            string email = User.email;
            string id = User.ID.ToString();

            Session["Name"] = name;
            Session["Email"] = email;
            Session["Id"] = id;
           


            return RedirectToAction("Index", "App");
        }

    }
}