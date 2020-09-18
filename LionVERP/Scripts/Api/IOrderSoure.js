function ISoureItems(emcode ,kj) {
    var url = "../../../UIServer/BaseSet/OrderSourceManage/OrderSources.aspx/QuerySourceEmcodeList";
    var o = {"emcode":emcode}
    var b = AjaxExb(url,o);
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