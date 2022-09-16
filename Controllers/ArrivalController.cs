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
    public class ArrivalController : Controller
    {
        ApplicationDBContext _context;
        public ArrivalController()
        {
            _context = new ApplicationDBContext();
        }
        // GET: Company
        [HttpGet]
        public ActionResult Arrival()
        {
            var arrival = _context.Arrivals.ToList();
            return View(arrival);
        }
        [HttpGet]
        public ActionResult NewArrival()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewArrival(Arrival_Table arrival_Table)
        {
            arrival_Table.arrival_name = Request.Form["arrival_name"];


            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "insert into arrival_table(arrival_name) values (@arrival_name)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@arrival_name", arrival_Table.arrival_name);
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
            {  try
                {
                    var query = "Delete from arrival_table where arrival_point='" + id + "'";


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
            return RedirectToAction("Arrival");
        }
        [HttpGet]
        public ActionResult EditArrival()
        {

            return View();
        }
        [HttpPost]
       

        public ActionResult EditArrival(int id, Arrival_Table arrival_Table)
        {      string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";
            using (var connect = new NpgsqlConnection(connection))
            { try{
                    var query = "UPDATE arrival_table SET arrival_name=@arrival_name where arrival_point='" + id + "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@arrival_name", arrival_Table.arrival_name);
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