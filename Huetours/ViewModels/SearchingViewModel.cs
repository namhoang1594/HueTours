using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Huetours.ViewModels
{
    public class SearchingViewModel
    {
        [Display(Name = "Search Term")]
        [Required(ErrorMessage = "You must enter a search term")]
        public string Query { get; set; }

        [Display(Name = "Search Page")]
        public string Page  { get; set; }

    }
}