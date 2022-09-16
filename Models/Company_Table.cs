using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineManagementSystem.Models
{
    [Table("company_table", Schema = "public")]
    public class Company_Table
    { [Key]
        public int company_id { get; set; }
        public string company_name { get; set; }
    }
}