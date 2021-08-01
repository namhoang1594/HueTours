using Huetours.Models;
using Huetours.Services;
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
    public class SearchingResultController : RenderMvcController
    {
        private readonly ISearchService _searchService;

        public SearchingResultController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public ActionResult Index(ContentModel model, string query, string page)
        {
            var searchResultModel = new SearchContentModel(model.Content);

            var searchingViewModel = new SearchingViewModel()
            {
                Query = query,
                Page = page
            };

            if(!int.TryParse(page, out var pageNumber))
            {
                pageNumber = 1;
            }

            var searchResults = _searchService.GetPageOfContentSearchResults(query, pageNumber, 
                out var totalItemCount, null);

            searchResultModel.SearchingViewModel = searchingViewModel;

            searchResultModel.SearchResults = searchResults;

            return CurrentTemplate(searchResultModel);
        }
    }
}