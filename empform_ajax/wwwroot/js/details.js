



function detailButton(ID) {

    var obj = {
        id: ID
    }

    $.ajax({
        type: 'get',
        url: "/Work/Details",
        data: obj,

        success: function (data) {

            console.log("success2");

            // Convert the HTML string to a jQuery object
            var $html = $(data);
            $("#dModal .modal-body").html($html);


            $("#dModal").modal("show");

            // Add an event listener to the modal to remove the backdrop when it is closed
            $("#dModal").on("hidden.bs.modal", function () {
                $(".modal-backdrop").remove();
            });

            // Add an event listener for the X button to remove the backdrop when it is clicked
            $("#dModal").find(".close").on("click", function () {
                $(".modal-backdrop").remove();
            });

        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}



