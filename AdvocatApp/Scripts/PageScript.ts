/// <reference path="typings/jquery/jquery.d.ts" />
class Staties {

    private statie: Statie = new Statie();

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
        if (typeof (youtube.attr("src")) == "undefined")
        {
            if (typeof (this.statie.VideoURL) == "undefined") {
                if (this.statie.VideoURL != "") {
                    page.find("h5").first().after('<iframe class="youtube" frameborder="0" src="' + this.statie.VideoURL
                        + '" allowfullscreen> </iframe>');
                }
            }
        }
        else
        {
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
            else
            {
                youtube.css("width", "0px");
                youtube.css("height", "0px");
                youtube.css("border", "none");
            }
        }
        page.find(".textSite").first().html(this.statie.Text);
        page.find(".dateOfCreating").last().html(this.statie.Date);
    }
}

class Statie {
    Id: number;
    VideoURL: string;
    Header: string;
    Date: string;
    Text: string;
}

window.onload = () => {
    var array = $(".textSt");
    var textArray = $(".textSite");
    for (let i: number = 0; i < array.length; i++) {
        let statie: string = $(array[i]).attr("value");
        $(textArray[i]).html( statie);
    }
    var array = $(".textSt");
    setTimeout(() => {
        $(".youtube").css("height", $(".youtube").width() / 1.75);
    }, 50);

    var staties: Staties = new Staties();

    $('.statieBut').click((e) => {
        var id;
        var parent = $(e.target).parent();
        if (parent.get(0).tagName == "BUTTON") parent = parent.parent();
        id = parent.children('.pId').val();
        staties.load(parseInt(id));
    });
};

window.onresize = () => {
    $(".youtube").css("height", $(".youtube").width() / 1.75); 
};