function printInvoke() {
    window.print();
}

function blazorGetTimezoneOffset() {
    return new Date().getTimezoneOffset();
}
//window.blazorGetTimezoneOffset = function () {
//    return new Date().getTimezoneOffset();
//};

window.onload = function () {
    Fancybox.bind("[data-fancybox]", {
        // Your custom options
    });
}