define([
        "dojo/_base/declare",
        "geta-epi-indexcontentinfind/command/_IndexContentInFindCommandMixin",
        "epi/i18n!epi/cms/nls/geta.epi.indexcontentinfind.indexcontentinfinddescendantsforcecommand"
],
    function (
        declare,
        _IndexContentInFindCommandMixin,
        resources
    ) {
        return declare("geta-epi-indexcontentinfind/command/IndexContentInFindDescendantsForceCommand", [_IndexContentInFindCommandMixin], {
            name: "IndexContentInFindDescendantsForceCommand",
            label: resources.label,
            tooltip: resources.tooltip,
            includeDescendants: true,
            force: true,
            resources: resources
        });
    });