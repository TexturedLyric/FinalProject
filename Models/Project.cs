using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public abstract class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}