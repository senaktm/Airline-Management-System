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
    public class FlightController : Controller
    {
        ApplicationDBContext _context;
       
        public FlightController()
        {
            _context = new ApplicationDBContext();
        }
        // GET: Flight
        [HttpGet]
        public ActionResult Flight()
        {
          

            var flight = _context.Flights.ToList();
            return View(flight);
       
        }
        [HttpGet]
     /*   public ActionResult NewFlight()
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
        public ActionResult NewFlight(ModelMix _departure, ModelMix _arrival, Flight_Table flight_table, ModelMix _plane)
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
                    var query = "insert into flight_table(departure_point,arrival_point,departure_time,arrival_time,flight_time,seating_capacity,price) values (@departure_point,@arrival_point,@departure_time,@arrival_time,@flight_time,@seating_capacity,@price)";


                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    //PlaneModel planeModel = new PlaneModel();
                    // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);

                    cmd.Parameters.AddWithValue("@departure_point", _departure.departure_table.departure_point);
                    cmd.Parameters.AddWithValue("@arrival_point", _arrival.arrival_table.arrival_point);
                    cmd.Parameters.AddWithValue("@departure_time", flight_table.departure_time);
                    cmd.Parameters.AddWithValue("@arrival_time", flight_table.arrival_time);
                    cmd.Parameters.AddWithValue("@flight_time", flight_table.flight_time);
                    cmd.Parameters.AddWithValue("@seating_capacity", flight_table.seating_capacity);
                    cmd.Parameters.AddWithValue("@price", flight_table.price);
                    // reader = cmd.ExecuteReader();
                    cmd.ExecuteNonQuery();

                    connect.Close();
                }
                catch
                {

                }
            }
            return View();
        }
        /*
        [HttpPost]
        public ActionResult NewFlight(Flight_Table flight_Table,ModelMix _location,Location_Table _location_table)
        {
             var e = _context.Locations.Where(m => m.location_id ==_location.location_table.location_id).FirstOrDefault();
            _location.location_table= e.;
            _context.Flights.Add(flight_Table);
            /*
               flight_Table.plane_id = Int32.Parse(Request.Form["plane_id"]);
               flight_Table.departure_point = Request.Form["departure_point"];
               flight_Table.arrival_point = Request.Form["arrival_point"];
               flight_Table.departure_time = Request.Form["departure_time"];
               flight_Table.departure_time = Request.Form["arrival_time"];
               flight_Table.departure_time = Request.Form["flight_time"];
               flight_Table.plane_id = Int32.Parse(Request.Form["seating_capacity"]);
               flight_Table.plane_id = Int32.Parse(Request.Form["price"]);
            

          */
        /*
        string connection = "server=localhost;port=5432;Database=database;" +
          " User Id=postgres;" + "Password=1234";


        using (var connect = new NpgsqlConnection(connection))
        {


            try
            {
                connect.Open();
                NpgsqlDataReader reader;
                var query = "insert into flight_table(plane_id,departure_point,arrival_point,departure_time," +
                    "arrival_time,flight_time,seating_capacity,price) " +
                    "values (plane_id,departure_point,arrival_point,departure_time,arrival_time,flight_time," +
                    "seating_capacity,price)";


                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                //PlaneModel planeModel = new PlaneModel();
                // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);

                cmd.Parameters.AddWithValue("@plane_id", flight_Table.plane_id);
                cmd.Parameters.AddWithValue("@departure_point", _location.location_table.location_id);
                cmd.Parameters.AddWithValue("@arrival_point", _location.location_table.location_id);
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
        return RedirectToAction("Flight");
    }*/

        public ActionResult Delete(int id)
        {
            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "Delete from flight_table where flight_id='" + id + "'";


                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    //PlaneModel planeModel = new PlaneModel();
                    // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);


                    // reader = cmd.ExecuteReader();
                    cmd.ExecuteNonQuery();

                    connect.Close();



                }
                catch
                {

                }
            }
            return RedirectToAction("Flight");
        }
        [HttpGet]
        public ActionResult EditFlight()
        {  List<SelectListItem> deger = (from i in _context.Departures.ToList()
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
                    var query = "UPDATE flight_table SET " +
                        "departure_point=@departure_point,arrival_point=@arrival_point" +
                        "departure_time=@departure_time,arrival_time=@arrival_time" +
                        "flight_time=@flight_time,seating_capacity=@seating_capacity" +
                        "price=@price where flight_id='" + id + "'";


                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    //PlaneModel planeModel = new PlaneModel();
                    // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);

                   
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
            return View();
        }
    }
}