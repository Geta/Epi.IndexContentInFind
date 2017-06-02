using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Find.Cms;

namespace Geta.Epi.IndexContentInFind
{
    public interface IIndexService
    {
        IEnumerable<ContentIndexingResult> Index(ContentReference contentLink);
        IEnumerable<ContentIndexingResult> IndexRecursive(ContentReference contentLink);
    }
}