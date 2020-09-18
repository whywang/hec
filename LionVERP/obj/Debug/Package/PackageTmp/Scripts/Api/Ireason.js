///获取责任类别
function IreasonItems(v, kj) {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/QueryList";
    var o = { "rrcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                arr.push({ "id": cel[0], "caption": cel[1], "sub": [] })
            }
            else {
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
        }
        kj.setItems(arr)
    }
}
function IreasonCItems(item, kj) {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/QueryList";
    var o = { "rrcode": item.id };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    var l = item.hasOwnProperty("sub");
    if (l && item.sub.length <= 0) {
        var arr = new Array();
        kj.removeChildren(item.id, true);
        for (var i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                kj.insertItems([{ "id": cel[0], "caption": cel[1], "sub": []}], item.id)
            }
            else {
                kj.insertItems([{ "id": cel[0], "caption": cel[1]}], item.id)
            }
        }
    }
}
function Ireasonlist(kj) {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/QueryAllList";
    var b = AjaxEb(url);
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
function Ireasonlistcaption(kj) {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/QueryAllList";
    var b = AjaxEb(url);
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
function Ireasontable(kj) {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/QueryAllList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[2], "cells": [{ "value": cel[2] }] })
        }
        kj.setRows(arr)
    }
}
//--------------------------Cust----------------------------------

function CustIreasonItems(v, kj) {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/CustQueryList";
    var o = { "rrcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                arr.push({ "id": cel[0], "caption": cel[1], "sub": [] })
            }
            else {
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
        }
        kj.setItems(arr)
    }
}