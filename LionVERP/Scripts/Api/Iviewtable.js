function ITableViewByAtrr(ev,tv, kj) {
    var url = "../../../UIServer/BaseSet/TreegridManage/Treegrids.aspx/QueryTableTitle";
    var o = { "emcode": ev ,"tab":tv};
    var b = AjaxExb(url, o);
    kj.setHeader(""); 
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 0; i < r[1].length; i++) {
            var cel = r[1][i].toString().split(',')
            arr.push({ "id": i, "width": cel[1], "type": "input", "caption": cel[0] })
        }
        kj.setHeader(arr)
    }
}
function ITableViewHead(ev, tv) {
    var url = "../../../UIServer/BaseSet/TreegridManage/Treegrids.aspx/QueryTableTitle";
    var o = { "emcode": ev, "tab": tv };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
      return  StringToRow(r[1])
    }
}
function IViewTab(ev, kj) {
    var url = "../../../UIServer/BaseSet/TreegridManage/Treegrids.aspx/QueryTabTitle";
    var o = { "emcode": ev};
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
