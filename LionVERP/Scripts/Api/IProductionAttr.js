function IinvCheckBoxList(v, kj) {
    var url = "../../../ProductionAttrEx/QueryInvAttr";
    var o = { "icode": v };
    var b = AjaxExb(url, o);
    var ks = kj.getItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (CheckItem(ks, cel)) {
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
        }
        kj.insertItems(arr)
    }
}
function CheckItem(olist, cobj) {
    var r = true;
    if (olist!=null) {
        if (olist != "") {
            for (i = 0; i < olist.length; i++) {
                if (olist[i].id == cobj[0]) {
                    r = false;
                    break;
                }
            }
        }
    }
    return r;
}
function IinvCheckBox(v, kj) {
    var r = false;
    var url = "../../../ProductionAttrEx/QueryInvAttr";
    var o = { "icode": v };
    var b = AjaxExb(url, o);
    var ks = kj.getItems();
    if (ks != "") {
        r= true;
    }
    else {
        var r = BackVad(b, "", false)
        if (r.length > 1) {
            r = true;
        }
    }
    return r;
}