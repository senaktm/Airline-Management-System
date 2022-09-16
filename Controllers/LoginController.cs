using AirlineManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public RedirectResult Login(string username, string password)
        {
            DatabaseConnection db = new DatabaseConnection();
            UserModel.username = Request.Form["username"];
            UserModel.password = Request.Form["password"];

            if (db.LoginCheck())
            {
                switch (UserModel.statu_name)
                {
                    case "admin":
                        return Redirect("Plane/Plane");              
                    case "user":
                        return Redirect("User/User");
                }
            }
            return Redirect("/");
        }
    }
}