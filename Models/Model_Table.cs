using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineManagementSystem.Models
{
    [Table("model_table", Schema = "public")]
    public class Model_Table
    {
        [Key]
        public int model_id { get; set; }
        public string model_name { get; set; }
    }
}