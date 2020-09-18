Class('App.MsPlanDlg', 'linb.Com', {
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
                .setLeft(90)
                .setTop(70)
                .setWidth(1080)
                .setHeight(520)
                .setCaption("门扇排产")
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
                (new linb.UI.Pane)
                .setHost(host, "ppt")
                .setDock("top")
                .setHeight(90)
            );

            host.ppt.append(
                (new linb.UI.Image)
                .setHost(host, "sbtn")
                .setLeft(980)
                .setTop(40)
                .setWidth(70)
                .setHeight(30)
                .setSrc("../../../Image/opeimage/searchbtn.jpg")
                .setCursor("pointer")
                .onClick("_sbtn_onclick")
            );

            host.ppt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "bdate")
                .setDataBinder("binder")
                .setDataField("bdate")
                .setLeft(30)
                .setTop(20)
                .setWidth(155)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#999999;font-size:14px'>生产日期</span>")
                .setLabelHAlign("left")
                .setType("date")
            );

            host.ppt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ptype")
                .setDataBinder("binder")
                .setDataField("ptype")
                .setReadonly(true)
                .setLeft(220)
                .setTop(20)
                .setWidth(155)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#999999;font-size:14px'>产品类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "ms", "caption": "门扇"}])
                .setValue("ms")
            );

            host.ppt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "pbdcode")
                .setDataBinder("binder")
                .setDataField("pbdcode")
                .setLeft(410)
                .setTop(20)
                .setWidth(155)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#999999;font-size:14px'>产品品牌</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.ppt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "psort")
                .setDataBinder("binder")
                .setDataField("psort")
                .setLeft(790)
                .setTop(20)
                .setWidth(155)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#999999;font-size:14px'>优化顺序</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "v", "caption": "尺寸-颜色"}])
            );

            host.ppt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "pgy")
                .setDataBinder("binder")
                .setDataField("pgy")
                .setLeft(600)
                .setTop(20)
                .setWidth(155)
                .setHeight(44)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#999999;font-size:14px'>生产工艺</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.pmeth.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ptreegrid")
                .setSelMode("multibycheckbox")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 80, "type": "input", "caption": "序号" }, { "id": "col2", "width": 140, "type": "input", "caption": "生产单号" }, { "id": "col3", "width": 80, "type": "input", "caption": "订单序号" }, { "id": "col3", "width": 110, "type": "input", "caption": "位置" }, { "id": "col4", "width": 140, "type": "input", "caption": "产品名称" }, { "id": "col4", "width": 130, "type": "input", "caption": "颜色" }, { "id": "col4", "width": 80, "type": "input", "caption": "高" }, { "id": "col4", "width": 80, "type": "input", "caption": "宽" }, { "id": "col4", "width": 80, "type": "input", "caption": "厚" }, { "id": "col4", "width": 80, "type": "input", "caption": "数量"}])
                .setValue("ms")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            //QueryCost();
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
                SaveCost(dc, dj, dr)
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        },
        _sbtn_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});