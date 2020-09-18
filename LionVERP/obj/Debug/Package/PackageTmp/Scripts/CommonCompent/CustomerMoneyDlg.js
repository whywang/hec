Class('App.CustomerMoneyDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(130)
                .setTop(160)
                .setWidth(550)
                .setHeight(160)
                .setCaption("设计订金")
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
                .setHost(host, "cdmoney")
                .setLeft(40)
                .setTop(60)
                .setWidth(410)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("订金")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cv = ns.cdmoney.getUIValue();
                if (!CheckInput(ns, ns.cdmoney, true, "number", "订金不能为空！", "正确输入订金", "", "")) {
                    return
                }
                setCustomeMoney(cv);
                ns.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ns.cdlg.setDisplay("none")
            }
        }
    }
});
function setCustomeMoney(cv) {
    var o = { "sid": sid, 'dmoney': cv }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderCustomMoney';
    var b = AjaxExb(url, o);
    BackVad(b, "", false);
}