var MsColor = {
    ColorItems: function (v, kj) {
        var url = "../../../MsAttr/GetMsColor";
        var o = { "mscode": v }
        var b = AjaxExb(url, o);
        kj.setUIValue("");
        kj.setItems();
        if (b) {
            var arr = new Array();
            var r = b.toString().split(';')
            for (i = 0; i < r.length; i++) {
                arr.push({ "id": r[i], "caption": r[i] })
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
            kj.setReadonly(true)
        }
    }
}