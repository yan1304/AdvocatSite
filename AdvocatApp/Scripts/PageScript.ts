/// <reference path="typings/jquery/jquery.d.ts" />

window.onload = () => {
    //let s: string = document.getElementById("textSt")
    //    .getAttribute("value");
    //document.getElementById("textSite").innerHTML = s;
    let statie: string = $("#textSt").val();
    $("#textSite").html(statie);
};