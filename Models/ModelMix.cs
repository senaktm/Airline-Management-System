using AirlineManagementSystem.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineManagementSystem.Models
{
    public class ModelMix{
        public Model_Table model_table { get; set; }
        public Company_Table company_table { get; set; }
        public ApplicationDBContext dBContext { get; set; }
        public PlaneModel planeModel { get; set; } 
        public Flight_Table flight_table { get; set; }
        public Departure_Table departure_table { get; set; }
        public Arrival_Table arrival_table { get; set; }
    }
}