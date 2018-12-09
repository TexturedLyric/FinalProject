using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

 namespace FinalProject.Models
 {
    public class People
    {
        public string ID { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email{ get; set; }

        public string Phone{ get; set; }
        public ICollection<ProjectRoster> Projects {get; set;}

        public override string ToString(){
            return $"First Name: {this.FirstName} Last Name: {this.LastName}";
        }
    }
}