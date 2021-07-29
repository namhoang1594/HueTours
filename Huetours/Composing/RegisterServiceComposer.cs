using Huetours.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Composing;
using Umbraco.Core;

namespace Huetours.Composing
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class RegisterServiceComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<ISearchService, SearchService>(Lifetime.Request);
        }
    }
}