Class('App.ProduceTypeDlg', 'linb.Com', {
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
                .setCaption("生产方式")
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
                (new linb.UI.Pane)
                .setHost(host, "scp")
                .setLeft(20)
                .setTop(50)
                .setWidth(90)
                .setHeight(60)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:5px" })
            );

            host.scp.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(20)
                .setTop(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>生产方式</span>")
            );

            host.cdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "gytype")
                .setLeft(160)
                .setTop(50)
                .setWidth(300)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>生产方式</span>")
                .setLabelHAlign("left")
                .setItems([{ "id": "线上", "caption": "线上" }, { "id": "线下", "caption": "线下"}])
                .setValue("线上")
                .setType("listbox")
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
                var cv = cn.gytype.getUIValue();
                if (!CheckInput(cn, cn.gytype, true, "", "生产方式不能为空！", "", "", "")) {
                    return
                }
                setProduceType(cv)
                cn.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                cn.cdlg.setDisplay("none")
            }
        }
    }
});
function setProduceType(v) {
    var o = { "sid": sid, 'emcode': emcode, 'bcode': bcode, 'gytype': v }
    var url = '../../../UIServer/CommonFile/OrderProduceType.aspx/SetOrderProduceType';
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false);
}