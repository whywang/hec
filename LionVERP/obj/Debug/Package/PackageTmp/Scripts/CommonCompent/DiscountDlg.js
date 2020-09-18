Class('App.DiscountDlg', 'linb.Com', {
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
                .setHeight(170)
                .setCaption("折扣设置")
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
                .setHost(host, "odiscount")
                .setLeft(160)
                .setTop(50)
                .setWidth(350)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>折扣</span>")
                .setLabelHAlign("left")
                .setValue(1)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "bjt")
                .setLeft(20)
                .setTop(40)
                .setWidth(100)
                .setHeight(70)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.bjt.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(30)
                .setTop(30)
                .setCaption("<span style='color:#999999;font-size:16px;font-weight:bolder'>折扣</span>")
            );

            host.cdlg.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setLeft(220)
                .setTop(110)
                .setCaption("<span style='color:#ff0000;font-size:14px'>(折扣输入0-1之间的小数)</span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            ds = this;
            this.cdlg.show();

        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.odiscount, true, "number", "请输入折扣！", "请正确输入折扣", "0", "1", "")) {
                    return
                }
                var dt = ds.odiscount.getUIValue();
                SetDiscounts(dt)
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
function SetDiscounts(v) {
    var o = { "sid":sid, 'dv': v  }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetDiscount';
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false);
    ds.cdlg.setDisplay("none")
}