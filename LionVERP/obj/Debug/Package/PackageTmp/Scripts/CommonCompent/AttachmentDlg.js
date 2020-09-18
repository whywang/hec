Class('App.AttachmentDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(190)
                .setWidth(780)
                .setHeight(450)
                .setCaption("附件管理")
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
                .setHeight(161)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Label)
                .setHost(host, "s1")
                .setLeft(20)
                .setTop(10)
                .setWidth(80)
                .setCaption("*附件上传")
                .setFontSize("16px")
                .setFontWeight("2em")
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(158)
                .setTop(70)
                .setWidth(430)
                .setHeight(30)
               // .setHtml("<input type='file' name='afile' id='afile'  accept='application/x-zip-compressed,application/octet-stream'  style='height:28px; width:420px'/>")
                .setHtml("<form id='upform' enctype='multipart/form-data'><input type='file' name='afile' id='afile'  accept='application/x-zip-compressed,application/octet-stream'  style='height:28px; width:420px'/></form>") 
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(130)
                .setTop(80)
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
                .setLabelCaption("文件名称")
            );

            host.pfj.append(
                (new linb.UI.ProgressBar)
                .setHost(host, "uprogress")
                .setLeft(120)
                .setTop(130)
                .setWidth(460)
                 .setDisplay("none")
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
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 300, "type": "input", "caption": "附件名称"}])
                .setValue("")
                .onRowSelected("_fjtreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            QueryAttachment(sid, "", "a");

        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.fname, true, "", "请输入附件名称！", "", "", "", "")) {
                    return
                }
                var fname = ds.fname.getUIValue()
                //var url = "../../../UIServer/CommonFile/BUpAttachment.ashx?sid=" + sid + "&fname=" + fname + "&ftype=a&gsid=";
                // UpFile(null, "afile", url, "QueryAttachment('" + sid + "', '', 'a')");
                var bufobj = BigUpFile;
                ds.uprogress.setDisplay("block")
                bufobj.url = "../../../UIServer/CommonFile/BUpAttachment.ashx?sid=" + sid + "&fname=" + fname + "&ftype=a&gsid=";
                bufobj.ufile = $("#afile")[0].files[0];
                bufobj.upload(ds.uprogress, 0, null, "QueryAttachment('" + sid + "', '', 'a')");
            }
            if (item.id == "a3") {
                var selid = ds.fjtreegrid.getUIValue();
                if (selid == "" || selid == null) {
                    linb.warn("请选择附件");
                    return;
                }
                linb.confirms("确定要删除", "DelAttachment('" + selid + "')")
            }
            if (item.id == "a4") {
                ds.cdlg.setDisplay("none");
            }
        },
        _fjtreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            ds.fjtreegrid.setValue(row.id)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryAttachment(asid, agsid, atype) {
    var o = { "sid": asid, 'gsid': agsid, 'ftype': atype }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryAttachmentList';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }] })
        }
        ds.fjtreegrid.setRows(arr)
    }
}
function DelAttachment(id) {
    var o = { "psid": id }
    var url = "../../../UIServer/CommonFile/ImageFiles.aspx/DelSelectAttachment"
    var b = AjaxExb(url, o);
    BackVad(b, "QueryAttachment('" + sid + "', '', 'a')", false)
}