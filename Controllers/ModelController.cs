using AirlineManagementSystem.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementSystem.Controllers
{
    public class ModelController : Controller
    {
        ApplicationDBContext _context;
        public ModelController()
        {
            _context = new ApplicationDBContext();
        }
        [HttpGet]
        public ActionResult Model()
        {
            var model = _context.Models.ToList();
            return View(model);
        }
    }
}