using Huetours.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Huetours.Models
{
    public class SearchContentModel : ContentModel
    {
        public SearchContentModel(IPublishedContent content) : base(content)
        {

        }

        public SearchingViewModel SearchingViewModel { get; set; }

        public IEnumerable<IPublishedContent> SearchResults { get; set; }
    }
}