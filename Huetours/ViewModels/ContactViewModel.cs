using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Huetours.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}