using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Examine.Search;

namespace Huetours.Services
{
    public class SearchService : ISearchService
    {
        public IEnumerable<IPublishedContent> GetPageOfContentSearchResult(string searchTerm, int pageNumber, out long totalItemCount, string[] docTypeAliases, string searchType, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISearchResult> GetPageOfSearchResult(string searchTerm, int pageNumber, out long totalItemCount, string[] docTypeAliases, string searchType, int pageSize = 10)
        {
            int skip = pageNumber > 1 ? (pageNumber - 1) * pageSize : 0;

            if(ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index))
            {
                string[] terms = !string.IsNullOrEmpty(searchTerm) && searchTerm.Contains(" ")
                    ? searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    : !string.IsNullOrEmpty(searchTerm) ? new string[] { searchTerm } : null;

                var searcher = index.GetSearcher();
                var criteria = searcher.CreateQuery(searchType);
                var query = criteria.GroupedNot(new string[] { "umbracoNavihide" },
                    new string[] { "1" });

                if(terms != null && terms.Any())
                {
                    query.And(q => q.GroupedOr(new[] {"nodeName", "pageTitle", "subPageTitle", "content",
                    "descriptionSEO", "keywords"}, terms), BooleanOperation.Or);
                }

                if(docTypeAliases != null && docTypeAliases.Any())
                {
                    query.And(q => q.GroupedNot(new[] { "__NodeTypeAlias" }, docTypeAliases));
                }

                var allResults = query.Execute();
                totalItemCount = allResults.TotalItemCount;
                var pageOfResults = allResults.Skip(skip).Take(pageSize);
            }

            totalItemCount = 0;
            return Enumerable.Empty<ISearchResult>();
        }
    }
}