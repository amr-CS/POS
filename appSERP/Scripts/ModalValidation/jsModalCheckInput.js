

// Check Modal Input
function funCheckModalInput() {

    // Triggered When Modal Try to Close
    $("#dataModal").one("hide.bs.modal", function (e) {

        // Is Valid Var
        var vIsValid = 1;

        // Check All Text Inputs
        $('input[type=text]').each(function () {

            // Get Current Element
            var vCurrentElement = $(this);
            // Get Current Value
            var vCurrentElementValue = vCurrentElement.val();
        
            // CheckCurrent Value
            if (vCurrentElementValue !== '') {

                vIsValid = 0;


            } // End Check Elements

        }) // End Check All Inputs


        if (vIsValid === 0) {
            // Confirm Close
            if (confirm('لم يتم حفظ البيانات, إستمرار الإغلاق؟')) {

                // Close [By Default It Will Close]

                return true;

            } else {

                // Cancel Closing Modal [Prevent Closing Event]
                e.preventDefault();

                // Return [Exit For Loop]
                return false;

            } // End Confirm Close
        }

    }); // End of Modal Closing Event

}