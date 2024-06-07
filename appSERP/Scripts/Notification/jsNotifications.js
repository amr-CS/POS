
/// <reference path="../jquery-3.3.1.js" />
/// <reference path="jquery.toast.js" />

// Notification Message
function funNotification(pMessage, pStatusId) {
    // Check Text
    if (pMessage == '') {
        return;
    }
    // Success
    var vStatusColor = '#28a745';
    // Check if Not Success
    if (pStatusId == 2) {
        // Warning
        vStatusColor = '#f39c12';
    }
    else if (pStatusId == 3) {
        // Danger
        vStatusColor = '#c0392b';
    }

    // Notification [Right to Left]
    $.toast({
        text: pMessage,
        bgColor: vStatusColor,
        loaderBg: '#007bff',
        hideAfter: 3500,
        allowToastClose: false,
        textAlign: 'right',
        heading: '',
        showHideTransition: 'slide',
        icon: 'info'
    });
}
