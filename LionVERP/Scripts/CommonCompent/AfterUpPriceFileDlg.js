Class('App.AfterUpPriceFileDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(150)
                .setTop(190)
                .setWidth(780)
                .setHeight(450)
                .setCaption("报价上传")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "删除" }, { "id": "a2", "type": "split", "split": true }, { "id": "a4", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(178)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Label)
                .setHost(host, "s1")
                .setLeft(20)
                .setTop(10)
                .setWidth(80)
                .setCaption("*报价文件")
                .setFontSize("16px")
                .setFontWeight("2em")
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(158)
                .setTop(110)
                .setWidth(430)
                .setHeight(30)
                .setHtml("<input type='file' name='pfile' id='pfile'  accept='aplication/zip'  style='height:28px; width:420px'/>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(130)
                .setTop(120)
                .setCaption("文件")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(100)
                .setTop(30)
                .setWidth(480)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("报价名称")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "oprice")
                .setLeft(100)
                .setTop(70)
                .setWidth(480)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("订单金额")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#cccccc" })
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "fnamel")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#bd6b14" })
            );

            host.cdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 300, "type": "input", "caption": "名称"}])
                .setValue("")
                .onRowSelected("_fjtreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            cn = this;
            QueryPriceFile();

        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(cn, cn.fname, true, "", "请输入附件名称！", "", "", "", "")) {
                    return
                }
                if (!CheckInput(cn, cn.oprice, true, "number", "请输订单金额！", "请正确输入金额", "", "", "")) {
                    return
                }
                var fname = cn.fname.getUIValue();
                var oprice = cn.oprice.getUIValue()
                var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterSale/AfterUpPriceFile.aspx?sid=" + sid + "&fname=" + fname + "&oprice=" + oprice + "";
                UpFile(null, "pfile", url, "QueryPriceFile()");
            }
            if (item.id == "a3") {
                var selid = cn.fjtreegrid.getUIValue();
                if (selid == "" || selid == null) {
                    linb.message("请选择附件");
                    return;
                }
                IDoFun("确定要删除", "DelPriceFile('" + selid + "')")
            }
            if (item.id == "a4") {
                cn.cdlg.setDisplay("none");
            }
        },
        _fjtreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            cn.fjtreegrid.setValue(row.id)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});

function QueryPriceFile() {
    var o = { "sid": sid }
    var url = '../../../UIServer/AfterSaleServiceBusiness/DistributorAfterSale/AfterOrderPrice.aspx/QueryPriceList';
    var b = AjaxExb(url, o);
    cn.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1]}] })
        }
        cn.fjtreegrid.setRows(arr)
    }
}
function DelPriceFile(id) {
    var o = { "pid": id }
    var url = "../../../../UIServer/AfterSaleServiceBusiness/DistributorAfterSale/AfterOrderPrice.aspx/DelPrice"
    var b = AjaxExb(url, o);
    BackVad(b, "QueryPriceFile()", false)
}