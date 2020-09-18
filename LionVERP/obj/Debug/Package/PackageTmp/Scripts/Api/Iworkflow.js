function IwfItems(v, kj) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/WorkFlow.aspx/QueryEventJdList";
    var o = { "emcode": v }; 
    var b = AjaxExb(url, o);
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