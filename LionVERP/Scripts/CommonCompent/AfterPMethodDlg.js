Class('App.AfterPMethodDlg', 'linb.Com', {
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
                .setCaption("付费方式")
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
                (new linb.UI.ComboInput)
                .setHost(host, "pmethod")
                .setLeft(60)
                .setTop(50)
                .setWidth(320)
                .setHeight(46)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "到付", "caption": "到付" }, { "id": "公司付", "caption": "公司付" }, { "id": "物流付", "caption": "物流付"}])
                .setLabelCaption("<span style='color:#666666;font-size:14px'>付费方式</span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
            QueryOrderPMethod();
        },
        _stoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.pmethod, true, "", "请选择付费方式！", "", "", "")) {
                    return
                }
                var v = ds.pmethod.getUIValue()
                SetAfterPMethod(v)
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none");
            }
        }
    }
});
function QueryOrderPMethod() {
    var o = { "sid": sid }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/QueryOrder"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.pmethod.setUIValue(r.pmethod)
    }
}
function SetAfterPMethod(v) {
    var o = { "sid": sid, "pmethod": v }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/SetPmethod"
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false)
    ds.ddlg.setDisplay("none");
}