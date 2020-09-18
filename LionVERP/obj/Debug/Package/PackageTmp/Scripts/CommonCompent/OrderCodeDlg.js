Class('App.OrderCodeDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {

            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                    .setHost(host, "cdlg")
                    .setDock("center")
                    .setTop(160)
                    .setWidth(550)
                    .setHeight(160)
                    .setCaption("订单编码")
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
                    .setLeft(40)
                    .setTop(60)
                    .setWidth(410)
                    .setHeight(25)
                    .setLabelSize(60)
                    .setLabelCaption("订单编码")
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
                if (!CheckInput(cn, cn.ocode, true, "", "订单编码不能为空！", "", "", "")) {
                    return
                }
                setOrderCode(cv);
                cn.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                cn.cdlg.setDisplay("none")
            }
        }
    }
});
function setOrderCode(v) {
    var fstr = "";
    if (xfunstr) {
        fstr = xfunstr;
    }
    var o = { "sid": sid, 'code': v }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderCode';
    var b = AjaxExb(url, o);
    BackVad(b, fstr, false);
}