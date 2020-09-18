Class('App.CheckBackDlg', 'linb.Com', {
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
                .setCaption("订单驳回")
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
                .setReadonly(true)
                .setLeft(50)
                .setTop(50)
                .setWidth(410)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("处理结果")
                .setType("listbox")
                .setItems([{ "id": "-1", "caption": "驳回"}])
                .setValue("-1")
            );

            host.cdlg.append(
                (new linb.UI.Input)
                .setHost(host, "checkbz")
                .setLeft(50)
                .setTop(100)
                .setWidth(410)
                .setHeight(50)
                .setLabelSize(60)
                .setLabelCaption("驳回意见")
                .setMultiLines(true)
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
                var bzt = ds.checkstate.getUIValue();
                var bdt = ds.checkbz.getUIValue();
                if (!CheckInput(ds, ds.checkbz, true, "", "请输入驳回原因！", "", "", "")) {
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