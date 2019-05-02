﻿$(document).ready(function () {
    $(document).on("click", ".collapsible", function (e) {
   // $(".collapsible").live("click", function (e) {
        e.preventDefault();

        var this1 = $(this); // Get Click item 
        var data = {
            pid: $(this).attr('pid')
        };

        var isLoaded = $(this1).attr('data-loaded'); // Check data already loaded or not
        if (isLoaded == "false") {
            $(this1).addClass("loadingP");   // Show loading panel
            $(this1).removeClass("collapseTree");

            // Now Load Data Here 
            $.ajax({
                url: "/Accounts/GetSubMenu",
                type: "GET",
                data: data,
                dataType: "json",
                success: function (d) {
                    $(this1).removeClass("loadingP");
                    console.log(d);
                    if (d.length > 0) {

                        var $ul = $("<ul></ul>");
                        $.each(d, function (i, ele) {
                            console.log(d);

                            $ul.append(
                                $("<li></li>").append(
                                    "<span class='collapseTree collapsible' data-loaded='false' pid='" + ele.id + "'>&nbsp;</span>" +
                                    "<span>" + ele.accountName + "</span>"
                                )
                            )
                        });

                        $(this1).parent().append($ul);
                        $(this1).addClass('collapseTree');
                        $(this1).toggleClass('collapseTree expand');
                        $(this1).closest('li').children('ul').slideDown();
                    }
                    else {
                        // no sub menu
                        $(this1).css({ 'dispaly': 'inline-block', 'width': '15px' });
                    }

                    $(this1).attr('data-loaded', true);
                },
                error: function () {
                    alert("Error!");
                }
            });

            function Edit(ID) { window.location.href = "/Accounts/Edit?ID"+ID ; };
        }
        else {
            // if already data loaded
            $(this1).toggleClass("collapseTree expand");
            $(this1).closest('li').children('ul').slideToggle();
        }

    });
});