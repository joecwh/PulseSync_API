using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Department
    {
        [Key]
        public int empId { get; set; }
        public string Designation { get; set; }
    }
}
