using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wclc.Models;
using System.Net;
using System.Net.Mail;

namespace wclc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Volunteer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Volunteer(FormCollection values)
        {
            try { 
            dynamic volEmail = new Email("VolunteerCheckedEmail");
            volEmail.To = "alygator3017@gmail.com";
            volEmail.Name = Request.Form["Name"];
            volEmail.Phone = Request.Form["Phone"];
            volEmail.Email = Request.Form["Email"];
            volEmail.Send();
            return View();
            }
            catch (Exception ex)
            {
                ViewBag.errorMsg = ex.GetBaseException();
                return View();
            }
        }
    }
}