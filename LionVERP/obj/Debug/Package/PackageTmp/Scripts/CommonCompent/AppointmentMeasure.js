Class('App.AppointmentMeasureDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.DataBinder)
                .setHost(host, "mbinder")
                .setName("mbinder")
            );

            append(
                (new linb.UI.Dialog)
                .setHost(host, "mdlg")
                .setDock("center")
                .setLeft(130)
                .setTop(0)
                .setWidth(550)
                .setHeight(590)
                .setCaption("测量预约")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.mdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.mdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "mdate")
                .setDataBinder("mbinder")
                .setDataField("mdate")
                .setLeft(50)
                .setTop(40)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>测量日期</span>")
                .setLabelHAlign("left")
                .setType("date")
            );

            host.mdlg.append(
                (new linb.UI.Input)
                .setHost(host, "mremark")
                .setDataBinder("mbinder")
                .setDataField("mremark")
                .setLeft(50)
                .setTop(240)
                .setWidth(440)
                .setHeight(90)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>测量要求</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.mdlg.append(
                (new linb.UI.Input)
                .setHost(host, "telephone")
                .setDataBinder("mbinder")
                .setDataField("telephone")
                .setLeft(290)
                .setTop(40)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>联系电话</span>")
                .setLabelHAlign("left")
            );

            host.mdlg.append(
                (new linb.UI.Input)
                .setHost(host, "customer")
                .setDataBinder("mbinder")
                .setDataField("customer")
                .setLeft(50)
                .setTop(90)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>客户</span>")
                .setLabelHAlign("left")
            );

            host.mdlg.append(
                (new linb.UI.Input)
                .setHost(host, "gzname")
                .setDataBinder("mbinder")
                .setDataField("gzname")
                .setLeft(290)
                .setTop(90)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>工长</span>")
                .setLabelHAlign("left")
            );

            host.mdlg.append(
                (new linb.UI.Input)
                .setHost(host, "address")
                .setDataBinder("mbinder")
                .setDataField("address")
                .setLeft(50)
                .setTop(190)
                .setWidth(440)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'> 详细地址</span>")
                .setLabelHAlign("left")
            );

            host.mdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "aprovince")
                .setDataBinder("mbinder")
                .setDataField("aprovince")
                .setLeft(50)
                .setTop(140)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>省/市</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .onChange("_aprovince_onchange")
            );

            host.mdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "acity")
                .setDataBinder("mbinder")
                .setDataField("acity")
                .setLeft(290)
                .setTop(140)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>市/区</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.mdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "mtreegrid")
                .setDock("none")
                .setLeft(50)
                .setTop(340)
                .setWidth(440)
                .setAltRowsBg(true)
                .setEditable(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setRowHandler(false)
                .setHeader([{ "id": "label", "type": "label", "width": 200, "caption": "产品类别" }, { "id": "input", "type": "input", "width": 120, "caption": "数量"}])
            );
            host.mdlg.append(
                (new linb.UI.Input)
                .setHost(host, "csid")
                .setDataBinder("mbinder")
                .setDataField("csid")
                .setLeft(50)
                .setTop(90)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setDisplay("none")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>客户</span>")
                .setLabelHAlign("left")
            );
            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.mdlg.show();
            ds = this;
            LoadMeasure();
            ICascadeItems("0", ds.aprovince);
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveMeasure();
                ds.mdlg.setDisplay("none");
            }
            else {
                ds.mdlg.setDisplay("none");
            }
        },
        _aprovince_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            ICascadeItems(newValue, ds.acity)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function LoadMeasure() {
    var o = { "sid": sid}
    var url = '../../../UIServer/CityService/DistributorMeasureService/MeasureOrderDetail.aspx/InitOrder';
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.customer.setUIValue(r.customer);
        ds.telephone.setUIValue(r.telephone);
        ds.aprovince.setUIValue(r.aprovince);
        ds.acity.setUIValue(r.acity);
        ds.address.setUIValue(r.address);
        ds.mremark.setUIValue(r.mremark);
        ds.csid.setUIValue(r.sid);
        ds.mdate.setUIValue(r.mdate);
        var arr = new Array();
        ds.mtreegrid.removeAllRows();
        if (r.bplist != null) {
            for (var k = 0; k < r.bplist.length; k++) {
                var robj = r.bplist[k];
                arr.push({ "id": robj.pcname, "cells": [{ "value": robj.pcname }, { "value": robj.pcnum}] })
            }
        }
        ds.mtreegrid.setRows(arr);
    }
}
function SaveMeasure() {
    if (!CheckInput(ds, ds.customer, true, "", "客户名称不能为空！", "", "", "")) {
        return
    }
    if (!CheckInput(ds, ds.telephone, true, "telephone", "电话不能为空！", "正确输入电话号码！", "", "")) {
        return
    }
    if (!CheckInput(ds, ds.address, true, "", "客户地址不能为空！", "", "", "")) {
        return
    }
    if (!CheckInput(ds, ds.mdate, true, "date", "测量日期不能为空！", "", "", "", "")) {
        return
    }
    if (!CheckInput(ds, ds.acity, true, "", "城市不能为空！", "", "", "", "")) {
        return
    }
    if (!CheckInput(ds, ds.aprovince, true, "", "导购不能为空！", "", "", "", "")) {
        return
    }
    var plist = ds.mtreegrid.getRows("min")
    var arg1 = { "sid": sid, "emcode": "0137", "bcode": "0296", "plist": plist }
    var url ="../../../UIServer/CityService/DistributorMeasureService/MeasureOrderDetail.aspx/SaveOrder"
    var db = linb.DataBinder.getFromName("mbinder");
    var arg2 = db.updateDataFromUI().getData();
    var o = $.extend(arg1, arg2);
    var b = AjaxExb(url, o)
    BackVad(b, linb.cumfun, false)
}