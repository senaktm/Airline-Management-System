using AirlineManagementSystem.DataContext;
using AirlineManagementSystem.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementSystem.Controllers
{
    public class NewFlightController : Controller
    {
        ApplicationDBContext _context;
        public NewFlightController()
        {
            _context = new ApplicationDBContext();
        }
        // GET: NewFlight
        [HttpGet]
        public ActionResult NewFlight()
        {
            List<SelectListItem> deger = (from i in _context.Departures.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.departure_name.ToString(),
                                              Value = i.departure_point.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            List<SelectListItem> deger3 = (from i in _context.Arrivals.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.arrival_name.ToString(),
                                              Value = i.arrival_point.ToString()
                                          }).ToList();
            ViewBag.dgr3 = deger3;

            List<SelectListItem> deger2 = (from i in _context.Planes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.plane_id.ToString(),
                                               Value = i.plane_id.ToString()
                                           }).ToList();

            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(ModelMix _departure,ModelMix _arrival, Flight_Table flight_table,ModelMix _plane)
        {
            flight_table.departure_time = Request.Form["departure_time"];
            flight_table.arrival_time = Request.Form["arrival_time"];
            flight_table.flight_time = Request.Form["flight_time"];
            flight_table.seating_capacity = Int32.Parse(Request.Form["seating_capacity"]);
            flight_table.price = Int32.Parse(Request.Form["price"]);

            

            var e = _context.Departures.Where(m => m.departure_point == _departure.departure_table.departure_point).FirstOrDefault();
            _departure.departure_table.departure_point = e.departure_point;
            var ex = _context.Arrivals.Where(m => m.arrival_point == _arrival.arrival_table.arrival_point).FirstOrDefault();
            _arrival.arrival_table.arrival_point = ex.arrival_point;



            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "insert into flight_table(departure_point,arrival_point,departure_time," +
                        "arrival_time,flight_time,seating_capacity,price) values" +
                        " (@departure_point,@arrival_point,@departure_time,@arrival_time," +
                        "@flight_time,@seating_capacity,@price)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@departure_point", _departure.departure_table.departure_point);
                    cmd.Parameters.AddWithValue("@arrival_point", _arrival.arrival_table.arrival_point);
                    cmd.Parameters.AddWithValue("@departure_time", flight_table.departure_time);
                    cmd.Parameters.AddWithValue("@arrival_time", flight_table.arrival_time);
                    cmd.Parameters.AddWithValue("@flight_time", flight_table.flight_time);
                    cmd.Parameters.AddWithValue("@seating_capacity", flight_table.seating_capacity);
                    cmd.Parameters.AddWithValue("@price", flight_table.price);
                    cmd.ExecuteNonQuery();

                    connect.Close();
                }
                catch
                {

                }
            }
            return RedirectToAction("NewFlight");
        }

    }
}