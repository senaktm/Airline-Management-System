using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineManagementSystem.Models
{
    [Table("flight_table", Schema = "public")]
    public class Flight_Table
    {
        [Key]
        public int flight_id { get; set; }
      
        public int departure_point { get; set; }
        public int arrival_point { get; set; }
        public string departure_time { get; set; }   
        public string arrival_time { get; set; }  
        public string flight_time { get; set; }   
        public int seating_capacity { get; set; }  
        public int price { get; set; }
    }
}