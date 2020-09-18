Class('App.AfterProductionInHouseDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "apdlg")
                .setDock("center")
                .setLeft(120)
                .setTop(110)
                .setWidth(795)
                .setHeight(453)
                .setCaption("返修产品入库")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.apdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "rtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 80, "type": "input", "caption": "序号" }, { "id": "col1", "width": 120, "type": "input", "caption": "位置" }, { "id": "col1", "width": 120, "type": "input", "caption": "产品" }, { "id": "col1", "width": 100, "type": "input", "caption": "颜色" }, { "id": "col1", "width": 160, "type": "input", "caption": "尺寸" }, { "id": "col1", "width": 80, "type": "input", "caption": "数量"}])
                .setValue("")
            );

            host.apdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "ppt")
                .setDock("top")
                .setHeight(120)
            );

            host.ppt.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(30)
                .setTop(40)
                .setWidth(100)
                .setHeight(70)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:8px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(10)
                .setTop(30)
                .setCaption("<span style='font-size:18px;font-weight:bolder;color:#666666'>产品入库</span>")
            );

            host.ppt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "stoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_stoolbar_onclick")
            );

            host.ppt.append(
                (new linb.UI.Input)
                .setHost(host, "iremark")
                .setLeft(150)
                .setTop(40)
                .setWidth(580)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px; color:#666666'>入库说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.apdlg.show();
            ds = this;
            QueryProductionItems()
        },
        _stoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var sv = ds.rtreegrid.getUIValue();
                if (sv == null || sv == "") {
                    linb.warn("请选择产品");
                    return;
                }
                var rv = ds.iremark.getUIValue();
                SaveProductionItems(sv, rv)
            }
            if (item.id == "a3") {
                ds.apdlg.setDisplay("none")
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryProductionItems() {
    var o = { "sid": sid }
    var url = '../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/QueryProductionInHouse';
    var b = AjaxExb(url, o);
    ds.rtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7] }, { "value": cel[8]}] })
        }
        ds.rtreegrid.setRows(arr)
    }
}
function SaveProductionItems(sv,rv) {
    var o = {"bcode":bcode, "sid": sid, "psids": sv, "remark": rv }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/ProductionInHouse"
    var b = AjaxExb(url, o)
    BackVad(b, "QueryProductionItems();WorkFlowBar(emcode, sid, ns.toolbar);", false)
}