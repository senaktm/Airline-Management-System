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
    public class EditFlightController : Controller
    {
        ApplicationDBContext _context;
        public EditFlightController()
        {
            _context = new ApplicationDBContext();
        }
        [HttpGet]
        public ActionResult EditFlight()
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
        public ActionResult EditFlight(int id, Flight_Table flight_Table, ModelMix _departure, ModelMix _arrival)
        {
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
                    var query = "UPDATE flight_table SET departure_point=@departure_point," +
                        "arrival_point=@arrival_point," +
                        "departure_time=@departure_time,arrival_time=@arrival_time," +
                        "flight_time=@flight_time,seating_capacity=@seating_capacity," +
                        "price=@price where flight_id='" +id+ "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@departure_point", _departure.departure_table.departure_point);
                    cmd.Parameters.AddWithValue("@arrival_point", _arrival.arrival_table.arrival_point);
                    cmd.Parameters.AddWithValue("@departure_time", flight_Table.departure_time);
                    cmd.Parameters.AddWithValue("@arrival_time", flight_Table.arrival_time);
                    cmd.Parameters.AddWithValue("@flight_time", flight_Table.flight_time);
                    cmd.Parameters.AddWithValue("@seating_capacity", flight_Table.seating_capacity);
                    cmd.Parameters.AddWithValue("@price", flight_Table.price);

                    // reader = cmd.ExecuteReader();
                    cmd.ExecuteNonQuery();

                    connect.Close();



                }
                catch
                {

                }
            }
            return RedirectToAction("EditFlight");
        }
    }
}