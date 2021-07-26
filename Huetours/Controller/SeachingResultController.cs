using Huetours.Models;
using Huetours.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Huetours.Controller
{
    public class SeachingResultController : RenderMvcController
    {
        public ActionResult Index(ContentModel model, string query)
        {
            var searchResultModel = new SearchContentModel(model.Content);
            var searchingViewModel = new SearchingViewModel()
            {
                Query = query
            };

            searchResultModel.SearchingViewModel = searchingViewModel;

            return CurrentTemplate(model);
        }
    }
}