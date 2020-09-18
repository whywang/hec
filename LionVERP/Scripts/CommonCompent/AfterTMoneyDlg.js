Class('App.AfterTMoneyDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setLeft(170)
                .setTop(150)
                .setWidth(457)
                .setHeight(170)
                .setCaption("实收金额")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbt")
                .setDock("top")
                .setHeight(30)
            );

            host.pbt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "stoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_stoolbar_onclick")
            );

            host.ddlg.append(
                (new linb.UI.Input)
                .setHost(host, "etmoney")
                .setLeft(70)
                .setTop(50)
                .setWidth(290)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>金额</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
            QueryOrderMoney();
        },
        _stoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.etmoney, true, "number", "实收金额不能为空！", "", "", "")) {
                    return
                }
                var v = ds.etmoney.getUIValue()
                SetAfterMoney(v)
               
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none");
            }
        }
    }
});
function QueryOrderMoney() {
    var o = { "sid": sid }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/QueryOrder"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.etmoney.setUIValue(r.tmoney)
    }
}
function SetAfterMoney(v) {
    var o = { "sid": sid,"cv":v }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/SetTrueMoney"
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false)
    ds.ddlg.setDisplay("none");
}