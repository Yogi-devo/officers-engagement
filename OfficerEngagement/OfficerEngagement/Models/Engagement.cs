using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfficerEngagement.Models
{
    public class Engagement
    {
        [Key]
        public int EngId { get; set; }
        [Display(Name ="Officer Name")]
        public string OfficerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public string Time { get; set; }
        public string Venue { get; set; }
        [Display(Name ="Chair By")]
        public string ChairBy { get; set; }
        public string Agenda { get; set; }

        public int Status { get; set; }

    }
}
