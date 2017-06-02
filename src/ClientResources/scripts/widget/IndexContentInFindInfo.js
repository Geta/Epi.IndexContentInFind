define([
    "dojo/_base/declare",
    "dojo/_base/lang",
    "dijit/layout/_LayoutWidget",
    "dijit/_TemplatedMixin",
    "epi/i18n!epi/cms/nls/geta.epi.indexcontentinfind.indexcontentinfindinfo",
    "dojo/text!./templates/IndexContentInFindInfo.html"
],
    function (
        declare,
        lang,
        _LayoutWidget,
        _TemplatedMixin,
        resources,
        template
    ) {
        return declare("geta-epi-indexcontentinfind/widget/IndexContentInFindInfo", [_LayoutWidget, _TemplatedMixin], {
            name: "IndexContentInFindCommand",
            recursive: false,
            text: resources.text,
            textNode: null,
            templateString: template,

            postCreate: function () {
                this.inherited(arguments);

                if (this.recursive) {
                    this.set('text', resources.recursivetext);
                }
            },

            showResult: function (indexingResult) {
                this.set('text', resources.resulttext.replace('{0}', indexingResult.length));
            },

            _setTextAttr: function(text) {
                this.textNode.innerHTML = text;
            }
        });
    });