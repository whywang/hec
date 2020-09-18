Class('App.OverServiceDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(140)
                .setWidth(638)
                .setHeight(400)
                .setCaption("<span style='font-size:14px;color:#666666'>服务类型</span>")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "plimg")
                .setDock("top")
                .setHeight("auto")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pt")
                .setDock("top")
                .setHeight(30)
            );

            host.pt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "otype")
                .setLeft(50)
                .setTop(50)
                .setWidth(220)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>服务类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "完成", "caption": "完成" }, { "id": "返修", "caption": "返修" }, { "id": "重做", "caption": "重做"}])
            );

            host.cdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "odate")
                .setLeft(330)
                .setTop(50)
                .setWidth(225)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>完工日期</span>")
                .setLabelHAlign("left")
                .setType("date")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "oinfo")
                .setLeft(50)
                .setTop(160)
                .setWidth(520)
                .setHeight(90)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>完工情况</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "cinfo")
                .setLeft(50)
                .setTop(260)
                .setWidth(520)
                .setHeight(90)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>客户意见</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "fmoney")
                .setLeft(50)
                .setTop(100)
                .setWidth(235)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>实收金额</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            ds = this;
            this.cdlg.show();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.otype, true, "", "请选择服务类型！", "", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.fmoney, true, "number", "请输入实际金额！", "", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.odate, true, "date", "请选择完工日期！", "", "", "", "")) {
                    return
                }
                var otv = ds.otype.getUIValue();
                var odv = ds.odate.getUIValue();
                var oiv = ds.oinfo.getUIValue();
                var civ = ds.cinfo.getUIValue();
                var fiv = ds.fmoney.getUIValue();
                setOverService(otv, odv, oiv, civ,fiv);
                ds.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});

function setOverService(otv, odv, oiv, civ,fiv) {
    var o = { "sid": sid, 'otype': otv, "odate": odv, "oinfo": oiv,"cinfo":civ ,"fmoney":fiv}
    var url = '../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterFreeBackOrderDetail.aspx/SetServiceOver';
    var b = AjaxExb(url, o);
    BackVad(b,xfunstr, false);
}