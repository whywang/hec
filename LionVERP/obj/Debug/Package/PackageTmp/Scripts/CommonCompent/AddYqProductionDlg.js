Class('App.AddProductionDlg', 'linb.Com', {
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
                .setTop(40)
                .setWidth(1060)
                .setHeight(620)
                .setCaption("新增产品")
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
                .setHeight(125)
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
                .setWidth(190)
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
                .setWidth(200)
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
                .setItems([{ "id": "无", "caption": "无" }, { "id": "左推", "caption": "左推" }, { "id": "右推", "caption": "右推" }, { "id": "左拉", "caption": "左拉" }, { "id": "右拉", "caption": "右拉"}])
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "fixed")
                .setDataBinder("abinder")
                .setDataField("fix")
                .setLeft(750)
                .setTop(20)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>安装方式</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "无", "caption": "无" }, { "id": "45°", "caption": "45°" }, { "id": "90°", "caption": "90°"}])
            );

            host.pmt.append(
                (new linb.UI.Input)
                .setHost(host, "pnum")
                .setDataBinder("abinder")
                .setDataField("pnum")
                .setLeft(80)
                .setTop(65)
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
                .setHost(host, "locks")
                .setDataBinder("abinder")
                .setDataField("locks")
                .setLeft(300)
                .setTop(65)
                .setWidth(200)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>锁孔类型</span>")
                .setLabelHAlign("left")
            );

            host.pmt.append(
                (new linb.UI.Input)
                .setHost(host, "floor")
                .setDataBinder("abinder")
                .setDataField("floor")
                .setLeft(750)
                .setTop(65)
                .setWidth(190)
                .setHeight(45)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>楼层</span>")
                .setLabelHAlign("left")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "isjc")
                .setDataBinder("abinder")
                .setDataField("isjc")
                .setLeft(710)
                .setTop(70)
                .setWidth(190)
                .setHeight(47)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("静音配件")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.pmt.append(
                (new linb.UI.ComboInput)
                .setHost(host, "locktype")
                .setDataBinder("abinder")
                .setDataField("locktype")
                .setLeft(530)
                .setTop(65)
                .setWidth(190)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>合页类型</span>")
                .setLabelHAlign("left")
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
                .setHost(host, "D01")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D01.append(
                (new linb.UI.Input)
                .setHost(host, "mscz")
                .setDataBinder("abinder")
                .setDataField("mscz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇颜色</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D01.append(
                (new linb.UI.Input)
                .setHost(host, "msname")
                .setDataBinder("abinder")
                .setDataField("msname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D01.append(
                (new linb.UI.Input)
                .setHost(host, "mscode")
                .setDataBinder("abinder")
                .setDataField("mscode")
                .setReadonly(true)
                .setLeft(570)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇编码</span>")
            );

            host.D01.append(
                (new linb.UI.ComboInput)
                .setHost(host, "msts")
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setLabelSize(60)
                .setType("listbox")
                .setDataBinder("abinder")
                .setDataField("msts")
                .setHeight(25)
                .setDisplay("none")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇套色</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D02")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D02.append(
                (new linb.UI.Input)
                .setHost(host, "mtcz")
                .setDataBinder("abinder")
                .setDataField("mtcz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套颜色</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D02.append(
                (new linb.UI.Input)
                .setHost(host, "mtname")
                .setDataBinder("abinder")
                .setDataField("mtname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D02.append(
                (new linb.UI.Input)
                .setHost(host, "mtcode")
                .setDataBinder("abinder")
                .setDataField("mtcode")
                .setReadonly(true)
                .setLeft(570)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套编码</span>")
            );

            host.D02.append(
                (new linb.UI.ComboInput)
                .setHost(host, "mttbcz")
                .setDataBinder("abinder")
                .setDataField("mttbcz")
                .setLeft(550)
                .setTop(10)
                .setWidth(210)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                 .setDisplay("none")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>套板材质</span>")
                .setType("listbox")
            );

            host.D02.append(
                (new linb.UI.ComboInput)
                .setHost(host, "mtlxcz")
                .setDataBinder("abinder")
                .setDataField("mtlxcz")
                .setLeft(790)
                .setTop(10)
                .setWidth(210)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                 .setDisplay("none")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>脸线材质</span>")
                .setType("listbox")
            );

            host.D02.append(
                (new linb.UI.ComboInput)
                .setHost(host, "cavetype")
                .setDataBinder("abinder")
                .setDataField("cavetype")
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                 .setDisplay("none")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门洞类型</span>")
                .setType("listbox")
            );

            host.D02.append(
                (new linb.UI.ComboInput)
                .setHost(host, "mtts")
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setLabelSize(60)
                .setType("listbox")
                 .setDataBinder("abinder")
                .setDataField("mtts")
                .setHeight(25)
                 .setDisplay("none")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套套色</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D05")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D05.append(
                (new linb.UI.Input)
                .setHost(host, "wjname")
                .setDataBinder("abinder")
                .setDataField("wjname")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>五金名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D05.append(
                (new linb.UI.Input)
                .setHost(host, "wjcode")
                .setDataBinder("abinder")
                .setDataField("wjcode")
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>五金编码</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D14")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbcz")
                .setDataBinder("abinder")
                .setDataField("mtbcz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门头颜色</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbname")
                .setDataBinder("abinder")
                .setDataField("mtbname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门头名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbcode")
                .setDataBinder("abinder")
                .setDataField("mtbcode")
                .setReadonly(true)
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门头编码</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D07")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D07.append(
                (new linb.UI.Input)
                .setHost(host, "slblname")
                .setDataBinder("abinder")
                .setDataField("slblname")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>上亮</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D07.append(
                (new linb.UI.Input)
                .setHost(host, "slblcode")
                .setDataBinder("abinder")
                .setDataField("slblcode")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>编码</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D03")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D03.append(
                (new linb.UI.Input)
                .setHost(host, "ctcz")
                .setDataBinder("abinder")
                .setDataField("ctcz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>窗套颜色</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D03.append(
                (new linb.UI.Input)
                .setHost(host, "ctname")
                .setDataBinder("abinder")
                .setDataField("ctname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>窗套名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D03.append(
                (new linb.UI.Input)
                .setHost(host, "ctcode")
                .setDataBinder("abinder")
                .setDataField("ctcode")
                .setReadonly(true)
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>窗套编码</span>")
            );

            host.D03.append(
                (new linb.UI.ComboInput)
                .setHost(host, "cttbcz")
                .setDataBinder("abinder")
                .setDataField("cttbcz")
                .setLeft(550)
                .setTop(10)
                .setWidth(210)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>套板材质</span>")
                .setType("listbox")
            );

            host.D03.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ctlxcz")
                .setDataBinder("abinder")
                .setDataField("ctlxcz")
                .setLeft(790)
                .setTop(10)
                .setWidth(210)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>脸线材质</span>")
                .setType("listbox")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D04")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D04.append(
                (new linb.UI.Input)
                .setHost(host, "ykcz")
                .setDataBinder("abinder")
                .setDataField("ykcz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>垭口颜色</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D04.append(
                (new linb.UI.Input)
                .setHost(host, "ykname")
                .setDataBinder("abinder")
                .setDataField("ykname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>垭口名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D04.append(
                (new linb.UI.Input)
                .setHost(host, "ykcode")
                .setDataBinder("abinder")
                .setDataField("ykcode")
                .setReadonly(true)
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>垭口编码</span>")
            );

            host.D04.append(
                (new linb.UI.ComboInput)
                .setHost(host, "yktbcz")
                .setDataBinder("abinder")
                .setDataField("yktbcz")
                .setLeft(550)
                .setTop(10)
                .setWidth(210)
                .setHeight(26)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>套板材质</span>")
                .setType("listbox")
            );

            host.D04.append(
                (new linb.UI.ComboInput)
                .setHost(host, "yklxcz")
                .setDataBinder("abinder")
                .setDataField("yklxcz")
                .setLeft(780)
                .setTop(10)
                .setWidth(210)
                .setHeight(26)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>套板材质</span>")
                .setType("listbox")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D13")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D13.append(
                (new linb.UI.Input)
                .setHost(host, "hjcz")
                .setDataBinder("abinder")
                .setDataField("hjcz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>护角材质</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D13.append(
                (new linb.UI.Input)
                .setHost(host, "hjname")
                .setDataBinder("abinder")
                .setDataField("hjname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>护角名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D13.append(
                (new linb.UI.Input)
                .setHost(host, "hjcode")
                .setDataBinder("abinder")
                .setDataField("hjcode")
                .setReadonly(true)
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>护角编码</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D06")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D06.append(
                (new linb.UI.Input)
                .setHost(host, "blname")
                .setDataBinder("abinder")
                .setDataField("blname")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D06.append(
                (new linb.UI.Input)
                .setHost(host, "blcode")
                .setDataBinder("abinder")
                .setDataField("blcode")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃编码</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D08")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D08.append(
                (new linb.UI.Input)
                .setHost(host, "sjname")
                .setDataBinder("abinder")
                .setDataField("sjname")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>锁具名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D08.append(
                (new linb.UI.Input)
                .setHost(host, "sjcode")
                .setDataBinder("abinder")
                .setDataField("sjcode")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>锁具编码</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D10")
                .setDock("width")
                .setTop(0)
                .setHeight(40)
                .setPosition("relative")
            );

            host.D10.append(
                (new linb.UI.Input)
                .setHost(host, "qtcz")
                .setDataBinder("abinder")
                .setDataField("qtcz")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(220)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>其他颜色</span>")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D10.append(
                (new linb.UI.Input)
                .setHost(host, "qtname")
                .setDataBinder("abinder")
                .setDataField("qtname")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>其他名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D10.append(
                (new linb.UI.Input)
                .setHost(host, "qtcode")
                .setDataBinder("abinder")
                .setDataField("qtcode")
                .setReadonly(true)
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>其他编码</span>")
            );

            host.D10.append(
                (new linb.UI.Image)
                .setHost(host, "cimg")
                .setLeft(270)
                .setTop(10)
                .setWidth(25)
                .setHeight(25)
                .setSrc("img/error.gif")
                .setCursor("pointer4")
                .onClick("_cimg_onclick")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D11")
                .setDock("width")
                .setTop(1)
                .setHeight(75)
                .setPosition("relative")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "plength")
                .setDataBinder("abinder")
                .setDataField("plength")
                .setLeft(50)
                .setTop(10)
                .setWidth(180)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度</span>")
                .setValue("0")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pwidth")
                .setDataBinder("abinder")
                .setDataField("pwidth")
                .setLeft(250)
                .setTop(10)
                .setWidth(180)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度</span>")
                .setValue("0")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pdeep")
                .setDataBinder("abinder")
                .setDataField("pdeep")
                .setLeft(450)
                .setTop(10)
                .setWidth(180)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>厚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度</span>")
                .setValue("0")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "psize")
                .setDataBinder("abinder")
                .setDataField("psize")
                .setLeft(630)
                .setTop(10)
                .setWidth(180)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>总高1</span>")
                .setValue("0")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "zsize")
                .setDataBinder("abinder")
                .setDataField("zsize")
                .setLeft(810)
                .setTop(10)
                .setWidth(180)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>总高2</span>")
                .setValue("0")
            );

            host.D11.append(
                (new linb.UI.SLabel)
                .setHost(host, "s4")
                .setLeft(370)
                .setTop(50)
                .setCaption("")
                .setCustomStyle({ "KEY": "color:red;font-size:16px" })
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D18")
                .setDock("width")
                .setTop(0)
                .setHeight(48)
                .setPosition("relative")
            );

            host.D18.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl5")
                .setLeft(10)
                .setTop(10)
                .setCaption("可选项")
                .setCustomStyle({ "KEY": "color:#333333; font-size:15px" })
            );

            host.D18.append(
                (new linb.UI.RadioBox)
                .setHost(host, "palist")
                .setDataBinder("abinder")
                .setDataField("alist")
                .setLeft(110)
                .setTop(10)
                .setWidth(800)
                .setHeight(30)
                .setSelMode("multibycheckbox")
                .setCheckBox(true)
                .setValue("a")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D12")
                .setDock("width")
                .setTop(-5)
                .setHeight(52)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "border-bottom:#f2f2f2 solid 3px" })
            );

            host.D12.append(
                (new linb.UI.Input)
                .setHost(host, "pbz")
                .setDataBinder("abinder")
                .setDataField("pbz")
                .setLeft(50)
                .setTop(10)
                .setWidth(850)
                .setHeight(40)
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</span>")
            );

            host.pa.append(
                (new linb.UI.Dialog)
                .setHost(host, "mdlg")
                .setLeft(330)
                .setTop(230)
                .setWidth(600)
                .setHeight(400)
                .setDisplay("none")
                .setCaption("材质颜色")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.mdlg.append(
                (new linb.UI.Layout)
                .setHost(host, "ly")
                .setItems([{ "id": "before", "pos": "before", "min": 280, "size": 280, "locked": false, "folded": false, "hidden": false, "cmd": true }, { "id": "main", "min": 10}])
                .setType("horizontal")
            );

            host.ly.append(
                (new linb.UI.TreeBar)
                .setHost(host, "mtreebar")
                .setItems([{ "id": "node1", "sub": ["node11", { "id": "node12", "image": "img/demo.gif" }, "node13", "node14"], "caption": "node1" }, { "id": "node2", "sub": ["node21", "node22", "node23", "node24"], "caption": "node2"}])
                .onItemSelected("_mtreebar_onitemselected")
                .beforeExpend("_mtreebar_beforeexpend")
            , "before");

            host.ly.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "mtreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 235, "type": "input", "caption": "材质名称"}])
                .onRowSelected("_mtreegrid_onrowselected")
            , "main");

            host.pa.append(
                (new linb.UI.Dialog)
                .setHost(host, "invdlg")
                .setLeft(309)
                .setTop(187)
                .setWidth(730)
                .setHeight(427)
                .setDisplay("none")
                .setCaption("产品")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.invdlg.append(
                (new linb.UI.Layout)
                .setHost(host, "ply")
                .setItems([{ "id": "before", "pos": "before", "min": 10, "size": 300, "locked": false, "folded": false, "hidden": false, "cmd": true }, { "id": "main", "min": 10}])
                .setType("horizontal")
            );

            host.ply.append(
                (new linb.UI.TreeBar)
                .setHost(host, "invtreebar")
                .setItems([{ "id": "node1", "sub": ["node11", { "id": "node12", "image": "img/demo.gif" }, "node13", "node14"], "caption": "node1" }, { "id": "node2", "sub": ["node21", "node22", "node23", "node24"], "caption": "node2"}])
                .onItemSelected("_invtreebar_onitemselected")
                .beforeExpend("_invtreebar_beforeexpend")
            , "before");

            host.ply.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "invtreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 160, "type": "input", "caption": "产品名称" }, { "id": "col2", "width": 120, "type": "input", "caption": "产品编码" }, { "id": "col3", "width": 150, "type": "input", "caption": "产品材质"}])
                .onRowSelected("_invtreegrid_onrowselected")
            , "main");

            host.invdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pts")
                .setDock("top")
                .setHeight(60)
                .setCustomStyle({ "KEY": "background:#f2f2f2" })
            );

            host.pts.append(
                (new linb.UI.Input)
                .setHost(host, "spname")
                .setLeft(180)
                .setTop(20)
                .setWidth(380)
                .setHeight(30)
                .setLabelSize(80)
                .setLabelCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>产品查询<span>")
                .onChange("_spname_onchange")
                .onHotKeyup("_spname_onhotkeyup")
                .onFocus("_spname_onfocus")
            );

            host.pa.append(
                (new linb.UI.Dialog)
                .setHost(host, "zjdlg")
                .setLeft(333)
                .setTop(261)
                .setWidth(577)
                .setHeight(369)
                .setDisplay("none")
                .setCaption("产品组件")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.zjdlg.append(
                (new linb.UI.TreeGrid)
                .setHost(host, "zjtreegrid")
                .setAltRowsBg(true)
                .setRowNumbered(true)
                .setHeaderHeight(25)
                .setRowHeight(25)
                .setHeader([{ "id": "col1", "width": 180, "type": "input", "caption": "组件名称" }, { "id": "col2", "width": 140, "type": "input", "caption": "组件编码" }, { "id": "col3", "width": 200, "type": "input", "caption": "组件材质"}])
                .onRowSelected("_zjtreegrid_onrowselected")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.apdlg.show();
            ds = this;
            selcz = ""; //选中材质控件名称
            selczv = ""; //选中材质值
            selinv = ""; // 选中产品控件名称
            sdinvcate = ""; //选中类别编码
            sinvcate = ""; //产品查询时查询范围控制
            gnum = "";
            bdcode = ""; //带品牌编码
            ltobj = LockType,
            hyobj = HyType,
            cvaobj = CaveType;
            prange = "mm"
            Init();
            CustIinvDropList("", prange, ds.invcate);
            ltobj.LockTypeItems(ds.locks);
            hyobj.HyTypeItems(ds.locktype);
            LoadOrderAttr(sid)
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
        },
        _mtreebar_onitemselected: function (profile, item, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            MQueryListChild(item, ns.mtreebar)
            CzQueryTable(item.id, ns.mtreegrid)
        },
        _mtreebar_beforeexpend: function (profile, item) {
            var ns = this, uictrl = profile.boxing();
            MQueryListChild(item, ns.mtreebar)
        },
        _mtreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            var czv = row.cells[0].value;
            var pricz = selcz.replace("cz", "")
            execfun("ds." + selcz + ".setValue('" + czv + "')")
            execfun("ds." + pricz + "name.setValue('')")
            execfun("ds." + pricz + "code.setValue('')")
            ns.mdlg.setDisplay("none")
        },
        _invtreebar_onitemselected: function (profile, item, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            var mvc = ns.mscode.getUIValue();
            if (item.id.toString().substring(0, 2) == "005" && mvc != "" && mvc != null) {
                MsCzQueryListInv(mvc, item.id, ns.invtreegrid);
                IMsCzinvCItems(mvc, item, ns.invtreebar)
            }
            else {
                ICzinvRangeItems(selczv, item, prange, ns.invtreebar)
                CzQueryListInv(selczv, item.id, ns.invtreegrid)
            }

        },
        _invtreebar_beforeexpend: function (profile, item) {
            var ns = this, uictrl = profile.boxing();
            var mvc = ns.mscode.getUIValue();
            if (item.id.toString().substring(1, 2) == "005" && mvc != "" && mvc != null) {
                MsCzQueryListInv(mvc, item.id, ns.invtreegrid);
                IMsCzinvCItems(mvc, item, ns.invtreebar)
            }
            else {
                ICzinvRangeItems(selczv, item, prange, ns.invtreebar)
                CzQueryListInv(selczv, item.id, ns.invtreegrid)
            }
        },
        _invtreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            InvSetValue(row)
            ns.invdlg.setDisplay("none");
            ds.spname.setUIValue("")
        },
        _zjtreegrid_onrowselected: function (profile, row, e, src, type) {
            var ns = this, uictrl = profile.boxing();

        },
        _invcate_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            sdinvcate = newValue.substring(8, 11);
            bdcode = newValue.substring(0, 8)
            ShowDiv(sdinvcate);
        },
        _refname_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            selinv = uictrl._nodes[0].alias;
            ns.invtreegrid.removeAllRows()
            if (CheckCz()) {
                ns.invdlg.setDisplay("block")
                InvSetCate()
            }
        },
        _refcz_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            selcz = uictrl._nodes[0].alias;
            ns.mdlg.setDisplay("block")
            ns.mtreegrid.removeAllRows();
            switch (mtype) {
                case "mq":
                    CustMTypeQueryList("mq", "", ns.mtreebar);
                    break;
                case "yq":
                    CustMTypeQueryList("yq", "", ns.mtreebar);
                    break;
                default:
                    CustMQueryList("", ns.mtreebar);
                    break;
            }

        },
        _cimg_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
            ns.qtcz.setValue("");
        },
        _spname_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            var spv = ds.spname.getUIValue();
            if (spv != "" && spv != null) {
                QuerySearingList(sinvcate, selczv, spv, ns.invtreegrid);
            }
        },
        _spname_onhotkeyup: function (profile, keyboard, e, src) {
            var ns = this, uictrl = profile.boxing();
            var spv = ds.spname.getUIValue();
            if (spv != "" && spv != null) {
                QuerySearingList(sinvcate, selczv, spv, ns.invtreegrid);
            }
        },
        _spname_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            if (newValue != "" && newValue != null) {
                QuerySearingList(sinvcate, selczv, newValue, ns.invtreegrid);
            }
        }
    },
    Static: {
        viewSize: { "width": 1280, "height": 1024 }
    }
});
function Init() {
    ds.D01.setDisplay("none");
    ds.D02.setDisplay("none");
    ds.D03.setDisplay("none");
    ds.D04.setDisplay("none");
    ds.D05.setDisplay("none");
    ds.D06.setDisplay("none");
    ds.D07.setDisplay("none");
    ds.D08.setDisplay("none");
    ds.D10.setDisplay("none");
    ds.D11.setDisplay("none");
    ds.D12.setDisplay("none");
    ds.D13.setDisplay("none");
    ds.D14.setDisplay("none");
    ds.D18.setDisplay("none");
}

///产品空键显示
function ShowDiv(v) {
    ds.D01.setDisplay("none");
    ds.D02.setDisplay("none");
    ds.D03.setDisplay("none");
    ds.D04.setDisplay("none");
    ds.D05.setDisplay("none");
    ds.D06.setDisplay("none");
    ds.D07.setDisplay("none");
    ds.D08.setDisplay("none");
    ds.D10.setDisplay("none");
    ds.D11.setDisplay("none");
    ds.D12.setDisplay("none");
    ds.D13.setDisplay("none");
    ds.D14.setDisplay("none")
    ds.D18.setDisplay("none");
    ds.palist.clearItems();
    switch (v) {
        case "010":
            ds.D01.setDisplay("block");
            ds.D02.setDisplay("block");
            //ds.D08.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D12.setDisplay("block");
            //ds.locktype.setValue("方");
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口厚</span>");
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            var smscode = ds.mscode.getUIValue();
            var smstode = ds.mtcode.getUIValue();
            DropMTypeItems(mtype, ds.msts);
            DropMTypeItems(mtype, ds.mtts);
            if (smscode != "") {
                IinvCheckBoxList(smscode, ds.palist);
                if (IinvCheckBox(smscode, ds.palist)) {
                    ds.D18.setDisplay("block");
                }
            }
            if (smstode != "") {
                IinvCheckBoxList(smstode, ds.palist);
                if (IinvCheckBox(smtcode, ds.palist)) {
                    ds.D18.setDisplay("block");
                }
            }
            break;
        case "001":
            ds.D01.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("方")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>门扇高度</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>门扇宽度</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>门扇厚度</span>");
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            DropMTypeItems(mtype, ds.msts);
            var smscode = ds.mscode.getUIValue();
            if (smscode != "") {
                //                IinvCheckBoxList(smscode, ds.palist);
                //                if (IinvCheckBox(smscode, ds.palist)) {
                //                    ds.D18.setDisplay("block");
                //                }
            }
            break;
        case "002":
            ds.D02.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("无")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口厚</span>");
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            DropMTypeItems(mtype, ds.mtts);
            var smtcode = ds.mtcode.getUIValue();
            if (smtcode != "") {
                //                IinvCheckBoxList(smtcode, ds.palist);
                //                if (IinvCheckBox(smtcode, ds.palist)) {
                //                    ds.D18.setDisplay("block");
                //                }
            }
            break;
        case "006":
            ds.D03.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("无")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口厚</span>");
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            var sctcode = ds.ctcode.getUIValue();
            if (sctcode != "") {
                //                IinvCheckBoxList(sctcode, ds.palist);
                //                if (IinvCheckBox(sctcode, ds.palist)) {
                //                    ds.D18.setDisplay("block");
                //                }
            }
            break;
        case "007":
            ds.D04.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("无")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口厚</span>");
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            var sykcode = ds.ykcode.getUIValue();
            if (sykcode != "") {
                //                IinvCheckBoxList(sykcode, ds.palist);
                //                if (IinvCheckBox(sykcode, ds.palist)) {
                //                    ds.D18.setDisplay("block");
                //                }
            }
            break;
        case "004":
            ds.D05.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("无")
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            break;
        case "005":
            ds.D06.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("无")
            ds.mscode.setValue();
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            break;
        case "008":
            ds.D13.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D12.setDisplay("block");
            ds.locktype.setValue("无")
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            break;
    }
}
///设置选中产品
function InvSetValue(r) {
    var rname = r.cells[0].value;
    var rcode = r.cells[1].value;
    var rcz = r.cells[2].value;
    var locks = ds.locks.getUIValue();
    var zjtype = "";
    RefProductionSize(rcode)
    var remarks = InvRemarkCheck(rcode)
    switch (selinv) {
        case "msname":
            ds.msname.setValue(rname)
            ds.mscode.setValue(rcode)
            if (sdinvcate == "010") {
                RefMt(rcode, rcz)
                ///----------检测整套门洞口类型
                var cmt=ds.mtcode.getValue();
                if(cmt!=""&&cmt!=null)
                {
                    cvaobj.IRCaveItem(rcode, cmt, ds.cavetype);
                }
            }
            zjtype = InvComponentCheck(rcode)
            if (zjtype == "b") {
                ds.D06.setDisplay("block")
            }
            else {
                ds.D06.setDisplay("none")
                ds.blcode.setValue("");
                ds.blname.setValue("");
            }
            break;
        case "mtname":
            ds.mtname.setValue(rname)
            ds.mtcode.setValue(rcode)
            zjtype = InvComponentCheck(rcode)
            ds.slblname.setValue("");
            ds.slblcode.setValue("");
            ds.D07.setDisplay("none");
            ds.D14.setDisplay("none")
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
            ds.slblname.setValue("");
            ds.slblcode.setValue("");
            ds.mtbname.setValue("");
            ds.mtbcode.setValue("");
            ds.mtbcz.setValue("");
            ds.psize.setValue(0);
            ds.zsize.setValue(0);
            ds.psize.setLabelCaption("外径1高");
            if (zjtype == "s") {
                ds.D07.setDisplay("block");
                ds.psize.setDisplay("block");
                ds.psize.setLabelCaption("门高");
            }
            if (zjtype == "m") {
                ds.D14.setDisplay("block");
                ds.psize.setDisplay("block");
                ds.plength.setLabelCaption("门高");
            }
            if (zjtype == "y") {
                ds.D14.setDisplay("block");
                ds.psize.setDisplay("block");
                ds.zsize.setDisplay("block");
                ds.plength.setLabelCaption("门洞高");
            }
            if (sdinvcate == "010") {
                ///----------检测整套门洞口类型
                var cmt = ds.mscode.getValue();
                if (cmt != "" && cmt != null) {
                    cvaobj.IRCaveItem(cmt, rcode, ds.cavetype);
                }
            }
            break;
        case "ctname":
            ds.ctname.setValue(rname)
            ds.ctcode.setValue(rcode)
            break;
        case "ykname":
            ds.ykname.setValue(rname)
            ds.ykcode.setValue(rcode)
            break;
        case "hjname":
            ds.hjname.setValue(rname)
            ds.hjcode.setValue(rcode);
            ds.plength.setLabelCaption("高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
            ds.pwidth.setLabelCaption("宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度")
            ds.pdeep.setLabelCaption("厚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
            break;
        case "qtname":
            ds.qtname.setValue(rname)
            ds.qtcode.setValue(rcode)
            if (rcode.substr(0, 4) == "009025") {
                ds.plength.setLabelCaption("高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
                ds.pwidth.setLabelCaption("宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度")
                ds.pdeep.setDisplay("none");
            }
            else {
                ds.plength.setLabelCaption("高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
                ds.pwidth.setLabelCaption("宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度")
                ds.pdeep.setLabelCaption("厚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
                ds.pdeep.setDisplay("block");
            }
            break;
        case "wjname":
            ds.wjname.setValue(rname)
            ds.wjcode.setValue(rcode)
            break;
        case "sjname":
            ds.sjname.setValue(rname)
            ds.sjcode.setValue(rcode)
            break;
        case "blname":
            ds.blname.setValue(rname)
            ds.blcode.setValue(rcode)
            break;
        case "slblname":
            ds.slblname.setValue(rname)
            ds.slblcode.setValue(rcode)
            break;
        case "mtbname":
            ds.mtbname.setValue(rname)
            ds.mtbcode.setValue(rcode)
            break;
    }
    if (remarks) {
        ds.pbz.setValue(remarks)
    }
    ds.palist.clearItems();
    switch (sdinvcate) {
        case "010":
            var pmsv = ds.mscode.getUIValue();
            if (pmsv != "") {
                IinvCheckBoxList(pmsv, ds.palist);
            }
            var pmtv = ds.mtcode.getUIValue();
            if (pmtv != "") {
                IinvCheckBoxList(pmtv, ds.palist);
            }
            var pblv = ds.blcode.getUIValue();
            if (pblv != "") {
                IinvCheckBoxList(pblv, ds.palist);
            }
            var pmtbv = ds.mtbcode.getUIValue();
            if (pmtbv != "") {
                IinvCheckBoxList(pmtbv, ds.palist);
            }
            var pslv = ds.slblcode.getUIValue();
            if (pslv != "") {
                IinvCheckBoxList(pslv, ds.palist);
            }

            break;
        case "001":
            var pmsv = ds.mscode.getUIValue();
            if (pmsv != "") {
                IinvCheckBoxList(pmsv, ds.palist);
            }
            var pblv = ds.blcode.getUIValue();
            if (pblv != "") {
                IinvCheckBoxList(pblv, ds.palist);
            }
            break;
        case "002":
            var pmtv = ds.mtcode.getUIValue();
            if (pmtv != "") {
                IinvCheckBoxList(pmtv, ds.palist);
            }
            var pmtbv = ds.mtbcode.getUIValue();
            if (pmtbv != "") {
                IinvCheckBoxList(pmtbv, ds.palist);
            }
            var pslv = ds.slblcode.getUIValue();
            if (pslv != "") {
                IinvCheckBoxList(pslv, ds.palist);
            }
            break;
        case "006":
            var pctv = ds.ctcode.getUIValue();
            if (pctv != "") {
                IinvCheckBoxList(pctv, ds.palist);
            }
            var pmtbv = ds.mtbcode.getUIValue();
            if (pmtbv != "") {
                IinvCheckBoxList(pmtbv, ds.palist);
            }
            var pslv = ds.slblcode.getUIValue();
            if (pslv != "") {
                IinvCheckBoxList(pslv, ds.palist);
            }
            break;
        case "007":
            var pykv = ds.ykcode.getUIValue();
            if (pykv != "") {
                IinvCheckBoxList(pykv, ds.palist);
            }
            var pmtbv = ds.mtbcode.getUIValue();
            if (pmtbv != "") {
                IinvCheckBoxList(pmtbv, ds.palist);
            }
            var pslv = ds.slblcode.getUIValue();
            if (pslv != "") {
                IinvCheckBoxList(pslv, ds.palist);
            }
            break;
        default:
            IinvCheckBoxList(rcode, ds.palist);
            break;
    }
    if (IinvCheckBox("", ds.palist)) {
        ds.D18.setDisplay("block");
    }
    return r;
}
///获取当前产品类型
function InvSetCate() {
    var smscode = ds.mscode.getUIValue();
    switch (selinv) {
        case "msname":
            sinvcate = bdcode + "001";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "mtname":
            sinvcate = bdcode + "002";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "ctname":
            sinvcate = bdcode + "006";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "ykname":
            sinvcate = bdcode + "007";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "qtname":
            sinvcate = bdcode + "009";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "wjname":
            sinvcate = bdcode + "004";
            ICzinvItems("", sinvcate, ds.invtreebar)
            break;
        case "sjname":
            sinvcate = bdcode + "004001";
            ICzinvItems("", sinvcate, ds.invtreebar)
            break;
        case "blname":
            if (smscode != "" && smscode != null) {
                sinvcate = bdcode + "005";
                IMsinvCzItems(smscode, sinvcate, ds.invtreebar)
            }
            else {
                sinvcate = bdcode + "005";
                ICzinvItems("", sinvcate, ds.invtreebar)
            }
            break;
        case "slblname":
            sinvcate = bdcode + "009003";
            ICzinvItems("", sinvcate, ds.invtreebar)
            break;
        case "mtbname":
            sinvcate = bdcode + "009006";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "hjname":
            sinvcate = bdcode + "008";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
    }
}
function CheckCz() {
    var r = true;
    switch (selinv) {
        case "msname":
            r = CheckInput(ds, ds.mscz, true, "", "选择产品材质", "", "", "");
            selczv = ds.mscz.getUIValue()
            break;
        case "mtname":
            r = CheckInput(ds, ds.mtcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.mtcz.getUIValue()
            break;
        case "mtbname":
            r = CheckInput(ds, ds.mtbcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.mtbcz.getUIValue()
            break;
        case "ctname":
            r = CheckInput(ds, ds.ctcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.ctcz.getUIValue()
            break;
        case "ykname":
            r = CheckInput(ds, ds.ykcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.ykcz.getUIValue()
            break;
        case "hjname":
            r = CheckInput(ds, ds.hjcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.hjcz.getUIValue()
            break;
        case "qtname":
            // r = CheckInput(ds, ds.qtcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.qtcz.getUIValue()
            break;
        default:
            selczv = ""
            break;
    }
    return r;
}
function LoadOrderAttr(sid) {
    var url = '../../../UIServer/SalesBusiness/DistributionDoorYqOrder/YqSaleOrder.aspx/LoadSaleOrder'
    var o = { "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        if (r.sid != "") {
            //材质
            ds.mscz.setValue(r.mname)
            ds.mtcz.setValue(r.mname)
            ds.ctcz.setValue(r.mname)
            ds.ykcz.setValue(r.mname)
            ds.mtbcz.setValue(r.mname)
            ds.hjcz.setValue(r.mname)
            //楼层
            ds.floor.setValue(r.floor)
        }
        else {
            //LoadAOrderAttr(sid);
        }
    }
}
function LoadAOrderAttr(sid) {
    var url = '../../../UIServer/AfterSaleServiceBusiness/DistributorAfterSale/AddAfterOrder.aspx/InitAfterOrder'
    var o = { "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        if (r.sid != "") {
            //材质
            ds.mscz.setValue(r.mname)
            ds.mtcz.setValue(r.mname)
            ds.ctcz.setValue(r.mname)
            ds.ykcz.setValue(r.mname)
            //ds.qtcz.setValue(r.mname)
            ds.hjcz.setValue(r.mname)
            //楼层
            ns.floor.setValue(r.floor)
        }
        else {
        }
    }
}
///获取选中门扇管理联门套
function RefMt(msv, czv) {
    var o = { "invcode": msv, "mname": czv }
    var url = "../../../UIServer/ProductionSet/AssortManage/Assorts.aspx/GetRefInv"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.mtname.setValue(r.icname);
        ds.mtcode.setValue(r.icode);
    }
}
///保存产品是进行校验
function SaveProductionCheck() {
    //获取尺寸进行尺寸限制检测
    var hv = ds.plength.getUIValue();
    var wv = ds.pwidth.getUIValue();
    var dv = ds.pdeep.getUIValue();
    var fv = ds.psize.getUIValue();
    if (!CheckInput(ds, ds.invcate, true, "", "请选择类别", "", "", "")) {
        return false;
    }
    if (!CheckInput(ds, ds.place, true, "", "请输入位置", "", "", "")) {
        return false;
    }
    if (!CheckInput(ds, ds.pnum, true, "number", "请输入产品数量", "正确输入产品数量", "0", "9999")) {
        return false;
    }
    if (sdinvcate == "010") {

        if (!CheckInput(ds, ds.direction, true, "", "请选择开向", "", "", "")) {
            return false;
        }
        if (!CheckInput(ds, ds.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }
        //        if (!CheckInput(ds, ds.locktype, true, "", "请选择锁具类型", "", "", "")) {
        //            return false;
        //        }
    
//        if (!CheckInput(ds, ds.sjname, true, "", "请选择锁具", "", "", "")) {
//            return false;
//        }
        if (!CheckInput(ds, ds.msname, true, "", "请选择门扇", "", "", "")) {
            return false;
        }
        if (!CheckInput(ds, ds.mtname, true, "", "请选择门套", "", "", "")) {
            return false;
        }
        if (!CheckInput(ds, ds.locks, true, "", "请选择锁孔", "", "", "")) {
            return false;
        }
        if (ds.D06.getDisplay() == "block") {
            if (!CheckInput(ds, ds.blname, true, "", "请选择玻璃", "", "", "")) {
                return false;
            }
        }
        var mtv = ds.mtcode.getUIValue();
        if (!CheckLimited(mtv, hv, wv, dv, fv)) {
            return false;
        }
    }
    if (sdinvcate == "001") {
        if (!CheckInput(ds, ds.direction, true, "", "请选择开向", "", "", "")) {
            return false;
        }
        //        if (!CheckInput(ds, ds.locktype, true, "", "请选择合页", "", "", "")) {
        //            return false;
        //        }
        if (!CheckInput(ds, ds.msname, true, "", "请选择门扇", "", "", "")) {
            return false;
        }
        if (!CheckInput(ds, ds.locks, true, "", "请选择锁孔", "", "", "")) {
            return false;
        }
        if (ds.D06.getDisplay() == "block") {
            if (!CheckInput(ds, ds.blname, true, "", "请选择玻璃", "", "", "")) {
                return false;
            }
        }

    }
    if (sdinvcate == "002") {
        if (!CheckInput(ds, ds.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }

        if (!CheckInput(ds, ds.mtname, true, "", "请选择门套", "", "", "")) {
            return false;
        }
        var mtv = ds.mtcode.getUIValue();
        if (!CheckLimited(mtv, hv, wv, dv, fv)) {
            return false;
        }
    }
    if (sdinvcate == "006") {
        if (!CheckInput(ds, ds.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }

        if (!CheckInput(ds, ds.ctname, true, "", "请选择窗套", "", "", "")) {
            return false;
        }
    }
    if (sdinvcate == "007") {
        if (!CheckInput(ds, ds.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }

        if (!CheckInput(ds, ds.ykname, true, "", "请选择垭口", "", "", "")) {
            return false;
        }
    }
    return true;
}
///保存产品
function SaveProduction() {
   
    if (SaveProductionCheck()) {
        // var isend = ns.isend.getUIValue();
        var arg1 = { "sid": sid, "gnum": gnum, "optype":""  }
        var db = linb.DataBinder.getFromName("abinder");
        var arg2 = db.updateDataFromUI().getData();
        var o = $.extend(arg1, arg2);
        var url = '../../../UIServer/SalesBusiness/DistributionDoorYqOrder/AddYqSaleOrderProduction.aspx/SaveProduction';
        var b = AjaxExb(url, o);
        BackVad(b, "IExeFun('" + xfunstr + "')", false)
        if (penum == 0) {
        }
        else {
            ds.apdlg.setDisplay("none");
        }
    }
    else {
        return
    }

}
///获取产品固定尺寸
function RefProductionSize(v) {
    var o = { "icode": v }
    var url = "../../../UIServer/CommonFile/RefNomalSize.aspx/RefNSize"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ds.plength.setValue(r.ng);
        ds.pwidth.setValue(r.nk);
        ds.pdeep.setValue(r.nh);
        ds.psize.setValue(r.nf);
    }
}
//检测产品属性
function CheckInvAttr(v, msv, mtv, ctv, ykv) {
    switch (v) {
        case "010":
            IinvCheckBoxList(msv, ds.palist);
            if (IinvCheckBox(msv, ds.palist)) {
                ds.D18.setDisplay("block");
            }
            IinvCheckBoxList(mtv, ds.palist);
            if (IinvCheckBox(mtv, ds.palist)) {
                ds.D18.setDisplay("block");
            }
            break;
        case "001":
            IinvCheckBoxList(msv, ds.palist);
            if (IinvCheckBox(msv, ds.palist)) {
                ds.D18.setDisplay("block");
            }
            break;
        case "002":
            IinvCheckBoxList(mtv, ds.palist);
            if (IinvCheckBox(mtv, ds.palist)) {
                ds.D18.setDisplay("block");
            }
            break;
        case "006":
            IinvCheckBoxList(ctv, ds.palist);
            if (IinvCheckBox(ctv, ds.palist)) {
                ds.D18.setDisplay("block");
            }
            break;
        case "007":
            IinvCheckBoxList(ykv, ds.palist);
            if (IinvCheckBox(ykv, ds.palist)) {
                ds.D18.setDisplay("block");
            }
            break;
    }
}
function EditProductions(sid, gnum) {
    var o = { "sid": sid, 'gnum': gnum }
    var url = "../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/EditProduction"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var zjpcode = "";
        bdcode = r.invprecode;
        sdinvcate = r.invcate
        ShowDiv(sdinvcate)
        zjpcode = r.mtcode == "" ? r.ctcode == "" ? r.ykcode : r.ctcode : r.mtcode;
        zjtype = InvComponentCheck(zjpcode)
        if (r.blname != "") {
            ds.D06.setDisplay("block");
        }
        if (r.slblname != "") {
            ds.D07.setDisplay("block");
        }
        if (zjtype == "m") {
            ds.D14.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.plength.setLabelCaption("门高");
            ds.mtbname.setValue(r.zjname);
            ds.mtbcz.setValue(r.zjcz);
            ds.mtbcode.setValue(r.zjcode);
        }
       
        if (zjtype == "y") {
            ds.D14.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.mtbname.setValue(r.zjname);
            ds.mtbcz.setValue(r.zjcz);
            ds.mtbcode.setValue(r.zjcode);
            ds.plength.setLabelCaption("门洞高");
        }
        if (zjtype == "s") {
            ds.D07.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.slblcode.setValue(r.zjcode);
            ds.slblname.setValue(r.zjname);
            ds.psize.setLabelCaption("门高");
        }
        ds.blcode.setValue(r.blcode);
        ds.blname.setValue(r.blname);
        ds.ctcode.setValue(r.ctcode);
        ds.ctcz.setValue(r.ctcz);
        ds.ctname.setValue(r.ctname);
        ds.cttbcz.setValue(r.tbcz);
        ds.ctlxcz.setValue(r.lxcz);
        ds.direction.setValue(r.direction);
        ds.fixed.setValue(r.fix);
        ds.pnum.setValue(r.pnum);
        ds.hjcode.setValue(r.hjcode);
        ds.hjcz.setValue(r.hjcz);
        ds.hjname.setValue(r.hjname);
        ds.invcate.setValue(bdcode + sdinvcate);
        ds.locktype.setValue(r.locktype);
        ds.locks.setValue(r.locks);
        ds.mscode.setValue(r.mscode);
        ds.mscz.setValue(r.mscz);
        ds.msname.setValue(r.msname);
        ds.msts.setValue(r.msts);
        ds.mtcode.setValue(r.mtcode);
        ds.mtcz.setValue(r.mtcz);
        ds.mtts.setValue(r.mtts);
        ds.mtname.setValue(r.mtname);
        ds.mttbcz.setValue(r.tbcz);
        ds.mtlxcz.setValue(r.lxcz);
        ds.mtname.setValue(r.mtname);
        ds.pbz.setValue(r.pbz);
        ds.pdeep.setValue(r.pdeep);
        ds.place.setValue(r.place);
        ds.plength.setValue(r.plength);
        ds.pnum.setValue(r.pnum);
        ds.psize.setValue(r.fsize);
        ds.zsize.setValue(r.zsize);
        ds.pwidth.setValue(r.pwidth);
        ds.qtcode.setValue(r.qtcode);
        ds.qtcz.setValue(r.qtcz);
        ds.qtname.setValue(r.qtname);
        ds.sjcode.setValue(r.sjcode);
        ds.sjname.setValue(r.sjname);
        ds.wjcode.setValue(r.wjcode);
        ds.wjname.setValue(r.wjname);
        ds.ykcode.setValue(r.ykcode);
        ds.ykcz.setValue(r.ykcz);
        ds.ykname.setValue(r.ykname);
        ds.isjc.setValue(r.isjc);
        if (sdinvcate == "010") {
            if (r.mtcode.substr(8, 12) == "002004" || r.mtcode.substr(8, 12) == "002005") {
                ds.D08.setDisplay("none");
            }
            else {
                ds.D08.setDisplay("none");
            }
            cvaobj.IRCaveItem(r.mscode, r.mtcode, ds.cavetype);
            if (r.cavetype != "") {
                ds.cavetype.setDisplay("block");
                ds.cavetype.setUIValue(r.cavetype)
            }
        }
        if (r.qtcode.substr(8, 4) == "009025") {
            ds.pdeep.setDisplay("none")
        }
        CheckInvAttr(sdinvcate, r.mscode, r.mtcode, r.ctcode, r.ykcode);
        EditProductionAttr(sid, gnum);
    }
}
function EditProductionAttr(sid, gnum) {
    var o = { "sid": sid, 'gnum': gnum }
    var url = "../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/EditProductionAttr"
    var b = AjaxExb(url, o);
    if (b) {
        ds.palist.setValue(b);
    }
}

 
