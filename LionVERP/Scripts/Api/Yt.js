var Yt = {
    YtItems: function (v, kj) {
        var url = "../../../MsAttr/GetYt";
        var o = { "icode": v }
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        kj.setUIValue("");
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
        }
        else {
            kj.setReadonly(true)
        }
    }
}