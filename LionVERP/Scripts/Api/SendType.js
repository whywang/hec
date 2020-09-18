var SendType = {
    ISendTypeItems: function (kj) {
        var url = "../../../SendType/QueryList";
        var b = AjaxEb(url);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    },
    ISendTypeChange: function (sv, kj1, kj2) {
        var url = "../../../SendType/InitSendType";
        var o = { "scode": sv }
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        if (r) {
            if (r.estate) {
                kj1.setReadonly(false);
                kj2.setReadonly(false);
                ICascadeItems("0", kj1)
            }
            else {
                kj1.setReadonly(true);
                kj2.setReadonly(true);
                kj1.setUIValue("");
                kj2.setUIValue("");
            }
        }
    }
}
 
