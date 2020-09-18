Class('App.DutyDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setTop(200)
                .setWidth(701)
                .setHeight(470)
                .setCaption("责任判定")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "tpane")
                .setDock("top")
                .setHeight(31)
            );

            host.tpane.append(
                (new linb.UI.ToolBar)
                .setHost(host, "dtoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_dtoolbar_onclick")
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pmeth")
                .setDock("top")
                .setHeight(129)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "dway")
                .setLeft(130)
                .setTop(60)
                .setWidth(450)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>处理方式</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "omoney")
                .setLeft(130)
                .setTop(10)
                .setWidth(450)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>支付金额</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Pane)
                .setHost(host, "ppdp")
                .setLeft(20)
                .setTop(30)
                .setWidth(80)
                .setHeight(80)
                .setCustomStyle({ "KEY": "border-radius:5px; background:#eeeeee" })
            );

            host.ppdp.append(
                (new linb.UI.SLabel)
                .setHost(host, "ls1")
                .setDock("center")
                .setLeft(20)
                .setTop(30)
                .setWidth(71)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666;font-family:汉仪细中圆简'>责任判定<span>")
            );

            host.ddlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "dtreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setEditable(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "zrname", "type": "label", "width": 150, "caption": "责任" }, { "id": "zrcode", "type": "label", "width": 120, "caption": "编码" }, { "id": "zrbl", "type": "number", "width": 120, "caption": "责任比例" }, { "id": "zrje", "type": "number", "width": 120, "caption": "责任金额"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            cn = this;
            QueryOrderDuty(cn.dtreegrid);
        },
        _dtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var bdt = cn.dway.getUIValue();
                if (!CheckInput(cn, cn.dway, true, "", "反馈单处理方式！", "", "", "")) {
                    return
                }
                if (!CheckInput(cn, cn.omoney, true, "number", "请输入城市收取进度！", "", "", "")) {
                    return
                }
                var dm = ns.omoney.getUIValue()
                var dv = ns.dtreegrid.getUIValue()
                SaveDuty(dv, dm, bdt)
            }
            if (item.id == "a3") {
                cn.ddlg.setDisplay("none")
            }
        }
    }
});
function SaveDuty(dv, dm, mv) {
    var prow = cn.dtreegrid.getRows("min")
    var o = { "sid": sid, "pduty": prow, "clfs": mv, "om": dm }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterOrderDetail.aspx/SetDuty"
    var b = AjaxExb(url, o);
    BackVad(b, xfunstr, false);
    cn.ddlg.setDisplay("none")
}
function QueryOrderDuty(kj) {
    var o = { "sid": sid }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterOrderDetail.aspx/QueryOrderDuty"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false);
    if (r) {
        kj.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[0] }, { "value": cel[1] }, { "value": cel[2] }, { "value": cel[3]}] })
        }
        kj.setRows(arr)
    }
}