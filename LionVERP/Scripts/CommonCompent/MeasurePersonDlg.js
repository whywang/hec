Class('App.MeasurePersonDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(120)
                .setTop(160)
                .setWidth(550)
                .setHeight(160)
                .setCaption("分配测量师")
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
                .setHeight(50)
                .setCustomStyle({ "KEY": "border:5px solid #f2f2f2;background:#ffffff;border-radius:5px" })
            );

            host.scp.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(16)
                .setTop(15)
                .setWidth(83)
                .setHeight(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>分配测量师</span>")
            );

            host.cdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "clperson")
                .setLeft(160)
                .setTop(50)
                .setWidth(300)
                .setHeight(50)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>测量师</span>")
                .setLabelHAlign("left")
                .setType("input")
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
                var cv = cn.clperson.getUIValue();
                if (!CheckInput(cn, cn.clperson, true, "", "测量师不能为空！", "", "", "")) {
                    return
                }
                SetMeasurePerson(cv)
                cn.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                cn.cdlg.setDisplay("none")
            }
        }
    }
});
function SetMeasurePerson(cv) {
    var o = { "sid": sid, 'clperson': cv, 'bcode': bcode }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetMeasurePerson';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false);
}