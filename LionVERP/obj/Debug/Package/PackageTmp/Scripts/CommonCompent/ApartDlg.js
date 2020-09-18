Class('App.ApartDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "adlg")
                .setDock("center")
                .setLeft(70)
                .setTop(100)
                .setWidth(1056)
                .setHeight(450)
                .setCaption("部件管理")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.adlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "&nbsp;确&nbsp;&nbsp;定&nbsp;" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "&nbsp;新增行&nbsp;" }, { "id": "a2", "type": "split", "split": true }, { "id": "a5", "caption": "&nbsp;删除行&nbsp;" }, { "id": "a2", "type": "split", "split": true }, { "id": "a6", "caption": "&nbsp;取&nbsp;&nbsp;消&nbsp;"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.adlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ertreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setEditable(true)
                .setRowHandlerWidth(30)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "rid", "type": "label", "width": 80, "caption": "行ID" }, { "id": "bjname", "type": "input", "width": 100, "caption": "部件名称" }, { "id": "bjcode", "type": "input", "width": 100, "caption": "部件编码" }, { "id": "bjh", "type": "number", "width": 80, "caption": "部件高" }, { "id": "bjk", "type": "number", "width": 80, "caption": "部件宽" }, { "id": "bjh", "type": "number", "width": 80, "caption": "部件厚" }, { "id": "bjsl", "type": "number", "width": 80, "caption": "部件数量" }, { "id": "bjlx", "type": "listbox", "width": 100, "caption": "部件类别", "editorListKey": "bjlb" }, { "id": "bjsxmc", "type": "listbox", "width": 100, "caption": "类型名称", "editorListKey": "bjlxmc" }, { "id": "bjsx", "type": "label", "width": 100, "caption": "部件类型" }, { "id": "kzsx", "type": "label", "width": 100, "caption": "部件扩展类型" }, { "id": "xz", "type": "listbox", "width": 100, "caption": "是否新增", "editorListKey": "isadd"}])
                .afterCellUpdated("_ertreegrid_aftercellupdated")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.adlg.show();
            ds = this;
            paobj = ProductionApart;
            apreurl = "../../../UIServer/CommonFile/Production.aspx";
            linb.UI.cacheData("bjlb", [{ "id": "t", "caption": "套" }, { "id": "m", "caption": "门"}]);
            linb.UI.cacheData('isadd', [{ "id": "a", "caption": "新增" }, { "id": "o", "caption": "原项"}]);
            paobj.Iprodctionapart('bjlxmc')
            InitRow();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveItems();
            }
            if (item.id == "a3") {
                AddRow();
            }
            if (item.id == "a5") {
                RemoveRow()
            }
            if (item.id == "a6") {
                ds.adlg.setDisplay("none");
            }
        },
        _ertreegrid_aftercellupdated: function (profile, cell, options, isHotRow) {
            var ns = this, uictrl = profile.boxing();
            if (cell._col.id == 'bjsxmc') {
                QueryCommonPart(cell.value, cell) 
            }
        }
    },
    Static: {
        viewSize: { "width": 1280, "height": 1024 }
    }
});
function InitRow() {
    var o = { "sid": agsid, "gnum": agnum }
    var url = apreurl + '/QueryItemProduction';
    var b = AjaxExb(url, o);
    ds.ertreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var pattr=true;
            var cel = r[i].toString().split(',')
            if (cel[7] == "") {
                pattr = false;
            }
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6], "editable": true }, { "value": cel[8] }, { "value": cel[7] }, { "value": cel[9] }, { "value": cel[10] }, { "value": cel[11] }, { "value": cel[12]}] })
        }
        ds.ertreegrid.setRows(arr)
    }
}
function AddRow() {
    i = GetMaxRow() + 1
    ds.ertreegrid.insertRows([{ "id": i, "cells": [
           { "value": "", "id": i + "_1" },
           { "value": "", "id": i + "_2" },
           { "value": "0", "id": i + "_3" },
           { "value": "0", "id": i + "_4" },
           { "value": "0", "id": i + "_5" },
           { "value": "0", "id": i + "_6" },
           { "value": "", "id": i + "_7" },
           { "value": "", "id": i + "_8" },
           { "value": "0", "id": i + "_9" },
           { "value": "0", "id": i + "_10" },
           { "value": "", "id": i + "_11" },
           { "value": "", "id": i + "_12" } 
           ]
    }])
}
function RemoveRow() {
    var srid = ds.ertreegrid.getActiveRow();
    if (srid == null || srid == "") {
        linb.message("请选择行");
        return;
    }
    else {
        ds.ertreegrid.removeRows(srid.id);
    }
}
function GetMaxRow() {
    var rows = ds.ertreegrid.getRows("data")
    var mrid = 1;
    for (i = 0; i < rows.length; i++) {
        var robj = rows[i]
        if (parseInt(mrid) < parseInt(robj.id)) {
            mrid = robj.id;
        }
    }
    return mrid;
}
function SaveItems() {
    var prow = ds.ertreegrid.getRows("min")
    var o = { "sid": agsid, "gnum": agnum, "itemlist": prow }
    var url = apreurl + '/SaveItemProduction';
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false);
    ds.adlg.setDisplay("none");
}
function QueryCommonPart(v,cel) {
    var o = { "bjcode": v }
    var url =  '../../../SizeFormat/QueryCommonSizeCollection';
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
       // ds.ertreegrid.updateCell(cel._row.cells[7].id, { "value": r.bjtype })
        ds.ertreegrid.updateCell(cel._row.cells[9].id, { "value": r.bjattr })
        ds.ertreegrid.updateCell(cel._row.cells[10].id, { "value": r.bjattrex })
    }
}