var Jst = {
    JstItems: function (v, kj) {
        var url = "../../../MsAttr/GetJst";
        var o = { "icode": v }
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        kj.setUIValue("");
        kj.setItems();
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
            if (arr.length > 0) {
                kj.setReadonly(false)
            }
            else {
                kj.setReadonly(true)
            }
            kj.setItems(arr)
        }
        else {
            kj.setDisplay("none")
        }
    }
}