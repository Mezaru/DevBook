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
function Test() {
    alert("test");
}
