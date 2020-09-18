Class('App.ShowApartDlg', 'linb.Com', {
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
                (new linb.UI.TreeGrid)
                .setHost(host, "ertreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setEditable(true)
                .setRowHandlerWidth(30)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "rid", "type": "label", "width": 80, "caption": "行ID" }, { "id": "bjname", "type": "input", "width": 100, "caption": "部件名称" }, { "id": "bjcode", "type": "input", "width": 100, "caption": "部件编码" }, { "id": "bjh", "type": "number", "width": 80, "caption": "部件高" }, { "id": "bjk", "type": "number", "width": 80, "caption": "部件宽" }, { "id": "bjh", "type": "number", "width": 80, "caption": "部件厚" }, { "id": "bjsl", "type": "number", "width": 80, "caption": "部件数量" }, { "id": "bjlx", "type": "listbox", "width": 100, "caption": "部件类别", "editorListKey": "bjlb" }, { "id": "bjsxmc", "type": "listbox", "width": 100, "caption": "类型名称", "editorListKey": "bjlxmc" }, { "id": "bjsx", "type": "label", "width": 100, "caption": "部件类型" }, { "id": "kzsx", "type": "label", "width": 100, "caption": "部件扩展类型" }, { "id": "xz", "type": "listbox", "width": 100, "caption": "是否新增", "editorListKey": "isadd"}])

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
            var pattr = true;
            var cel = r[i].toString().split(',')
            if (cel[7] == "") {
                pattr = false;
            }
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6], "editable": true }, { "value": cel[8] }, { "value": cel[7] }, { "value": cel[9] }, { "value": cel[10] }, { "value": cel[11] }, { "value": cel[12]}] })
        }
        ds.ertreegrid.setRows(arr)
    }
}