function GetInformation (id) {
    $.ajax({
        url: "/Home/GetData/",
        type: "Get",
        data: { "id": id },
        success: function (result) {
            console.log(result);
            $("#PersonInfo").html(result);
        }
    });
}
