using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace lindaniDS.Models
{
    public class VehicleHire
    {
        [Key]
        public int vehicleID { get; set; }


        [ForeignKey("VehicleModel")]
        [Display(Name = "Car Model")]
        public int modelID { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please provide with valid E-mail!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Car Color")]
        public string color { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string regNo { get; set; }

        [Required]
        [Display(Name = "Car Number Plate")]
        public string noPlate { get; set; }

        [Required]
        [Display(Name = "Car Hire Cost")]
        public decimal cost { get; set; }

        [Required]
        [Display(Name = "Condition of the Car")]
        public string condition { get; set; }

        [Required]
        [Display(Name = "Is This Car Available?")]
        public bool availability { get; set; }
    }
}