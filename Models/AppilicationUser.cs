using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficerEngagement.Models
{
    public class AppilicationUser:IdentityUser
    {
        public string firstName { get; set; }

        public string LaststName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
