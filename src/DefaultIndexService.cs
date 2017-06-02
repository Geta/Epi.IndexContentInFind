using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Find.Cms;
using EPiServer.ServiceLocation;

namespace Geta.Epi.IndexContentInFind
{
    [ServiceConfiguration(typeof(IIndexService), Lifecycle = ServiceInstanceScope.Hybrid)]
    public class DefaultIndexService : IIndexService
    {
        protected readonly IContentLoader ContentLoader;
        protected readonly IContentIndexer ContentIndexer;

        public DefaultIndexService(IContentLoader contentLoader, IContentIndexer contentIndexer)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (contentIndexer == null) throw new ArgumentNullException(nameof(contentIndexer));
            ContentLoader = contentLoader;
            ContentIndexer = contentIndexer;
        }

        public virtual IEnumerable<ContentIndexingResult> Index(ContentReference contentLink)
        {
            var content = ContentLoader.Get<IContent>(contentLink);
            return ContentIndexer.Index(content);
        }

        public virtual IEnumerable<ContentIndexingResult> IndexRecursive(ContentReference contentLink)
        {
            var mainContent = ContentLoader.Get<IContent>(contentLink);
            var contentReferencesToIndex = ContentLoader.GetDescendents(contentLink);
            var contentsToIndex = ContentLoader.GetItems(contentReferencesToIndex, CultureInfo.InvariantCulture).ToList();

            // Add main content to list
            contentsToIndex.Insert(0, mainContent);

            return ContentIndexer.Index(contentsToIndex);
        }
    }
}