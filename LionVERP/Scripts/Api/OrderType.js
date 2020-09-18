var OrderType = {
    IOrderTypeItems: function (ev, kj) {
        var url = "../../../UIServer/BaseSet/OrderTypeManage/OrderTypes.aspx/CustQueryListByEmenu";
        var o = { 'emcode': ev }
        var b = AjaxExb(url, o);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[1], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    },
     IOrderTypeAllItems: function ( kj) {
        var url = "../../../UIServer/BaseSet/OrderTypeManage/OrderTypes.aspx/QueryList";
        var b = AjaxEb(url);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[1], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    }
}
 
