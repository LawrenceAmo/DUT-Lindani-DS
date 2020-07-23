using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lindaniDS.Models
{
    public class BookingPackages
    {
        [Key]
        public int packageID { get; set; }

        [Required]
        [Display(Name = "Package Name")]
        public string packageName { get; set; }

        [Required]
        [Display(Name = "Package Cost")]
        public string cost { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Package Availability")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime availabilityDate { get; set; }

    }
}