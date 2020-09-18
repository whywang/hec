Class('App.AfterProuctionRemarkDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.DataBinder)
                .setHost(host, "binder")
                .setName("binder")
            );

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setLeft(70)
                .setTop(200)
                .setWidth(701)
                .setHeight(210)
                .setCaption("产品返修说明")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "tpane")
                .setDock("top")
                .setHeight(31)
            );

            host.tpane.append(
                (new linb.UI.ToolBar)
                .setHost(host, "dtoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_dtoolbar_onclick")
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pmeth")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "adremark")
                .setDataBinder("binder")
                .setDataField("adremark")
                .setLeft(130)
                .setTop(20)
                .setWidth(450)
                .setHeight(90)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>返修内容</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pmeth.append(
                (new linb.UI.Pane)
                .setHost(host, "ppdp")
                .setLeft(20)
                .setTop(30)
                .setWidth(80)
                .setHeight(80)
                .setCustomStyle({ "KEY": "border-radius:5px; background:#eeeeee" })
            );

            host.ppdp.append(
                (new linb.UI.SLabel)
                .setHost(host, "ls1")
                .setDock("center")
                .setLeft(20)
                .setTop(30)
                .setWidth(71)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666;font-family:汉仪细中圆简'>返修说明<span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
            QueryProductionRemark() 
        },
        _dtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.adremark, true, "", "请输入返修内容", "", "", "")) {
                    return
                }
                SaveProductionRemark()
                ds.ddlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none")
            }
        } 
    }
});
function QueryProductionRemark() {
    var o = { "sid": sid, "gnum": egnum }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/QueryProduction"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false);
    if (r) {
        ds.adremark.setUIValue(r.adremark);
    }
}
function SaveProductionRemark() {
    var adv=ds.adremark.getUIValue();
    var o = { "sid": sid, "gnum": egnum, "adremark": adv }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/SaveProductionRemark"
    var b = AjaxExb(url, o);
    var r = BackVad(b, linb.cumfun, false);
}