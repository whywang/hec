function Iimglist(kj) {
    var url =  "../../../UIServer/ProductionSet/ImageManage/ImageFile.aspx/QueryList";
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
function SetProductionImg(pv, nv) {
    var o = { "pcode": pv, "icode": nv }
    var url = "../../../UIServer/ProductionSet/ImageManage/ImageFile.aspx/SetProductionImg"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function ReSetProductionImg(pv) {
    var o = { "pcode": pv }
    var url ="../../../UIServer/ProductionSet/ImageManage/ImageFile.aspx/ReSetProductionImg"
    var b = AjaxExb(url, o);
    BackVad(b, "", false)
}
function GetProductionImg(pv,kj) {
    var o = { "pcode": pv }
    var url =  "../../../UIServer/ProductionSet/ImageManage/ImageFile.aspx/GetProductionImg"
    var b = AjaxExb(url, o);
    if (b == "") {
        linb.warn("未设置图片");
        kj.setValue()
    }
    else {
        kj.setValue(b)
    }
}
///--------------------------------------Cust-------------------------------------
function CustIimglist(kj) {
    var url = "../../../UIServer/ProductionSet/ImageManage/ImageFile.aspx/CustQueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2]}] })
        }
        kj.setRows(arr)
    }
}

///获取产品图片
function QueryImage(icode, kj) {
    var o = { "pcode": icode }
    var url = "../../../UIServer/ProductionSet/ImageManage/ImageFile.aspx/QueryImg"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    {
        kj.setSrc(r.iurl)
    }
}