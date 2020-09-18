Class('App.SendAddressDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "sdlg")
                .setLeft(217)
                .setTop(171)
                .setWidth(670)
                .setHeight(390)
                .setCaption("发货地址设置")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.sdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.sdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "atp")
                .setDock("top")
                .setHeight(141)
            );

            host.atp.append(
                (new linb.UI.Input)
                .setHost(host, "cperson")
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("联系人")
                .setLabelHAlign("left")
            );

            host.atp.append(
                (new linb.UI.Input)
                .setHost(host, "telephone")
                .setLeft(340)
                .setTop(10)
                .setWidth(240)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("联系电话")
                .setLabelHAlign("left")
            );

            host.atp.append(
                (new linb.UI.Input)
                .setHost(host, "address")
                .setLeft(50)
                .setTop(60)
                .setWidth(530)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("联系人")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.sdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "streegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(28)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 120, "type": "input", "caption": " 联系人" }, { "id": "col2", "width": 120, "type": "input", "caption": "联系电话" }, { "id": "col3", "width": 330, "type": "input", "caption": "发货地址"}])
                .onRowSelected("_streegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.sdlg.show();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
              
            }
            if (item.id == "a3") {
                ns.sdlg.setDisplay("none")
            }
        },
        _streegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});