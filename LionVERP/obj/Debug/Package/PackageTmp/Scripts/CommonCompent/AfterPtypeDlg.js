Class('App.AfterPtypeDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setLeft(170)
                .setTop(150)
                .setWidth(457)
                .setHeight(330)
                .setCaption("返修类别")
                .setMinBtn(false)
                .setMaxBtn(false)
            );



            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbt")
                .setDock("top")
                .setHeight(30)
            );

            host.pbt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "stoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_stoolbar_onclick")
            );
            host.ddlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "rtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 300, "type": "input", "caption": "类别"}])
                .setValue("")

            );
            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
            QueryPtypeList();
        },
        _rtreegrid_onrowselected: function (profile, row, e, src, type) {
            var uictrl = profile.boxing();

            ds.ddlg.setDisplay("none");
        },
        _stoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var sv=ds.rtreegrid.getUIValue();
                curobj.ptype.setUIValue(sv);
                ds.ddlg.setDisplay("none");
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none");
            }
        }
    }
});
function QueryPtypeList() {
    var url = "../../../RepairPtype/QueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        ds.rtreegrid.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[1], "cells": [{ "value": cel[1] }, { "value": cel[0]}] })
        }
        ds.rtreegrid.setRows(arr)
    }
}