Class('App.AddAfterProductionDlg', 'linb.Com', {
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
                .setHost(host, "cdlg")
                .setDock("center")
                .setLeft(40)
                .setTop(120)
                .setWidth(930)
                .setHeight(380)
                .setCaption("售后产品")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "tpane")
                .setDock("top")
                .setHeight(30)
                .setPosition("relative")
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
                .setDock("width")
                .setTop(0)
                .setHeight(230)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "itype")
                .setDataBinder("binder")
                .setDataField("itype")
                .setLeft(30)
                .setTop(20)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>产品类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "门板", "caption": "门板" }, { "id": "门套", "caption": "门套" }, { "id": "垭口", "caption": "垭口" }, { "id": "集成家装", "caption": "集成家装" }, { "id": "家具", "caption": "家具" }, { "id": "其他", "caption": "其他"}])
                .onChange("_itype_onchange")
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "place")
                .setDataBinder("binder")
                .setDataField("place")
                .setLeft(250)
                .setTop(20)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>位置</span>")
                .setLabelHAlign("left")
                .setItems([{ "id": "主卧", "caption": "主卧" }, { "id": "次卧", "caption": "次卧" }, { "id": "客厅", "caption": "客厅" }, { "id": "阳台", "caption": "阳台" }, { "id": "厨房", "caption": "厨房" }, { "id": "卫生间", "caption": "卫生间" }, { "id": "儿童房", "caption": "儿童房"}])
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "direction")
                .setDataBinder("binder")
                .setDataField("direction")
                .setLeft(470)
                .setTop(20)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>开向</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "左内", "caption": "左内" }, { "id": "右外", "caption": "右外" }, { "id": "左外", "caption": "左外" }, { "id": "右内", "caption": "右内" }, { "id": "左推", "caption": "左推" }, { "id": "右推", "caption": "右推" }, { "id": "左折", "caption": "左折" }, { "id": "右折", "caption": "右折"}])
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "fixs")
                .setDataBinder("binder")
                .setDataField("fixs")
                .setLeft(690)
                .setTop(20)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套拼接方式</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "45°", "caption": "45°" }, { "id": "90°", "caption": "90°"}])
                .setValue("无")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "mname")
                .setDataBinder("binder")
                .setDataField("mname")
                .setLeft(30)
                .setTop(70)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>饰面花色</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "glasss")
                .setDataBinder("binder")
                .setDataField("glasss")
                .setLeft(470)
                .setTop(70)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃花色及做法</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "gsize")
                .setDataBinder("binder")
                .setDataField("gsize")
                .setLeft(690)
                .setTop(70)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃尺寸</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "pname")
                .setDataBinder("binder")
                .setDataField("pname")
                .setLeft(250)
                .setTop(120)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>返修部件</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "ph")
                .setDataBinder("binder")
                .setDataField("ph")
                .setLeft(250)
                .setTop(170)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>高</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "pw")
                .setDataBinder("binder")
                .setDataField("pw")
                .setLeft(390)
                .setTop(170)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>宽</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "pd")
                .setDataBinder("binder")
                .setDataField("pd")
                .setLeft(530)
                .setTop(170)
                .setWidth(110)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>厚</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "pnum")
                .setDataBinder("binder")
                .setDataField("pnum")
                .setLeft(660)
                .setTop(170)
                .setWidth(110)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>数量</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .setDisplay("none")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "psid")
                .setDataBinder("binder")
                .setDataField("psid")
                .setLeft(280)
                .setTop(140)
                .setWidth(140)
                .setHeight(45)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>psid</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "locks")
                .setDataBinder("binder")
                .setDataField("locks")
                .setLeft(250)
                .setTop(70)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>锁体类型</span>")
                .setLabelHAlign("left")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "不开锁孔", "caption": "不开锁孔" }, { "id": "标准T口单开磁力（老款）", "caption": "标准T口单开磁力（老款）" }, { "id": "标准T口单开磁力（新款）", "caption": "标准T口单开磁力（新款）" }, { "id": "露水河平口门（新款磁力锁体））", "caption": "露水河平口门（新款磁力锁体）" }, { "id": "全玻璃", "caption": "全玻璃" }, { "id": "SJ001锁体", "caption": "SJ001锁体" }, { "id": "甲供", "caption": "甲供" }, { "id": "兰迪", "caption": "兰迪" }, { "id": "单边锁", "caption": "单边锁" }, { "id": "标准锁体", "caption": "标准锁体" }, { "id": "圆弧套/对开门老款磁力锁体", "caption": "圆弧套/对开门老款磁力锁体"}])
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "msname")
                .setDataBinder("binder")
                .setDataField("msname")
                .setLeft(470)
                .setTop(120)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门型</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "stype")
                .setDataBinder("binder")
                .setDataField("stype")
                .setLeft(30)
                .setTop(170)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>尺寸类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "套内", "caption": "套内" }, { "id": "套外", "caption": "套外" }, { "id": "实际尺寸（90度）", "caption": "实际尺寸（90度）" }, { "id": "门板尺寸", "caption": "门板尺寸"}])
                .onChange("_itype_onchange")
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "sitype")
                .setDataBinder("binder")
                .setDataField("sitype")
                .setLeft(30)
                .setTop(120)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>返修产品小类</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ggy")
                .setDataBinder("binder")
                .setDataField("ggy")
                .setLeft(690)
                .setTop(120)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃工艺</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "正", "caption": "正" }, { "id": "反", "caption": "反"}])
                .setValue("无")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "pmsd")
                .setDataBinder("binder")
                .setDataField("pmsd")
                .setLeft(790)
                .setTop(170)
                .setWidth(100)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门厚</span>")
                .setLabelHAlign("left")
                .setDisplay("none")
                .setValue("")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pbzp")
                .setDock("width")
                .setHeight(80)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pbzp.append(
                (new linb.UI.Input)
                .setHost(host, "premark")
                .setDataBinder("binder")
                .setDataField("premark")
                .setLeft(30)
                .setTop(0)
                .setWidth(860)
                .setHeight(70)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>特殊项</span>")
                .setLabelHAlign("left")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            if (egnum == 0) {
            }
            else {
                AEditProduction(egnum)
            }
        },
        _dtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var itype = ds.itype.getUIValue()
                if (!CheckInput(ds, ds.itype, true, "", "请选择产品类型！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.place, true, "", "位置不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.direction, true, "", "开向不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.mname, true, "", "饰面花色不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.locks, true, "", "锁体类型不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.glasss, true, "", "玻璃花色及做法不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.gsize, true, "", "玻璃尺寸不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.pname, true, "", "产品不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.msname, true, "", "门型不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.stype, true, "", "产品尺寸不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.pnum, true, "number", "产品数量不能为空！", "请正确数据产品数量", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.sitype, true, "", "返修产品子类型不能为空！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.premark, true, "", "返修产品子类型不能为空！", "", "", "")) {
                    return
                }
                if (itype == "门套") {
                    if (!CheckInput(ds, ds.pmsd, true, "", "门厚不能为空！", "", "", "")) {
                        return
                    }
                }
                SaveProduction()
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        },
        _itype_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            ShowsPart(newValue)
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function initProduction() {
    ds.place.setValue("");
    ds.direction.setValue("");
    ds.fixs.setValue("");
    ds.mname.setValue("");
    ds.locks.setValue("");
    ds.glasss.setValue("");
    ds.gsize.setValue("");
    ds.pname.setValue("");
    ds.ph.setValue(0);
    ds.pw.setValue(0);
    ds.pd.setValue(0);
    ds.stype.setValue("");
    ds.msname.setValue("");
    ds.pnum.setValue(1);
    ds.premark.setValue("");
    ds.psid.setValue("");
    ds.sitype.setValue("");
    ds.msname.setValue("");
    ds.stype.setValue("");
    ds.itype.setValue("");
    ds.ggy.setValue("");
    ds.pmds.setValue("");
}
function SaveProduction() {
    var arg1 = { "sid": sid }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/AddProduction"
    var db = linb.DataBinder.getFromName("binder");
    var arg2 = db.updateDataFromUI().getData();
    var o = $.extend(arg1, arg2);
    var b = AjaxExb(url, o)
    BackVad(b, linb.cumfun, false)
    if (egnum != 0) {
        ds.cdlg.setDisplay("none");
    }
    WorkFlowBar(emcode, sid, ns.toolbar);
    initProduction();
}
function AEditProduction(gn) {
    var o = { "sid": sid, "gnum": gn }
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AddAfterProduction.aspx/QueryProduction"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.itype.setValue(r.itype);
        ds.place.setValue(r.place);
        ds.direction.setValue(r.direction);
        ds.fixs.setValue(r.fixs);
        ds.mname.setValue(r.mname);
        ds.locks.setValue(r.locks);
        ds.glasss.setValue(r.glass);
        ds.gsize.setValue(r.gsize);
        ds.pname.setValue(r.pname);
        ds.ph.setValue(r.height);
        ds.pw.setValue(r.width);
        ds.pd.setValue(r.deep);
        ds.stype.setValue(r.stype);
        ds.msname.setValue(r.msname);
        ds.pnum.setValue(r.pnum);
        ds.premark.setValue(r.remark);
        ds.psid.setValue(r.psid);
        ds.sitype.setValue(r.sitype);
        ds.msname.setValue(r.msname);
        ds.stype.setValue(r.stype);
        ds.ggy.setValue(r.ggy);
        ds.pmsd.setValue(r.pmsd);
        ShowsPart(r.itype)
    }
}
function ShowsPart(v) {
    if (v == "门套") {
        ds.sitype.setItems([{ "id": "标准T口套", "caption": "标准T口套" }, { "id": "圆弧套", "caption": "圆弧套" }, { "id": "全玻璃门套", "caption": "全玻璃门套" }, { "id": "推拉套", "caption": "推拉套" }, { "id": "折叠套", "caption": "折叠套" }, { "id": "双T口套", "caption": "双T口套" }, { "id": "档条门套", "caption": "档条门套" }, { "id": "露水河套", "caption": "露水河套" }, { "id": "防火套", "caption": "防火套" }, { "id": "联动折叠套", "caption": "联动折叠套" }, { "id": "半玻璃门套", "caption": "半玻璃门套"}])
        ds.pmsd.setDisplay("block");
    }
    if (v == "门板") {
        ds.sitype.setItems([{ "id": "标准T口单开门", "caption": "标准T口单开门" }, { "id": "圆弧门", "caption": "圆弧门" }, { "id": "全玻璃门", "caption": "全玻璃门" }, { "id": "推拉门", "caption": "推拉门" }, { "id": "折叠门", "caption": "折叠门" }, { "id": "双T口门", "caption": "双T口门" }, { "id": "档条门", "caption": "档条门" }, { "id": "露水河门", "caption": "露水河门" }, { "id": "防火门", "caption": "防火门" }, { "id": "联动折叠门", "caption": "联动折叠门" }, { "id": "半玻璃门", "caption": "半玻璃门"}])
    }
    if (v == "垭口") {
        ds.sitype.setItems([{ "id": "标准垭口", "caption": "标准垭口" }, { "id": "圆弧垭口", "caption": "圆弧垭口" }, { "id": "露水河垭口", "caption": "露水河垭口"}])
    }
    if (v != "门套" && v != "门板" && v != "垭口") {
        ds.sitype.setItems("");
    }
}
