﻿function ICascadeItems(v, kj) {
    var url = "../../../JlProvince/QueryList";
    var o = { "pcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) { 
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] });
        }
        kj.setItems(arr)
    }
}
