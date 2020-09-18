Class('App.DismantleDlg', 'linb.Com', {
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
                .setCaption("分配拆单")
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
                .setHost(host, "cdy")
                .setLeft(160)
                .setTop(50)
                .setWidth(350)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#999999'>拆单员</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(20)
                .setTop(50)
                .setWidth(100)
                .setHeight(50)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(20)
                .setTop(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#999999'>拆单员</span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            IEmployeeCd("0028", ds.cdy)
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cdy = ds.cdy.getUIValue()
                if (!CheckInput(ds, ds.cdy, true, "", "选择拆单员！", "", "", "")) {
                    return
                }
                SetDismantle(cdy)
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
function SetDismantle(v) {
    var o = { "sid": sid, 'cdy': v }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderDismantle';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cunfum, false);
    ds.cdlg.setDisplay("none")
}