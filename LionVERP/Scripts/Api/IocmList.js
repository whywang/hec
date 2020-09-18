function Iocm(kj) {
    var url = "../../../UIServer/ProductionSet/OverComputeMethodManage/OverComputes.aspx/QueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7] }, { "value": cel[8] }, { "value": cel[9]}] })
        }
        kj.setRows(arr)
    }
}
function SetProductionOcm(pv, nv) {
    var o = { "pcode": pv, "fcode": nv }
    var url = "../../../UIServer/ProductionSet/OverComputeMethodManage/OverComputes.aspx/SetProductionOcm"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetProductionOcm(pv) {
    var o = { "pcode": pv }
    var url = "../../../UIServer/ProductionSet/OverComputeMethodManage/OverComputes.aspx/ReSetProductionOcm"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetProductionOcm(pv,kj) {
    var o = { "pcode": pv }
    var url = "../../../UIServer/ProductionSet/OverComputeMethodManage/OverComputes.aspx/GetProductionOcm"
    var b = AjaxExb(url, o);
    if (b == "") {
        linb.message("未设置结算方式");
        kj.setValue()
    }
    else {
        kj.setValue(b)
    }
}

//----------------------------------------Cust-------------------------------------

function CustIocm(kj) {
    var url = "../../../UIServer/ProductionSet/OverComputeMethodManage/OverComputes.aspx/CustQueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7] }, { "value": cel[8] }, { "value": cel[9]}] })
        }
        kj.setRows(arr)
    }
}