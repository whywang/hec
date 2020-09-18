Class('App.MqOrderInHouseDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ihdlg")
                .setLeft(70)
                .setTop(130)
                .setWidth(940)
                .setHeight(510)
                .setCaption("免漆产品入库")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ihdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.ihdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.ihdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(108)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "qremark")
                .setLeft(40)
                .setTop(10)
                .setWidth(850)
                .setHeight(80)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>入库说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.ihdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.ihdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([  { "id": "col1", "width": 200, "type": "input", "caption": "包装编码" }, { "id": "col1", "width": 160, "type": "input", "caption": "包装号" }])
                .setValue("")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ihdlg.show();
            ds = this;
            QueryProductionItems()
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var bz = ds.qremark.getUIValue();
                var rv = ds.fjtreegrid.getUIValue();
                if (rv == "" || rv == null) {
                    linb.message("请选择包装");
                    return;
                }
                SaveItems(bz, rv)
            }
            if (item.id == "a3") {
                ds.ihdlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryProductionItems() {
    var o = { "sid": sid }
    var url = '../../../UIServer/CommonFile/OrderPackage.aspx/QueryPackageUnInHouseList';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7] }, { "value": cel[8]}] })
        }
        ds.fjtreegrid.setRows(arr)
    }
}
function SaveItems( bz, rv) {
    var o = { "sid": sid,"qremark": bz, "rowid": rv }
    var url = '../../../UIServer/StorageBusiness/DistributorDoorMqOrder/InDoorMqOrderDetail.aspx/SavePackage';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    BackVad(b, "QueryProductionItems()", false)
}