Class('App.ShowAttachmentDlg', 'linb.Com', {
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
                .setCaption("附件管理")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.sadlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.sadlg.append(
                (new linb.UI.Pane)
                .setHost(host, "fnamel")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#bd6b14" })
            );

            host.sadlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 300, "type": "input", "caption": "附件名称" }, { "id": "col1", "width": 200, "type": "input", "caption": "下载"}])
                .setValue("")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.sadlg.show();
            ds = this;
            QueryAttachment(sid, "", "a");
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryAttachment(asid, agsid, atype) {
    var o = { "sid": asid, 'gsid': agsid, 'ftype': atype }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryAttachmentList';
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