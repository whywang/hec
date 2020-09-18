Class('App.OrderTypeDlg', 'linb.Com', {
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
                .setHeight(160)
                .setCaption("设置订单类型")
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
                (new linb.UI.ComboInput)
                .setHost(host, "mztype")
                .setLeft(130)
                .setTop(50)
                .setWidth(320)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>设计类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "审核类型", "caption": "审核类型" }, { "id": "设计类型", "caption": "设计类型"}])
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "dpt")
                .setLeft(20)
                .setTop(50)
                .setWidth(90)
                .setHeight(60)
                .setCustomStyle({ "KEY": "border-radius:5px; background:#eeeeee" })
            );

            host.dpt.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(10)
                .setTop(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666;font-family:汉仪细中圆简'>订单类型<span>")
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
                var cv = ns.mztype.getUIValue();
                if (!CheckInput(ns, ns.mztype, true, "", "请选择订单类型！", "", "", "")) {
                    return
                }
                setOrderType(cv);
                ns.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ns.cdlg.setDisplay("none")
            }
        }
    }
});
function setOrderType(cv) {
    var o = { "sid": sid, 'stype': cv }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderType';
    var b = AjaxExb(url, o);
    BackVad(b, "", false);
}

 