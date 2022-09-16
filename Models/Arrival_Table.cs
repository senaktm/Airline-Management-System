using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineManagementSystem.Models
{ [Table("arrival_table", Schema = "public")]
    public class Arrival_Table
    {
       
        
            [Key]
            public int arrival_point { get; set; }
            public string arrival_name { get; set; }
        
    }
}