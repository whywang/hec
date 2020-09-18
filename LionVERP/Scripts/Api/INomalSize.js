function InomalsizeList(kj) {
    var url ="../../../UIServer/ProductionSet/NomalSizeManage/NomalSizes.aspx/QueryList";
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
function SetProductionNs(pv, nv) {
    var o = { "pcode": pv, "ncode": nv }
    var url =  "../../../UIServer/ProductionSet/NomalSizeManage/NomalSizes.aspx/SetProductionNs"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetProductionNs(pv) {
    var o = { "pcode": pv }
    var url =  "../../../UIServer/ProductionSet/NomalSizeManage/NomalSizes.aspx/ReSetProductionNs"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetProductionNs(pv,kj) {
    var o = { "pcode": pv }
    var url = "../../../UIServer/ProductionSet/NomalSizeManage/NomalSizes.aspx/GetProductionNs"
    var b = AjaxExb(url, o);
    if (b == "") {
        linb.message("未设置标准尺寸");
        kj.setValue()
    }
    else {
        kj.setValue(b)
    }
}

//---------------------------------------Cust---------------------------------------------
function CustInomalsizeList(kj) {
    var url = "../../../UIServer/ProductionSet/NomalSizeManage/NomalSizes.aspx/CustQueryList";
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