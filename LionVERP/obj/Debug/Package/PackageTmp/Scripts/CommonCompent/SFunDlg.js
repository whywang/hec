Class('App.SFunDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "sfdlg")
                .setLeft(200)
                .setTop(260)
                .setWidth(550)
                .setHeight(270)
                .setCaption("选择方法")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.sfdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ftreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 190, "type": "input", "caption": "方法名称" }, { "id": "col2", "width": 250, "type": "input", "caption": "方法"}])
                .onRowSelected("_ftreegrid_onrowselected")
            );

            return children;

        },
        customAppend: function () {
            ds = this;
            this.sfdlg.show();
            QueryFunclist();
        },
        _ftreegrid_onrowselected: function (profile, row, e, src, type) {
            var ds = this, uictrl = profile.boxing();
            kj.setUIValue(row.cells[1].value.toString().replace(new RegExp('-', 'g'), ','));
            ds.sfdlg.setDisplay("none")
        }
    }
});
function QueryFunclist() {
    var url = "../../../CommonFunction/QueryList";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        ds.ftreegrid.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2]}] })
        }
        ds.ftreegrid.setRows(arr)
    }
}