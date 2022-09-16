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
    public class CompanyController : Controller
    {
        ApplicationDBContext _context;
        public CompanyController()
        {
            _context = new ApplicationDBContext();
        }
        // GET: Company
        [HttpGet]
        public ActionResult Company()
        {
            var company = _context.Companys.ToList();
            return View(company);
        }
        [HttpGet]
        public ActionResult NewCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCompany(Company_Table company_Table)
        {
            company_Table.company_name = Request.Form["company_name"];


            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "insert into company_table(company_name) values (@company_name)";


                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    //PlaneModel planeModel = new PlaneModel();
                   // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);
                    cmd.Parameters.AddWithValue("@company_name",company_Table.company_name);
                
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
                    var query = "Delete from company_table where company_id='"+id+"'";


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
            return RedirectToAction("Company");
        }
        [HttpGet]
        public ActionResult EditCompany()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EditCompany(int id,Company_Table company_Table)
        {

            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";
         

            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "UPDATE company_table SET company_name=@company_name where company_id='"+id+"'";


                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    //PlaneModel planeModel = new PlaneModel();
                    // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);
                
                    cmd.Parameters.AddWithValue("@company_name", company_Table.company_name);

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