﻿/// <reference path="typings/jquery/jquery.d.ts" />

window.onload = () => {
    var array = $(".textSt");
    var textArray = $(".textSite");
    for (let i: number = 0; i < array.length; i++) {
        let statie: string = array[i].getAttribute("value");
        textArray[i].innerHTML = statie;
    }

    var youtubeFrame = $(".youtube");
    if (youtubeFrame !== undefined && youtubeFrame.length > 0) {
        youtubeFrame.each((i, elem) => {
            if (innerWidth < 768) {
                elem.setAttribute("width", (innerWidth / 1.2).toString());
            }
            else {
                elem.setAttribute("width", (innerWidth / 3.3).toString());
            }
            elem.setAttribute("height", (parseInt(elem.getAttribute("width"))/1.75).toString());
        });
    }
};

window.onresize = () => {
    var youtubeFrame = $(".youtube");
    if (youtubeFrame !== undefined && youtubeFrame.length > 0) {
        youtubeFrame.each((i, elem) => {
            if (innerWidth < 768) {
                elem.setAttribute("width", (innerWidth / 1.2).toString());
            }
            else {
                elem.setAttribute("width", (innerWidth / 3.3).toString());
            }
            elem.setAttribute("height", (parseInt(elem.getAttribute("width")) / 1.75).toString());
        });
    }
};