function Icmlist(kj) {
    var url = "../../../UIServer/ProductionSet/ComputeMethodManage/ComputeMethods.aspx/QueryList";
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
function IcmlistByType(pv, kj) {
    var o = { "ctype": pv }
    var url = "../../../UIServer/ProductionSet/ComputeMethodManage/ComputeMethods.aspx/QueryByTypeList";
    var b = AjaxExb(url,o);
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
function SetProductionCm(pv, nv,tx) {
    var o = { "pcode": pv, "fcode": nv ,"ptx":tx}
    var url =  "../../../UIServer/ProductionSet/ComputeMethodManage/ComputeMethods.aspx/SetProductionCm"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetProductionCm(pv,tx) {
    var o = { "pcode": pv, "ptx": tx }
    var url =   "../../../UIServer/ProductionSet/ComputeMethodManage/ComputeMethods.aspx/ReSetProductionCm"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetProductionCm(pv,kj,tx) {
    var o = { "pcode": pv,"ptx": tx}
    var url =   "../../../UIServer/ProductionSet/ComputeMethodManage/ComputeMethods.aspx/GetProductionCm"
    var b = AjaxExb(url, o);
    if (b == "") {
        linb.warn("未设置计算公式");
        kj.setValue()
    }
    else {
        kj.setValue(b)
    }
}

//-----------------------------------------Cust------------------------------------------
function CustIcmlist(kj) {
    var url = "../../../UIServer/ProductionSet/ComputeMethodManage/ComputeMethods.aspx/CustQueryList";
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