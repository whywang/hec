
//获取订单工作流程及完成节点
function WorkLine(sid,ev,kj) {
    priWorkLine(ev, kj);
    priOverPoint(sid, ev, kj)
}

// 获取订单工作流程
function priWorkLine(ev, kj) {
    var url = "../../../../UIServer/CommonFile/OrderFlowLine.aspx/QueryFlowLine";
    var o = { "emcode": ev };
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
// 获取已完成工作节点
function priOverPoint(sid,ev, kj) {
    var url = "../../../../UIServer/CommonFile/OrderFlowLine.aspx/GetOverFlowPoint";
    var o = { 'sid':sid,"emcode": ev };
    var b = AjaxExb(url, o);
    kj.setValue(b)
}