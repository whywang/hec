function IGroupItems(kj) {
    var url = "../../../UIServer/BaseSet/GroupManage/Groups.aspx/QueryGroupList";
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
function IGroupTable(kj) {
    var url = "../../../UIServer/BaseSet/GroupManage/Groups.aspx/QueryGroupList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0]}] })
        }
        kj.setRows(arr)
    }
}