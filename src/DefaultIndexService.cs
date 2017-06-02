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
        private readonly IContentLoader _contentLoader;
        private readonly IContentIndexer _contentIndexer;

        public DefaultIndexService(IContentLoader contentLoader, IContentIndexer contentIndexer)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (contentIndexer == null) throw new ArgumentNullException(nameof(contentIndexer));
            _contentLoader = contentLoader;
            _contentIndexer = contentIndexer;
        }

        public IEnumerable<ContentIndexingResult> Index(ContentReference contentLink)
        {
            var content = _contentLoader.Get<IContent>(contentLink);
            return _contentIndexer.Index(content);
        }

        public IEnumerable<ContentIndexingResult> IndexRecursive(ContentReference contentLink)
        {
            var mainContent = _contentLoader.Get<IContent>(contentLink);
            var contentReferencesToIndex = _contentLoader.GetDescendents(contentLink);
            var contentsToIndex = _contentLoader.GetItems(contentReferencesToIndex, CultureInfo.InvariantCulture).ToList();

            // Add main content to list
            contentsToIndex.Insert(0, mainContent);

            return _contentIndexer.Index(contentsToIndex);
        }
    }
}