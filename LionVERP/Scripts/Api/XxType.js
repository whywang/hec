var XxType = {
    RefLineItems: function (mv, kj) {
        var url = "../../../MsAttr/GetLine";
        var o = { "icode": mv }
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        kj.setItems();
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[0] })
            }
            if (arr.length > 0) {
                kj.setReadonly(false)
                kj.setItems(arr)
            }
            else {
                kj.setReadonly(true)
            }
        }
        else {
            kj.setReadonly(true)
        }
    }
}