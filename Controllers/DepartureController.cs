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
    public class DepartureController : Controller
    {
        ApplicationDBContext _context;
        public DepartureController()
        {
            _context = new ApplicationDBContext();
        }
        // GET: Company
        [HttpGet]
        public ActionResult Departure()
        {
            var arrival = _context.Departures.ToList();
            return View(arrival);
        }
        [HttpGet]
        public ActionResult NewDeparture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDeparture(Departure_Table departure_Table)
        {
            departure_Table.departure_name = Request.Form["departure_name"];


            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "insert into departure_table(departure_name) values (@departure_name)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@departure_name", departure_Table.departure_name);
                    cmd.ExecuteNonQuery();

                    connect.Close();



                }
                catch
                {

                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {
                try
                {
                    var query = "Delete from departure_table where departure_point='" + id + "'";


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
            return RedirectToAction("Departure");
        }
        [HttpGet]
        public ActionResult EditDeparture()
        {

            return View();
        }
       
 
        [HttpPost]
        public ActionResult EditDeparture(int id, Departure_Table departure_Table)
        {  string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234"; 
            using (var connect = new NpgsqlConnection(connection))
            {
                try {
                    var query = "UPDATE departure_table SET departure_name=@departure_name where departure_point='" + id + "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@departure_name", departure_Table.departure_name);
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