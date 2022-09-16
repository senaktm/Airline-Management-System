using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineManagementSystem.Models
{


    [Table("plane_table", Schema = "public")]
    public class PlaneModel
    {
        [Key]
        public string plane_id { get; set; }  
        public int company_id { get; set; }
        public int model_id { get; set; }
        public int passenger_capacity { get; set; }


    
    }
}