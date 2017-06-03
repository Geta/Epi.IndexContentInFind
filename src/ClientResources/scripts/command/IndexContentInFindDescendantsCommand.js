define([
        "dojo/_base/declare",
        "geta-epi-indexcontentinfind/command/_IndexContentInFindCommandMixin",
        "epi/i18n!epi/cms/nls/geta.epi.indexcontentinfind.indexcontentinfinddescendantscommand"
],
    function (
        declare,
        _IndexContentInFindCommandMixin,
        resources
    ) {
        return declare("geta-epi-indexcontentinfind/command/IndexContentInFindDescendantsCommand", [_IndexContentInFindCommandMixin], {
            name: "IndexContentInFindDescendantsCommand",
            label: resources.label,
            tooltip: resources.tooltip,
            includeDescendants: true,
            resources: resources
        });
    });