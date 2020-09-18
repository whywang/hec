Class('App.ProductionCostDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setLeft(112)
                .setTop(101)
                .setWidth(1056)
                .setHeight(450)
                .setCaption("用料管理")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "rtreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setEditable(true)
                .setRowHandlerWidth(30)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "rid", "type": "label", "width": 80, "caption": "序号" }, { "id": "bjname", "type": "input", "width": 100, "caption": "产品名称" }, { "id": "bjcode", "type": "input", "width": 100, "caption": "高" }, { "id": "bjh", "type": "number", "width": 80, "caption": "宽" }, { "id": "bjk", "type": "number", "width": 80, "caption": "厚" }, { "id": "bjh", "type": "number", "width": 80, "caption": "数量" }, { "id": "bjsl", "type": "number", "width": 80, "caption": "部件" }, { "id": "bjlx", "type": "listbox", "width": 100, "caption": "工艺" }, { "id": "bjsxmc", "type": "listbox", "width": 100, "caption": "工艺编码" }, { "id": "bjsx", "type": "label", "width": 100, "caption": "用料" }, { "id": "kzsx", "type": "label", "width": 100, "caption": "用料编码" }, { "id": "xz", "type": "listbox", "width": 100, "caption": "材料" }, { "id": "xz", "type": "listbox", "width": 100, "caption": "材料编码" }, { "id": "xz", "type": "listbox", "width": 100, "caption": "优化" }, { "id": "xz", "type": "listbox", "width": 100, "caption": "用量"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            bs = this;
            cpreurl = "../../../UIServer/CommonFile/ProductionPlan.aspx";
            InitRowC();
        }
    },
    Static: {
        viewSize: { "width": 1280, "height": 1024 }
    }
});
function InitRowC() {
    var o = { "sid": csid, "gnum": cgnum }
    var url = cpreurl + '/QueryCostList';
    var b = AjaxExb(url, o);
    bs.rtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var pattr = true;
            var cel = r[i].toString().split(',')
            if (cel[7] == "") {
                pattr = false;
            }
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[8] }, { "value": cel[7] }, { "value": cel[9] }, { "value": cel[10] }, { "value": cel[11] }, { "value": cel[12] }, { "value": cel[13] }, { "value": cel[14] }, { "value": cel[15]}] })
        }
        bs.rtreegrid.setRows(arr)
    }
}