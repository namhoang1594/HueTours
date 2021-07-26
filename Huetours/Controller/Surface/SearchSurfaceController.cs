using Huetours.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Huetours.Controller.Surface
{
    public class SearchSurfaceController : SurfaceController
    {
        public ActionResult SubmitForm(SearchingViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var queryString = new NameValueCollection();
            if(!string.IsNullOrWhiteSpace(model.Query))
            {
                queryString.Add("query", model.Query);
            }

            return RedirectToCurrentUmbracoPage(queryString);
        }
    }
}