function IPackageTable(kj) {
    var url = "../../../UIServer/ProductionSet/PackageManage/Packages.aspx/QueryList";
    var b = AjaxEb(url);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[7] }, { "value": cel[6] },  { "value": cel[8] }, { "value": cel[9]}] })
        }
        kj.setRows(arr)
    }
}
//名称方式
function IPackageItems(kj) {
    var url = "../../../UIServer/ProductionSet/PackageManage/Packages.aspx/QueryList";
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
function SetPackProduction(ov, pv, nv) {
    var o = { "pcode": ov, "icode": pv, "ppcode": nv }
    var url = "../../../UIServer/ProductionSet/PackageManage/Packages.aspx/SetPackageProduction"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetPackProduction(ov) {
    var o = { "pcode": ov }
    var url = "../../../UIServer/ProductionSet/PackageManage/Packages.aspx/ReSetPackageProduction"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetPackProduction(ov, pv,kj) {
    var o = { "pcode": ov, "icode": pv }
    var url =  "../../../UIServer/ProductionSet/PackageManage/Packages.aspx/GetPackageProduction"
    var b = AjaxExb(url, o);
    if (b) {
        kj.setValue(b)
    }
    else {
        linb.message("未设置包装规则");
        kj.setValue("")
    }
}