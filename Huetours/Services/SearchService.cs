using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Examine.Search;
using Umbraco.Web;
using Lucene.Net.Analysis;
using Huetours.Extensions;

namespace Huetours.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        public SearchService(IUmbracoContextAccessor umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }
        public IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string searchTerm, 
            int pageNumber, out long totalItemCount, string[] docTypeAliases, 
            int pageSize = 10)
        {
            var pageOfResults = GetPageOfSearchResults(searchTerm, pageNumber,
                out totalItemCount, null, "content");

            var items = new List<IPublishedContent>();
            if(pageOfResults != null && pageOfResults.Any())
            {
                foreach(var item in pageOfResults)
                {
                    var page = _umbracoContextAccessor.UmbracoContext.Content.GetById(int.Parse(item.Id));
                    if(page != null)
                    {
                        items.Add(page);
                    }
                }
            }
            return items;
        }

        public IEnumerable<ISearchResult> GetPageOfSearchResults (string searchTerm, 
            int pageNumber, out long totalItemCount, string[] docTypeAliases,
            string searchType, int pageSize = 10)
        {
            int skip = pageNumber > 1 ? (pageNumber - 1) * pageSize : 0;

            string[] terms = !string.IsNullOrEmpty(searchTerm) && searchTerm.Contains(" ")
                ? searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                : !string.IsNullOrWhiteSpace(searchTerm) ? new string[] { searchTerm } : null;

            if(terms != null && terms.Any() && ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index))
            {
                if (terms != null && terms.Any()) 
                { 
                terms = terms.Where(x => !StopAnalyzer.ENGLISH_STOP_WORDS_SET.Contains(x.ToLower()) &&
                    x.Length > 2).ToArray();
                }

                var searcher = index.GetSearcher();
                var criteria = searcher.CreateQuery(searchType);
                var query = criteria.GroupedNot(new string[] { "umbracoNavihide" },
                    new string[] { "1" });

                if(terms != null && terms.Any())
                {
                    query.And(q => q.GroupedOr(new[] {"nodeName" }, terms.Boost(10)).Or()
                    .GroupedOr(new[] { "pageTitle" }, terms.Boost(9)).Or()
                    .GroupedOr(new[] { "subPageTitle" }, terms.Boost(8)).Or()
                    .GroupedOr(new[] { "content" }, terms.Boost(7)).Or()
                    .GroupedOr(new[] { "descriptionSEO" }, terms.Boost(6)).Or()
                    .GroupedOr(new[] { "keywords" }, terms.Boost(5)).Or()
                    .GroupedOr(new[] {"nodeName", "pageTitle", "subPageTitle", "content",
                    "descriptionSEO", "keywords"}, terms.Fuzzy()), BooleanOperation.Or);
                }

                if(docTypeAliases != null && docTypeAliases.Any())
                {
                    query.And(q => q.GroupedOr(new[] { "__NodeTypeAlias" }, docTypeAliases));
                }

                var allResults = query.Execute();
                totalItemCount = allResults.TotalItemCount;
                var pageOfResults = allResults.Skip(skip).Take(pageSize);

                return pageOfResults;
            }

            totalItemCount = 0;
            return Enumerable.Empty<ISearchResult>();
        }
    }
}