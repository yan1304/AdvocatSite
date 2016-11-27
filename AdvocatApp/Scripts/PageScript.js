/// <reference path="typings/jquery/jquery.d.ts" />
window.onload = () => {
    var array = $(".textSt");
    var textArray = $(".textSite");
    for (let i = 0; i < array.length; i++) {
        let statie = array[i].getAttribute("value");
        textArray[i].innerHTML = statie;
    }
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
};
//# sourceMappingURL=PageScript.js.map