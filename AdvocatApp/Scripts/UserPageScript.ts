/// <reference path="typings/jquery/jquery.d.ts" />
interface ILoadJSON {
    load(id: number): void;
    insertValues(): void;
}

class StatieU {
    Id: number;
    VideoURL: string;
    Header: string;
    Date: string;
    Text: string;
}
class UserStaties implements ILoadJSON {

    private statie: StatieU = new StatieU();

    load(id: number): void {
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetPage/" + id,
            (data) => {
                this.statie = data;
                this.insertValues();
            });
    }


    insertValues(): void {
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
    }
}

class UserWarrings implements ILoadJSON {
    private warrings: StatieU[] = new Array<StatieU>(10);

    load(id: number): void {
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetWarringPageList?pageNum=" + id,
            (data) => {
                this.warrings = new Array<StatieU>(10);
                this.warrings = data;
                this.insertValues();
                $(".warSelectBut").removeClass("selectedBtn");
                $('.warSelectBut:contains(' + id + ')').addClass("selectedBtn");
            });
    }

    insertValues(): void {
        var div = $(".warringPages").first().clone();

        $('.warringPages').remove();
        $('.wPage').append(div);
        div = $(".warringPages");
        for (let i: number = 0; i < 10; i++) {
            if (this.warrings[i] === undefined)
                break;

            var newDiv = div.clone();
            newDiv.show();

            newDiv.find("h5").first().html(this.warrings[i].Header);
            newDiv.find(".textSite").first().html(this.warrings[i].Text);
            newDiv.find(".dateOfCreating").last().html(this.warrings[i].Date);

            newDiv.insertAfter(div);
            div = newDiv;
        }

    }
}

class UserNews implements ILoadJSON {
    private news: StatieU[] = new Array<StatieU>(10);
    load(id: number): void {
        $.getJSON(window.location.protocol + "//" + window.location.host + "/Admin/GetWarringPageList?pageNum=" + id,
            (data) => {
                this.news = new Array<StatieU>(10);
                this.news = data;
                this.insertValues();
                $(".newsSelectBut").removeClass("selectedBtn");
                $('.newsSelectBut:contains(' + id + ')').addClass("selectedBtn");
            });
    }

    insertValues(): void {
        var div = $(".newsPages").first().clone();

        $('.newsPages').remove();
        $('.nPage').append(div);
        div = $(".newsPages");
        for (let i: number = 0; i < 10; i++) {
            if (this.news[i] === undefined)
                break;

            var newDiv = div.clone();
            newDiv.show();

            newDiv.find("h5").first().html(this.news[i].Header);
            newDiv.find(".textSite").first().html(this.news[i].Text);
            newDiv.find(".dateOfCreating").last().html(this.news[i].Date);

            newDiv.insertAfter(div);
            div = newDiv;
        }
    }
}

window.onload = () => {
    var array = $(".textSt");
    var textArray = $(".textSite");
    for (let i: number = 0; i < array.length; i++) {
        let statie: string = $(array[i]).attr("value");
        $(textArray[i]).html(statie);
    }
    var array = $(".textSt");
    setTimeout(() => {
        $(".youtube").css("height", $(".youtube").width() / 1.75);
    }, 50);

    var staties: UserStaties = new UserStaties();

    $('.statieSelect').click((e) => {
         $(e.target).find('.statieBut').click();
    });

    $('.statieBut').click((e) => {
        e.preventDefault();
        var id;
        var parent = $(e.target).parent();
        if (parent.get(0).tagName == "BUTTON") parent = parent.parent();
        id = parent.children('.pId').val();
        staties.load(parseInt(id));
    });

    var warrings: UserWarrings = new UserWarrings();
    $('.warSelectBut').click((e) => {
        var id = parseInt($(e.target).text());
        warrings.load(id);
    });

    var news: UserNews = new UserNews();
    $('.newsSelectBut').click((e) => {
        var id = parseInt($(e.target).text());
        news.load(id);
    });

    $('.warSelectBut').first().click();
    $('.newsSelectBut').first().click();
};

window.onresize = () => {
    $(".youtube").css("height", $(".youtube").width() / 1.75);
};
