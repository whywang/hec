
///获取一级部门
function IdepItems(v,kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryAllList";
    var o = {"dcode":v};
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
      var arr= new Array();
      for(i=1;i<r.length;i++) {
          var cel = r[i].toString().split(',')
          if (cel[2] == "false") {
              arr.push({ "id": cel[0], "caption": cel[1], "sub": []})
          }
          else {
              arr.push({ "id": cel[0], "caption": cel[1],"type":"checkbox"})
          }
      }
      kj.setItems(arr)
    }
}
//获取子部门
function IdepCItems(item ,kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryAllList";
    var o = { "dcode": item.id };
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
//获取属性部门
function IdepItemsByAtrr(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryListByAttr";
    var o = { "attr": v };
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
//获取特定部门下的属性部门
function IdepItemsByDepAtrr(dv,v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryListByDepAttr";
    var o = { "dcode":dv,"attr": v };
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
//获取属性部门DropList
function IdepItemsByAtrrName(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryListByAttr";
    var o = { "attr": v };
    var b = AjaxExb(url, o);
    kj.setItems();
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
//获取子部门部门Table
function IdepTableByCode(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryAllList";
    var o = { "dcode": v };
    var b = AjaxExb(url, o);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0]}] })
        }
        kj.setRows(arr)
    }
}
//获取属性部门Table
function IdepTableByAtrr(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryListByAttr";
    var o = { "attr": v };
    var b = AjaxExb(url, o);
    kj.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[0]}] })
        }
        kj.setRows(arr)
    }
}
//获取人员属性部门
function IEmploeeydepItemsByAtrr(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryEmployeeByAttr";
    var o = { "attr": v };
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
///获取同一级编码部门
function IdepOnlyItems(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryAllList";
    var o = { "dcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[1], "type": "checkbox" })
        }
        kj.setItems(arr)
    }
}
//获取同一级属性部门
function IdepOnlyItemsByAtrr(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/QueryListByAttr";
    var o = { "attr": v };
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

//-------------------------------------New 客户获取部门--------------------------------------------------
///获取一级部门
function ICustdepItems(v,kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/CustQueryAllList";
    var o = {"dcode":v};
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
      var arr= new Array();
      for(i=1;i<r.length;i++) {
          var cel = r[i].toString().split(',')
          if (cel[2] == "false") {
              arr.push({ "id": cel[0], "caption": cel[1], "sub": []})
          }
          else {
              arr.push({ "id": cel[0], "caption": cel[1],"type":"checkbox"})
          }
      }
      kj.setItems(arr)
    }
}
//获取属性部门
function ICustdepItemsByAtrr(v, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/CustQueryListByAttr";
    var o = { "attr": v };
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
//范围属性查询部门
function IDimDepAItems(dv, av, dn, kj) {
    var url = "../../../UIServer/BaseSet/DepManage/Depment.aspx/DimQueryDep";
    var o = { "dcode": dv,"attr":av,"dname":dn };
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