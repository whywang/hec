Class('App.AddWlProductionDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.DataBinder)
                .setHost(host, "binder")
                .setName("binder")
            );

            append(
                (new linb.UI.Dialog)
                .setHost(host, "addwldlg")
                .setDock("center")
                .setLeft(120)
                .setTop(110)
                .setWidth(808)
                .setHeight(530)
                .setCaption("新增物料")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.addwldlg.append(
                (new linb.UI.Pane)
                .setHost(host, "apt")
                .setDock("top")
                .setHeight(80)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.apt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "atoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_atoolbar_onclick")
            );

            host.apt.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setLeft(20)
                .setTop(50)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>新增产品</span>")
            );

            host.addwldlg.append(
                (new linb.UI.Pane)
                .setHost(host, "apl")
                .setDock("left")
                .setWidth(12)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.addwldlg.append(
                (new linb.UI.Pane)
                .setHost(host, "apr")
                .setDock("right")
                .setWidth(12)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.addwldlg.append(
                (new linb.UI.Pane)
                .setHost(host, "apm")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff; border-redius:5px" })
            );

            host.apm.append(
                (new linb.UI.Input)
                .setHost(host, "pname")
                .setDataBinder("binder")
                .setDataField("pname")
                .setReadonly(true)
                .setLeft(30)
                .setTop(10)
                .setWidth(220)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>物料名称</span>")
                .setLabelHAlign("left")
                .onFocus("_pname_onfocus")
            );

            host.apm.append(
                (new linb.UI.Input)
                .setHost(host, "pcode")
                .setDataBinder("binder")
                .setDataField("pcode")
                .setLeft(280)
                .setTop(10)
                .setWidth(220)
                .setHeight(45)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("物料编码")
                .setLabelHAlign("left")
            );

            host.apm.append(
                (new linb.UI.Input)
                .setHost(host, "pnum")
                .setDataBinder("binder")
                .setDataField("pnum")
                .setLeft(280)
                .setTop(10)
                .setWidth(220)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>物料数量</span>")
                .setLabelHAlign("left")
                .setValue("1")
            );

            host.apm.append(
                (new linb.UI.Input)
                .setHost(host, "psize")
                .setDataBinder("binder")
                .setDataField("psize")
                .setReadonly(true)
                .setLeft(530)
                .setTop(10)
                .setWidth(220)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>物料规格</span>")
                .setLabelHAlign("left")
            );

            host.apm.append(
                (new linb.UI.Input)
                .setHost(host, "pbz")
                 .setDataBinder("binder")
                .setDataField("pbz")
                .setLeft(30)
                .setTop(60)
                .setWidth(720)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>物料说明</span>")
                .setLabelHAlign("left")
            );

            host.apm.append(
                (new linb.UI.Image)
                .setHost(host, "pimg")
                .setLeft(240)
                .setTop(140)
                .setWidth(310)
                .setHeight(240)
                .setSrc("img/error.gif")
                .setCustomStyle({ "KEY": "border:5px solid #f2f2f2;border-radius:5px" })
            );

            host.apm.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setLeft(30)
                .setTop(120)
                .setCaption("<span style='font-size:14px;color:#666666'>产品图</span>")
            );

            host.apm.append(
                (new linb.UI.Dialog)
                .setHost(host, "invdlg")
                .setLeft(240)
                .setTop(0)
                .setWidth(521)
                .setHeight(370)
                .setDisplay("none")
                .setCaption("选择产品")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.invdlg.append(
                (new linb.UI.Layout)
                .setHost(host, "ly")
                .setItems([{ "id": "before", "pos": "before", "min": 10, "size": 200, "locked": false, "folded": false, "hidden": false, "cmd": true }, { "id": "main", "min": 10}])
                .setType("horizontal")
            );

            host.ly.append(
                (new linb.UI.TreeBar)
                .setHost(host, "itreebar")
                .onItemSelected("_itreebar_onitemselected")
                .beforeExpend("_itreebar_beforeexpend")
            , "before");

            host.ly.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "itreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 120, "type": "input", "caption": "名称" }, { "id": "col2", "width": 1, "type": "input", "caption": " " }, { "id": "col3", "width": 130, "type": "input", "caption": "规格"}])
                .onRowSelected("_itreegrid_onrowselected")
            , "main");

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.addwldlg.show();
            ds = this;
            IinvRangeItems('', ptype, ds.itreebar);
//            if (egnum != "0" && egnum != "") {
//                gnum = egnum;
//                EditProductions(sid, gnum)
//                egnum = 0;
//            }
//            else {
//                gnum = 0;
//            }
        },
        _atoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveProduction()
            }
            else {
                ds.addwldlg.setDisplay("none");
            }
        },
        _itreebar_onitemselected: function (profile, item, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            IinvRangeCItems(item, ptype, ds.itreebar);
            QueryListWlInv(item.id, ns.itreegrid)
        },
        _itreebar_beforeexpend: function (profile, item) {
            var ns = this, uictrl = profile.boxing();
            IinvRangeCItems(item, ptype, ds.itreebar);
        },
        _itreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            var sn = row.cells[0].value;
            var sc = row.cells[1].value;
            var sz = row.cells[2].value;
            ns.pname.setUIValue(sn);
            ns.pcode.setUIValue(sc);
            ns.psize.setUIValue(sz);
            ns.invdlg.setDisplay("none");
            QueryImage(sc, ns.pimg)
        },
        _pname_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            ns.invdlg.setDisplay("block");
        }

    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
})
function SaveProduction() {
    if (!CheckInput(ds, ds.pname, true, "", "请选择产品", "", "", "")) {
        return false;
    }
    if (!CheckInput(ds, ds.pnum, true, "number", "请输入产品数量", "正确输入产品数量", "0", "9999")) {
        return false;
    }
    var arg1 = { "sid": sid, "gnum": gnum }
    var db = linb.DataBinder.getFromName("binder");
    var arg2 = db.updateDataFromUI().getData();
    var o = $.extend(arg1, arg2);
    var url = '../../../UIServer/SalesBusiness/DistributionMeterialOrder/AddMeterialProduction.aspx/SaveProduction';
    var b = AjaxExb(url, o);
    BackVad(b, "IExeFun('" + xfunstr + "')", false)
    if (egnum == 0) {
    }
    else {
        ds.addwldlg.setDisplay("none");
    }
}