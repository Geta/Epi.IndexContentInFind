define([
    "dojo",
    "dojo/_base/declare",
    "epi/_Module",
    "epi/dependency",
    "epi/routes",
    "geta-epi-indexcontentinfind/command/ToolsMenuCommandProvider"
], function (
    dojo,
    declare,
    _Module,
    dependency,
    routes,
    ToolsMenuCommandProvider
) {
    return declare("geta-epi-indexcontentinfind/CommandsInitializer", [_Module], {
        initialize: function () {
            this.inherited(arguments);
            var commandregistry = dependency.resolve("epi.globalcommandregistry");
            var area = "epi.cms.contentdetailsmenu";
            commandregistry.registerProvider(area, new ToolsMenuCommandProvider());

            var storeRegistry = this.resolveDependency("epi.storeregistry");
            storeRegistry.create("indexcontentstore", this._getRestPath("indexcontentstore"));
        },

        _getRestPath: function (storeName) {
            return routes.getRestPath({ moduleArea: "geta-epi-indexcontentinfind", storeName: storeName });
        }
    });
});