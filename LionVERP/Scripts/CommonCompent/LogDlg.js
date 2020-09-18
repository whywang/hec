Class('App.LogDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "logdlg")
                .setDock("center")
                .setTop(150)
                .setWidth(780)
                .setHeight(530)
                .setCaption("日志")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.logdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ltreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(50)
                .setHeader([{ "id": "col1", "width": 130, "type": "input", "caption": "事件" }, { "id": "col1", "width": 130, "type": "input", "caption": "操作人" }, { "id": "col2", "width": 300, "type": "input", "caption": "说明" }, { "id": "col2", "width": 140, "type": "input", "caption": "日期"}])
                .setValue("")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.logdlg.show();
            ds = this;
            QueryLog();
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
})
function QueryLog() {
    var o = { "sid": sid }
    var url = '../../../UIServer/CommonFile/LogRecords.aspx/QueryList';
    var b = AjaxExb(url, o);
    ds.ltreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4]}] })
        }
        ds.ltreegrid.setRows(arr)
    }
}