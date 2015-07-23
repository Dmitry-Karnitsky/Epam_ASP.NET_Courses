//function processData(data) {

//    var target = $("#tableBody");
//    target.empty();
//    for (var i = 0; i < data.length; i++) {
//        var content = data[i];
//        target.append("<tr><td>" + content.name + "</td><td>"
//            + content.type + "</td></tr>");
//    }
//}

function refillTable(data) {

    var items = $("#ajax-table .single-column-table-item");

    for (var i = 0; i < items.length; i++) {
        $(item).addClass("invisible");
    }

    for (var i = 0; i < data.length; i++) {
        var item = items[i];
        $(item).removeClass("invisible");
        var itemNodes = item.children[0].children;
        itemNodes[0].innerText = data[i].name;
        itemNodes[1].innerText = data[i].type;
    }
}


$("#ajax-table-pagination").on("click", ".page-link", function (event) {
    if ($(this).hasClass("clicked")) {
        return;
    }

    $("#ajax-table-pagination .page-link").removeClass("clicked");
    $(this).addClass("clicked");
});

function redirectToPage(url) {
    window.location.replace(url);
}

$("header").on("click", ".unauthenticated-login-button", function (event) { 
    $(".header-login-window").removeClass("invisible")
    return false;
});

$("header").on("click", "#close-login-window", function (event) {
    $(".header-login-window").addClass("invisible")
    return false;
});

function addComment(data) {

    var target = $("#ajax-comments ul.comments-list");

    target.append("<li class=\"comment\">" + "<div class=\"comment-user\">" +
        data.Username + "</div>" + "<div class=\"comment-time\">" + data.Time +
        "</div>" + "<div class=\"comment-text\">" + data.Comment + "</div>" + "</li>");
}

$(document).ready(function () {
    $("#add-comment-button").attr('disabled', 'disabled');
    $("#comment-input").keyup(function () {
        $("#add-comment-button").attr('disabled', 'disabled');
        $("#add-comment-button").css("cursor", "default");
        if ($(this).val() != '') {
            $('#add-comment-button').removeAttr('disabled');
            $("#add-comment-button").css("cursor", "pointer");
        }
    });
});