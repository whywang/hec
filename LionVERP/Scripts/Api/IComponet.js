///校验产品是否存在组件
function InvComponentCheck(v) {
    var url = '../../../UIServer/CommonFile/CheckComponent.aspx/CheckInvCom';
    var o = { "icode": v };
    var b = AjaxExb(url, o);
    return b;
}
///产品增加时获取组件
function ICzZjItems(mv, iv, kj) {
    var url = '../../../UIServer/ProductionSet/ComponentManage/Components.aspx/QueryInvComList';
    var o = { "icode": iv,"mname":mv };
    var b = AjaxExb(url, o);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2]}] })
        }
        kj.setRows(arr)
    }
}

