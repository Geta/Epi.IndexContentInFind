define([
    "dojo",
    "dojo/_base/declare",
    "epi/shell/command/_CommandProviderMixin",
    "geta-epi-indexcontentinfind/command/IndexContentInFindCommand",
    "geta-epi-indexcontentinfind/command/IndexContentInFindDescendantsCommand",
    "geta-epi-indexcontentinfind/command/IndexContentInFindForceCommand",
    "geta-epi-indexcontentinfind/command/IndexContentInFindDescendantsForceCommand"
],
function (
    dojo,
    declare,
    _CommandProviderMixin,
    IndexContentInFindCommand,
    IndexContentInFindDescendantsCommand,
    IndexContentInFindForceCommand,
    IndexContentInFindDescendantsForceCommand
) {
    return declare("geta-epi-indexcontentinfind/command/ToolsMenuCommandProvider", [_CommandProviderMixin], {

        constructor: function () {
            this.inherited(arguments);

            this.add("commands", new IndexContentInFindCommand());
            this.add("commands", new IndexContentInFindForceCommand());
            this.add("commands", new IndexContentInFindDescendantsCommand());
            this.add("commands", new IndexContentInFindDescendantsForceCommand());
        }
    });
});