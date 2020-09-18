Class('App.RequestDesignPlanDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(150)
                .setTop(190)
                .setWidth(698)
                .setHeight(510)
                .setCaption("设计需求")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pcol1")
                .setDock("top")
                .setHeight(3)
                .setCustomStyle({ "KEY": "background:#a8e0e2" })
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Label)
                .setHost(host, "s1")
                .setLeft(20)
                .setTop(10)
                .setWidth(80)
                .setCaption("*设计需求")
                .setFontSize("16px")
                .setFontWeight("2em")
                .setCustomStyle({ "KEY": "color:#666666" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(138)
                .setTop(100)
                .setWidth(430)
                .setHeight(30)
                .setHtml("<input type='file' name='ffile' id='ffile'  accept='aplication/zip'  style='height:28px; width:420px'/>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fawj")
                .setLeft(90)
                .setTop(110)
                .setCaption("文&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "pplace")
                .setLeft(80)
                .setTop(50)
                .setWidth(480)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("位&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;置")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "prequest")
                .setLeft(80)
                .setTop(150)
                .setWidth(480)
                .setHeight(120)
                .setLabelSize(60)
                .setLabelCaption("设计要求")
                .setMultiLines(true)
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "pdemo")
                .setLeft(80)
                .setTop(290)
                .setWidth(480)
                .setHeight(120)
                .setLabelSize(60)
                .setLabelCaption("方案描述")
                .setMultiLines(true)
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ns = this;
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ns, ns.pplace, true, "", "请输入方案位置！", "", "", "", "")) {
                    return
                }
                var pplace = ns.pplace.getUIValue();
                var prequest = ns.prequest.getUIValue()
                var pdemo = ns.pdemo.getUIValue()
                var url = "../../../UIServer/MzSaleBusiness/DistributorMzSale/UpRequestPlan.aspx?sid=" + sid + "&place=" + pplace + "&preqest=" + prequest + "&pdemo=" + pdemo + "";
                UpFile(null, "ffile", url, "CloseDlg();");
                ns.cdlg.setDisplay("none");


            }
            if (item.id == "a3") {
                ns.cdlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function CloseDlg() {
    window.location.href=window.location.href
}