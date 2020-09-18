//获取子部门部门Table
function IBdCustomer(v, kj) {
    var url = "../../../UIServer/CommonFile/Customer.aspx/QueryList";
    var o = { "customer": v };
    var b = AjaxExb(url, o);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3]}] })
        }
        kj.setRows(arr)
    }
} 
