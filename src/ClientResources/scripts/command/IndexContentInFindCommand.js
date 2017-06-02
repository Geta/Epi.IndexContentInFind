define([
        "dojo/_base/declare",
        "geta-epi-indexcontentinfind/command/_IndexContentInFindCommandMixin",
        "epi/i18n!epi/cms/nls/geta.epi.indexcontentinfind.indexcontentinfindcommand"
],
    function(
        declare,
        _IndexContentInFindCommandMixin,
        resources
    ) {
        return declare("geta-epi-indexcontentinfind/command/IndexContentInFindCommand", [_IndexContentInFindCommandMixin], {
            name: "IndexContentInFindCommand",
            label: resources.label,
            tooltip: resources.tooltip,
            recursive: false,
            resources: resources
        });
    });