function checkLength(text, value) {
    var maxlength = new Number(value);
    if (text.value.length > maxlength) {
        text.value = text.value.substring(0, maxlength);
    }
}

$().ready(function () {

    function getParameterByName(name,value) {
        var match = RegExp('[?&]' + name + '=([^&]*)')
                    .exec(value);

        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    }

    function ajaxGetContent(url) {
        var callBack = false;
        if (!getParameterByName("callback", url))
            url = url + "&CallBack=true";
        $.get(
           url ,
            function (data) {
                $("#someContent").html(data);
                changeHistory(url);
                callBack = true;
            });

        if (!callBack) {
            window.document.URL = url;
        }

    }
    function changeHistory(url) {
        if ((history && history.pushState)) {
            history.pushState(null, url, url);
        }
    }
    $(".caption").live('click', function () {
        var url = $(this).attr('href');
        ajaxGetContent(url);
        return false;
    });
    $("a.pager").live('click', function() {
        var url = $(this).attr('href');
        ajaxGetContent(url);
        return false;
    });

    $(".caption, .selection a").live('click', function () {
        var url = $(this).attr('href');

        $(".selection a").removeClass("selected");
        $(this).addClass("selected");

        ajaxGetContent(url);
        return false;
    });

    $("#cont_cont_search_btn_btn").click(function () {
        var selection = getParameterByName("selection", window.location.search);
        var max = document.getElementById("cont_left_yearsEnd");
        var min = document.getElementById("cont_left_yearsStart");
        var page = getParameterByName("page", window.location.search);
        var search = document.getElementById("cont_cont_search_input");
        var exp = document.getElementById("cont_left_sortExpression");
        var dir = document.getElementById("cont_left_sortDirection");
        var redirectString = encodeURI("Default.aspx?" +
            "selection=" + selection +
            "&search=" + search.value +
            "&page=" + page +
            "&min=" + min.value +
            "&max=" + max.value +
            "&exp=" + exp.value +
            "&dir=" + dir.value);
        ajaxGetContent(redirectString);
    }
        );
});