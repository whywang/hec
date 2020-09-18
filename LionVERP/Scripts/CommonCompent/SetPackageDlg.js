Class('App.SetPackageDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "bdlg")
                .setDock("center")
                .setLeft(120)
                .setTop(110)
                .setWidth(616)
                .setHeight(170)
                .setCaption("包装设置")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.bdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "ppt")
                .setDock("top")
                .setHeight(120)
            );

            host.ppt.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(30)
                .setTop(40)
                .setWidth(100)
                .setHeight(70)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:8px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(10)
                .setTop(30)
                .setCaption("<span style='font-size:18px;font-weight:bolder;color:#666666'>产品包装</span>")
            );

            host.ppt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "stoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_stoolbar_onclick")
            );

            host.ppt.append(
                (new linb.UI.Input)
                .setHost(host, "bnum")
                .setLeft(170)
                .setTop(50)
                .setWidth(350)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px; color:#666666'>包装数</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
                .setValue("1")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.bdlg.show();
            ds = this;
        },
        _stoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id = "a1") {
                var sv = ds.bnum.getUIValue();
                if (!CheckInput(ds, ds.bnum, true, "", "请输入包装数量！", "", "", "")) {
                    return
                }
                SetPackageNum(sv)
                ds.bdlg.setDisplay("none");
            }
            if (item.id = "a3") {
                ds.bdlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function SetPackageNum(v) {
    var o = { "sid": sid, "bnum": v}
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/SetPackageNum"
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false);
}