Class('App.OrderRemarkDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "rdlg")
                .setLeft(130)
                .setTop(160)
                .setWidth(550)
                .setHeight(210)
                .setCaption("工艺要求")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.rdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "rtoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_rtoolbar_onclick")
            );

            host.rdlg.append(
                (new linb.UI.Input)
                .setHost(host, "sremark")
                .setLeft(70)
                .setTop(50)
                .setWidth(410)
                .setHeight(100)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>工艺要求</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.rdlg.show();
            ds = this;
        },
        _rtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cv = ds.sremark.getUIValue();
                if (!CheckInput(ds, ds.sremark, true, "", "订单编码不能为空！", "", "", "")) {
                    return
                }
                SaveRemark(cv);
                ds.rdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.rdlg.setDisplay("none")
            }
        }
    }
});

function SaveRemark(cv) {
    var o = { "sid": sid, 'emcode': emcode,'bcode':bcode,'remark':cv }
    var url = '../../../UIServer/CommonFile/CommonOrderRemark.aspx/SetOrderZbRemark';
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false);
}