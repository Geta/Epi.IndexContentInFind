define([
    "dojo",
    "dojo/_base/declare",
    "epi/shell/command/_CommandProviderMixin",
    "geta-epi-indexcontentinfind/command/IndexContentInFindCommand",
    "geta-epi-indexcontentinfind/command/IndexContentInFindRecursiveCommand",
    "geta-epi-indexcontentinfind/command/IndexContentInFindForceCommand"
],
function (
    dojo,
    declare,
    _CommandProviderMixin,
    IndexContentInFindCommand,
    IndexContentInFindRecursiveCommand,
    IndexContentInFindForceCommand
) {
    return declare("geta-epi-indexcontentinfind/command/ToolsMenuCommandProvider", [_CommandProviderMixin], {

        constructor: function () {
            this.inherited(arguments);

            this.add("commands", new IndexContentInFindCommand());
            this.add("commands", new IndexContentInFindRecursiveCommand());
            this.add("commands", new IndexContentInFindForceCommand());
        }
    });
});