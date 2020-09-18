Class('App.DesignPlanDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(160)
                .setTop(180)
                .setWidth(780)
                .setHeight(330)
                .setCaption("设计方案")
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
                .setCaption("*设计方案")
                .setFontSize("16px")
                .setFontWeight("2em")
                .setCustomStyle({ "KEY": "color:#666666" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(158)
                .setTop(150)
                .setWidth(422)
                .setHeight(30)
                .setHtml("<form id='upform' enctype='multipart/form-data'><input type='file' name='dfile' id='dfile'  accept='aplication/zip'  style='height:28px; width:420px'/></form>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(110)
                .setTop(160)
                .setCaption("文&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(100)
                .setTop(30)
                .setWidth(480)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("方案名称")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fplace")
                .setLeft(100)
                .setTop(70)
                .setWidth(480)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("位&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;置")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fnum")
                .setLeft(100)
                .setTop(110)
                .setWidth(480)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("图纸数量")
            );

            host.pfj.append(
                (new linb.UI.ProgressBar)
                .setHost(host, "uprogress")
                .setLeft(110)
                .setTop(210)
                .setWidth(470)
                .setDisplay("none")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            dtype = "";
            ds = this;
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var  uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ds.fname, true, "", "请输入方案名称！", "", "", "", "")) {
                    return
                }
                if (!CheckInput(ds, ds.fnum, true, "number", "请输图纸梳理！", "", "", "", "")) {
                    return
                }
                var fname = ds.fname.getUIValue();
                var fplace = ds.fplace.getUIValue();
                var pnum = ds.fnum.getUIValue();
                var bufobj = BigUpFile;
                ds.uprogress.setDisplay("block")
                bufobj.url = "../../../UIServer/CommonFile/BUpDesignPlan.ashx?sid=" + sid + "&fname=" + fname + "&fplace=" + fplace + "&pnum=" + pnum + "&ptype=" + ns.dtype + "";
                bufobj.ufile = $("#dfile")[0].files[0];
                bufobj.upload(ds.uprogress, 0, ds.cdlg, "CloseDlg()");
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none");
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function CloseDlg() {
    window.location.href = window.location.href;
}