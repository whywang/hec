Class('App.ProductionTypeDlg', 'linb.Com', {
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
                .setCaption("设置产品类型")
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
                .setHost(host, "pztype")
                .setLeft(130)
                .setTop(50)
                .setWidth(320)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>产品类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无家具", "caption": "无家具" }, { "id": "含家具", "caption": "含家具"}])
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
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666;font-family:汉仪细中圆简'>产品类型<span>")
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
                var cv = ns.pztype.getUIValue();
                if (!CheckInput(ns, ns.pztype, true, "", "请选择产品类型！", "", "", "")) {
                    return
                }
                setProductionType(cv);
                ns.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ns.cdlg.setDisplay("none")
            }
        }
    }
});
function setProductionType(cv) {
    var o = { "sid": sid, 'ptype': cv }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetProductionType';
    var b = AjaxExb(url, o);
    BackVad(b, "", false);
}
