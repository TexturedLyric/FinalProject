using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public abstract class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}