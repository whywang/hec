Class('App.DesignRequestDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(180)
                .setWidth(780)
                .setHeight(471)
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
                .setHost(host, "pfj")
                .setDock("fill")
                .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "fjbox")
                .setLeft(120)
                .setTop(330)
                .setWidth(580)
                .setHeight(30)
                .setHtml("<form id='upform' enctype='multipart/form-data'><input type='file' name='dfile' id='dfile'  accept='aplication/zip'  style='height:28px; width:420px'/></form>")
            );

            host.pfj.append(
                (new linb.UI.SLabel)
                .setHost(host, "fjwj")
                .setLeft(120)
                .setTop(310)
                .setCaption("<span style='color:#666666;font-size:14px'>方案文件</span>")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setLeft(420)
                .setTop(30)
                .setWidth(280)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>文件名称</span>")
                .setLabelHAlign("left")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "fplace")
                .setLeft(120)
                .setTop(30)
                .setWidth(270)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>位置</span>")
                .setLabelHAlign("left")
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "drequst")
                .setLeft(120)
                .setTop(90)
                .setWidth(580)
                .setHeight(100)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>设计要求</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pfj.append(
                (new linb.UI.Input)
                .setHost(host, "dremark")
                .setLeft(120)
                .setTop(200)
                .setWidth(580)
                .setHeight(100)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='color:#666666;font-size:14px'>设计说明</span>")
                .setLabelHAlign("left")
                .setMultiLines(true)
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "pxq")
                .setLeft(10)
                .setTop(20)
                .setWidth(90)
                .setHeight(60)
                .setCustomStyle({ "KEY": "border-radius:5px; background:#eeeeee" })
            );

            host.pxq.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setDock("center")
                .setLeft(20)
                .setTop(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666;font-family:汉仪细中圆简'>方案需求<span>")
            );

            host.pfj.append(
                (new linb.UI.ProgressBar)
                .setHost(host, "uprogress")
                .setLeft(120)
                .setTop(370)
                .setWidth(580)
                .setDisplay("none")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                if (!CheckInput(ds, ns.fname, true, "", "请输入方案名称！", "", "", "", "")) {
                    return
                }
                var fname = ds.fname.getUIValue();
                var fplace = ds.fplace.getUIValue();
                var fdrq = ds.drequst.getUIValue();
                var fdrk = ds.dremark.getUIValue();
                var bufobj = BigUpFile;
                ds.uprogress.setDisplay("block")
                bufobj.url = "../../../UIServer/CommonFile/BUpRequestDesign.ashx?sid=" + sid + "&fname=" + fname + "&fplace=" + fplace + "&fdrq=" + fdrq + "&fdrk=" + fdrk + "";
                bufobj.ufile = $("#dfile")[0].files[0];
                bufobj.upload(ds.uprogress, 0, ds.cdlg, "");
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