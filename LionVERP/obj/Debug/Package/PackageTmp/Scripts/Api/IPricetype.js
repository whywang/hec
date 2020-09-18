function IPriceItemsByAtrr(v, kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/QueryList";
    var o = { "ptype": v };
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
function IPriceTable(v,kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/QueryList";
    var o = { "ptype": v };
    var b = AjaxExb(url,o);
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
function IPriceTableAll( kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/QueryListAll";
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
function QueryListInvPrice(p,pt,plx, kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/QueryListInventory";
    var o = { "mcode": p,"plb":pt,"plx":plx };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6]}] })
        }
        kj.setRows(arr)
    }
}

//--------------------------------Cust---------------------------------
function CustIPriceTable(v, kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/CustQueryList";
    var o = { "ptype": v };
    var b = AjaxExb(url, o);
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
function CustIPriceItemsByAtrr(v, kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/CustQueryList";
    var o = { "ptype": v };
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
function CustIPriceTableAll(kj) {
    var url = "../../../UIServer/ProductionSet/PriceManage/Prices.aspx/CustQueryListAll";
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