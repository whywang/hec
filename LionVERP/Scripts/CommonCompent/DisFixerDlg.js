Class('App.DisFixerDlg', 'linb.Com', {
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
                .setCaption("安装师")
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
                .setHost(host, "azperson")
                .setLeft(140)
                .setTop(50)
                .setWidth(330)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>安装师</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(10)
                .setTop(50)
                .setWidth(100)
                .setHeight(60)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:5px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setDock("center")
                .setLeft(10)
                .setTop(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>分配安装</span>")
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
                var cv = ds.azperson.getUIValue();
                if (!CheckInput(ds, ds.azperson, true, "", "安装师不能为空！", "", "", "")) {
                    return
                }
                setFixter(cv);
                ds.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});

function setFixter(cv) {
    var o = { "sid": sid, 'azperson': cv }
    var url = '../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterFreeBackOrderDetail.aspx/SetFixter';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false);
}