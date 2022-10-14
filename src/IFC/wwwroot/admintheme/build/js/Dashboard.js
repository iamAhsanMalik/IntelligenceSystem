function GetWings(Wing, CoreName) {
    debugger
    $("#BtnDiv a").parent().find('a').attr("style", "border:1px solid white!important;");
    var storename = $('#StoreName').val();

    IsClick = 1;
    $("#btnCore").show();
    CoreID = Wing;
    CoreName = CoreName;
    //   $("#" + CoreName).attr("style")
    $("#" + CoreName).attr("style", "border:1px solid Red!important;");
    var PageSize = $('#pageSize').val();

    $.ajax({
        url: "/Home/GetWingsItemData",
        type: "POST",
        data: { Wing: Wing, storename: storename, PageSize: PageSize },
        dataType: "json",
        success: function (response) {
            debugger
            SetHeading(response, IsClick);

            onDrop(response);
            $('#LastRowId').val(response.LastRowID);
            $('#PageSize').val(response.PageSize);
            $('#TotalRecord').val(response.TotalRecord);
            $('#AreaUnderTable').removeAttr("hidden");
            pagination(response);

            if (!response.Data) {
                //   $('#myTable').DataTable().destroy();
                $('#myTable tbody').empty();
                $('#AreaUnderTable').attr("hidden", "true");
                $('.pagercustom #DynamicRecord').empty();
                sweetAlert("No wing exist against selected corpse", "", "error");

            }




        },

        error: function (result) {
            //    alert('Something Went Wrong');
            sweetAlert("Internet Issue Please Try Again Later...!", "", "error");
        }

    });

}