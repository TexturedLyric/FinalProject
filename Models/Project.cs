using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

 namespace FinalProjet.Models
{
    public class Project
    {
        [Key]
        public string ID { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public ICollection<ProjectRoster> Participants { get; set; }

        public override string ToString(){
            return $"Project Name: {this.ProjectName}\nProject Description: {this.ProjectDescription}";
        }
    }
}