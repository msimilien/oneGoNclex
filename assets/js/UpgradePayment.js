$(function () {
    if (document.cookie.indexOf("userData") !== -1) {
        $("#loginAction").fadeIn();
    } else {
        $("#loginAction").fadeOut();
    }
});

function collapse() {
    $('#collapseOptions').collapse('toggle');
}

function logoff() {
    location.href = "/banks?dc=1";
}

function goSettings() {
    location.href = "/bankquestions/upgradepayment?" + location.href.split('?')[1];
}