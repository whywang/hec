///获取产品类别
function IinvItems(v, kj) {
    v = v == "" ? "00010001" : v;
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventoryCategory";
    var o = { "ipcode": v };
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
function IinvCItems(item, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventoryCategory";
    var o = { "ipcode": item.id };
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
function IinvRangeItems(v,rv, kj) {
    v = v == "" ? "00010001" : v;
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventoryCategoryRange";
    var o = { "ipcode": v, "drange": rv };
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
function IinvRangeCItems(item,rv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventoryCategoryRange";
    var o = { "ipcode": item.id, "drange": rv };
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
function QueryListInv(p,kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventory";
    var o = { "mcode": p };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }, { "value": cel[3] },{ "value": cel[8]}] })
        }
        kj.setRows(arr)
    }
}
///产品类别不带产品编码
function QueryListInvEx(p, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventory";
    var o = { "mcode": p };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[8]}] })
        }
        kj.setRows(arr)
    }
}
function QueryListWlInv(p, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventory";
    var o = { "mcode": p };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[9] }] })
        }
        kj.setRows(arr)
    }
}
///获取材质产品类别及产品
function ICzinvItems(c,v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/CzQueryListInventoryCategory";
    var o = { "ipcode": v,"mname":c };
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
function ICzinvCItems(c,item, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/CzQueryListInventoryCategory";
    var o = { "ipcode": item.id, "mname": c };
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
function CzQueryListInv(c,p, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/CzQueryProductionList";
    var o = { "mcode": p ,"mname":c};
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2] }] })
        }
        kj.setRows(arr)
    }
}
///获取产品类别DropList
function IinvDropList(v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventoryCategory";
    var o = { "ipcode": v };
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
///获取产品类别DropList
function IinvDropListCache(v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventoryCategory";
    var o = { "ipcode": v };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[1] })
        }
        linb.UI.cacheData(kj, arr)
    }
}
///获取产品DropList
function IpDropList(v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListInventory";
    var o = { "mcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
function Iwjproduction(v,cv) {
    var url = '../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListCateProduce';
    var o = { 'mcode': v };
    var b = AjaxExb(url, o);
    var barr = new Array();
    barr.push({ "id": "", "caption": "" });
    if (b.length > 0 && b[0] != null) {
        for (var i = 1; i < b.length; i++) {
            ib = b[i].toString().split(",");
            barr.push({ "id": ib[0], "caption": ib[1] });
        }
        linb.UI.cacheData(cv, barr)
    }
}
function IWjproductionEx(v, kj) {
    var url = '../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListCateProduce';
    var o = { 'mcode': v };
    var b = AjaxExb(url, o);
    var barr = new Array();
    barr.push({ "id": "", "caption": "" });
    if (b.length > 0 && b[0] != null) {
        for (var i = 1; i < b.length; i++) {
            ib = b[i].toString().split(",");
            barr.push({ "id": ib[1], "caption": ib[1] });
        }
    }
    kj.setItems(barr)
}
///校验门扇玻璃
function IMsinvCzItems(mv, v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListMsInventoryCategory";
    var o = { "mscode": mv, "ipcode": v };
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
function IMsCzinvCItems(mv, item, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListMsInventoryCategory";
    var o = { "mscode":mv,"ipcode": item.id };
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
function MsCzQueryListInv(c, p, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/MsCzQueryProductionList";
    var o = { "mscode": c, "mcode": p };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2]}] })
        }
        kj.setRows(arr)
    }
}
//-------------------------------------------门扇可选门套设置--------------------
function IMsRefMtCate(msv,mtv, czv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryMsRefMtCate";
    var o = { "mscode": msv, "pmtcode": mtv, "mname": czv };
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
function IMsRefMtItem(item, msv, czv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryMsRefMtCate";
    var o = { "mscode": msv, "pmtcode": item.id, "mname": czv };
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
//-----------------------------------------------可选玻璃------------------------
function IMsRefBlCate(msv, mtv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryMsRefBlCate";
    var o = { "mscode": msv, "blcode": mtv };
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
function IMsRefBlItem(msv, item, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryMsRefBlCate";
    var o = { "mscode": msv, "blcode": item.id };
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
//--------------------------------------Cust-------------------------------------

function CustIinvItems(v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/CustQueryListInventoryCategory";
    var o = { "ipcode": v };
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
///获取产品类别DropList
function CustIinvDropList(v,rv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/CustQueryListInventoryCategory";
    var o = { "ipcode": v ,'drange':rv};
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
///获取产品类别DropList
function QueryLastCate(v, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QueryListLastCategory";
    var o = { "ipcode": v };
    var b = AjaxExb(url, o);
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
function ICzinvRangeItems(c, item,rv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/CzQueryInveRangeCategory";
    var o = { "ipcode": item.id, "mname": c ,"drange":rv};
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
//根据产品类别和材质模糊查询产品列表
function QuerySearingList(iv,mv,pv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QuerySearingList";
    var o = { "icode":iv, "mname": mv, "pname": pv };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0] }, { "value": cel[2]}] })
        }
        kj.setRows(arr)
    }
}
function QueryInvItems(iv, mv, pv, kj) {
    var url = "../../../UIServer/ProductionSet/ProductionManage/Productions.aspx/QuerySearingList";
    var o = { "icode": iv, "mname": mv, "pname": pv };
    var b = AjaxExb(url, o);
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