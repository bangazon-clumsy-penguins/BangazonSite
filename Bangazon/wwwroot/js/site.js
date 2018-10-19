// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let localCheck = document.getElementById('localCheck');
console.log(localCheck.checked);

let cityDiv = document.getElementById('city');

$(localCheck).on('click', (e) => {
    localCheck.checked ? cityDiv.style.display = "block" : cityDiv.style.display = "none";
    console.log(localCheck.checked);
})