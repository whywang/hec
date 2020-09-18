////编码方式
function IunitItems(kj) {
    var url = "../../../UIServer/BaseSet/UnitManage/Units.aspx/QueryListUnit";
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
//名称方式
function IunitNItems(kj) {
    var url = "../../../UIServer/BaseSet/UnitManage/Units.aspx/QueryListUnit";
    var b = AjaxEb(url);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}