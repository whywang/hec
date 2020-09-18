function ListPageToolBar(emcode,kj) {
    var url = '../../../UIServer/BaseSet/WorkFlowManage/CommonButtons.aspx/ListPageBtn';
    var o = { "emcode": emcode,"btype":"L" };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) { 
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push([{ "id": cel[0], "caption": cel[1], "fun": cel[2], "url": cel[3], "btype": cel[4], "bcode": cel[5], "image": cel[6]}])
        }
        kj.setItems(arr);
    }
}
function ListPageToolBarEx(emcode, kj,tab) {
    var url = '../../../UIServer/BaseSet/WorkFlowManage/CommonButtons.aspx/ListPageBtnEx';
    var o = { "emcode": emcode, "btype": "L","tab":tab };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push([{ "id": cel[0], "caption": cel[1], "fun": cel[2], "url": cel[3], "btype": cel[4], "bcode": cel[5], "image": cel[6]}])
        }
        kj.setItems(arr);
    }
}
function WorkFlowBar(emcode,sid, kj) {
    var url = '../../../UIServer/BaseSet/WorkFlowManage/CommonButtons.aspx/ListWorkFlowBtn';
    var o = { "emcode": emcode, "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push([{ "id": cel[0], "caption": cel[1], "fun": cel[2], "url": cel[3], "btype": cel[4], "bcode": cel[5], "btip": cel[6], "image": cel[7]}])
        }
        kj.setItems(arr);
    }
}
function SinglePageBar(emcode, sid, kj) {
    var url = '../../../UIServer/BaseSet/WorkFlowManage/CommonButtons.aspx/SinglePageBtn';
    var o = { "emcode": emcode, "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push([{ "id": cel[0], "caption": cel[1], "fun": cel[2], "url": cel[3], "btype": cel[4], "bcode": cel[5], "image": cel[7]}])
        }
        kj.setItems(arr);
    }
}