using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineManagementSystem.Models
{
    [Table("departure_table", Schema = "public")]
    public class Departure_Table
    {
        [Key]
        public int departure_point { get; set; }
        public string departure_name { get; set; }
    }
}