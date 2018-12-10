using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{

    public class Member : People
    {
        public string Major {get; set;}
    }
}