using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
       private dbUnversityEntities db= new dbUnversityEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dashboard() 
        {
            int totalstudents=db.students.Count();
            int totalregistrations=db.registrations.Count();
            int totalcourses=db.courses.Count();
            ViewBag.Totalstudents=totalstudents;
            ViewBag.Totalregistrations = totalregistrations;
            ViewBag.Totalcourses=totalcourses;



            return View();
        }
    }
}