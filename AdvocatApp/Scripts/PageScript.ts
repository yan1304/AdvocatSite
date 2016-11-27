/// <reference path="typings/jquery/jquery.d.ts" />

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
                elem.setAttribute("width", (innerWidth / 1.3).toString());
            }
            else {
                elem.setAttribute("width", (innerWidth /2.58).toString());
            }
            elem.setAttribute("height", (parseInt(elem.getAttribute("width"))/1.75).toString());
        });
    }
    if (innerWidth < 600) {
        $("h1").css("font-size", 20);
    }
};

window.onresize = () => {
    var youtubeFrame = $(".youtube");
    if (youtubeFrame !== undefined && youtubeFrame.length > 0) {
        youtubeFrame.each((i, elem) => {
            if (innerWidth < 768) {
                elem.setAttribute("width", (innerWidth / 1.3).toString());
            }
            else {
                elem.setAttribute("width", (innerWidth / 2.58).toString());
            }
            elem.setAttribute("height", (parseInt(elem.getAttribute("width")) / 1.75).toString());
        });
    }
    if (innerWidth < 768) {
        $("h1").css("font-size", 20);
        $(".navbar-default h2").css("font-size", 20);
        $(".navbar-default h2").css("margin", 10);
    }
    else
    {
        $("h1").css("font-size", 40);
        $(".navbar-default h2").css("font-size", 30);
        $(".navbar-default h2").css("margin", "auto");
        $(".navbar-default h2").css("margin-top", 20);
        $(".navbar-default h2").css("margin-bottom", 10);
        
    }
};