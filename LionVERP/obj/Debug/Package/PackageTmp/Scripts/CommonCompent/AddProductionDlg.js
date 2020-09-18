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
                .setLeft(67)
                .setTop(99)
                .setWidth(1200)
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
                .setHeight(75)
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
                .setItems([{ "id": "无", "caption": "无" }, { "id": "左内", "caption": "左内" }, { "id": "右内", "caption": "右内" }, { "id": "左外", "caption": "左外" }, { "id": "右外", "caption": "右外" }, { "id": "左推", "caption": "左推" }, { "id": "右推", "caption": "右推" }, { "id": "左折", "caption": "左折" }, { "id": "右折", "caption": "右折"}])
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
                .setDisplay("none")
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
                .setHeight(57)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#eff9eb;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D01.append(
                (new linb.UI.Input)
                .setHost(host, "mscz")
                .setDataBinder("abinder")
                .setDataField("mscz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇主色/正面颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D01.append(
                (new linb.UI.Input)
                .setHost(host, "msname")
                .setDataBinder("abinder")
                .setDataField("msname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇名称</span>")
                .setLabelHAlign("left")
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
                (new linb.UI.Input)
                .setHost(host, "zmsname")
                .setDataBinder("abinder")
                .setDataField("zmsname")
                .setReadonly(true)
                .setLeft(540)
                .setTop(10)
                .setWidth(220)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>子门</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D01.append(
                (new linb.UI.Input)
                .setHost(host, "zmscode")
                .setDataBinder("abinder")
                .setDataField("zmscode")
                .setReadonly(true)
                .setLeft(760)
                .setTop(10)
                .setWidth(220)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>子门</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D01.append(
                (new linb.UI.SLabel)
                .setHost(host, "lms")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>门扇信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D16")
                .setDock("width")
                .setTop(0)
                .setHeight(60)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#eff9eb;border-radius:5px;;border-bottom:1px solid #cccccc" })
            );

            host.D16.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ytcz")
                .setDataBinder("abinder")
                .setDataField("ytcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>门板压条颜色</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.D16.append(
                (new linb.UI.Input)
                .setHost(host, "fbtcz")
                .setDataBinder("abinder")
                .setDataField("fbtcz")
                .setReadonly(true)
                .setLeft(280)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>门扇封边颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D16.append(
                (new linb.UI.Input)
                .setHost(host, "msfmcz")
                .setDataBinder("abinder")
                .setDataField("msfmcz")
                .setReadonly(true)
                .setLeft(440)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>门扇反面颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D16.append(
                (new linb.UI.SLabel)
                .setHost(host, "lmst")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>门扇特殊项</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D22")
                .setDock("width")
                .setTop(0)
                .setHeight(59)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#eff9eb;border-radius:5px;;border-bottom:1px solid #cccccc" })
            );

            host.D22.append(
                (new linb.UI.ComboInput)
                .setHost(host, "msjst")
                .setDataBinder("abinder")
                .setDataField("msjst")
                .setReadonly(true)
                .setLeft(280)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>金属条</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.D22.append(
                (new linb.UI.ComboInput)
                .setHost(host, "msts")
                .setDataBinder("abinder")
                .setDataField("msts")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>门扇阴影颜色</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.D22.append(
                (new linb.UI.ComboInput)
                .setHost(host, "xxline")
                .setDataBinder("abinder")
                .setDataField("xxline")
                .setReadonly(true)
                .setLeft(440)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>铣型线</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.D22.append(
                (new linb.UI.SLabel)
                .setHost(host, "lmsa")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>门扇属性</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D17")
                .setDock("width")
                .setTop(0)
                .setHeight(59)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#eff9eb;border-radius:5px;;border-bottom:1px solid #cccccc" })
            );

            host.D17.append(
                (new linb.UI.Input)
                .setHost(host, "mbname")
                .setDataBinder("abinder")
                .setDataField("mbname")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇玻璃</span>")
                .setLabelHAlign("left")
                .onFocus("_refname_onfocus")
            );

            host.D17.append(
                (new linb.UI.Input)
                .setHost(host, "mbcode")
                .setDataBinder("abinder")
                .setDataField("mbcode")
                .setReadonly(true)
                .setLeft(50)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门扇玻璃</span>")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D17.append(
                (new linb.UI.Input)
                .setHost(host, "mbnum")
                .setDataBinder("abinder")
                .setDataField("mbnum")
                .setLeft(550)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃格数</span>")
                .setValue("1")
            );

            host.D17.append(
                (new linb.UI.ComboInput)
                .setHost(host, "mbfx")
                .setDataBinder("abinder")
                .setDataField("mbfx")
                .setLeft(280)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃方向</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "正", "caption": "正" }, { "id": "反", "caption": "反"}])
            );

            host.D17.append(
                (new linb.UI.ComboInput)
                .setHost(host, "mbytcz")
                .setDataBinder("abinder")
                .setDataField("mbytcz")
                .setLeft(540)
                .setTop(10)
                .setWidth(205)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>压条颜色</span>")
                .setType("listbox")
                .setItems([{ "id": "正", "caption": "正" }, { "id": "反", "caption": "反"}])
            );

            host.D17.append(
                (new linb.UI.SLabel)
                .setHost(host, "lmsbl")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>门扇玻璃</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D02")
                .setDock("width")
                .setTop(0)
                .setHeight(58)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#f3e6d7;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D02.append(
                (new linb.UI.Input)
                .setHost(host, "mtcz")
                .setDataBinder("abinder")
                .setDataField("mtcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D02.append(
                (new linb.UI.Input)
                .setHost(host, "mtname")
                .setDataBinder("abinder")
                .setDataField("mtname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门套名称</span>")
                .setLabelHAlign("left")
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
                .setLabelCaption("<span style='font-size:14px;color:#666666'>门洞类型</span>")
                .setType("listbox")
            );

            host.D02.append(
                (new linb.UI.SLabel)
                .setHost(host, "lmt")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>门套信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D03")
                .setDock("width")
                .setTop(0)
                .setHeight(59)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#f3e6d7;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D03.append(
                (new linb.UI.Input)
                .setHost(host, "ctcz")
                .setDataBinder("abinder")
                .setDataField("ctcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>垭口颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D03.append(
                (new linb.UI.Input)
                .setHost(host, "ctname")
                .setDataBinder("abinder")
                .setDataField("ctname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>垭口名称</span>")
                .setLabelHAlign("left")
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

            host.D03.append(
                (new linb.UI.SLabel)
                .setHost(host, "lyk")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>垭口信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D15")
                .setDock("width")
                .setTop(0)
                .setHeight(97)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#f3e6d7;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D15.append(
                (new linb.UI.ComboInput)
                .setHost(host, "sktlx")
                .setDataBinder("abinder")
                .setDataField("sktlx")
                .setLeft(120)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>收口条</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "", "caption": "" }, { "id": "双面", "caption": "双面" }, { "id": "正面", "caption": "正面" }, { "id": "反面", "caption": "反面"}])
                .onChange("_sktlx_onchange")
            );

            host.D15.append(
                (new linb.UI.Input)
                .setHost(host, "sktcz")
                .setDataBinder("abinder")
                .setDataField("sktcz")
                .setReadonly(true)
                .setLeft(280)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>正收口条颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D15.append(
                (new linb.UI.Input)
                .setHost(host, "sktname")
                .setDataBinder("abinder")
                .setDataField("sktname")
                .setReadonly(true)
                .setLeft(440)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>正收口条</span>")
                .setLabelHAlign("left")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D15.append(
                (new linb.UI.Input)
                .setHost(host, "sktcode")
                .setDataBinder("abinder")
                .setDataField("sktcode")
                .setReadonly(true)
                .setLeft(540)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(80)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>收口条名称</span>")
            );

            host.D15.append(
                (new linb.UI.ComboInput)
                .setHost(host, "sktjc")
                .setDataBinder("abinder")
                .setDataField("sktjc")
                .setLeft(120)
                .setTop(45)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>T型边加长</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "0", "caption": "" }, { "id": "5", "caption": "5mm" }, { "id": "10", "caption": "10mm" }, { "id": "15", "caption": "15mm" }, { "id": "20", "caption": "20mm" }, { "id": "50", "caption": "50mm" }, { "id": "80", "caption": "80mm" }, { "id": "100", "caption": "100mm" }, { "id": "150", "caption": "150mm" }, { "id": "200", "caption": "200mm" }, { "id": "300", "caption": "300mm"}])
            );

            host.D15.append(
                (new linb.UI.ComboInput)
                .setHost(host, "cbjc")
                .setDataBinder("abinder")
                .setDataField("cbjc")
                .setLeft(440)
                .setTop(45)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>衬板加长</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "0", "caption": "" }, { "id": "5", "caption": "5mm" }, { "id": "10", "caption": "10mm" }, { "id": "15", "caption": "15mm" }, { "id": "20", "caption": "20mm" }, { "id": "50", "caption": "50mm" }, { "id": "80", "caption": "80mm" }, { "id": "100", "caption": "100mm" }, { "id": "150", "caption": "150mm" }, { "id": "200", "caption": "200mm" }, { "id": "300", "caption": "300mm"}])
            );

            host.D15.append(
                (new linb.UI.ComboInput)
                .setHost(host, "skttjc")
                .setDataBinder("abinder")
                .setDataField("skttjc")
                .setLeft(280)
                .setTop(45)
                .setWidth(130)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>装饰边加长</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "0", "caption": "" }, { "id": "5", "caption": "5mm" }, { "id": "10", "caption": "10mm" }, { "id": "15", "caption": "15mm" }, { "id": "20", "caption": "20mm" }, { "id": "50", "caption": "50mm" }, { "id": "80", "caption": "80mm" }, { "id": "100", "caption": "100mm" }, { "id": "150", "caption": "150mm" }, { "id": "200", "caption": "200mm" }, { "id": "300", "caption": "300mm"}])
            );

            host.D15.append(
                (new linb.UI.Input)
                .setHost(host, "skttcz")
                .setDataBinder("abinder")
                .setDataField("skttcz")
                .setReadonly(true)
                .setLeft(600)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>反收口条颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D15.append(
                (new linb.UI.Input)
                .setHost(host, "skttname")
                .setDataBinder("abinder")
                .setDataField("skttname")
                .setReadonly(true)
                .setLeft(760)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>反收口条</span>")
                .setLabelHAlign("left")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D15.append(
                (new linb.UI.Input)
                .setHost(host, "skttcode")
                .setDataBinder("abinder")
                .setDataField("skttcode")
                .setReadonly(true)
                .setLeft(540)
                .setTop(10)
                .setWidth(240)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(80)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>收口条名称</span>")
            );

            host.D15.append(
                (new linb.UI.SLabel)
                .setHost(host, "lyt")
                .setLeft(50)
                .setTop(40)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>套特殊项</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D14")
                .setDock("width")
                .setTop(0)
                .setHeight(50)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#f3e6d7;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbcz")
                .setDataBinder("abinder")
                .setDataField("mtbcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>引板颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbname")
                .setDataBinder("abinder")
                .setDataField("mtbname")
                .setReadonly(true)
                .setLeft(280)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>引板名称</span>")
                .setLabelHAlign("left")
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

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbscz")
                .setDataBinder("abinder")
                .setDataField("mtbscz")
                .setReadonly(true)
                .setLeft(440)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>反面引板颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbsname")
                .setDataBinder("abinder")
                .setDataField("mtbsname")
                .setReadonly(true)
                .setLeft(600)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>反面引板名称</span>")
                .setLabelHAlign("left")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D14.append(
                (new linb.UI.Input)
                .setHost(host, "mtbscode")
                .setDataBinder("abinder")
                .setDataField("mtbscode")
                .setReadonly(true)
                .setLeft(780)
                .setTop(20)
                .setWidth(230)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(100)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>反面引板名称</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D14.append(
                (new linb.UI.SLabel)
                .setHost(host, "lyb")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>引板</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D07")
                .setDock("width")
                .setTop(0)
                .setHeight(49)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#f3e6d7;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D07.append(
                (new linb.UI.Input)
                .setHost(host, "slblname")
                .setDataBinder("abinder")
                .setDataField("slblname")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>上亮/侧亮玻璃</span>")
                .setLabelHAlign("left")
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

            host.D07.append(
                (new linb.UI.Input)
                .setHost(host, "slbcode")
                .setDataBinder("abinder")
                .setDataField("slbcode")
                .setReadonly(true)
                .setLeft(540)
                .setTop(10)
                .setWidth(220)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>上亮板</span>")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D07.append(
                (new linb.UI.ComboInput)
                .setHost(host, "slbname")
                .setDataBinder("abinder")
                .setDataField("slbname")
                .setLeft(280)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("block")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>隔板类型</span>")
                .setLabelHAlign("left")
                .setItems([{ "id": "木质隔板", "caption": "木质隔板" }, { "id": "玻璃隔板", "caption": "玻璃隔板"}])
            );

            host.D07.append(
                (new linb.UI.Input)
                .setHost(host, "slgbnum")
                .setDataBinder("abinder")
                .setDataField("slgbnum")
                .setLeft(440)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setDisplay("block")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>隔板数量</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.D07.append(
                (new linb.UI.ComboInput)
                .setHost(host, "slytcz")
                .setDataBinder("abinder")
                .setDataField("slytcz")
                .setLeft(300)
                .setTop(10)
                .setWidth(205)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>压条颜色</span>")
                .setType("listbox")
            );

            host.D07.append(
                (new linb.UI.SLabel)
                .setHost(host, "lsl")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>上亮</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D21")
                .setDock("width")
                .setTop(0)
                .setHeight(100)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#f3e6d7;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D21.append(
                (new linb.UI.Input)
                .setHost(host, "ykhjfw")
                .setDataBinder("abinder")
                .setDataField("ykhjfw")
                .setReadonly(true)
                .setLeft(600)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>横衬板接缝位置</span>")
                .setLabelHAlign("left")
            );

            host.D21.append(
                (new linb.UI.Input)
                .setHost(host, "yksjtw")
                .setDataBinder("abinder")
                .setDataField("yksjtw")
                .setReadonly(true)
                .setLeft(280)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>竖衬板接缝位置</span>")
                .setLabelHAlign("left")
            );

            host.D21.append(
                (new linb.UI.Input)
                .setHost(host, "ykzt")
                .setDataBinder("abinder")
                .setDataField("ykzt")
                .setLeft(760)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>左凸</span>")
                .setLabelHAlign("left")
            );

            host.D21.append(
                (new linb.UI.Input)
                .setHost(host, "ykyt")
                .setDataBinder("abinder")
                .setDataField("ykyt")
                .setLeft(920)
                .setTop(0)
                .setWidth(145)
                .setHeight(43)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:12px;color:#666666'>右凸</span>")
                .setLabelHAlign("left")
            );

            host.D21.append(
                (new linb.UI.SLabel)
                .setHost(host, "lykt")
                .setLeft(50)
                .setTop(40)
                .setCaption("<span style='font-weight:bolder;font-size:12px;color:#666666'>垭口特殊项</span>")
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ykhjft")
                .setDataBinder("abinder")
                .setDataField("ykhjft")
                .setReadonly(true)
                .setLeft(440)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("block")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>横衬板接缝类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "中间接缝", "caption": "中间接缝" }, { "id": "左侧接缝", "caption": "左侧接缝" }, { "id": "右侧接缝", "caption": "右侧接缝"}])
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "yksjft")
                .setDataBinder("abinder")
                .setDataField("yksjft")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("block")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>竖衬板接缝类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "下部衬板长", "caption": "下部衬板长"}])
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ykzcb")
                .setDataBinder("abinder")
                .setDataField("ykzcb")
                .setLeft(440)
                .setTop(50)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>左侧衬板无圆弧侧反面</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "斜切", "caption": "斜切" }, { "id": "开口10*11", "caption": "开口10*11" }, { "id": "开口15*11", "caption": "开口15*11" }, { "id": "开口20*11", "caption": "开口20*11" }, { "id": "开口30*11", "caption": "开口30*11" }, { "id": "开口10*11", "caption": "开口10*11"}])
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ykhq")
                .setDataBinder("abinder")
                .setDataField("ykhq")
                .setLeft(120)
                .setTop(50)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>横梁衬板斜切</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "1", "caption": "是" }, { "id": "0", "caption": "否"}])
                .onChange("_ykhq_onchange")
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ykycb")
                .setDataBinder("abinder")
                .setDataField("ykycb")
                .setLeft(600)
                .setTop(50)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>右侧衬板无圆弧侧反面</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "斜切", "caption": "斜切" }, { "id": "开口10*11", "caption": "开口10*11" }, { "id": "开口15*11", "caption": "开口15*11" }, { "id": "开口20*11", "caption": "开口20*11" }, { "id": "开口30*11", "caption": "开口30*11" }, { "id": "开口10*11", "caption": "开口10*11"}])
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ykscb")
                .setDataBinder("abinder")
                .setDataField("ykscb")
                .setLeft(760)
                .setTop(50)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>上梁衬板无圆弧侧反面</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "斜切", "caption": "斜切" }, { "id": "开口10*11", "caption": "开口10*11" }, { "id": "开口15*11", "caption": "开口15*11" }, { "id": "开口20*11", "caption": "开口20*11" }, { "id": "开口30*11", "caption": "开口30*11" }, { "id": "开口10*11", "caption": "开口10*11"}])
            );

            host.D21.append(
                (new linb.UI.ComboInput)
                .setHost(host, "ykacb")
                .setDataBinder("abinder")
                .setDataField("ykacb")
                .setLeft(280)
                .setTop(50)
                .setWidth(130)
                .setHeight(43)
                .setDisplay("none")
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>所有衬板无圆弧侧反面</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "斜切", "caption": "斜切" }, { "id": "开口10*11", "caption": "开口10*11" }, { "id": "开口15*11", "caption": "开口15*11" }, { "id": "开口20*11", "caption": "开口20*11" }, { "id": "开口30*11", "caption": "开口30*11" }, { "id": "开口10*11", "caption": "开口10*11"}])
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D05")
                .setDock("width")
                .setTop(0)
                .setHeight(60)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#e2f4f5;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D05.append(
                (new linb.UI.Input)
                .setHost(host, "wjname")
                .setDataBinder("abinder")
                .setDataField("wjname")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>五金名称</span>")
                .setLabelHAlign("left")
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

            host.D05.append(
                (new linb.UI.SLabel)
                .setHost(host, "lwj")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>五金信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D04")
                .setDock("width")
                .setTop(0)
                .setHeight(59)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#bae2ed;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D04.append(
                (new linb.UI.Input)
                .setHost(host, "ykcz")
                .setDataBinder("abinder")
                .setDataField("ykcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>产品颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D04.append(
                (new linb.UI.Input)
                .setHost(host, "ykname")
                .setDataBinder("abinder")
                .setDataField("ykname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>产品名称</span>")
                .setLabelHAlign("left")
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

            host.D04.append(
                (new linb.UI.SLabel)
                .setHost(host, "lswl")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>辅料信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D13")
                .setDock("width")
                .setTop(0)
                .setHeight(60)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#e2f4f5;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D13.append(
                (new linb.UI.Input)
                .setHost(host, "hjcz")
                .setDataBinder("abinder")
                .setDataField("hjcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>家具材质</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D13.append(
                (new linb.UI.Input)
                .setHost(host, "hjname")
                .setDataBinder("abinder")
                .setDataField("hjname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>家具名称</span>")
                .setLabelHAlign("left")
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
                .setLabelCaption("<span style='font-size:14px;color:#666666'>家具编码</span>")
            );

            host.D13.append(
                (new linb.UI.SLabel)
                .setHost(host, "lhj")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>护角信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D06")
                .setDock("width")
                .setTop(0)
                .setHeight(60)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#bae2ed;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D06.append(
                (new linb.UI.Input)
                .setHost(host, "blname")
                .setDataBinder("abinder")
                .setDataField("blname")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>玻璃名称</span>")
                .setLabelHAlign("left")
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

            host.D06.append(
                (new linb.UI.SLabel)
                .setHost(host, "lbl")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>玻璃信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D10")
                .setDock("width")
                .setTop(0)
                .setHeight(57)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#e2f4f5;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D10.append(
                (new linb.UI.Input)
                .setHost(host, "qtcz")
                .setDataBinder("abinder")
                .setDataField("qtcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(160)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>其他颜色</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D10.append(
                (new linb.UI.Input)
                .setHost(host, "qtname")
                .setDataBinder("abinder")
                .setDataField("qtname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>其他名称</span>")
                .setLabelHAlign("left")
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
                .setLeft(280)
                .setTop(20)
                .setWidth(25)
                .setHeight(25)
                .setSrc("../../../Image/opeimage/close.gif")
                .setCursor("pointer")
                .onClick("_cimg_onclick")
            );

            host.D10.append(
                (new linb.UI.SLabel)
                .setHost(host, "lsqt")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>其他信息</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D19")
                .setDock("width")
                .setTop(0)
                .setHeight(59)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#bae2ed;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D19.append(
                (new linb.UI.ComboInput)
                .setHost(host, "locks")
                .setDataBinder("abinder")
                .setDataField("locks")
                .setLeft(120)
                .setTop(0)
                .setWidth(165)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>锁孔类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.D19.append(
                (new linb.UI.ComboInput)
                .setHost(host, "locktype")
                .setDataBinder("abinder")
                .setDataField("locktype")
                .setLeft(330)
                .setTop(0)
                .setWidth(165)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>合页孔类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
            );

            host.D19.append(
                (new linb.UI.SLabel)
                .setHost(host, "lsj")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>开孔类型</span>")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D20")
                .setDock("width")
                .setTop(0)
                .setHeight(59)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#bae2ed;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D20.append(
                (new linb.UI.Input)
                .setHost(host, "wlname")
                .setDataBinder("abinder")
                .setDataField("wlname")
                .setReadonly(true)
                .setLeft(330)
                .setTop(0)
                .setWidth(180)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>辅助产品</span>")
                .setLabelHAlign("left")
                .onFocus("_refname_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D20.append(
                (new linb.UI.ComboInput)
                .setHost(host, "wlcode")
                .setDataBinder("abinder")
                .setDataField("wlcode")
                .setReadonly(true)
                .setLeft(300)
                .setTop(10)
                .setWidth(220)
                .setHeight(25)
                .setDisplay("none")
                .setLabelSize(60)
                .setLabelCaption("<span style='font-size:14px;color:#666666'>辅助产品</span>")
            );

            host.D20.append(
                (new linb.UI.SLabel)
                .setHost(host, "lfl")
                .setLeft(50)
                .setTop(20)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>辅料信息</span>")
            );

            host.D20.append(
                (new linb.UI.Input)
                .setHost(host, "wlcz")
                .setDataBinder("abinder")
                .setDataField("wlcz")
                .setReadonly(true)
                .setLeft(120)
                .setTop(0)
                .setWidth(160)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>辅助材质</span>")
                .setLabelHAlign("left")
                .onFocus("_refcz_onfocus")
                .setCustomClass({ "KEY": "inputsearch" })
            );

            host.D20.append(
                (new linb.UI.Image)
                .setHost(host, "wimg")
                .setLeft(280)
                .setTop(20)
                .setWidth(25)
                .setHeight(25)
                .setCursor("pointer")
                .setSrc("../../../Image/opeimage/close.gif")
                .onClick("_wimg_onclick")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D11")
                .setDock("width")
                .setTop(1)
                .setHeight(69)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "background:#d7c8a9;border-radius:5px;border-bottom:1px solid #cccccc" })
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "plength")
                .setDataBinder("abinder")
                .setDataField("plength")
                .setLeft(280)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>高度</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .onChange("_plength_onchange")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pwidth")
                .setDataBinder("abinder")
                .setDataField("pwidth")
                .setLeft(420)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>宽度</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .onChange("_pwidth_onchange")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pdeep")
                .setDataBinder("abinder")
                .setDataField("pdeep")
                .setLeft(560)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>厚度</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .onChange("_pdeep_onchange")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "psize")
                .setDataBinder("abinder")
                .setDataField("psize")
                .setLeft(700)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>总高1</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "zsize")
                .setDataBinder("abinder")
                .setDataField("zsize")
                .setLeft(840)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>总高2</span>")
                .setLabelHAlign("left")
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

            host.D11.append(
                (new linb.UI.ComboInput)
                .setHost(host, "stype")
                .setDataBinder("abinder")
                .setDataField("stype")
                .setLeft(120)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>尺寸类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "dk", "caption": "洞口尺寸" }, { "id": "wj", "caption": "套外径" }, { "id": "nj", "caption": "套内径" }, { "id": "ng", "caption": "套内高" }, { "id": "nk", "caption": "套内宽" }, { "id": "wg", "caption": "套外高" }, { "id": "wk", "caption": "套外宽" }, { "id": "wgnk", "caption": "套外高套内宽" }, { "id": "wkng", "caption": "套外宽套内高"}])
                .onChange("_stype_onchange")
            );

            host.D11.append(
                (new linb.UI.SLabel)
                .setHost(host, "lsz")
                .setLeft(50)
                .setTop(30)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>尺寸信息</span>")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pgdg")
                .setDataBinder("abinder")
                .setDataField("pgdg")
                .setLeft(700)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>固定门高</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .onChange("_pdeep_onchange")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pgdk")
                .setDataBinder("abinder")
                .setDataField("pgdk")
                .setLeft(700)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>固定门宽</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .onChange("_pdeep_onchange")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "pgdzmk")
                .setDataBinder("abinder")
                .setDataField("pgdzmk")
                .setLeft(700)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>固定子母宽</span>")
                .setLabelHAlign("left")
                .setValue("0")
                .onChange("_pdeep_onchange")
            );

            host.D11.append(
                (new linb.UI.Input)
                .setHost(host, "ydeep")
                .setDataBinder("abinder")
                .setDataField("ydeep")
                .setLeft(700)
                .setTop(10)
                .setWidth(130)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>右侧墙厚</span>")
                .setLabelHAlign("left")
                .setValue("0")
            );

            host.pm.append(
                (new linb.UI.Pane)
                .setHost(host, "D12")
                .setDock("width")
                .setTop(0)
                .setHeight(81)
                .setPosition("relative")
                .setCustomStyle({ "KEY": "border-bottom:#f2f2f2 solid 3px" })
            );

            host.D12.append(
                (new linb.UI.Input)
                .setHost(host, "pbz")
                .setDataBinder("abinder")
                .setDataField("pbz")
                .setLeft(120)
                .setTop(10)
                .setWidth(850)
                .setHeight(60)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</span>")
                .setLabelHAlign("left")
            );

            host.D12.append(
                (new linb.UI.SLabel)
                .setHost(host, "lsm")
                .setLeft(10)
                .setTop(30)
                .setCaption("<span style='font-weight:bolder;font-size:16px;color:#666666'>特殊说明</span>")
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
            d11 = "0"; //尺寸框是否显示
            bdcode = ""; //带品牌编码
            ltobj = LockType,
            hyobj = HyType,
            cvaobj = CaveType;
            jstobj = Jst;
            ytobj = Yt;
            mcobj = MsColor;
            xxobj = XxType;
            stobj = SizeType;
            mtzsbobj = MtZsbEdit;
            prange = "mm";
            refped = "", refp = ""; //被关联产品 与管理产品
            zmscz = ""; //子门材质
            zmccode = ""//子门类别编码
            szarr = new Array();
            Init();
            CustIinvDropList("", prange, ds.invcate);
            LoadOrderAttr(sid);
            //上亮压条色
            IDimMaterialAItems("", pbdcode, ds.slytcz)
            //压条套色
            IDimMaterialAItems("", pbdcode, ds.ytcz)
            //门扇压条色
            IDimMaterialAItems("", pbdcode, ds.mbytcz)
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
            execfun("ds." + selcz + ".setUIValue('" + czv + "')")
            if (pricz != "fbt") {
                execfun("ds." + pricz + "name.setUIValue('')")
                execfun("ds." + pricz + "code.setUIValue('')")
            }
            ns.mdlg.setDisplay("none")
        },
        _invtreebar_onitemselected: function (profile, item, e, src, type) {
            var ns = this, uictrl = profile.boxing();
            var msc = ns.mscode.getUIValue();
            if (refped == "ms") {
                if (refp == "msbl") {
                    IMsRefBlItem(msc, item, ns.invtreebar)
                    CzQueryListInv(selczv, item.id, ds.invtreegrid);
                }
                if (refp == "msmt") {
                    IMsRefMtItem(item, msc, selczv, ds.invtreebar)
                    CzQueryListInv(selczv, item.id, ds.invtreegrid);
                }
            }
            if (refped == "") {
                ICzinvRangeItems(selczv, item, prange, ds.invtreebar)
                CzQueryListInv(selczv, item.id, ds.invtreegrid)
            }
        },
        _invtreebar_beforeexpend: function (profile, item) {
            var ns = this, uictrl = profile.boxing();
            var msv = ns.mscode.getUIValue();
            if (refped == "ms") {
                if (refp == "msbl") {
                    IMsRefBlItem(msv, item, ds.invtreebar)
                }
                if (refp == "msmt") {
                    IMsRefMtItem(item, msv, selczv, ds.invtreebar)
                }
            }
            if (refped == "") {
                ICzinvRangeItems(selczv, item, prange, ds.invtreebar)
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
            ds.invtreegrid.removeAllRows()
            if (CheckCz()) {
                ds.invdlg.setDisplay("block")
                InvSetCate()
            }
        },
        _refcz_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            selcz = uictrl._nodes[0].alias;
            ns.mdlg.setDisplay("block")
            ns.mtreegrid.removeAllRows();
            QueryMaterialListByBdcode(pbdcode, "", ns.mtreebar);
        },
        _cimg_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
            ds.qtcz.setValue("");
        },
        _spname_onfocus: function (profile) {
            var ns = this, uictrl = profile.boxing();
            var spv = ds.spname.getUIValue();
            if (spv != "" && spv != null) {
                spv = spv.replace('[', '')
                QuerySearingList(sinvcate, selczv, spv, ns.invtreegrid);
            }
        },
        _spname_onhotkeyup: function (profile, keyboard, e, src) {
            var ns = this, uictrl = profile.boxing();
            var spv = ds.spname.getUIValue();
            if (spv != "" && spv != null) {
                spv = spv.replace('[', '')
                QuerySearingList(sinvcate, selczv, spv, ns.invtreegrid);
            }
        },
        _spname_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            if (newValue != "" && newValue != null) {
                spv = newValue.replace('[', '')
                QuerySearingList(sinvcate, selczv, spv, ns.invtreegrid);
            }
        },
        _sktlx_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            if (newValue == "") {
                ds.sktname.setDisplay("none")
                ds.sktcz.setDisplay("none")
                ds.skttname.setDisplay("none")
                ds.skttcz.setDisplay("none")
                ds.sktname.setUIValue("")
                ds.sktcz.setUIValue("")
                ds.skttname.setUIValue("")
                ds.skttcz.setUIValue("")
            }
            else {
                ds.sktname.setDisplay("block")
                ds.sktcz.setDisplay("block")
                ds.skttname.setDisplay("block")
                ds.skttcz.setDisplay("block")
                var mtv = ds.mtcode.getUIValue();
                CheckMtZsb(mtv)
            }
        },
        _plength_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            CheckOverSize(newValue, 0);
            // FormatHigh();
        },
        _pwidth_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            CheckOverSize(0, newValue);
            //FormatWidth();
        },
        _pdeep_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            //FormatDeep();
        },
        _stype_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            //            FormatHigh();
            //            FormatWidth();
            //            FormatDeep();
        },
        _ykhq_onchange: function (profile, oldValue, newValue) {
            var ns = this, uictrl = profile.boxing();
            CheckYkQ(newValue);
        },
        _wimg_onclick: function (profile, e, src) {
            var ns = this, uictrl = profile.boxing();
            ds.wlcz.setUIValue("")
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
    ds.D10.setDisplay("none");
    ds.D11.setDisplay("none");
    ds.D12.setDisplay("none");
    ds.D13.setDisplay("none");
    ds.D14.setDisplay("none");
    ds.D15.setDisplay("none");
    ds.D16.setDisplay("none");
    ds.D17.setDisplay("none");
    ds.D22.setDisplay("none");
    ds.D19.setDisplay("none");
    ds.D20.setDisplay("none");
    ds.D21.setDisplay("none");
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
    ds.D10.setDisplay("none");
    ds.D11.setDisplay("none");
    ds.D12.setDisplay("none");
    ds.D13.setDisplay("none");
    ds.D14.setDisplay("none");
    ds.D15.setDisplay("none");
    ds.D16.setDisplay("none");
    ds.D17.setDisplay("none");
    ds.D22.setDisplay("none");
    ds.D19.setDisplay("none");
    ds.D20.setDisplay("none");
    ds.D21.setDisplay("none");
    ds.psize.setDisplay("none");
    ds.ydeep.setDisplay("none");
    ds.pgdzmk.setDisplay("none");
    ds.pgdk.setDisplay("none");
    ds.pgdg.setDisplay("none");
    ds.zsize.setDisplay("none");
    switch (v) {
        case "010":
            ds.D01.setDisplay("block");
            ds.D02.setDisplay("block");
            ds.D15.setDisplay("block");
            ds.D16.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D19.setDisplay("block");
            ds.D22.setDisplay("block");
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞厚</span>");
            var smscode = ds.mscode.getUIValue();
            var smstode = ds.mtcode.getUIValue();
            break;
        case "001":
            ds.D01.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D16.setDisplay("block");
            ds.D19.setDisplay("block");
            ds.D22.setDisplay("block");
            ds.locktype.setValue("")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>门高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>门宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>门厚</span>");
            break;
        case "002":
            ds.D02.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.D15.setDisplay("block");
            ds.locktype.setValue("无")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞口厚</span>");
            break;
        case "006":
            ds.D03.setDisplay("block");
            ds.D14.setDisplay("block");
            ds.D15.setDisplay("block");
            ds.D21.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.locktype.setValue("无")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞厚</span>");
            break;
        case "007":
            ds.D04.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.locktype.setValue("无")
            ds.plength.setLabelCaption("<span style='font-size:14px;color:#666666'>洞高</span>");
            ds.pwidth.setLabelCaption("<span style='font-size:14px;color:#666666'>洞宽</span>");
            ds.pdeep.setLabelCaption("<span style='font-size:14px;color:#666666'>洞厚</span>");
            break;
        case "004":
            ds.D05.setDisplay("block");
            ds.locktype.setValue("无")
            break;
        case "005":
            ds.D06.setDisplay("block");
            ds.locktype.setValue("无")
            ds.mscode.setValue();
            break;
        case "008":
            ds.D13.setDisplay("block");
            ds.D11.setDisplay("block");
            ds.locktype.setValue("无")
            break;
        case "009":
            ds.D10.setDisplay("block");
            // ds.D11.setDisplay("block");
            ds.locktype.setValue("无")
            break;
        case "011":
            ds.D20.setDisplay("block");
            ds.D12.setDisplay("block");
            break;
    }
    if (eremark) {
        ds.D12.setDisplay("block");
    }
}
///设置选中产品
function InvSetValue(r) {
    var rname = r.cells[0].value;
    var rcode = r.cells[1].value;
    var rcz = r.cells[2].value;
    var locks = ds.locks.getUIValue();
    var zjtype = "";
    d11 = "0";
    var csize = 0;
    //RefProductionSize(rcode)
    var remarks = ""; //  InvRemarkCheck(rcode);
    switch (selinv) {
        case "msname":
            ds.msname.setUIValue(rname)
            ds.mscode.setUIValue(rcode)
            if (sdinvcate == "010") {
                //RefMt(rcode, rcz)
                ///----------检测整套门洞口类型
                var cmt = ds.mtcode.getValue();
                if (cmt != "" && cmt != null) {
                    cvaobj.IRCaveItem(rcode, cmt, ds.cavetype);
                }
            }
            CheckZjShow("msname", rcode)
            jstobj.JstItems(rcode, ds.msjst);
            ytobj.YtItems(rcode, ds.ytcz);
            mcobj.ColorItems(rcode, ds.msts);
            ltobj.RefLockItems(rcode, ds.locks);
            hyobj.RefHyItems(rcode, ds.locktype);
            xxobj.RefLineItems(rcode, ds.xxline)
            CheckZmm(rname, rcode);
            ds.mbname.setUIValue('')
            ds.mbcode.setUIValue('')
            break;
        case "zmsname":
            ds.zmsname.setUIValue(rname)
            ds.zmscode.setUIValue(rcode)
            break;
        case "mtname":
            ds.mtname.setUIValue(rname)
            ds.mtcode.setUIValue(rcode)
            CheckZjShow("mtname", rcode)
            break;
        case "ctname":
            ds.ctname.setUIValue(rname)
            ds.ctcode.setUIValue(rcode)
            CheckZjShow("ctname", rcode)
            CheckMtZsb(rcode)
            break;
        case "sktname":
            ds.sktname.setUIValue(rname)
            ds.sktcode.setUIValue(rcode)
            break;
        case "skttname":
            ds.skttname.setUIValue(rname)
            ds.skttcode.setUIValue(rcode)
            break;
        case "ykname":
            ds.ykname.setUIValue(rname)
            ds.ykcode.setUIValue(rcode)
            break;
        case "hjname":
            ds.hjname.setUIValue(rname)
            ds.hjcode.setUIValue(rcode);
            ds.plength.setLabelCaption("高度");
            ds.pwidth.setLabelCaption("宽度")
            ds.pdeep.setLabelCaption("厚度");
            break;
        case "qtname":
            d11 = "1";
            CheckHj(rcode)
            ds.qtname.setUIValue(rname)
            ds.qtcode.setUIValue(rcode)
            if (rcode.substr(0, 4) == "009025") {
                ds.plength.setLabelCaption("高度");
                ds.pwidth.setLabelCaption("宽度")
                ds.pdeep.setDisplay("none");
            }
            else {
                ds.plength.setLabelCaption("高度");
                ds.pwidth.setLabelCaption("宽度")
                ds.pdeep.setLabelCaption("厚度");
                ds.pdeep.setDisplay("block");
            }
            break;
        case "wjname":
            ds.wjname.setUIValue(rname)
            ds.wjcode.setUIValue(rcode)
            break;
        case "wlname":
            ds.wlname.setUIValue(rname)
            ds.wlcode.setUIValue(rcode)
            d11 = "1";
            break;
        case "blname":
            ds.blname.setUIValue(rname)
            ds.blcode.setUIValue(rcode)
            break;
        case "mbname":
            ds.mbname.setUIValue(rname)
            ds.mbcode.setUIValue(rcode)
            break;
        case "slblname":
            ds.slblname.setUIValue(rname)
            ds.slblcode.setUIValue(rcode)
            break;
        case "mtbname":
            csize = 1;
            ds.mtbname.setUIValue(rname)
            ds.mtbcode.setUIValue(rcode)
            break;
        case "mtbsname":
            csize = 1;
            ds.mtbsname.setUIValue(rname)
            ds.mtbscode.setUIValue(rcode)
            break;
    }
    if (remarks) {
        ds.pbz.setUIValue(remarks)
    }
    if (csize != 1) {
        stobj.ICheckSizeType(rcode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
    }
    // ds.palist.clearItems();
    //    switch (sdinvcate) {
    //        case "010":
    //            var pmsv = ds.mscode.getUIValue();
    //            if (pmsv != "") {
    //                IinvCheckBoxList(pmsv, ds.palist);
    //            }
    //            var pmtv = ds.mtcode.getUIValue();
    //            if (pmtv != "") {
    //                IinvCheckBoxList(pmtv, ds.palist);
    //            }
    //            var pblv = ds.blcode.getUIValue();
    //            if (pblv != "") {
    //                IinvCheckBoxList(pblv, ds.palist);
    //            }
    //            var pmtbv = ds.mtbcode.getUIValue();
    //            if (pmtbv != "") {
    //                IinvCheckBoxList(pmtbv, ds.palist);
    //            }
    //            var pslv = ds.slblcode.getUIValue();
    //            if (pslv != "") {
    //                IinvCheckBoxList(pslv, ds.palist);
    //            }

    //            break;
    //        case "001":
    //            var pmsv = ds.mscode.getUIValue();
    //            if (pmsv != "") {
    //                IinvCheckBoxList(pmsv, ds.palist);
    //            }
    //            var pblv = ds.blcode.getUIValue();
    //            if (pblv != "") {
    //                IinvCheckBoxList(pblv, ds.palist);
    //            }
    //            break;
    //       
    //        case "002":
    //            var pmtv = ds.mtcode.getUIValue();
    //            if (pmtv != "") {
    //                IinvCheckBoxList(pmtv, ds.palist);
    //            }
    //            var pmtbv = ds.mtbcode.getUIValue();
    //            if (pmtbv != "") {
    //                IinvCheckBoxList(pmtbv, ds.palist);
    //            }
    //            var pslv = ds.slblcode.getUIValue();
    //            if (pslv != "") {
    //                IinvCheckBoxList(pslv, ds.palist);
    //            }
    //            break;
    //        case "006":
    //            var pctv = ds.ctcode.getUIValue();
    //            if (pctv != "") {
    //                IinvCheckBoxList(pctv, ds.palist);
    //            }
    //            var pmtbv = ds.mtbcode.getUIValue();
    //            if (pmtbv != "") {
    //                IinvCheckBoxList(pmtbv, ds.palist);
    //            }
    //            var pslv = ds.slblcode.getUIValue();
    //            if (pslv != "") {
    //                IinvCheckBoxList(pslv, ds.palist);
    //            }
    //            break;
    //        case "007":
    //            var pykv = ds.ykcode.getUIValue();
    //            if (pykv != "") {
    //                IinvCheckBoxList(pykv, ds.palist);
    //            }
    //            var pmtbv = ds.mtbcode.getUIValue();
    //            if (pmtbv != "") {
    //                IinvCheckBoxList(pmtbv, ds.palist);
    //            }
    //            var pslv = ds.slblcode.getUIValue();
    //            if (pslv != "") {
    //                IinvCheckBoxList(pslv, ds.palist);
    //            }
    //            break;
    //        default:
    //            IinvCheckBoxList(rcode, ds.palist);
    //            break;
    //    }
    //    if (IinvCheckBox("", ds.palist)) {
    //        ds.D18.setDisplay("block");
    //    }
    return r;
}
///获取当前产品类型
function InvSetCate() {
    var smscode = ds.mscode.getUIValue();
    refped = "";
    refp = "";
    switch (selinv) {
        case "msname":
            sinvcate = bdcode + "001";
            zmscz = selczv
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "zmsname":
            sinvcate = zmccode;
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "mtname":
            sinvcate = bdcode + "002";
            if (sdinvcate == "010") {
                refped = "ms";
                refp = "msmt";
                var rmscode = ds.mscode.getUIValue();
                if (rmscode == "") {
                    linb.warn("请选择门扇");
                    ds.invdlg.setDisplay("none");
                    return
                }
                else {
                    IMsRefMtCate(rmscode, sinvcate, selczv, ds.invtreebar)
                }
            }
            else {
                ICzinvItems(selczv, sinvcate, ds.invtreebar)
            }
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
        case "wlname":
            sinvcate = bdcode + "011";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        //        case "hyname": 
        //            sinvcate = bdcode + "004002"; 
        //            ICzinvItems("", sinvcate, ds.invtreebar) 
        //            break; 
        case "blname":
            if (smscode != "" && smscode != null) {
                refped = "ms";
                refp = "msbl";
                sinvcate = bdcode + "005";
                IMsRefBlCate(smscode, sinvcate, ds.invtreebar)
            }
            else {
                sinvcate = bdcode + "005";
                ICzinvItems("", sinvcate, ds.invtreebar)
            }
            break;
        case "mbname":
            if (smscode != "" && smscode != null) {
                refped = "ms";
                refp = "msbl";
                sinvcate = bdcode + "005";
                IMsRefBlCate(smscode, sinvcate, ds.invtreebar)
            }
            else {
                sinvcate = bdcode + "005";
                ICzinvItems("", sinvcate, ds.invtreebar)
            }
            break;
        case "slblname":
            sinvcate = bdcode + "005001";
            ICzinvItems("", sinvcate, ds.invtreebar)
            break;
        case "mtbname":
            sinvcate = bdcode + "009002";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "mtbsname":
            sinvcate = bdcode + "009002";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "hjname":
            sinvcate = bdcode + "008";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "sktname":
            sinvcate = bdcode + "009002001";
            ICzinvItems(selczv, sinvcate, ds.invtreebar)
            break;
        case "skttname":
            sinvcate = bdcode + "009002001";
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
        case "zmsname":
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
        case "mtbsname":
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
        case "sktname":
            r = CheckInput(ds, ds.sktcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.sktcz.getUIValue()
            break;
        case "skttname":
            r = CheckInput(ds, ds.skttcz, true, "", "选择产品材质", "", "", "");
            selczv = ds.skttcz.getUIValue()
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
    var url = '../../../UIServer/SalesBusiness/DistributorDoorOrder/SaleOrder.aspx/LoadSaleOrder'
    var o = { "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        if (r.sid != "") {
            //材质
            ds.mscz.setUIValue(r.mname)
            ds.mtcz.setUIValue(r.mname)
            ds.ctcz.setUIValue(r.mname)
            ds.ykcz.setUIValue(r.mname)
            ds.mtbcz.setUIValue(r.mname)
            ds.hjcz.setUIValue(r.mname)
            //楼层
            ds.floor.setUIValue(r.floor)
        }
        else {
            LoadAOrderAttr(sid);
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
            ds.mscz.setUIValue(r.mname)
            ds.mtcz.setUIValue(r.mname)
            ds.ctcz.setUIValue(r.mname)
            ds.ykcz.setUIValue(r.mname)
            ds.kxcz.setUIValue(r.mname)
            ds.qtcz.setUIValue(r.mname)
            ds.hjcz.setUIValue(r.mname)
            //楼层
            ns.floor.setUIValue(r.floor)
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
        ds.mtname.setUIValue(r.icname);
        ds.mtcode.setUIValue(r.icode);
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
    if (!CheckInput(ds, ds.pnum, true, "number", "请输入产品数量", "正确输入产品数量", "0", "9999")) {
        return false;
    }
    if (sdinvcate == "010") {

        if (!CheckInput(ds, ds.direction, true, "", "请选择开向", "", "", "")) {
            return false;
        }
        if (!CheckInput(ds, ds.msname, true, "", "请选择门扇", "", "", "")) {
            return false;
        }
        if (!CheckInput(ds, ds.mtname, true, "", "请选择门套", "", "", "")) {
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
        if (!CheckInput(ds, ds.mtname, true, "", "请选择门套", "", "", "")) {
            return false;
        }
        var mtv = ds.mtcode.getUIValue();
        if (!CheckLimited(mtv, hv, wv, dv, fv)) {
            return false;
        }
    }
    if (sdinvcate == "006") {
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
        var arg1 = { "sid": sid, "gnum": gnum }
        var db = linb.DataBinder.getFromName("abinder");
        var arg2 = db.updateDataFromUI().getData();
        var o = $.extend(arg1, arg2);
        var url = '../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/SaveProduction';
        var b = AjaxExb(url, o);
        BackVad(b, linb.cumfun, false)
        if (penum == 0) {
            InitProduction()
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
        ds.plength.setUIValue(r.ng);
        ds.pwidth.setUIValue(r.nk);
        ds.pdeep.setUIValue(r.nh);
        ds.psize.setUIValue(r.nf);
    }
}
////检测产品属性
//function CheckInvAttr(v, msv, mtv, ctv, ykv) {
//    switch (v) {
//        case "010":
//            IinvCheckBoxList(msv, ds.palist);
//            if (IinvCheckBox(msv, ds.palist)) {
//                ds.D18.setDisplay("block");
//            }
//            IinvCheckBoxList(mtv, ds.palist);
//            if (IinvCheckBox(mtv, ds.palist)) {
//                ds.D18.setDisplay("block");
//            }
//            break;
//        case "001":
//            IinvCheckBoxList(msv, ds.palist);
//            if (IinvCheckBox(msv, ds.palist)) {
//                ds.D18.setDisplay("block");
//            }
//            break;
//        case "002":
//            IinvCheckBoxList(mtv, ds.palist);
//            if (IinvCheckBox(mtv, ds.palist)) {
//                ds.D18.setDisplay("block");
//            }
//            break;
//        case "006":
//            IinvCheckBoxList(ctv, ds.palist);
//            if (IinvCheckBox(ctv, ds.palist)) {
//                ds.D18.setDisplay("block");
//            }
//            break;
//        case "007":
//            IinvCheckBoxList(ykv, ds.palist);
//            if (IinvCheckBox(ykv, ds.palist)) {
//                ds.D18.setDisplay("block");
//            }
//            break;
//    }
//}
function EditProductions(sid, gnum) {
    ClearFormat();
    var o = { "sid": sid, 'gnum': gnum }
    var url = "../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/EditProduction"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        var zjpcode = "";
        bdcode = r.invprecode;
        sdinvcate = r.invcate;
        ds.invcate.setUIValue(bdcode + sdinvcate);
        ShowDiv(sdinvcate)
        zjpcode = r.mtcode == "" ? r.ctcode == "" ? r.ykcode : r.ctcode : r.mtcode;
        zjtype = InvComponentCheck(zjpcode);
        if (r.mbname != "") {
            ds.D17.setDisplay("block");
        }
        if (r.blname != "") {
            ds.D06.setDisplay("block");
        }
        if (zjtype == "m") {
            ds.D14.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.mtbname.setUIValue(r.zjname);
            ds.mtbcz.setUIValue(r.zjcz);
            ds.mtbcode.setUIValue(r.zjcode);
        }
        if (zjtype == "y") {
            ds.D14.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.mtbname.setUIValue(r.zjname);
            ds.mtbcz.setUIValue(r.zjcz);
            ds.mtbcode.setUIValue(r.zjcode);
            ds.plength.setLabelCaption("洞高");
        }
        if (zjtype == "s") {
            ds.D07.setDisplay("block");
            ds.slblcode.setUIValue(r.zjcode);
            ds.slblname.setUIValue(r.zjname);
        }
        if (zjtype == "c") {
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.psize.setLabelCaption("横板总长");
            ds.zsize.setLabelCaption("横板总宽");
        }
        if (zjtype == "d") {
            ds.ykzcb.setDisplay("block");
            ds.ykycb.setDisplay("block");
            ds.ykscb.setDisplay("block");
            ds.ykacb.setDisplay("block");
            ds.ykhq.setDisplay("block");
        }
        else {
            ds.ykzcb.setDisplay("none");
            ds.ykycb.setDisplay("none");
            ds.ykscb.setDisplay("none");
            ds.ykacb.setDisplay("none");
            ds.ykhq.setDisplay("none");
            ds.ykzcb.setUIValue("");
            ds.ykycb.setUIValue("");
            ds.ykscb.setUIValue("");
            ds.ykacb.setUIValue("");
            ds.ykhq.setUIValue("");
        }
        if (r.mscode != "") {
            ytobj.YtItems(r.mscode, ds.ytcz);
            jstobj.JstItems(r.mscode, ds.msjst);
            mcobj.ColorItems(r.mscode, ds.msts);
            ltobj.RefLockItems(r.mscode, ds.locks);
            hyobj.RefHyItems(r.mscode, ds.locktype);
            xxobj.RefLineItems(r.mscode, ds.xxline)
        }

        CheckZmm(r.msname, r.mscode)
        ds.mbcode.setUIValue(r.mbcode);
        ds.mbname.setUIValue(r.mbname);
        ds.mbfx.setUIValue(r.mbfx);
        ds.mbnum.setUIValue(r.mbnum);
        ds.msjst.setUIValue(r.jstname);
        ds.xxline.setUIValue(r.xxline);
        ds.stype.setUIValue(r.stype);
        ds.blcode.setUIValue(r.blcode);
        ds.blname.setUIValue(r.blname);
        ds.ctcode.setUIValue(r.ctcode);
        ds.ctcz.setUIValue(r.ctcz);
        ds.ctname.setUIValue(r.ctname);
        ds.cttbcz.setUIValue(r.tbcz);
        ds.ctlxcz.setUIValue(r.lxcz);
        ds.direction.setUIValue(r.direction);
        ds.fixed.setUIValue(r.fix);
        ds.pnum.setUIValue(r.pnum);
        ds.hjcode.setUIValue(r.hjcode);
        ds.hjcz.setUIValue(r.hjcz);
        ds.hjname.setUIValue(r.hjname);
        ds.locktype.setUIValue(r.locktype);
        ds.locks.setUIValue(r.locks);
        ds.mscode.setUIValue(r.mscode);
        ds.mscz.setUIValue(r.mscz);
        ds.ytcz.setUIValue(r.ytcz);
        ds.mbytcz.setUIValue(r.mbytcz);
        ds.slytcz.setUIValue(r.slytcz);
        ds.msname.setUIValue(r.msname);
        ds.mtcode.setUIValue(r.mtcode);
        ds.zmsname.setUIValue(r.zmsname);
        ds.zmscode.setUIValue(r.zmscode);
        ds.mtcz.setUIValue(r.mtcz);
        ds.mtname.setUIValue(r.mtname);
        ds.mttbcz.setUIValue(r.tbcz);
        ds.mtlxcz.setUIValue(r.lxcz);
        ds.mtname.setUIValue(r.mtname);
        ds.pbz.setUIValue(r.pbz);
        ds.pdeep.setUIValue(r.pdeep);
        ds.place.setUIValue(r.place);
        ds.plength.setUIValue(r.plength);
        ds.pnum.setUIValue(r.pnum);
        ds.psize.setUIValue(r.fsize);
        ds.zsize.setUIValue(r.zsize);
        ds.pwidth.setUIValue(r.pwidth);
        ds.qtcode.setUIValue(r.qtcode);
        ds.qtcz.setUIValue(r.qtcz);
        ds.qtname.setUIValue(r.qtname);
        // ds.sjcode.setUIValue(r.sjcode);
        //sjname.setUIValue(r.sjname);
        ds.wjcode.setUIValue(r.wjcode);
        ds.wjname.setUIValue(r.wjname);
        ds.ykcode.setUIValue(r.ykcode);
        ds.ykcz.setUIValue(r.ykcz);
        ds.ykname.setUIValue(r.ykname);
        ds.isjc.setUIValue(r.isjc);
        ds.sktname.setUIValue(r.sktname);
        ds.sktcode.setUIValue(r.sktcode);
        ds.sktcz.setUIValue(r.sktcz);
        ds.skttname.setUIValue(r.skttname);
        ds.skttcode.setUIValue(r.skttcode);
        ds.skttcz.setUIValue(r.skttcz);
        ds.sktlx.setUIValue(r.sktlx);
        ds.slbname.setUIValue(r.slbname);
        ds.slbcode.setUIValue(r.slbcode);
        ds.slgbnum.setUIValue(r.slbnum);
        ds.sktjc.setUIValue(r.sktjc);
        ds.skttjc.setUIValue(r.skttjc);
        ds.cbjc.setUIValue(r.cbjc);
        ds.yksjtw.setUIValue(r.sxjf);
        ds.ykhjfw.setUIValue(r.zyjf);
        ds.fbtcz.setUIValue(r.fbtmname);
        ds.ykzt.setUIValue(r.ykzt);
        ds.ykyt.setUIValue(r.ykyt);
        ds.pgdg.setUIValue(r.gdg);
        ds.pgdk.setUIValue(r.gdk);
        ds.pgdzmk.setUIValue(r.zmgdk);
        ds.ydeep.setUIValue(r.ydeep);
        ds.ykacb.setUIValue(r.ykacb);
        ds.ykhjft.setUIValue(r.ykhjft);
        ds.ykhjfw.setUIValue(r.ykhjfw);
        ds.ykscb.setUIValue(r.ykscb);
        ds.yksjft.setUIValue(r.yksjft);
        ds.yksjtw.setUIValue(r.yksjtw);
        ds.ykycb.setUIValue(r.ykycb);
        ds.ykhq.setUIValue(r.ykhq);
        ds.ykzcb.setUIValue(r.ykzcb);
        ds.wlcz.setUIValue(r.wlcz)
        ds.wlcode.setUIValue(r.wlcode)
        ds.wlname.setUIValue(r.wlname)
        CheckYkQ(r.ykhq)
        if (r.sktlx == "") {
            ds.sktname.setDisplay("none")
            ds.sktcz.setDisplay("none")
        }
        else {
            ds.sktname.setDisplay("block")
            ds.sktcz.setDisplay("block")
        }
        CheckMtZsb(r.mtcode);
        //CheckInvAttr(sdinvcate, r.mscode, r.mtcode, r.ctcode, r.ykcode);
        // EditProductionAttr(sid, gnum);
        if (r.ctcode != "") {
            CheckOverSize(r.plength, 0);
            CheckOverSize(0, r.pwidth);
        }
        if (sdinvcate == "010") {
            stobj.ICheckSizeType(r.mtcode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
        }
        if (sdinvcate == "001") {
            stobj.ICheckSizeType(r.mscode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
        }
        if (sdinvcate == "002") {
            stobj.ICheckSizeType(r.mtcode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
        }
        if (sdinvcate == "006") {
            stobj.ICheckSizeType(r.ctcode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
        }
        if (sdinvcate == "009") {
            stobj.ICheckSizeType(r.qtcode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
        }
        if (sdinvcate == "011") {
            stobj.ICheckSizeType(r.wlcode, ds.D11, ds.plength, ds.pwidth, ds.pdeep, ds.psize, ds.zsize, ds.pgdg, ds.pgdk, ds.pgdzmk)
        }
    }
    OnFormat()
}
function CheckZmm(v, cv) {
    if (v.toString().indexOf("子母") > -1) {
        ds.zmsname.setDisplay("block");
        zmccode = cv.substring(0, cv.length - 9)
    }
    else {
        ds.zmsname.setDisplay("none");
    }
}
function EditProductionAttr(sid, gnum) {
    var o = { "sid": sid, 'gnum': gnum }
    var url = "../../../UIServer/SalesBusiness/DistributorDoorOrder/AddSaleOrderProduction.aspx/EditProductionAttr"
    var b = AjaxExb(url, o);
    if (b) {
        ds.palist.setUIValue(b);
    }
}
function CheckZjShow(pv, rv) {
    zjtype = InvComponentCheck(rv);
    if (pv == "msname") {
        if (zjtype == "b") {
            ds.D17.setDisplay("block")
        }
        else {
            ds.D17.setDisplay("none")
            ds.mbcode.setUIValue("");
            ds.mbname.setUIValue("");
        }
    }
    if (pv == "mtname") {
        ds.D07.setDisplay("none");
        ds.D14.setDisplay("none")
        ds.psize.setDisplay("none");
        ds.zsize.setDisplay("none");
        ds.slblname.setUIValue("");
        ds.slblcode.setUIValue("");
        ds.slblname.setUIValue("");
        ds.slblcode.setUIValue("");
        ds.mtbname.setUIValue("");
        ds.mtbcode.setUIValue("");
        ds.mtbcz.setUIValue("");
        ds.psize.setValue(0);
        ds.zsize.setValue(0);
        ds.psize.setLabelCaption("洞高");
        if (zjtype == "s") {
            ds.D07.setDisplay("block");
        }
        if (zjtype == "m") {
            ds.D14.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.plength.setLabelCaption("洞高");
            ds.psize.setLabelCaption("正面总高");
            ds.zsize.setLabelCaption("反面总高");
        }
        if (zjtype == "y") {
            ds.D14.setDisplay("block");
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.plength.setLabelCaption("洞高");
            ds.psize.setLabelCaption("正面总高");
            ds.zsize.setLabelCaption("反面总高");
        }
    }
    if (pv == "ctname") {
        if (zjtype == "c") {
            ds.psize.setDisplay("block");
            ds.zsize.setDisplay("block");
            ds.psize.setLabelCaption("横板总长");
            ds.zsize.setLabelCaption("横板总宽");
        }
        else {
            ds.psize.setDisplay("none");
            ds.zsize.setDisplay("none");
        }
        if (zjtype == "d") {
            ds.ykzcb.setDisplay("block");
            ds.ykycb.setDisplay("block");
            ds.ykscb.setDisplay("block");
            ds.ykacb.setDisplay("block");
            ds.ykhq.setDisplay("block");
        }
        else {
            ds.ykzcb.setDisplay("none");
            ds.ykycb.setDisplay("none");
            ds.ykscb.setDisplay("none");
            ds.ykacb.setDisplay("none");
            ds.ykhq.setDisplay("none");
            ds.ykzcb.setUIValue("");
            ds.ykycb.setUIValue("");
            ds.ykscb.setUIValue("");
            ds.ykacb.setUIValue("");
            ds.ykhq.setUIValue("");
        }
    }
}
function InitProduction() {
    ShowDiv("")
    ds.invcate.setUIValue("")
    ds.mbcode.setUIValue("");
    ds.mbname.setUIValue("");
    ds.mbfx.setUIValue("");
    ds.mbnum.setUIValue(0);
    ds.msjst.setUIValue("");
    ds.xxline.setUIValue("");
    ds.stype.setUIValue("");
    ds.blcode.setUIValue("");
    ds.blname.setUIValue("");
    ds.ctcode.setUIValue("");
    ds.ctname.setUIValue("");
    ds.cttbcz.setUIValue("");
    ds.ctlxcz.setUIValue("");
    ds.direction.setUIValue("");
    ds.fixed.setUIValue("");
    ds.pnum.setUIValue(1);
    ds.hjcode.setUIValue("");
    ds.hjcz.setUIValue("");
    ds.hjname.setUIValue("");
    ds.locktype.setUIValue("");
    ds.locks.setUIValue("");
    ds.mscode.setUIValue("");
    ds.mscz.setUIValue("");
    ds.ytcz.setUIValue("");
    ds.mbytcz.setUIValue("");
    ds.slytcz.setUIValue("");
    ds.msname.setUIValue("");
    ds.mtcode.setUIValue("");
    ds.zmsname.setUIValue("");
    ds.zmscode.setUIValue("");
    ds.mtcz.setUIValue("");
    ds.mtname.setUIValue("");
    ds.mttbcz.setUIValue("");
    ds.mtlxcz.setUIValue("");
    ds.mtname.setUIValue("");
    ds.pbz.setUIValue("");
    ds.pdeep.setUIValue("");
    ds.place.setUIValue("");
    ds.plength.setUIValue(0);
    ds.pnum.setUIValue(1);
    ds.psize.setUIValue(0);
    ds.zsize.setUIValue(0);
    ds.pwidth.setUIValue(0);
    ds.qtcode.setUIValue("");
    ds.qtcz.setUIValue("");
    ds.qtname.setUIValue("");
    ds.wjcode.setUIValue("");
    ds.wjname.setUIValue("");
    ds.ykcode.setUIValue("");
    ds.ykcz.setUIValue("");
    ds.ykname.setUIValue("");
    ds.isjc.setUIValue(false);
    ds.sktname.setUIValue();
    ds.sktcode.setUIValue();
    ds.sktcz.setUIValue("");
    ds.sktlx.setUIValue("");
    ds.slbname.setUIValue("");
    ds.slbcode.setUIValue("");
    ds.slgbnum.setUIValue(0);
    ds.msts.setUIValue("");
    ds.ykzt.setUIValue("");
    ds.ykyt.setUIValue("");
    ds.ydeep.setUIValue("");
    ds.ykacb.setUIValue("");
    ds.ykhjft.setUIValue("");
    ds.ykhjfw.setUIValue("");
    ds.ykscb.setUIValue("");
    ds.yksjft.setUIValue("");
    ds.yksjtw.setUIValue("");
    ds.ykycb.setUIValue("");
    ds.ykhq.setUIValue("");
    ds.ykzcb.setUIValue("");
    ds.cbjc.setUIValue("");
    ds.yksjtw.setUIValue("");
    ds.ykhjfw.setUIValue("");
    ds.fbtcz.setUIValue("");
    ds.ykzt.setUIValue("");
    ds.ykyt.setUIValue("");
    ds.pgdg.setUIValue("");
    ds.pgdk.setUIValue("");
    ds.pgdzmk.setUIValue("");
    LoadOrderAttr(sid);
}
//减尺垭口是否超宽超高
function CheckOverSize(hv, wv) {
    if (hv != 0) {
        var ykv = ds.ctcode.getUIValue()
        if (ykv != "" && hv > 2400) {
            ds.yksjtw.setReadonly(false)
            ds.yksjft.setReadonly(false)
        }
        else {
            ds.yksjtw.setReadonly(true)
            ds.yksjft.setReadonly(true)
            ds.yksjtw.setUIValue("")
            ds.yksjft.setUIValue("")
        }
    }
    if (wv != 0) {
        if (ykv != "" && wv > 2800) {
            ds.ykhjfw.setReadonly(false)
            ds.ykhjft.setReadonly(false)
        }
        else {
            ds.ykhjfw.setReadonly(true)
            ds.ykhjft.setReadonly(true)
            ds.ykhjfw.setUIValue("")
            ds.ykhjft.setUIValue("")
        }
    }
}
//洞口规尺
function FormatHigh() {
    var sdt = ds.stype.getUIValue();
    var ssv = ds.plength.getUIValue();
    if (sdt == "" || sdt == 'nk' || sdt == 'dk') {
        var ln = NumberRounding(ssv);
        ds.plength.setUIValue(ln);
    }
}
function FormatWidth() {
    var sdt = ds.stype.getUIValue();
    var ssv = ds.pwidth.getUIValue();
    if (sdt == "" || sdt == 'ng' || sdt == 'dk') {
        var ln = NumberRounding(ssv);
        ds.pwidth.setUIValue(ln);
    }
}
function FormatDeep() {
    var sdt = ds.stype.getUIValue();
    var ssv = ds.pdeep.getUIValue();
    if (sdt == "") {
        var ln = NumberFiveZero(ssv);
        ds.pdeep.setUIValue(ln);
    }
}
function ClearFormat() {
    ds.pdeep.onChange("")
    ds.pwidth.onChange("")
    ds.plength.onChange("")
}
function OnFormat() {
    ds.pdeep.onChange("_pdeep_onchange")
    ds.pwidth.onChange("_pwidth_onchange")
    ds.plength.onChange("_plength_onchange")
}
function CheckHj(v) {
    //    if (v.substr(0, 14) == "00010001009005") {
    //        ds.D11.setDisplay("block");
    //    }
    //    else {
    //        ds.D11.setDisplay("none");
    //    }
}
function CheckYkQ(v) {
    if (v == "1") {
        ds.pdeep.setLabelCaption("左侧墙厚")
        ds.ydeep.setDisplay("block")
    }
    else {
        ds.pdeep.setLabelCaption("洞口")
        ds.ydeep.setDisplay("none")
    }
}
function CheckMtZsb(v) {
    if (mtzsbobj.IMtZsbCheck(v) == 1) {
        ds.sktname.setDisplay("block");
        ds.sktcode.setDisplay("block");
        ds.sktcz.setDisplay("block");
    }
    else {
        ds.sktname.setDisplay("none");
        ds.sktcode.setDisplay("none");
        ds.sktcz.setDisplay("none");
        ds.sktname.setUIValue("");
        ds.sktcode.setUIValue("");
        ds.sktcz.setUIValue("");
    }
}