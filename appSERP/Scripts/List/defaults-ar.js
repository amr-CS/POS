(function (root, factory) {
    if (root === undefined && window !== undefined) root = window;
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module unless amdModuleId is set
        define(["jquery"], function (a0) {
            return (factory(a0));
        });
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(require("jquery"));
    } else {
        factory(root["jQuery"]);
    }
}(this, function (jQuery) {

    /*!
     * Translated default messages for bootstrap-select.
     * Locale: AR (Arabic)
     * Author: Yasser Lotfy <y_l@alive.com>
     */
    (function ($) {
        $.fn.selectpicker.defaults = {
            noneSelectedText: 'لم يتم إختيار شئ',
            noneResultsText: 'لا يوجد نتائج بحث',
            countSelectedText: function (numSelected, numTotal) {
                return (numSelected == 1) ? '{0} Ø®ÙŠØ§Ø± ØªÙ… Ø¥Ø®ØªÙŠØ§Ø±Ù‡' : '{0} Ø®ÙŠØ§Ø±Ø§Øª ØªÙ…Øª Ø¥Ø®ØªÙŠØ§Ø±Ù‡Ø§';
            },
            maxOptionsText: function (numAll, numGroup) {
                return [
                    (numAll == 1) ? 'ØªØ®Ø·Ù‰ Ø§Ù„Ø­Ø¯ Ø§Ù„Ù…Ø³Ù…ÙˆØ­ ({n} Ø®ÙŠØ§Ø± Ø¨Ø­Ø¯ Ø£Ù‚ØµÙ‰)' : 'ØªØ®Ø·Ù‰ Ø§Ù„Ø­Ø¯ Ø§Ù„Ù…Ø³Ù…ÙˆØ­ ({n} Ø®ÙŠØ§Ø±Ø§Øª Ø¨Ø­Ø¯ Ø£Ù‚ØµÙ‰)',
                    (numGroup == 1) ? 'ØªØ®Ø·Ù‰ Ø§Ù„Ø­Ø¯ Ø§Ù„Ù…Ø³Ù…ÙˆØ­ Ù„Ù„Ù…Ø¬Ù…ÙˆØ¹Ø© ({n} Ø®ÙŠØ§Ø± Ø¨Ø­Ø¯ Ø£Ù‚ØµÙ‰)' : 'ØªØ®Ø·Ù‰ Ø§Ù„Ø­Ø¯ Ø§Ù„Ù…Ø³Ù…ÙˆØ­ Ù„Ù„Ù…Ø¬Ù…ÙˆØ¹Ø© ({n} Ø®ÙŠØ§Ø±Ø§Øª Ø¨Ø­Ø¯ Ø£Ù‚ØµÙ‰)'
                ];
            },
            selectAllText: 'إختيار الكل',
            deselectAllText: 'إلغاء الإختيار',
            multipleSeparator: ', '
        };
    })(jQuery);


}));