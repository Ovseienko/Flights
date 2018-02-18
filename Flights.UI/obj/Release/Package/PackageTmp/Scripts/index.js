
const list = $("#searchResults");
const searchInput = $("#searchInput");
const searchBtn = $("#searchBtn");
const searchNextLink = $(".search__next-link");
const emptySearch = `<li class='search__empty'>
                        <i>Nothing found.</i>
                        But you can see <a class="see-all" onclick="showFullList()">the full list.</a>
                    </li>`;
var param = window.location.search.split("=")[1];
var endpoint;

$(document).ready(function () {
    switch (searchInput.attr("name")) {
        case "country": endpoint = "/FindFlight/GetCountry";
            break;
        case "city": endpoint = "/FindFlight/GetCity";
            break;
        case "flight": endpoint = "/FindFlight/GetFlight";
            break;
    }
});

function getList(url, key, filterParam) {
    $.ajax({
        url: url,
        data: { "key": key, "filterParam": filterParam },
        success: function (resp) {
            if (!resp.length) {
                list.append(emptySearch);
            } else {
                for (let i = 0; i < resp.length; i++) {
                    if (searchInput.attr("name") == "flight") {
                        list.append("<li class='search__result'><a href=/Flight/Details?code=" + resp[i].Code + ">" + resp[i].Code + ": " + resp[i].DepartureCity.Name + "-" + resp[i].DestinationCity.Name + "</a></li>")
                    } else {
                        list.append($("<li class='search__result'>").text(resp[i].Name))
                    }
                    console.log(resp[i]);
                }
            }
        },
        error: function (xhr) {
            console.log(xhr.status);
        }
    });
};

function initSearch() {
    let key = $("#searchInput").val();
    list.empty();

    getList(endpoint, key, param);

    $("#searchInput").val("");
}

$("#searchBtn").click(function () {
    initSearch();
});

searchInput.on("keyup", function (e) {
    if (e.target.value.length) {

        searchBtn.removeAttr("disabled");
        if (e.which === 13) {
            $(this).attr("disabled", "disabled");

            initSearch();

            $(this).removeAttr("disabled");
        }

    } else {
        searchBtn.attr("disabled", true);

    }

});

$("#searchResults").on("click", "li.search__result", function () {
    let li = $("#searchResults li.selected");
    let href = searchNextLink.attr("href");
    li.removeClass("selected");
    $(this).addClass("selected");
    searchNextLink.attr("href", href += $(this).text());
    searchNextLink.removeClass("disabled");
});

function showFullList() {
    list.empty();
    getList(endpoint, "", param);
}
