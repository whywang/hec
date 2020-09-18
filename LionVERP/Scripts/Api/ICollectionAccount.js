function CQueryTalbeList(kj) {
    var url = "../../../CollectionAccount/QueryCList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[3] }, { "value": cel[4] }, { "value": cel[2] }] })
        }
        kj.setRows(arr)
    }
}