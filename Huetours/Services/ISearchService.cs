using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace Huetours.Services
{
    public interface ISearchService
    {
        IEnumerable<ISearchResult> GetPageOfSearchResults(string searchTerm, int pageNumber,
            out long totalItemCount, string[] docTypeAliases, 
            string searchType, int pageSize = 10);

        IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string searchTerm, int pageNumber,
            out long totalItemCount, string[] docTypeAliases, int pageSize = 10);
    }
}