using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assessment.Data.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee: Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsPermanent { get; set; }
    }
}
