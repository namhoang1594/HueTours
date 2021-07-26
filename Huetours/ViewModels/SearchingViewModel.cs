using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Huetours.ViewModels
{
    public class SearchingViewModel
    {
        [Display(Name = "Searching....")]
        public string Query { get; set; }
    }
}