function ISetMealList(kj) {
    var url = "../../../SetMeal/QuerySmList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] },{ "value": cel[3] }, { "value": cel[4]}] })
        }
        kj.setRows(arr)
    }
}
function ISetMealProductionList(v,kj) {
    var url = "../../../SetMeal/QuerySmPList";
    var o = {'tcpcode':v}
    var b = AjaxExb(url,o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[2] }, { "value": cel[0] }, { "value": cel[3] }, { "value": cel[4]}] })
        }
        kj.setRows(arr)
    }
}
function ISMPList(kj) {
    var url = "../../../SetMeal/QuerySmPAllList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }] })
        }
        kj.setRows(arr)
    }
}

function ISmProduction(tv, pt, mt, kj) {
    var url = "../../../SetMeal/QuerySmProdution";
    var o = { 'tccode': tv,'ptype':pt,"ismt":mt }
    var b = AjaxExb(url,o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] } ] })
        }
        kj.setRows(arr)
    }
}