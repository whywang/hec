Class('App.DesignDlg', 'linb.Com', {
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
                .setCaption("设计方案")
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
                .setHeight(131)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(168)
                .setTop(90)
                .setWidth(412)
                .setHeight(30)
                .setHtml("<input type='file' name='afile' id='afile'  accept='application/x-zip-compressed,application/octet-stream'  style='height:28px; width:420px'/>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(170)
                .setTop(70)
                .setWidth(44)
                .setHeight(20)
                .setCaption("<span style='font-size:14px;color:#666666'>文件</span>")
                .setHAlign("left")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(170)
                .setTop(10)
                .setWidth(400)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;;color:#666666'>设计名称</span>")
                .setLabelHAlign("left")
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "bjp")
                .setLeft(30)
                .setTop(20)
                .setWidth(100)
                .setHeight(70)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.bjp.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(20)
                .setTop(30)
                .setCaption("<span style='font-size:16px;font-weight:bold;color:#666666'>设计方案</span>")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#cccccc" })
            );

            host.cdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "fjtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 300, "type": "input", "caption": "设计名称"}])
                .setValue("")
                .onRowSelected("_fjtreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            QueryDesign(sid);
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.fname, true, "", "请输入方案名称！", "", "", "", "")) {
                    return
                }
                var fname = ds.fname.getUIValue()
                var url = "../../../UIServer/CommonFile/UpDesignFile.aspx?sid=" + sid + "&fname=" + fname + "&dtype=" + fatype + "";
                UpFile(null, "afile", url, "QueryDesign('" + sid + "')");
            }
            if (item.id == "a3") {
                var selid = ns.fjtreegrid.getUIValue();
                if (selid == "" || selid == null) {
                    linb.warn("请选择附件");
                    return;
                }
                linb.confirms("确定要删除", "DelDesign('" + selid + "')")
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
function QueryDesign(asid) {
    var o = { "sid": asid,"dtype":fatype}
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryDesignList';
    var b = AjaxExb(url, o);
    ds.fjtreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1]}] })
        }
        ds.fjtreegrid.setRows(arr)
    }
}
function DelDesign(id) {
    var o = { "psid": id }
    var url = "../../../UIServer/CommonFile/ImageFiles.aspx/DelSelectDesign"
    var b = AjaxExb(url, o);
    BackVad(b, "QueryDesign('" + sid + "')", false)
}