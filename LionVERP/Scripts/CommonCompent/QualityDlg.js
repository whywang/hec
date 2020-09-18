Class('App.QualityDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "jydlg")
                .setDock("center")
                .setTop(170)
                .setWidth(940)
                .setHeight(510)
                .setCaption("产品检验")
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
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.jydlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(128)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "qremark")
                .setLeft(40)
                .setTop(60)
                .setWidth(850)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>验货说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pfj.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ytype")
                .setLeft(40)
                .setTop(10)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "s", "caption": "合格" }, { "id": "f", "caption": "不合格"}])
                .setWidth(230)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>检验类型</span>")
                .setValue("s")
            );

            host.jydlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.jydlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 60, "type": "input", "caption": "序号" }, { "id": "col1", "width": 150, "type": "input", "caption": "产品名称" }, { "id": "col1", "width": 80, "type": "input", "caption": "高" }, { "id": "col1", "width": 80, "type": "input", "caption": "宽" }, { "id": "col1", "width": 80, "type": "input", "caption": "厚" }, { "id": "col1", "width": 80, "type": "input", "caption": "数量" }, { "id": "col1", "width": 120, "type": "input", "caption": "颜色" }, { "id": "col1", "width": 200, "type": "input", "caption": "备注"}])
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
                var qv = ds.ytype.getUIValue();
                var bz = ds.qremark.getUIValue();
                var rv = ds.fjtreegrid.getUIValue();
                if (qv == "" || qv == null) {
                    linb.message("请选择检验类型");
                    return;
                }
                if (rv == "" || rv == null) {
                    linb.message("请选择检验产品");
                    return;
                }
                SaveItems(qv, bz, rv)
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
    var o = { "sid": sid}
    var url = '../../../UIServer/CommonFile/Production.aspx/QueryQualityProduction';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [ { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7] }, { "value": cel[8]}] })
        }
        ds.fjtreegrid.setRows(arr)
    }
}
function SaveItems(qv,bz,rv) {
    var o = { "sid": sid ,"qtype":qv,"qremark":bz,"rowid":rv}
    var url = '../../../UIServer/QualityBusiness/DistributorDoorOrder/QcDoorOrderDetail.aspx/SaveQualityProduction';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    BackVad(b, "QueryProductionItems()", false)
}