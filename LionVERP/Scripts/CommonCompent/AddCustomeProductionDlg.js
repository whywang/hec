Class('App.AddCustomeProductionDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.DataBinder)
                .setHost(host, "abinder")
                .setName("abinder")
            );

            append(
                (new linb.UI.Dialog)
                .setHost(host, "apdlg")
                .setDock("center")
                .setLeft(26)
                .setTop(50)
                .setWidth(1020)
                .setHeight(430)
                .setCaption("非标产品")
                .setMaxBtn(false)
            );

            host.apdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pa")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.pa.append(
                (new linb.UI.Pane)
                .setHost(host, "pt")
                .setDock("top")
                .setHeight(60)
            );

            host.pt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "atoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定", "image": "../../../Image/BtnImg/sub.png" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消", "image": "../../../Image/BtnImg/back.png"}], "caption": "grp1"}])
                .onClick("_atoolbar_onclick")
            );

            host.pt.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl")
                .setLeft(30)
                .setTop(40)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>新增产品</span>")
            );

            host.pa.append(
                (new linb.UI.Pane)
                .setHost(host, "pl")
                .setDock("left")
                .setWidth(20)
            );

            host.pa.append(
                (new linb.UI.Pane)
                .setHost(host, "pr")
                .setDock("right")
                .setWidth(20)
            );

            host.pa.append(
                (new linb.UI.Pane)
                .setHost(host, "pm")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "pmt")
                .setDock("width")
                .setTop(0)
                .setHeight(175)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "border-bottom:#f2f2f2 solid 5px" })
            );

            host.pmt.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setLeft(10)
                .setTop(10)
                .setCaption("<span style='font-size:14px;font-weight:bolder;color:#666666'>产品信息</span>")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "invcate")
                .setDataBinder("abinder")
                .setDataField("invcate")
                .setLeft(80)
                .setTop(20)
                .setWidth(175)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>产品类别</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .onChange("_invcate_onchange")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "place")
                .setDataBinder("abinder")
                .setDataField("place")
                .setLeft(300)
                .setTop(20)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>位置</span>")
                .setLabelHAlign("left")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "主卧", "caption": "主卧" }, { "id": "次卧", "caption": "次卧" }, { "id": "客厅", "caption": "客厅" }, { "id": "厨房", "caption": "厨房" }, { "id": "卫生间", "caption": "卫生间" }, { "id": "儿童房", "caption": "儿童房" }, { "id": "阳台", "caption": "阳台" }, { "id": "餐厅", "caption": "餐厅" }, { "id": "入户套", "caption": "入户套"}])
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "direction")
                .setDataBinder("abinder")
                .setDataField("direction")
                .setLeft(530)
                .setTop(20)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>开向</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "左内", "caption": "左内" }, { "id": "右内", "caption": "右内" }, { "id": "左外", "caption": "左外" }, { "id": "右外", "caption": "右外" }, { "id": "左推", "caption": "左推" }, { "id": "右推", "caption": "右推" }, { "id": "左折", "caption": "左折" }, { "id": "右折", "caption": "右折"}])
            );

            host.pmt.append(
                (new linb.UI.Input)
                .setHost(host, "pnum")
                .setDataBinder("abinder")
                .setDataField("pnum")
                .setLeft(750)
                .setTop(20)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>数量</span>")
                .setLabelHAlign("left")
                .setValue("1")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "dtype")
                .setDataBinder("abinder")
                .setDataField("dtype")
                .setLeft(80)
                .setTop(70)
                .setWidth(175)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>洞口类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "洞口尺寸", "caption": "洞口尺寸" }, { "id": "套外径", "caption": "套外径" }, { "id": "套内径", "caption": "套内径" }, { "id": "套内高", "caption": "套内高" }, { "id": "套内宽", "caption": "套内宽" }, { "id": "套外高", "caption": "套外高" }, { "id": "套外宽", "caption": "套外宽"}])
            );

            host.pmt.append(
                (new linb.UI.Input)
                .setHost(host, "psize")
                .setDataBinder("abinder")
                .setDataField("psize")
                .setLeft(300)
                .setTop(70)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>洞口尺寸</span>")
                .setLabelHAlign("left")
            );

            host.pmt.append(
                (new linb.UI.Input)
                .setHost(host, "msname")
                .setDataBinder("abinder")
                .setDataField("msname")
                .setLeft(530)
                .setTop(70)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门型</span>")
                .setLabelHAlign("left")
            );

            host.pmt.append(
                (new linb.UI.Input)
                .setHost(host, "mtname")
                .setDataBinder("abinder")
                .setDataField("mtname")
                .setLeft(750)
                .setTop(70)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>套型</span>")
                .setLabelHAlign("left")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "locks")
                .setDataBinder("abinder")
                .setDataField("locks")
                .setLeft(530)
                .setTop(120)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>锁孔</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .onChange("_invcate_onchange")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "hyname")
                .setDataBinder("abinder")
                .setDataField("hyname")
                .setLeft(750)
                .setTop(120)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>合页</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "blname")
                .setDataBinder("abinder")
                .setDataField("blname")
                .setLeft(80)
                .setTop(120)
                .setWidth(175)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃型号及做法</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "blgy")
                .setDataBinder("abinder")
                .setDataField("blgy")
                .setLeft(300)
                .setTop(120)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃工艺面</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "正面", "caption": "正面" }, { "id": "反面", "caption": "反面"}])
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "pinfo")
                .setDock("width")
                .setTop(0)
                .setHeight(32)
                .setPosition("relative")
            );

            host.pinfo.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl3")
                .setLeft(10)
                .setTop(10)
                .setCaption("<span style='font-size:14px;font-weight:bolder;color:#666666'>产品明细</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D12")
                .setDock("width")
                .setTop(-5)
                .setHeight(110)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "border-bottom:#f2f2f2 solid 3px" })
            );

            host.D12.append(
                (new linb.UI.Input)
                .setHost(host, "remark")
                .setDataBinder("abinder")
                .setDataField("remark")
                .setLeft(80)
                .setTop(10)
                .setWidth(860)
                .setHeight(90)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.apdlg.show();
            ds = this;
            gnum = "";
            penum = "";
            prange = "mm"
            ltobj = LockType,
            hyobj = HyType,
            bdcode = ""; //带品牌编码
            CustIinvDropList("", prange, ds.invcate);
            ltobj.LockTypeItems(ds.locks);
            hyobj.HyTypeItems(ds.hyname);
            IWjproductionEx("00010001005", ds.blname);
            if (egnum != "0" && egnum != "") {
                gnum = egnum;
                EditProductions(sid, gnum)
                egnum = 0;
            }
            else {
                gnum = 0;
            }
        },
        _atoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveProduction();
            }
            else {
                ns.apdlg.setDisplay("none")
            }
        }
    },
    Static: {
        viewSize: { "width": 1280, "height": 1024 }
    }
});
///保存产品
function SaveProduction() {
    if (!CheckInput(ds, ds.pnum, true, "number", "请输入产品数量", "正确输入产品数量", "0", "9999")) {
        return false;
    }
    var arg1 = { "sid": sid, "gnum": gnum }
    var db = linb.DataBinder.getFromName("abinder");
    var arg2 = db.updateDataFromUI().getData();
    var o = $.extend(arg1, arg2);
    var url = '../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/CustSaveProduction';
    var b = AjaxExb(url, o);
    BackVad(b, linb.cumfun, false)
    if (penum == 0) {
        InitProduction()
    }
    else {
        ds.apdlg.setDisplay("none");
    }
}
function EditProductions(sid, gnum) {
    var o = { "sid": sid, 'gnum': gnum }
    var url = "../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/CustEditProduction"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.invcate.setUIValue("00010001"+r.itype)
        ds.place.setUIValue(r.place)
        ds.pnum.setUIValue(r.pnum)
        ds.direction.setUIValue(r.direction)
        ds.remark.setUIValue(r.remark)
        ds.dtype.setUIValue(r.dtype)
        ds.psize.setUIValue(r.psize)
        ds.msname.setUIValue(r.msname)
        ds.mtname.setUIValue(r.mtname)
        ds.blname.setUIValue(r.blname)
        ds.blgy.setUIValue(r.blgy)
        ds.locks.setUIValue(r.locks)
        ds.hyname.setUIValue(r.hing)
    }
}
function InitProduction() {
    ds.remark.setUIValue("")
    ds.pnum.setUIValue("")
}