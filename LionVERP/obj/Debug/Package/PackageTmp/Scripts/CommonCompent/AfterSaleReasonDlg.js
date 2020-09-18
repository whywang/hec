Class('App.AfterSaleReasonDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setTop(200)
                .setWidth(650)
                .setHeight(300)
                .setCaption("售后原因")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "rtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 400, "type": "input", "caption": "责任" }, { "id": "col1", "width": 160, "type": "input", "caption": "类别"}])
                .setValue("")
                .onRowSelected("_rtreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
            QueryReasonList();
        },
        _rtreegrid_onrowselected: function (profile, row, e, src, type) {
            var uictrl = profile.boxing();
            ns.areason.setUIValue(row.cells[0].value);
            ds.ddlg.setDisplay("none");
        }
    }
});
function QueryReasonList() {
    var url = "../../../UIServer/BaseSet/RepairReasonManage/RepairReasons.aspx/QueryAllList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        ds.rtreegrid.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[2] }, { "value": cel[1] }] })
        }
        ds.rtreegrid.setRows(arr)
    }
}