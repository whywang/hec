Class('App.ChangeCostDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(70)
                .setTop(104)
                .setWidth(701)
                .setHeight(341)
                .setCaption("更改成本")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "tpane")
                .setDock("top")
                .setHeight(31)
            );

            host.tpane.append(
                (new linb.UI.ToolBar)
                .setHost(host, "dtoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_dtoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pmeth")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pmeth.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(30)
                .setTop(30)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>更改成本</span>")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "ycost")
                .setLeft(90)
                .setTop(130)
                .setWidth(550)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>已发生成本</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "pscjd")
                .setLeft(90)
                .setTop(50)
                .setWidth(550)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>生产进度</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "cremark")
                .setLeft(90)
                .setTop(180)
                .setWidth(550)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>备注</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            QueryCost();
        },
        _dtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.ycost, true, "", "变更成本不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.pscjd, true, "", "订单进度不能为空！", "", "", "")) {
                    return
                }
                var dc = ds.ycost.getUIValue();
                var dj = ds.pscjd.getUIValue();
                var dr = ds.cremark.getUIValue();
                SaveCost(dc, dj,dr)
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
function QueryCost() {
    var o = { "sid": sid}
    var url = "../../../UIServer/ChangeServiceBusiness/DistributorChangeDoorMqOrder/CSaleMqOrder.aspx/QueryOrder"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false);
    if (r) {
        ds.ycost.setUIValue(r.ccost);
        ds.pscjd.setUIValue(r.pjd);
        ds.cremark.setUIValue(r.cremark);
    }
}
function SaveCost(dc,dj,dr) {
    var o = { "sid": sid, "ccost": dc, "cremark": dr, "pjd": dj }
    var url = "../../../UIServer/ChangeServiceBusiness/DistributorChangeDoorMqOrder/CSaleMqOrder.aspx/UpChangeCost"
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", true);
}