$("#LoadingStatus").html("Loading....");
$.get("/SPAAccounts/GetAccounts", null, DataBind);
function DataBind(AccountList) {
    var SetData = $("#SetList");
    for (var i = 0; i < AccountList.length; i++) {
        var Data = "<tr class='row_" + AccountList[i].ID + "'>" +
            "<td>" + AccountList[i].AccountName + "</td>" +
            "<td>" + AccountList[i].AccountDesc + "</td>" +
          
            "<td>" + "<a href='#' class='btn btn-warning' onclick='EditAccount(" + AccountList[i].ID + ")' ><span class='glyphicon glyphicon-edit'></span> Edit </a>" + "</td>" +
            "<td>" + "<a href='#' class='btn btn-danger' onclick='DeleteAccount(" + AccountList[i].ID + ")'><span class='glyphicon glyphicon-trash'></span> Delete</a>" + "</td>" +
            "</tr>";
        SetData.append(Data);
        $("#LoadingStatus").html(" ");

    }
}



$.ajax({
    type: "Get",
    url: "/SPAAccounts/AccountNatures",
    dataType: "json",
    success: function (data) {

        var s = '<option value="-1">Please Select One</option>';
        for (var i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].ID + '">' + data[i].AccountNatureName + '</option>';
        }
        $("#AccountNatureID").append(s);
    }
});

$.ajax({
    type: "Get",
    url: "/SPAAccounts/GetAccounts",
    dataType: "json",
    success: function (data) {

        var s = '<option value="-1">Please Select One</option>';
        for (var i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].ID + '">' + data[i].AccountName + '</option>';
        }
        $("#ParentAccountID").append(s);
    }
});

//Show The Popup Modal For Add New Student


$(".AddNew").on('click', function () {
    $('#form').each(function () { this.reset() });
    $("#ModalTitle").html("Add New Account");
    $("#MyModal").addClass('show').css('display', 'block');
});


$(".tree").on('click', function () {
    $('#form').each(function () { this.reset() });
    $("#ModalTitle").html("Accounts Tree");
    $("#TreeModal").addClass('show').css('display', 'block');
});

$(".close").on('click', function () {
    $("#MyModal").removeClass('show').css('display', '');
    $("#TreeModal").removeClass('show').css('display', '');
    $("#DeleteConfirmation").removeClass('show').css('display', '');
});





function EditAccount(ID) {
    $("#TreeModal").removeClass('show').css('display', '');
    var url = "/SPAAccounts/GetAccountByID?id=" + ID;
    $("#ModalTitle").html("Update Record");
    $("#MyModal").addClass('show').css('display', 'block');
    $.ajax({
        type: "Post",
        url: url,
        dataType: "json",
        success: function (data) {
            $("#AccountSerial").val(data.AccountSerial);
            $("#AccountName").val(data.AccountName);
            $("#AccountDesc").val(data.AccountDesc);
            $("#GroupOrder").val(data.GroupOrder);
            $("#Active").val(data.Active);
            $("#IsMain").val(data.IsMain);
            $("#AddDate").val(data.AddDate);
            $("#AccountNatureID option:selected").text(data.ID);
            $("#ParentAccountID option:selected").val(data.ID);

        }
    });
}



$("#SaveFeatureRecord").click(function () {


    $.ajax({
        type: "Post",
        url: "/SPAAccounts/AddFeatures",
        data: {
            AccountSerial: $("#AccountSerial").val(data.AccountSerial),
            AccountName: $("#AccountName").val(data.AccountName),
            AccountDesc: $("#AccountDesc").val(data.AccountDesc),
            GroupOrder: $("#GroupOrder").val(data.GroupOrder),
            Active: $("#Active").val(data.Active),
            IsMain: $("#IsMain").val(data.IsMain),
            AddDate: $("#AddDate").val(data.AddDate),
            AccountNatureID: $("#AccountNatureID option:selected").text(data.ID),
            ParentAccountID: $("#ParentAccountID option:selected").val(data.ID)

        },
        success: function (result) {
            alert("Success!..");
            window.location.href = "/SPAAccounts/GetAccounts";
            $("#MyModal").modal("hide");

        }
    })
});


var DeleteAccount = function (ID) {
    $("#TreeModal").removeClass('show').css('display', '');
    $("#ID").val(ID);
    $("#DeleteConfirmation").addClass('show').css('display', 'block');
}
var ConfirmDelete = function () {
    var ID = $("#ID").val();
    $.ajax({
        type: "POST",
        url: "/SPAAccounts/DeleteAccount?ID=" + ID,
        success: function (result) {
            $("#DeleteConfirmation").modal("hide");
        }
    })
}
