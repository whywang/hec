function ILockItems(lv,kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventory";
    var o = { "mcode": lv };
    var b = AjaxExb(url, o);
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
function ILockTypeItems(kj) {
    var url = "../../../LocksType/QueryList";
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
function ILocks(kj) {
    var url = "../../../LocksType/QueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        linb.UI.cacheData( kj,arr)
    }
}