Class('App.SetOverDateDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setLeft(171)
                .setTop(149)
                .setWidth(575)
                .setHeight(161)
                .setCaption("完工设置")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbt")
                .setDock("top")
                .setHeight(30)
            );

            host.pbt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "stoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_stoolbar_onclick")
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(30)
                .setTop(50)
                .setWidth(90)
                .setHeight(60)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:8px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(10)
                .setTop(20)
                .setCaption("<span style='font-size:18px;font-weight:bolder;color:#666666'>完工日期</span>")
            );

            host.ddlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "sodate")
                .setLeft(160)
                .setTop(55)
                .setWidth(300)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelHAlign("left")
                .setType("date")
                .setLabelCaption("<span style='font-size:14px ; color:#666666'>完工日期</span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
        },
        _stoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.sodate, true, "date", "完工日期不能为空！", "", "", "", "")) {
                    return
                }
                var odt = ds.sodate.getUIValue();
                SetOverDate(odt) 
                ds.ddlg.setDisplay("none");
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none");
            }
        }
    }
});
function SetOverDate(odt) {
    var o = { "sid": sid ,'odate':odt}
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/SaveOverDate"
    var b = AjaxExb(url, o)
    BackVad(b, linb.cumfun, false)
}