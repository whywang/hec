Class('App.BtnImgDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "bidlg")
                .setLeft(310)
                .setTop(140)
                .setWidth(381)
                .setHeight(530)
                .setCaption("事件图片")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.bidlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a4", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.bidlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.bidlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("top")
                .setHeight(138)
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Label)
                .setHost(host, "s1")
                .setLeft(20)
                .setTop(10)
                .setWidth(80)
                .setCaption("事件图标")
                .setFontSize("16px")
                .setFontWeight("2em")
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(100)
                .setTop(30)
                .setWidth(230)
                .setHeight(30)
                .setHtml("<input type='file' name='afile' id='afile'  accept='Image/*'  style='height:28px; width:200px'/>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(50)
                .setTop(40)
                .setCaption("图标文件")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(40)
                .setTop(80)
                .setWidth(290)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("图标名称")
                .setMultiLines(true)
            );

            host.bidlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pg1")
                .setDock("top")
                .setHeight(10)
                .setCustomStyle({ "KEY": "background:#cccccc" })
            );

            host.bidlg.append(
                (new linb.UI.Pane)
                .setHost(host, "fnamel")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#bd6b14" })
            );

            host.bidlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "itreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(50)
                .setHeader([{ "id": "col1", "width": 150, "type": "input", "caption": "名称" }, { "id": "col2", "width": 100, "type": "input", "caption": "图标"}])
                .onRowSelected("_itreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.bidlg.show();
            ds = this;
            QueryImg();

        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ds = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var fname = ds.fname.getUIValue()
                var url = "../../../UIServer/BaseSet/WorkFlowManage/UpBtnImg.aspx?bname=" + fname + "";
                UpFile(ds.bidlg, "afile", url, "QueryImg()");
            }
            if (item.id == "a4") {
                ds.bidlg.setDisplay("none");
            }
        },
        _itreegrid_onrowselected: function (profile, row, e, src, type) {
            var ds = this, uictrl = profile.boxing();
            ds.itreegrid.setValue(row.id)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryImg() {
    var url = '../../../BtnImg/QueryList';
    var b = AjaxEb(url);
    ds.itreegrid.removeAllRows();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2]}] })
        }
        ds.itreegrid.setRows(arr)
    }

    binobj.IBtnIconItem(kj);
}