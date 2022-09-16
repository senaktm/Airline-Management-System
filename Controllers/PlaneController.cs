﻿using AirlineManagementSystem.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineManagementSystem.DataContext;

namespace AirlineManagementSystem.Controllers
{
    public class PlaneController : Controller
    {
        ApplicationDBContext _context;
        public PlaneController(){
            _context = new ApplicationDBContext();
            }
        // GET: Plane
       
        [HttpGet]
        public ActionResult Plane()

        {
            var plane = _context.Planes.ToList();
            return View(plane);

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
                    var query = "Delete from plane_table where plane_id='" + id + "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    cmd.ExecuteNonQuery();

                    connect.Close();



                }
                catch
                {

                }
            }
            return RedirectToAction("Plane");
        }
        [HttpGet]
        public ActionResult EditPlane()
        {
            List<SelectListItem> deger = (from i in _context.Companys.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.company_name.ToString(),
                                              Value = i.company_id.ToString()
                                          }).ToList();

            ViewBag.dgr = deger;
            List<SelectListItem> deger2 = (from i in _context.Models.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.model_name.ToString(),
                                               Value = i.model_id.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult EditPlane(int id, PlaneModel plane_Table,ModelMix _company, ModelMix _model)
        {
            var e = _context.Companys.Where(m => m.company_id == _company.company_table.company_id).FirstOrDefault();
            _company.company_table.company_id = e.company_id;
            var ex = _context.Models.Where(m => m.model_id == _model.model_table.model_id).FirstOrDefault();
            _model.model_table.model_id = ex.model_id;
            string connection = "server=localhost;port=5432;Database=database;" +
              " User Id=postgres;" + "Password=1234";


            using (var connect = new NpgsqlConnection(connection))
            {


                try
                {
                    connect.Open();
                    NpgsqlDataReader reader;
                    var query = "UPDATE plane_table SET " +
                        "company_id=@company_id,model_id=@model_id where plane_id='" + id + "'";


                    NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                    //PlaneModel planeModel = new PlaneModel();
                    // cmd.Parameters.AddWithValue("@company_id", company_Table.company_id);


                    cmd.Parameters.AddWithValue("@company_id", _company.company_table.company_id);
                    cmd.Parameters.AddWithValue("@model_id", _model.model_table.model_id);
         

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