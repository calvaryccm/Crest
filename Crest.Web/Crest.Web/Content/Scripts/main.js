//$('#box').keyup(function () {
//    var valThis = $(this).val().toLowerCase();
//    if (valThis == "") {
//        $('.error-list > li').show();
//    } else {
//        $('.error-list > li').each(function () {
//            var text = $(this).text().toLowerCase();
//            (text.indexOf(valThis) >= 0) ? $(this).show() : $(this).hide();
//        });
//    };
//});

$('document').ready(function () {
    $('#demo').jplist({

        itemsBox: '.demo-tbl tbody'
        , itemPath: '.tbl-item'
        , panelPath: '.jplist-panel'

        //save plugin state
        , storage: 'localstorage' //'', 'cookies', 'localstorage'			
        , storageName: 'jplist-table-2'

        , redrawCallback: function () {
            $('.tbl-item').each(function (index, el) {
                if (index % 2 === 0) {
                    $(el).addClass('even');
                }
                else {
                    $(el).addClass('odd');
                }
            });
        }
    });
});