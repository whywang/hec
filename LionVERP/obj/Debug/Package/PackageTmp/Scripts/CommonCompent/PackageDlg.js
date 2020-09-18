Class('App.PackageDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "jydlg")
                .setDock("center")
                .setLeft(48)
                .setTop(126)
                .setWidth(940)
                .setHeight(510)
                .setCaption("产品分包")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.jydlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.jydlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
 
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setEditable(true)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 60, "type": "input", "caption": "ID号" }, { "id": "col1", "width": 80, "type": "input", "caption": "包号" }, { "id": "col1", "width": 80, "type": "input", "caption": "产品序号" }, { "id": "col1", "width": 150, "type": "input", "caption": "产品名称" }, { "id": "col1", "width": 80, "type": "input", "caption": "颜色" }, { "id": "col1", "width": 160, "type": "input", "caption": "尺寸" }, { "id": "col1", "width": 80, "type": "input", "caption": "总数" }, { "id": "col1", "width": 80, "type": "input", "caption": "数量" }, { "id": "col1", "width": 200, "type": "input", "caption": "备注"}])
                .setValue("")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.jydlg.show();
            ds = this;
            QueryProductionItems()
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveItems()
            }
            if (item.id == "a3") {
                ds.jydlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryProductionItems() {
    var o = { "sid": sid }
    var url = '../../../UIServer/CommonFile/ProductionPackage.aspx/QueryPackageProductionList';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7] }, { "value": cel[8]}] })
        }
        ds.fjtreegrid.setRows(arr)
    }
}
function SaveItems() {
    var rv = ds.fjtreegrid.getRows("min")
    var o = { "sid": sid,"blist": rv }
    var url = '../../../UIServer/CommonFile/ProductionPackage.aspx/SavePackageProduction';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    BackVad(b, "QueryProductionItems()", false)
}