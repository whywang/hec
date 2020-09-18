Class('App.AfterDutyDlg', 'linb.Com', {
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
                .setHost(host, "ddlg")
                .setDock("center")
                .setLeft(70)
                .setTop(40)
                .setWidth(701)
                .setHeight(470)
                .setCaption("责任判定")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.ddlg.append(
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

            host.ddlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pmeth")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "adremark")
                .setDataBinder("binder")
                .setDataField("adremark")
                .setLeft(130)
                .setTop(60)
                .setWidth(450)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>责任说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "aduty")
                .setDataBinder("binder")
                .setDataField("aduty")
                .setReadonly(true)
                .setLeft(130)
                .setTop(10)
                .setWidth(450)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>责任</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Pane)
                .setHost(host, "ppdp")
                .setLeft(20)
                .setTop(30)
                .setWidth(80)
                .setHeight(80)
                .setCustomStyle({ "KEY": "border-radius:5px; background:#eeeeee" })
            );

            host.ppdp.append(
                (new linb.UI.SLabel)
                .setHost(host, "ls1")
                .setDock("center")
                .setLeft(20)
                .setTop(30)
                .setWidth(71)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666;font-family:汉仪细中圆简'>责任判定<span>")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "omoney")
                .setDataBinder("binder")
                .setDataField("omoney")
                .setLeft(130)
                .setTop(220)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>收费金额</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "qmoney")
                .setDataBinder("binder")
                .setDataField("qmoney")
                .setLeft(380)
                .setTop(220)
                .setWidth(200)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>教育费</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "stype")
                .setDataBinder("binder")
                .setDataField("stype")
                .setReadonly(true)
                .setLeft(130)
                .setTop(170)
                .setWidth(450)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>结算方式</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "premark")
                .setDataBinder("binder")
                .setDataField("premark")
                .setLeft(130)
                .setTop(270)
                .setWidth(450)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>收费说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

          

            host.pmeth.append(
                (new linb.UI.Image)
                .setHost(host, "simg")
                .setLeft(550)
                .setTop(35)
                .setWidth(20)
                .setHeight(20)
                .setSrc("../../../Image/opeimage/search.gif")
                .setCursor("pointer")
                .onClick("_simg_onclick")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "afname")
                .setDataBinder("binder")
                .setDataField("afname")
                .setReadonly(true)
                .setLeft(130)
                .setTop(340)
                .setWidth(450)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>生产厂</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "afcode")
                .setDataBinder("binder")
                .setDataField("afcode")
                .setReadonly(true)
                .setLeft(130)
                .setTop(300)
                .setWidth(450)
                .setHeight(45)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>生产厂</span>")
                .setLabelHAlign("left")
            );

            host.pmeth.append(
                (new linb.UI.Image)
                .setHost(host, "gimg")
                .setLeft(550)
                .setTop(365)
                .setWidth(20)
                .setHeight(20)
                .setSrc("../../../Image/opeimage/search.gif")
                .setCursor("pointer")
                .onClick("_gimg_onclick")
            );

           

            host.pmeth.append(
                (new linb.UI.Input)
                .setHost(host, "areason")
                .setDataBinder("binder")
                .setDataField("areason")
                .setReadonly(true)
                .setLeft(130)
                .setTop(120)
                .setWidth(450)
                .setHeight(48)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>返修原因</span>")
                .setLabelHAlign("left")
                .onFocus("_areason_onfocus")
            );

            host.pmeth.append(
                (new linb.UI.Pane)
                .setHost(host, "pfb")
                .setLeft(330)
                .setTop(30)
                .setWidth(270)
                .setHeight(340)
                .setDisplay("none")
                .setCustomStyle({ "KEY": "background:#ffffff;border:5px solid #f2f2f2" })
            );

            host.pfb.append(
                (new linb.UI.Pane)
                .setHost(host, "pfbt")
                .setDock("top")
                .setHeight(30)
            
            );

            host.pfbt.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.pfb.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "rtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 180, "type": "input", "caption": "返修原因" }])
                .setValue("")
               
            );
            host.pmeth.append(
                (new linb.UI.Dialog)
                .setHost(host, "dtdlg")
                .setLeft(370)
                .setTop(10)
                .setHeight(320)
                .setDisplay("none")
                .setCaption("责任")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.dtdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "ddtp")
                .setDock("top")
                .setHeight(30)
            );

            host.ddtp.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ddtoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定"}], "caption": "grp1"}])
                .onClick("_ddtoolbar_onclick")
            );

            host.dtdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "dtreegrid")
                .setSelMode("multibycheckbox")
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 200, "type": "input", "caption": "责任名称"}])
                .setValue("")
            );
            host.pmeth.append(
                (new linb.UI.Dialog)
                .setHost(host, "gcdlg")
                .setLeft(320)
                .setTop(40)
                .setDisplay("none")
                .setCaption("生产厂")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.gcdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "gctp")
                .setDock("top")
                .setHeight(30)
            );

            host.gctp.append(
                (new linb.UI.ToolBar)
                .setHost(host, "gtoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定"}], "caption": "grp1"}])
                .onClick("_gtoolbar_onclick")
            );

            host.gcdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "gtreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 200, "type": "input", "caption": "工厂"}])
                .setNoCtrlKey(false)
                .setValue("")
            );
            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.ddlg.show();
            ds = this;
            Idutylisttable(ds.dtreegrid)
        },
        _dtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.aduty, true, "", "请选择责任！", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.afname, true, "", "请输生产工厂！", "", "", "")) {
                    return
                }
                SaveDuty();
                ds.ddlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.ddlg.setDisplay("none")
            }
        },
        _ddtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            var sv = ds.dtreegrid.getUIValue();
            ds.aduty.setUIValue(sv);
            ds.stype.setUIValue(sv);
            ds.dtdlg.setDisplay("none")
        },
        _simg_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
            ds.dtdlg.setDisplay("block")
        },
        _gimg_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
            ds.gcdlg.setDisplay("block");
            IdepTableByAtrr('gc', ds.gtreegrid)
        },
        _gtoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            var sv = ds.gtreegrid.getUIValue();
            var sr = ds.gtreegrid.getRowbyRowId(sv);
            ns.afcode.setUIValue(sv);
            ns.afname.setUIValue(sr.cells[0].value);
            ds.gcdlg.setDisplay("none");
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var sv = ds.rtreegrid.getUIValue();
                ds.areason.setUIValue(sv);
            }
            ds.pfb.setDisplay("none")
        },
        _areason_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            ns.pfb.setDisplay("block");
            Ireasontable(ds.rtreegrid)
        }
    }
});
function SaveDuty() {
    var arg1 = { "sid": sid}
    var url = "../../../UIServer/AfterSaleServiceBusiness/DistributorAfterDoorYqOrder/AfterRedoOrderDetail.aspx/SaveDuty"
    var db = linb.DataBinder.getFromName("binder");
    var arg2 = db.updateDataFromUI().getData();
    var o = $.extend(arg1, arg2);
    var b = AjaxExb(url, o)
    BackVad(b, linb.cumfun, false)
}
 