
function SearchButton(query) {
    var query1 = query;
    var obj = {
        query: query1
    }

    $.ajax({
        type: 'get',
        url: "/Work/Search",
        data: obj,

        success: function (data) {

            $("body").html(data);

        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}
