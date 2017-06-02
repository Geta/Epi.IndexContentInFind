using System.Web.Hosting;
using EPiServer.Framework.TypeScanner;
using EPiServer.Shell.Modules;

namespace Geta.Epi.IndexContentInFind
{
    public class IndexContentInFindModule : ShellModule
    {
        public IndexContentInFindModule(string name, string routeBasePath, string resourceBasePath) : base(name, routeBasePath, resourceBasePath)
        {
        }

        public IndexContentInFindModule(string name, string routeBasePath, string resourceBasePath, ITypeScannerLookup typeScannerLookup, VirtualPathProvider virtualPathProvider) : base(name, routeBasePath, resourceBasePath, typeScannerLookup, virtualPathProvider)
        {
        }
    }
}