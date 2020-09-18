Class('App.OrderDistributionFactroyDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "ddlg")
                .setDock("center")
                .setTop(160)
                .setWidth(565)
                .setHeight(200)
                .setCaption("工厂分单")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.ddlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "fname")
                .setLeft(150)
                .setTop(50)
                .setWidth(340)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>生产中心</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .onChange("_fname_onchange")
            );

            host.ddlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "sccycle")
                .setLeft(150)
                .setTop(100)
                .setWidth(340)
                .setHeight(47)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>计划完工日期</span>")
                .setLabelHAlign("left")
                .setType("date")
            );

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(10)
                .setTop(60)
                .setWidth(100)
                .setHeight(80)
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(30)
                .setTop(30)
                .setCaption("<span  style='font-size:16px;font-weight:bolder;color:#999'>工厂</span>")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            ds = this;
            this.ddlg.show();
            IdepOnlyItemsByAtrr("gc", ds.fname);
            pbobj = ProductionBrand
            pbobj.IFristFactory(pbdcode, ds.fname)
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.fname, true, "", "请选择工厂！", "", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.sccycle, true, "date", "请输入完工日期！", "请正确输完工日期", "", "", "")) {
                    return
                }
                var fc = ds.fname.getUIValue();
                var fd = ds.sccycle.getUIValue();
                SetOrderFactory(fc, fd);
                ds.ddlg.setDisplay("none");
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none")
            }
        },
        _fname_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            QueryScDate(newValue);
        }
    }
});
function SetOrderFactory(fc, fd) {
    var o = { "bcode": bcode, 'fcode': fc,"fdate":fd,"sid":sid,"emcode":emcode }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SaveFactory';
    var b = AjaxExb(url, o);
    BackVad(b,  linb.cumfun, true);
}
function QueryScDate(fc) {
    var o = { "bdcode": pbdcode, 'fcode': fc, "sid": sid }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/QueryFactoryDate';
    var b = AjaxExb(url, o);
    ds.sccycle.setUIValue(b)
}

