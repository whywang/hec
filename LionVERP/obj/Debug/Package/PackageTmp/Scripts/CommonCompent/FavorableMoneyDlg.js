Class('App.FavorableMoneyDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(150)
                .setWidth(550)
                .setHeight(220)
                .setCaption("订单优惠")
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
                .setHost(host, "fmoney")
                .setLeft(160)
                .setTop(50)
                .setWidth(340)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#999999'>优惠金额</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
                .setValue("0")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "fremark")
                .setLeft(160)
                .setTop(100)
                .setWidth(340)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#999999'>优惠说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pt")
                .setLeft(20)
                .setTop(60)
                .setWidth(100)
                .setHeight(100)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2; border-radius:5px" })
            );

            host.pt.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setLeft(30)
                .setTop(40)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#999999'>优惠</span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cv = ds.fmoney.getUIValue();
                if (!CheckInput(ds, ds.fmoney, true, "number", "优惠金额不能为空！", "正确输入优惠金额", "0", "201")) {
                    return
                }
                var rv = ds.fremark.getUIValue();
                setCustomeMoney(cv,rv);
                ds.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
function setCustomeMoney(cv,rv) {
    var o = { "sid": sid, 'fmoney': cv ,"remark":rv}
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderFavorable';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false);
}