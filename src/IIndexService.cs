using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Find.Cms;

namespace Geta.Epi.IndexContentInFind
{
    public interface IIndexService
    {
        IEnumerable<ContentIndexingResult> Index(ContentReference contentLink, bool ignoreConventions);
        IEnumerable<ContentIndexingResult> IndexFrom(ContentReference contentLink, bool ignoreConventions);
    }
}