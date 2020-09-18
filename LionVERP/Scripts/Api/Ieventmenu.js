///f 流程标示
///l 列表标示
///t 特殊标示
///e 扩展标示
function IeventmenuItems(f,l,t,e, kj) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventMenu.aspx/QueryListEventMenu";
    var o = { 'e':e,'f':f,'l':l,'t':t};  
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
//获取主流程表单
function ImeventmenuItems(ev,kj) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventMenu.aspx/QueryMainEventMenu";
    var o = { 'etype': ev};
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
//---------------------------------Cust-----------------------------------------------------
function CustImeventmenuItems(ev, kj) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventMenu.aspx/CustQueryMainEventMenu";
    var o = { 'etype': ev };
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
//---------------------------------通过表格属性值获取表单------------------------------
function IeventMenuByAttr(v, kj) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventMenu.aspx/QueryListEventMenuByAttr";
    var o = { 'eattr': v };
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