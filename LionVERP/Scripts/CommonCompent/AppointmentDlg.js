Class('App.AppointmentDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(160)
                .setWidth(550)
                .setCaption("售后预约")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "sdate")
                .setLeft(40)
                .setTop(50)
                .setWidth(180)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>售后日期</span>")
                .setLabelHAlign("left")
                .setType("date")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "gofee")
                .setLeft(280)
                .setTop(50)
                .setWidth(200)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>上门费</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "servfee")
                .setLeft(40)
                .setTop(100)
                .setWidth(200)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>材料费</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "stext")
                .setLeft(40)
                .setTop(150)
                .setWidth(440)
                .setHeight(90)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>售后内容</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            QueryOrder();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cv = ds.sdate.getUIValue();
                var gv = ds.gofee.getUIValue();
                var vv = ds.servfee.getUIValue();
                var sv = ds.stext.getUIValue();
                if (!CheckInput(ds, ds.sdate, true, "date", "请选择售后日期！", "", "", "")) {
                    return
                }

                setAppointment(cv, gv, vv, sv);
                ds.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
function QueryOrder() {
    var o = { "sid": sid }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterFreeBackOrderDetail.aspx/QueryOrder"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.sdate.setValue(r.sdate);
        ds.gofee.setValue(r.gofee);
        ds.servfee.setValue(r.servfee);
        ds.stext.setValue(r.stext);
    }
}
function setAppointment(cv, gv, vv, sv) {
    var o = { "sid": sid,"cv":cv,"gv":gv, "vv":vv, "sv":sv}
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterFreeBackOrderDetail.aspx/UpdateAppointment"
    var b = AjaxExb(url, o);
    var r = BackVad(b, xfunstr, false)
}