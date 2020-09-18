Class('App.CheckDlg', 'linb.Com', {
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
                .setHeight(210)
                .setCaption("单据审核")
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
                .setHost(host, "checkstate")
                .setLeft(140)
                .setTop(50)
                .setWidth(350)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#999999'>处理结果</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "1", "caption": "通过" }, { "id": "-1", "caption": "驳回"}])
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "checkbz")
                .setLeft(140)
                .setTop(100)
                .setWidth(350)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#999999'>处理意见</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(20)
                .setTop(50)
                .setWidth(100)
                .setHeight(100)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(30)
                .setTop(40)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#999999'>审核</span>")
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
                var bzt = ns.checkstate.getUIValue();
                var bdt = ns.checkbz.getUIValue();
                if (!CheckInput(ns, ns.checkstate, true, "", "选择审核状态！", "", "", "")) {
                    return
                }
                FireCheckBtn(sid, bcode, bzt, bdt)
            }
            if (item.id == "a3") {
                ns.cdlg.setDisplay("none")
            }
        }
    }
});