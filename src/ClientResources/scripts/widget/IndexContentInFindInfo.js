define([
    "dojo/_base/declare",
    "dojo/_base/lang",
    "dojo/_base/array",
    "dijit/layout/_LayoutWidget",
    "dijit/_TemplatedMixin",
    "epi/i18n!epi/cms/nls/geta.epi.indexcontentinfind.indexcontentinfindinfo",
    "dojo/text!./templates/IndexContentInFindInfo.html"
],
    function (
        declare,
        lang,
        array,
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
                var successfulCount = 0,
                    excludedCount = 0,
                    errorCount = 0;

                array.forEach(indexingResult, function (item) {
                    if (item.ok) {
                        successfulCount++;
                    }
                    else if (item.excludedByConventions === false) {
                        errorCount++;
                    }

                    if (item.excludedByConventions) {
                        excludedCount++;
                    }
                }, this);

                var resultText = resources.resulttext;
                resultText = resultText.replace('{0}', successfulCount);
                resultText = resultText.replace('{1}', excludedCount);
                resultText = resultText.replace('{2}', errorCount);

                this.set('text', resultText);
            },

            _setTextAttr: function(text) {
                this.textNode.innerHTML = text;
            }
        });
    });