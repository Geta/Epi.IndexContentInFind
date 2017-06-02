using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Find.Cms;
using EPiServer.Shell.Services.Rest;

namespace Geta.Epi.IndexContentInFind.Rest
{
    [RestStore("indexcontentstore")]
    public class IndexContentStore : RestControllerBase
    {
        protected readonly IIndexService IndexService;

        public IndexContentStore(IIndexService indexService)
        {
            if (indexService == null) throw new ArgumentNullException(nameof(indexService));
            IndexService = indexService;
        }

        [HttpPost]
        public virtual ActionResult Post(IndexInFindData data)
        {
            if (data == null || ContentReference.IsNullOrEmpty(data.ContentLink))
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "ContentLink cannot be null.");
            }

            IEnumerable<ContentIndexingResult> indexingResults;

            if (data.Recursive)
            {
                indexingResults = IndexService.IndexRecursive(data.ContentLink);
            }
            else
            {
                indexingResults = IndexService.Index(data.ContentLink);
            }

            return Rest(indexingResults);
        }
    }

    public class IndexInFindData
    {
        public ContentReference ContentLink { get; set; }
        public bool Recursive { get; set; }
    }
}