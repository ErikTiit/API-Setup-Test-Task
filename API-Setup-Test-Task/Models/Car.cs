using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API_Setup_Test_Task.Models
{
    
    public class Vehicle
    {
        
        [Key]
        public string VIN { get; set; } // Car VIN is used as a primary key in database
        public string Make  { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationCode { get; set; }
    }
}
