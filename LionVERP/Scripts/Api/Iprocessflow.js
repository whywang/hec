function IProcessItems( kj) {
    var url = "../../../UIServer/ProductionSet/ProcessFlowManage/ProcessFlows.aspx/QueryAllList";
    var b = AjaxEb(url);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                arr.push({ "id": cel[0], "caption": cel[1], "sub": [] })
            }
            else {
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
        }
        kj.setItems(arr)
    }
}
function IDropProcessItems(kj) {
    var url = "../../../UIServer/ProductionSet/ProcessFlowManage/ProcessFlows.aspx/QueryAllList";
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
//-----------------------------------Cust--------------------------------
function CustIProcessItems(kj) {
    var url = "../../../UIServer/ProductionSet/ProcessFlowManage/ProcessFlows.aspx/CustQueryAllList";
    var b = AjaxEb(url);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                arr.push({ "id": cel[0], "caption": cel[1], "sub": [] })
            }
            else {
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
        }
        kj.setItems(arr)
    }
}
function CustIDropProcessItems(kj) {
    var url = "../../../UIServer/ProductionSet/ProcessFlowManage/ProcessFlows.aspx/CustQueryAllList";
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