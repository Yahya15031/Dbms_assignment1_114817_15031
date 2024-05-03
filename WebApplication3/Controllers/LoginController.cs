using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    public class LoginController : Controller
    {
        dbUnversityEntities dab = new dbUnversityEntities();
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        // GET: Login/Create
        public ActionResult Login()
        {
            
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Login(FormCollection collection, admin_ ad)
        {
            // TODO: Add insert logic here
            var context = new dbUnversityEntities();

            bool isvalid = context.admin_.Any(x => x.Password == ad.Password && x.ID == ad.ID);
            if (isvalid)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.message = "invalid Admin Name or ID";
            ModelState.AddModelError("", "invalid Admin Name or ID");
            return View();

        }



    }
}
