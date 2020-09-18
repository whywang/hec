Class('App.ProdcutionChangeDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "pcdlg")
                .setLeft(10)
                .setTop(90)
                .setWidth(1010)
                .setHeight(450)
                .setCaption("产品更改说明")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.pcdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.pcdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ectreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setEditable(true)
                .setRowHandlerWidth(30)
                .setHeaderHeight(28)
                .setRowHeight(25)
                .setHeader([{ "id": "rid", "type": "label", "width": 80, "caption": "行ID" }, { "id": "bjname", "type": "label", "width": 80, "caption": "序号" }, { "id": "bjh", "type": "label", "width": 150, "caption": "名称" }, { "id": "bjk", "type": "label", "width": 100, "caption": "颜色" }, { "id": "bjh", "type": "label", "width": 120, "caption": "尺寸" }, { "id": "bjsl", "type": "label", "width": 150, "caption": "备注" }, { "id": "bjlx", "type": "input", "width": 300, "caption": "更改说明"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.pcdlg.show();
            ds = this;
            cpreurl = "../../../UIServer/CommonFile/Production.aspx";
            InitRow();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveChangeItems()
            }
            if (item.id == "a3") {
                ns.pcdlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function InitRow() {
    var o = {"sid":sid, "osid":osid }
    var url = cpreurl + '/QueryGroupProduction';
    var b = AjaxExb(url, o);
    ds.ectreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var pattr = true;
            var cel = r[i].toString().split(',')
            if (cel[7] == "") {
                pattr = false;
            }
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6], "editable": true }, { "value": cel[7] }, { "value": cel[8]}] })
        }
        ds.ectreegrid.setRows(arr)
    }
}
function SaveChangeItems() {
    var prow = ds.ectreegrid.getRows("min");
    var o = { "sid": sid, "prow": prow }
    var url = '../../../UIServer/ChangeServiceBusiness/DistributorChangeDoorMqOrder/CProductionMqChangeRequest.aspx/SaveProductionChangeRequest';
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false);
}