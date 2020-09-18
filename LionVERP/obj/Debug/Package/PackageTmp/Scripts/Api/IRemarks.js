function Iremarkslist(kj) {
    var url = "../../../UIServer/ProductionSet/RemarksManage/Remarks.aspx/QueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3]}] })
        }
        kj.setRows(arr)
    }
}
function SetProductionRemark(pv, nv) {
    var o = { "pcode": pv, "rcode": nv }
    var url =   "../../../UIServer/ProductionSet/RemarksManage/Remarks.aspx/SetProductionRemarks"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetProductionRemark(pv) {
    var o = { "pcode": pv }
    var url =  "../../../UIServer/ProductionSet/RemarksManage/Remarks.aspx/ReSetProductionRemarks"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetProductionRemark(pv,kj) {
    var o = { "pcode": pv }
    var url =  "../../../UIServer/ProductionSet/RemarksManage/Remarks.aspx/GetProductionRemarks"
    var b = AjaxExb(url, o);
    if (b == "") {
        linb.message("未设置备注");
        kj.setValue()
    }
    else {
        kj.setValue(b)
    }
}
///-------------------------------------Cust-------------------------------------------
function CustIremarkslist(kj) {
    var url = "../../../UIServer/ProductionSet/RemarksManage/Remarks.aspx/CustQueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3]}] })
        }
        kj.setRows(arr)
    }
}