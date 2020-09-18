Class('App.ShowDesignDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "sadlg")
                .setLeft(150)
                .setTop(190)
                .setWidth(780)
                .setHeight(450)
                .setCaption("设计方案管理")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.sadlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 300, "type": "input", "caption": "方案名称" }, { "id": "col1", "width": 200, "type": "input", "caption": "下载"}])
                .setValue("")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.sadlg.show();
            ds = this;
            QueryDesign(sid);
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryDesign(asid) {
    var o = { "sid": asid,"dtype":fatype }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryDesignList';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2]}] })
        }
        ds.fjtreegrid.setRows(arr)
    }
}