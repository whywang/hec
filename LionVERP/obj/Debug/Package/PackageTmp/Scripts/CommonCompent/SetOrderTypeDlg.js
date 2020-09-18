Class('App.SetOrderTypeDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "scdlg")
                .setLeft(130)
                .setTop(160)
                .setWidth(550)
                .setHeight(140)
                .setCaption("单据类型")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.scdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.scdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "otype")
                .setLeft(50)
                .setTop(50)
                .setWidth(410)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("订单类型")
                .setType("listbox")
                .setItems([{ "id": "1", "caption": "通过" }, { "id": "-1", "caption": "驳回"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.scdlg.show();
            ds = this;
            otobj = OrderType
            otobj.IOrderTypeItems(emcode, ds.otype)
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var otype = ns.otype.getUIValue();
                SetOrderTypes(otype)
                ds.scdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.scdlg.setDisplay("none")
            }
        }
    }
});
function SetOrderTypes(ot) {
    var o = { "sid": sid, "otype": ot }
    var url = "../../../UIServer/CommonFile/CommonOrderType.aspx/SetOrderCode"
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false);
 
}