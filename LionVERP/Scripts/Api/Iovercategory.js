function Iovercomputecate(kj) {
    var url = "../../../UIServer/ProductionSet/OverConditionManage/OverCondition.aspx/QueryListCate";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3] }] })
        }
        kj.setRows(arr)
    }
}
function Iovercgcate(kj) {
    var url = "../../../UIServer/ProductionSet/OverConditionManage/CgOverCondition.aspx/QueryListCate";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3]}] })
        }
        kj.setRows(arr)
    }
}
//---------------------------------Cust------------------------------------
function CustIovercomputecate(kj) {
    var url = "../../../UIServer/ProductionSet/OverConditionManage/OverCondition.aspx/CustQueryListCate";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3]}] })
        }
        kj.setRows(arr)
    }
}