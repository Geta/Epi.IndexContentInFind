define([
        "dojo/_base/declare",
        "geta-epi-indexcontentinfind/command/_IndexContentInFindCommandMixin",
        "epi/i18n!epi/cms/nls/geta.epi.indexcontentinfind.indexcontentinfindforcecommand"
],
    function(
        declare,
        _IndexContentInFindCommandMixin,
        resources
    ) {
        return declare("geta-epi-indexcontentinfind/command/IndexContentInFindForceCommand", [_IndexContentInFindCommandMixin], {
            name: "IndexContentInFindCommand",
            label: resources.label,
            tooltip: resources.tooltip,
            includeDescendants: false,
            force: true,
            resources: resources
        });
    });