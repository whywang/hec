var HyType = {
    HyTypeItems: function (kj) {
        var url = "../../../HyType/QueryList";
        var b = AjaxEb(url);
        var r = BackVad(b, "", false)
        kj.setItems();
        if (r) {
            var arr = new Array();
            arr.push({ "id": "", "caption": "" })
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[1], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    }
    ,
    RefHyItems: function (mv, kj) {
        var url = "../../../MsAttr/GetHy";
        var o = { "icode": mv }
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        kj.setItems();
        if (r) {
            var arr = new Array();
            arr.push({ "id": "", "caption": "" })
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[0] })
            }
            kj.setItems(arr)
        }
    }
}