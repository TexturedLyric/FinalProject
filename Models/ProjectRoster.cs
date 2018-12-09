using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class ProjectRoster
    {
        public string ParticipantID { get; set; }
        public People Participant { get; set; }
        public string ProjectID { get; set; }
        public Project Project { get; set; }
    }
}