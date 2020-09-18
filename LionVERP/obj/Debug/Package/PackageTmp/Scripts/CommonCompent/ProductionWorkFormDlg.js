Class('App.ProductionWorkFormDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(110)
                .setTop(150)
                .setWidth(830)
                .setHeight(350)
                .setCaption("产品生产车间")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "ptb")
                .setDock("top")
                .setHeight(30)
            );

            host.ptb.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ptreegrid")
                .setAltRowsBg(true)
                .setEditable(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setRowHandler(false)
                .setHeader([{ "id": "label", "type": "label", "width": 80, "caption": "ID" }, { "id": "input", "type": "label", "width": 80, "caption": "序号" }, { "id": "combobox", "type": "label", "width": 120, "caption": "产品类型" }, { "id": "listbox", "type": "label", "width": 120, "caption": "名称位置" }, { "id": "getter", "type": "label", "width": 120, "caption": "产品小类" }, { "id": "cmdbox", "type": "label", "width": 140, "caption": "返修部件" }, { "id": "popbox", "type": "input", "width": 140, "caption": "生产车间"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            cn = this;
            QueryProduction();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SetWorkFrom()
                cn.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                cn.cdlg.setDisplay("none")
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryProduction() {
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/QueryProductionList";
    var o = { "sid": sid };
    var b = AjaxExb(url, o);
    cn.ptreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6]}] })
        }
        cn.ptreegrid.setRows(arr)
    }
}
function SetWorkFrom() {
    var plist = cn.ptreegrid.getRows("min")
    var o = { "sid": sid, 'plist': plist }
    var url = '../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/SetWorkFrom';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false);
}