using System;
using System.Net;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Shell.Services.Rest;

namespace Geta.Epi.IndexContentInFind.Rest
{
    [RestStore("indexcontentstore")]
    public class IndexContentStore : RestControllerBase
    {
        private readonly IIndexService _indexService;

        public IndexContentStore(IIndexService indexService)
        {
            _indexService = indexService ?? throw new ArgumentNullException(nameof(indexService));
        }

        [HttpPost]
        public virtual ActionResult Post(IndexInFindRequest data)
        {
            if (data == null || ContentReference.IsNullOrEmpty(data.ContentLink))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ContentLink cannot be null.");
            }

            var indexingResults = data.IncludeDescendants
                ? _indexService.IndexFrom(data.ContentLink, data.Force)
                : _indexService.Index(data.ContentLink, data.Force);

            return Rest(indexingResults);
        }
    }

    public class IndexInFindRequest
    {
        public ContentReference ContentLink { get; set; }
        public bool IncludeDescendants { get; set; }
        public bool Force { get; set; }
    }
}