
function MQueryList(v,kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListMaterialCategory";
    var o = { "mpcode": v };
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
function MQueryItems(v, kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListMaterialCategory";
    var o = { "mpcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
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
function MQueryListChild(item,kj) {
    var url ="../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListMaterialCategory";
    var o = { "mpcode": item.id };
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

////编码方式
function IMaterialItems(kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListItem";
    var b = AjaxEb(url);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": ""})
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
//名称方式
function IMaterialNItems(kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListItem";
    var b = AjaxEb(url);
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
//增加单据名称方式
function IMaterialAItems(kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/CustQueryListItem";
    var b = AjaxEb(url);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
        arr.push({ "id": "见详情", "caption": "见详情" })
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
//名称方式
function IMaterialNTable(kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListItem";
    var b = AjaxEb(url);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "cells": [{ "value": cel[1] }]})
        }
        kj.setRows(arr)
    }
}
function CzQueryTable(p ,kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryTableMaterial";
    var o = { "mcode": p };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "cells": [{ "value": cel[1] }] })
        }
        kj.setRows(arr)
    }
}
///--------------------------------Cust----------------------------------
function CustMQueryList(v, kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/CustQueryListMaterialCategory";
    var o = { "mpcode": v };
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
//名称方式
function CustIMaterialNTable(kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/CustQueryListItem";
    var b = AjaxEb(url);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "cells": [{ "value": cel[1]}] })
        }
        kj.setRows(arr)
    }
}

function IDimMaterialAItems(sv, btype, kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListItemByBrand";
    var o = { "mname": sv, "bcode": btype }
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
        arr.push({ "id": "见详情", "caption": "见详情" })
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}

function IDimMaterialAllItems(iv, kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListItemEx";
    var o = { "mname": iv };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
        arr.push({ "id": "见详情", "caption": "见详情" })
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}
//分材质类型获取
function QueryMaterialListByBdcode(cv, v, kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryMaterialListCategoryByBdcode";
    var o = { "btype": cv, "mpcode": v };
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
//分材质类型获取
function DropMTypeItems(cv, kj) {
    var url = "../../../UIServer/ProductionSet/MaterialManage/Materials.aspx/QueryListItemByType";
    var o = { "mtype": cv};
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption":""})
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[1] })
        }
        kj.setItems(arr)
    }
}