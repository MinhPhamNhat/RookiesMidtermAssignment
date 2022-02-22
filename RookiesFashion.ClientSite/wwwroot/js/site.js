// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('.dropdown-toggle').on('click', function (e) {
    var el = this.nextElementSibling
    el.style.display = el.style.display==='block'?'none':'block'
    
   
})