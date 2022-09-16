using AirlineManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirlineManagementSystem.DataContext
{
    public class ApplicationDBContext:DbContext
    {
    public ApplicationDBContext() : base(nameOrConnectionString:"Context")
        {

        }
    
 
        public DbSet<PlaneModel> Planes { get; set; }
        public DbSet<Company_Table> Companys { get; set; }
        public DbSet<Flight_Table> Flights { get; set; }
        public DbSet<Model_Table> Models { get; set; }
        public DbSet<Departure_Table> Departures { get; set; }
        public DbSet<Arrival_Table> Arrivals { get; set; }









    }
}