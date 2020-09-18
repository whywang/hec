function IPageTab(ev, kj) {
    var url = "../../../MenuTab/QueryRoleTab";
    var o = { "tmcode": ev };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
function IPageTabEx(ev,sid,ptype, kj) {
    var url = "../../../MenuTab/QueryRoleTabEx";
    var o = { "tmcode": ev, "ptype": ptype, "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
