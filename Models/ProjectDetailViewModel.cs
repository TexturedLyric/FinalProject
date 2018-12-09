using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class ProjectDetailViewModel
    {

        public Project Project {get; set;}

        public List<Client> Clients { get; set; }
        
        public List<Member> Members { get; set; }

        
    }
}