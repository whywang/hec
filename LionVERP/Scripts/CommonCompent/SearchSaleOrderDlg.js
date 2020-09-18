Class('App.SearchSaleOrderDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "sdlg")
                .setDock("center")
                .setTop(200)
                .setWidth(947)
                .setHeight(340)
                .setCaption("订单查询")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.sdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "qt")
                .setDock("top")
                .setHeight(80)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.qt.append(
                (new linb.UI.Input)
                .setHost(host, "scode")
                .setLeft(30)
                .setTop(10)
                .setWidth(450)
                .setHeight(50)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>订单信息</span>")
                .setLabelHAlign("left")
            );

            host.qt.append(
                (new linb.UI.Image)
                .setHost(host, "simg")
                .setLeft(500)
                .setTop(30)
                .setWidth(90)
                .setHeight(30)
                .setSrc("../../../Image/opeimage/searchbtn.jpg")
                .setCursor("pointer")
                .onClick("_simg_onclick")
            );

            host.sdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "streegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(28)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 160, "type": "input", "caption": "订单编号" }, { "id": "col2", "width": 120, "type": "input", "caption": "城市" }, { "id": "col3", "width": 120, "type": "input", "caption": "店面" }, { "id": "col4", "width": 120, "type": "input", "caption": "客户" }, { "id": "col4", "width": 120, "type": "input", "caption": "电话" }, { "id": "col4", "width": 200, "type": "input", "caption": "地址"}])
                .onRowSelected("_streegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.sdlg.show();
            ds = this;
        },
        _streegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            IExeFun("SearchOrder('" + row.id + "')")
            ds.sdlg.setDisplay("none");
        },
        _simg_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
            var sv = ds.scode.getUIValue();
            QuerySaleOrder(sv)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QuerySaleOrder(v) {
    var url = "../../../UIServer/CommonFile/SearchingOrder.aspx/QuerySearchOrder";
    var o={"stype":otype,"sstr":v}
    var b = AjaxExb(url,o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.streegrid.removeAllRows();
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "cells": [{ "value": cel[1] }, { "value": cel[2] }, { "value": cel[3] }, { "value": cel[4] }, { "value": cel[5] }, { "value": cel[6] }, { "value": cel[7]}] })
        }
        ds.streegrid.setRows(arr)
    }
}