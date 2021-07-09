function AddRowInTable() {
    var table = document.getElementById("profiles");

    if (document.getElementById("pName").value.length > 1
        && document.getElementById("pSurname").value.length > 1
        && document.getElementById("pNickname").value.length > 1) {
        //$("#profiles tr:eq(-1) td:eq(0)").css("background-color", "yellow");
        var tr = table.insertRow(-1);
        var tabCell = tr.insertCell(-1);
        //tabCell.innerHTML = ;
        //console.log(document.getElementById("profiles").getElementsByTagName("tr")[this.length]);
        tabCell.innerHTML = $("#profiles tr:eq(-1) td:eq(0)")/*.value*/;
        console.log(tabCell.innerHTML);
        //tabCell.innerHTML = 3;
        tabCell = tr.insertCell(-1);
        tabCell.innerHTML = document.getElementById("pName").value;
        tabCell = tr.insertCell(-1);
        tabCell.innerHTML = document.getElementById("pSurname").value;
        tabCell = tr.insertCell(-1);
        tabCell.innerHTML = "@" + document.getElementById("pNickname").value;
    }
}

$(document).ready(function () {
    $("#filter").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#profiles tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
});