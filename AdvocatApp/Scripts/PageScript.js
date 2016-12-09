/// <reference path="typings/jquery/jquery.d.ts" />
class Staties {
    constructor() {
        this.statie = new Statie();
    }
    load(id) {
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetPage/" + id, (data) => {
            this.statie = data;
            this.insertValues();
        });
    }
    insertValues() {
        var page = $("#pageTextVideo").find(".pages");
        page.find("h5").first().html(this.statie.Header);
        var youtube = page.find(".youtube").first();
        if (typeof (youtube.attr("src")) == "undefined") {
            if (typeof (this.statie.VideoURL) == "undefined") {
                if (this.statie.VideoURL != "") {
                    page.find("h5").first().after('<iframe class="youtube" frameborder="0" src="' + this.statie.VideoURL
                        + '" allowfullscreen> </iframe>');
                }
            }
        }
        else {
            if (typeof (this.statie.VideoURL) != "undefined") {
                if (this.statie.VideoURL != "" && this.statie.VideoURL != null) {
                    youtube.attr("src", this.statie.VideoURL);
                }
                else {
                    youtube.css("width", "0px");
                    youtube.css("height", "0px");
                    youtube.css("border", "none");
                }
            }
            else {
                youtube.css("width", "0px");
                youtube.css("height", "0px");
                youtube.css("border", "none");
            }
        }
        page.find(".textSite").first().html(this.statie.Text);
        page.find(".dateOfCreating").last().html(this.statie.Date);
        var p = page.find(".linksPage");
        p.children("a").first().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/EditPage/" + this.statie.Id);
        p.children("a").last().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/DeletePage/" + this.statie.Id);
    }
}
class Warrings {
    constructor() {
        this.warrings = new Array(10);
    }
    load(id) {
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetWarringPageList?pageNum=" + id, (data) => {
            this.warrings = new Array(10);
            this.warrings = data;
            console.log(data);
            this.insertValues();
            $(".warSelectBut").removeClass("selectedBtn");
            $('.warSelectBut:contains(' + id + ')').addClass("selectedBtn");
        });
    }
    insertValues() {
        var div = $(".warringPages").first().clone();
        $('.warringPages').remove();
        $('.wPage').append(div);
        div = $(".warringPages");
        for (let i = 0; i < 10; i++) {
            if (this.warrings[i] === undefined)
                break;
            var newDiv = div.clone();
            newDiv.show();
            newDiv.find("h5").first().html(this.warrings[i].Header);
            newDiv.find(".textSite").first().html(this.warrings[i].Text);
            newDiv.find(".dateOfCreating").last().html(this.warrings[i].Date);
            var p = newDiv.find(".linksWar");
            p.children("a").first().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/EditPage/" + this.warrings[i].Id);
            p.children("a").last().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/DeletePage/" + this.warrings[i].Id);
            newDiv.insertAfter(div);
            div = newDiv;
        }
    }
}
class News {
    constructor() {
        this.news = new Array(10);
    }
    load(id) {
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetNewsPageList?pageNum=" + id, (data) => {
            this.news = new Array(10);
            this.news = data;
            console.log(data);
            this.insertValues();
            $(".newsSelectBut").removeClass("selectedBtn");
            $('.newsSelectBut:contains(' + id + ')').addClass("selectedBtn");
        });
    }
    insertValues() {
        var div = $(".newsPages").first().clone();
        $('.newsPages').remove();
        $('.nPage').append(div);
        div = $(".newsPages");
        for (let i = 0; i < 10; i++) {
            if (this.news[i] === undefined)
                break;
            var newDiv = div.clone();
            newDiv.show();
            newDiv.find("h5").first().html(this.news[i].Header);
            newDiv.find(".textSite").first().html(this.news[i].Text);
            newDiv.find(".dateOfCreating").last().html(this.news[i].Date);
            var p = newDiv.find(".linksNews");
            p.children("a").first().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/EditPage/" + this.news[i].Id);
            p.children("a").last().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/DeletePage/" + this.news[i].Id);
            newDiv.insertAfter(div);
            div = newDiv;
        }
    }
}
class Statie {
}
window.onload = () => {
    var array = $(".textSt");
    var textArray = $(".textSite");
    for (let i = 0; i < array.length; i++) {
        let statie = $(array[i]).attr("value");
        $(textArray[i]).html(statie);
    }
    var array = $(".textSt");
    setTimeout(() => {
        $(".youtube").css("height", $(".youtube").width() / 1.75);
        $(".youtubeAbout").css("height", $(".youtubeAbout").width() / 1.75);
    }, 50);
    var staties = new Staties();
    $('.statieBut').click((e) => {
        var id;
        var parent = $(e.target).parent();
        if (parent.get(0).tagName == "BUTTON")
            parent = parent.parent();
        id = parent.children('.pId').val();
        staties.load(parseInt(id));
    });
    var warrings = new Warrings();
    $('.warSelectBut').click((e) => {
        var id = parseInt($(e.target).text());
        warrings.load(id);
    });
    var news = new News();
    $('.newsSelectBut').click((e) => {
        var id = parseInt($(e.target).text());
        news.load(id);
    });
    $('.warSelectBut').first().click();
    $('.newsSelectBut').first().click();
};
window.onresize = () => {
    $(".youtube").css("height", $(".youtube").width() / 1.75);
    $(".youtubeAbout").css("height", $(".youtubeAbout").width() / 1.75);
};
//# sourceMappingURL=PageScript.js.map