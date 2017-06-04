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
            if (indexService == null) throw new ArgumentNullException("indexService");
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

            if (data.IncludeDescendants)
            {
                indexingResults = IndexService.IndexFrom(data.ContentLink, data.Force);
            }
            else
            {
                indexingResults = IndexService.Index(data.ContentLink, data.Force);
            }

            return Rest(indexingResults);
        }
    }

    public class IndexInFindData
    {
        public ContentReference ContentLink { get; set; }
        public bool IncludeDescendants { get; set; }
        public bool Force { get; set; }
    }
}