function GetInformation(id) {
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
function SortPersons() {

    var id = $("#DropDownList").find(":selected").attr("class");

    if (id !== undefined) {
        $.ajax({
            url: "/Home/FilterPersons/",
            type: "Get",
            data: { "id": id },
            success: function (result) {
                console.log(result);
                $("#SelectList").html(result);
            }
        });
    }
    else {
        console.log("hello")
    }
}
function Test() {
    alert("test")
}


