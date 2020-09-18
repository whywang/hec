Class('App.OrderMoneyDlg', 'linb.Com', {
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
                .setHeight(250)
                .setCaption("订单金额")
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
                (new linb.UI.Input)
                .setHost(host, "ocode")
                .setLeft(170)
                .setTop(50)
                .setWidth(330)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>订单金额</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
                .setValue("0")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "bj")
                .setLeft(20)
                .setTop(90)
                .setWidth(100)
                .setHeight(50)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.bj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl")
                .setLeft(20)
                .setTop(20)
                .setCaption("<span style='font-size:16px;font-weight:bold;color:#666666'>订单金额</span>")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "mremark")
                .setLeft(170)
                .setTop(100)
                .setWidth(330)
                .setHeight(100)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>价格说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            cn = this;
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cv = cn.ocode.getUIValue();
                var rv = cn.mremark.getUIValue();
                if (!CheckInput(cn, cn.ocode, true, "number", "订单金额不能为空！", "", 0, 1000000)) {
                    return
                }
                if (!CheckInput(cn, cn.mremark, true, "", "价格说明不能为空！", "", "", "")) {
                    return
                }
                SetOrderMoney(cv,rv);
                cn.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                cn.cdlg.setDisplay("none")
            }
        }
    }
});
function SetOrderMoney(v,rv) {
    var o = { "sid": sid, 'omoney': v, 'mremark': rv }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderMoney';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false);
}