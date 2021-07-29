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
        IEnumerable<ISearchResult> GetPageOfSearchResult(string searchTerm, out long totalItemCount,
            string[] docTypeAliases, string searchType, int pageSize = 10);

        IEnumerable<IPublishedContent> GetPageOfContentSearchResult(string searchTerm, out long totalItemCount,
            string[] docTypeAliases, string searchType, int pageSize = 10);
    }
}