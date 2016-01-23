using System;
using System.ComponentModel.DataAnnotations;

namespace AIS.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Company or Industry")]
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Interest { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}