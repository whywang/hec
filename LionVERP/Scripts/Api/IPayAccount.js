﻿function PQueryTalbeList(kj) {
    var url = "../../../PayAccount/QueryPList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[2] }, { "value": cel[3] }, { "value": cel[1] }] })
        }
        kj.setRows(arr)
    }
}