/// <reference path="typings/jquery/jquery.d.ts" />
var Staties = (function () {
    function Staties() {
        this.statie = new Statie();
    }
    Staties.prototype.load = function (id) {
        var _this = this;
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetPage/" + id, function (data) {
            _this.statie = data;
            _this.insertValues();
        });
    };
    Staties.prototype.insertValues = function () {
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
        p.children("a").last().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/DeleteP/" + this.statie.Id);
    };
    return Staties;
}());
var Warrings = (function () {
    function Warrings() {
        this.warrings = new Array(10);
    }
    Warrings.prototype.load = function (id) {
        var _this = this;
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetWarringPageList?pageNum=" + id, function (data) {
            _this.warrings = new Array(10);
            _this.warrings = data;
            console.log(data);
            _this.insertValues();
            $(".warSelectBut").removeClass("selectedBtn");
            $('.warSelectBut:contains(' + id + ')').addClass("selectedBtn");
        });
    };
    Warrings.prototype.insertValues = function () {
        var div = $(".warringPages").first().clone();
        $('.warringPages').remove();
        $('.wPage').append(div);
        div = $(".warringPages");
        for (var i = 0; i < 10; i++) {
            if (this.warrings[i] === undefined)
                break;
            var newDiv = div.clone();
            newDiv.show();
            newDiv.find("h5").first().html(this.warrings[i].Header);
            newDiv.find(".textSite").first().html(this.warrings[i].Text);
            newDiv.find(".dateOfCreating").last().html(this.warrings[i].Date);
            var p = newDiv.find(".linksWar");
            p.children("a").first().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/EditPage/" + this.warrings[i].Id);
            p.children("a").last().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/DeleteP/" + this.warrings[i].Id);
            newDiv.insertAfter(div);
            div = newDiv;
        }
    };
    return Warrings;
}());
var News = (function () {
    function News() {
        this.news = new Array(10);
    }
    News.prototype.load = function (id) {
        var _this = this;
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetNewsPageList?pageNum=" + id, function (data) {
            _this.news = new Array(10);
            _this.news = data;
            console.log(data);
            _this.insertValues();
            $(".newsSelectBut").removeClass("selectedBtn");
            $('.newsSelectBut:contains(' + id + ')').addClass("selectedBtn");
        });
    };
    News.prototype.insertValues = function () {
        var div = $(".newsPages").first().clone();
        $('.newsPages').remove();
        $('.nPage').append(div);
        div = $(".newsPages");
        for (var i = 0; i < 10; i++) {
            if (this.news[i] === undefined)
                break;
            var newDiv = div.clone();
            newDiv.show();
            newDiv.find("h5").first().html(this.news[i].Header);
            newDiv.find(".textSite").first().html(this.news[i].Text);
            newDiv.find(".dateOfCreating").last().html(this.news[i].Date);
            var p = newDiv.find(".linksNews");
            p.children("a").first().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/EditPage/" + this.news[i].Id);
            p.children("a").last().attr("href", window.location.protocol + "//" + window.location.host + "/Admin/DeleteP/" + this.news[i].Id);
            newDiv.insertAfter(div);
            div = newDiv;
        }
    };
    return News;
}());
var Statie = (function () {
    function Statie() {
    }
    return Statie;
}());
window.onload = function () {
    var array = $(".textSt");
    var textArray = $(".textSite");
    for (var i = 0; i < array.length; i++) {
        var statie = $(array[i]).attr("value");
        $(textArray[i]).html(statie);
    }
    var array = $(".textSt");
    setTimeout(function () {
        $(".youtube").css("height", $(".youtube").width() / 1.75);
        $(".youtubeAbout").css("height", $(".youtubeAbout").width() / 1.75);
    }, 50);
    var staties = new Staties();
    $('.statieBut').click(function (e) {
        var id;
        var parent = $(e.target).parent();
        if (parent.get(0).tagName == "BUTTON")
            parent = parent.parent();
        id = parent.children('.pId').val();
        staties.load(parseInt(id));
    });
    var warrings = new Warrings();
    $('.warSelectBut').click(function (e) {
        var id = parseInt($(e.target).text());
        warrings.load(id);
    });
    var news = new News();
    $('.newsSelectBut').click(function (e) {
        var id = parseInt($(e.target).text());
        news.load(id);
    });
    $('.warSelectBut').first().click();
    $('.newsSelectBut').first().click();
};
window.onresize = function () {
    $(".youtube").css("height", $(".youtube").width() / 1.75);
    $(".youtubeAbout").css("height", $(".youtubeAbout").width() / 1.75);
};
//# sourceMappingURL=PageScript.js.map