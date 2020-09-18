///获取人员姓名
function IEmployeeItems(dv,kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/QueryList";
    var o = {"dcode":dv}
    var b = AjaxExb(url,o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
//人员DropDownList
function IEmployeeItemsEx(rv,dv, kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/QueryListEx";
    var o = { "dcode": dv ,"rcode":rv}
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
//模糊人员DropDownList
function IEmployeeItemsEx2(rv, dv, kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/QueryListEx2";
    var o = { "dcode": dv, "rcode": rv }
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
function IEmployeeRowsEx(rv, dv, kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/QueryListEx";
    var o = { "dcode": dv, "rcode": rv }
    var b = AjaxExb(url, o);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "cells": [{ "value": cel[1]}] })
        }
        kj.setRows(arr)
    }
}
///获取人员编号
function IEmployeeCodeItems(dv, kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/QueryList";
    var o = { "dcode": dv }
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
function IEmployeeRow(kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/AllQueryEmploee";
    var b = AjaxEb(url);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0]}] })
        }
        kj.setRows(arr)
    }
}
//人员拆单员
function IEmployeeCd(rv, kj) {
    var url = "../../../UIServer/BaseSet/EmploeeManage/Emploees.aspx/QueryCdyList";
    var o = { "rcode": rv }
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
