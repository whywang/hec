function IOptItems(kj) {
    var url = "../../../UIServer/ProductionSet/OptimizeManage/Optimizes.aspx/QueryList";
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
}
function IOptCol(v) {
    var url = "../../../UIServer/ProductionSet/OptimizeManage/Optimizes.aspx/InitOpt";
    var o = {"ocode":v}
    var b = AjaxExb(url,o);
    var r = BackVad(b, "", false)
    if (r) {
        return r.ocols;
    }
    else {
        return "";
    }
}
function IPacCol(v) {
    var url = "../../../UIServer/ProductionSet/OptimizeManage/Optimizes.aspx/InitOpt";
    var o = { "ocode": v }
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        return r.pcols;
    }
    else {
        return "";
    }
}
function IOptMname(v) {
    var url = "../../../UIServer/ProductionSet/OptimizeManage/Optimizes.aspx/InitOpt";
    var o = { "ocode": v }
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        return r.mtype;
    }
    else {
        return "";
    }
}