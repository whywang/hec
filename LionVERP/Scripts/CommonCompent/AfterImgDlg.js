Class('App.AfterImgDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "afterdlg")
                .setDock("center")
                .setTop(200)
                .setWidth(780)
                .setHeight(530)
                .setCaption("图片上传")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.afterdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "atoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "删除" }, { "id": "a2", "type": "split", "split": true }, { "id": "a4", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_atoolbar_onclick")
            );

            host.afterdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(198)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(160)
                .setTop(35)
                .setWidth(430)
                .setHeight(30)
                .setHtml("<input type='file' name='afile' id='afile'  accept='Image/*'  style='height:25px; width:420px'/>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(160)
                .setTop(20)
                .setCaption("<span style='font-size:14px;color:#666666'>图片文件</span>")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fremark")
                .setLeft(160)
                .setTop(120)
                .setWidth(420)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>图片说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(160)
                .setTop(70)
                .setWidth(420)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>文件名称</span>")
                .setLabelHAlign("left")
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "pbp")
                .setLeft(30)
                .setTop(30)
                .setWidth(100)
                .setHeight(150)
                .setCustomStyle({ "KEY": "border-radius:5px;background:#f2f2f2" })
            );

            host.pbp.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(20)
                .setTop(70)
                .setCaption("<span style='font-size:18px;font-weight:bolder;color:#666666'>传图</span>")
            );

            host.afterdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.afterdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ftreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(50)
                .setHeader([{ "id": "col1", "width": 150, "type": "input", "caption": "图片" }, { "id": "col1", "width": 150, "type": "input", "caption": "名称" }, { "id": "col2", "width": 450, "type": "input", "caption": "说明"}])
                .setValue("")
                .onRowSelected("_ftreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.afterdlg.show();
            ds = this;
            QueryImg(sid);

        },

        _ftreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            ds.ftreegrid.setValue(row.id)
        },
        _atoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var fname = ds.fname.getUIValue();
                var fremark = ds.fremark.getUIValue();
                var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorMqOrder/UpFeedBackImg.aspx?sid=" + sid + "&fname=" + fname + "&fremark=" + fremark + "";
                UpFile(null, "afile", url, "QueryImg()");
            }
            if (item.id == "a3") {
                var selid = ds.ftreegrid.getUIValue();
                if (selid == "" || selid == null) {
                    linb.message("请选择附件");
                    return;
                }
                linb.confirms("确定要删除", "DelImg('" + selid + "')")
            }
            if (item.id == "a4") {
                ds.afterdlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
})
function QueryImg() {
    var o = { "sid": sid }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryAfterImgList';
    var b = AjaxExb(url, o);
    ds.ftreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[3] }, { "value": cel[1] }, { "value": cel[2]}] })
        }
        ds.ftreegrid.setRows(arr)
    }
}
function DelImg(id) {
    var o = { "psid": id }
    var url = "../../../UIServer/CommonFile/ImageFiles.aspx/DelAfterImg"
    var b = AjaxExb(url, o);
    BackVad(b, "QueryImg()", false)
}