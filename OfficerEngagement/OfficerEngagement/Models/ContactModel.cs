using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OfficerEngagement.Models
{
    public class ContactModel
    {
        [Key]
        public int serialno { get; set; }
        public string empcode { get; set; }
        [Required]
        public string empname { get; set; }
        [Required]
        public string sex { get; set; }
        public DateTime dateofjoininggovt { get; set; }
        public DateTime dateofjoiningdhi { get; set; }
        public DateTime dateofbirth { get; set; }
        public DateTime dateofretirement { get; set; }
        public string pan_no { get; set; }
        public string address_permanent { get; set; }

        public string mobileno { get; set; }
        public string roomno { get; set; }
        public int intercom { get; set; }
        public string emailaddress { get; set; }
        public string paylevel { get; set; }
        public string Status { get; set; }

        public string remark { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

    }
}
