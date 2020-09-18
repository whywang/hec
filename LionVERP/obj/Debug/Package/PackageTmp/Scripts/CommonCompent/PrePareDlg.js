Class('App.PrePareDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "pdlg")
                .setDock("center")
                .setTop(81)
                .setWidth(880)
                .setHeight(450)
                .setCaption("产品备货")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.pdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.pdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.pdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(98)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "psm")
                .setDataField("psm")
                .setLeft(40)
                .setTop(10)
                .setWidth(770)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("备货说明")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ertreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setEditable(true)
                .setRowHandlerWidth(30)
                .setHeaderHeight(28)
                .setRowHeight(25)
                .setHeader([{ "id": "bid", "type": "label", "width": 80, "caption": "行ID" }, { "id": "bname", "type": "label", "width": 200, "caption": "名称" }, { "id": "dw", "type": "label", "width": 120, "caption": "单位" }, { "id": "dgsl", "type": "label", "width": 120, "caption": "订购数量" }, { "id": "ybsl", "type": "label", "width": 120, "caption": "已备货量" }, { "id": "bhsl", "type": "number", "width": 120, "caption": "备货量"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.pdlg.show();
            ds = this;
            apreurl = "../../../UIServer/CommonFile/Production.aspx";
            InitRow();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveItems();
            }
            if (item.id == "a3") {
                ds.adlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});

function InitRow() {
    var vid = msid != "" ? msid : sid;
    var o = { "sid": vid }
    var url = apreurl + '/QueryWjProduction';
    var b = AjaxExb(url, o);
    ds.ertreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var pattr = true;
            var cel = r[i].toString().split(',')
            if (cel[7] == "") {
                pattr = false;
            }
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }] })

        }
        ds.ertreegrid.setRows(arr)
    }
}
function SaveItems(rm) {
    var rm = ds.psm.getUIValue();
    var prow = ds.ertreegrid.getRows("min")
    var o = { "sid":sid, "itemlist": prow ,"remark":rm}
    var url = '../../../UIServer/StorageBusiness/DistributorWjPrepareOrder/WjPreparePartOrderDetail.aspx/SavePreParePartOrder';
    var b = AjaxExb(url, o);
    BackVad(b, "", false);
    ds.pdlg.setDisplay("none");
}