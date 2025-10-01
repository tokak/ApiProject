﻿using ApiProject.WepApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjeKampi.WebApi.Entities
{
    public class EmployeeTaskChef
    {
        [Key]
        public int Id { get; set; }  

        [ForeignKey("EmployeeTask")]
        public int EmployeeTaskId { get; set; }
        public EmployeeTask EmployeeTask { get; set; }

        [ForeignKey("Chef")]
        public int ChefId { get; set; }
        public Chef Chef { get; set; }
    }
}
