function IJcTable(kj) {
    var url = "../../../UIServer/ProductionSet/SizeTransformManage/JianChis.aspx/QueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2]}] })
        }
        kj.setRows(arr)
    }
}
function SetProductionJc(pv, jv) {
    var o = { "pcode": pv, "jcode": jv }
    var url = "../../../UIServer/ProductionSet/SizeTransformManage/JianChis.aspx/SetProductionJc"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetProductionJc(pv) {
    var o = { "pcode": pv }
    var url = "../../../UIServer/ProductionSet/SizeTransformManage/JianChis.aspx/ReSetProductionJc"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetProductionJc(pv,kj) {
    var o = { "pcode": pv }
    var url = "../../../UIServer/ProductionSet/SizeTransformManage/JianChis.aspx/GetProductionJc"
    var b = AjaxExb(url, o);
    if (b == "") {
        linb.message("未设置减尺方式");
        kj.setValue()
    }
    else {
        kj.setValue(b)
    }
}

//-------------------------------------Cust-----------------------------------------
function CustIJcTable(kj) {
    var url = "../../../UIServer/ProductionSet/SizeTransformManage/JianChis.aspx/CustQueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2]}] })
        }
        kj.setRows(arr)
    }
}