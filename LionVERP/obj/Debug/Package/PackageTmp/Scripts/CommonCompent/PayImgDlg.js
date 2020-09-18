Class('App.PayImgDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(230)
                .setTop(160)
                .setWidth(780)
                .setHeight(530)
                .setCaption("图片上传")
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
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(138)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(160)
                .setTop(30)
                .setWidth(430)
                .setHeight(30)
                .setHtml("<input type='file' name='afile' id='afile'  accept='Image/*'  style='height:28px; width:420px'/>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(160)
                .setTop(10)
                .setCaption("<span style='font-size:14px;color:#999999'>图片文件</span>")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(160)
                .setTop(70)
                .setWidth(440)
                .setHeight(50)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#999999'>备注</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "pib")
                .setLeft(20)
                .setTop(20)
                .setWidth(100)
                .setHeight(100)
                .setCustomStyle({ "KEY": "background:#ffffff;border-radius:5px ;border:5px solid #f2f2f2" })
            );

            host.pib.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(20)
                .setTop(40)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#999999'>汇款凭证</span>")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.cdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "itreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(50)
                .setHeader([{ "id": "col1", "width": 150, "type": "input", "caption": "图片" }, { "id": "col2", "width": 450, "type": "input", "caption": "说明"}])
                .setValue("")
                .onRowSelected("_fjtreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            QueryPayImg();

        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var fname = ds.fname.getUIValue()
                var url = "../../../UIServer/SalesBusiness/DistributorDoorOrder/UpPayImg.aspx?sid=" + sid + "&imgms=" + fname + "&ptype=" + pztype + "";
                UpFile(null, "afile", url, "QueryPayImg()");
            }
            if (item.id == "a3") {
                var selid = ds.itreegrid.getUIValue();
                if (selid == "" || selid == null) {
                    linb.warn("请选择附件");
                    return;
                }
                linb.confirms("确定要删除", "DelPayImg('" + selid + "')")
            }
            if (item.id == "a4") {
                ds.cdlg.setDisplay("none");
            }
        },
        _fjtreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            ds.itreegrid.setValue(row.id)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryPayImg() {
    var o = {sid: sid,ptype: pztype }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryPayImgList';
    var b = AjaxExb(url, o);
    ds.itreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }] })
        }
        ds.itreegrid.setRows(arr)
    }
  
}
function DelPayImg(id) {
    var o = { "pid": id }
    var url = "../../../UIServer/CommonFile/ImageFiles.aspx/DelPayImg"
    var b = AjaxExb(url, o);
    BackVad(b, "QueryPayImg()", false)
}