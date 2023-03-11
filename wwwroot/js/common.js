function printInvoke() {
    window.print();
}


window.blazorGetTimezoneOffset = function () {
    return new Date().getTimezoneOffset();
};

window.onload = function () {
    Fancybox.bind("[data-fancybox]", {
        // Your custom options
    });
}