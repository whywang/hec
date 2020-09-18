Class('App.ProductionImgDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(200)
                .setWidth(550)
                .setHeight(190)
                .setCaption("产品图片")
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
                (new linb.UI.ComboInput)
                .setHost(host, "mtype")
                .setLeft(150)
                .setTop(40)
                .setWidth(300)
                .setHeight(45)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("<span style='font-size:14px;color:#666666'>图片类型</span>")
                .setLabelHAlign("left")
                .setType("listbox")
                .setItems([{ "id": "mt", "caption": "门图" }, { "id": "bt", "caption": "备注"}])
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "opn")
                .setLeft(20)
                .setTop(50)
                .setWidth(80)
                .setHeight(60)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:5px" })
            );

            host.opn.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(0)
                .setTop(20)
                .setWidth(64)
                .setHeight(20)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>产品图片</span>")
            );

            host.cdlg.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl2")
                .setLeft(150)
                .setTop(90)
                .setCaption("<span style='font-size:14px;color:#666666'>图纸</span>")
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "ppimg")
                .setLeft(150)
                .setTop(110)
                .setWidth(300)
                .setHeight(30)
                .setHtml("<input type='file' name='afile' id='afile'  accept='Image/*'  style='height:28px; width:300px'/>")

            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            ds.cdlg.setTop(ns.stv)
            delete ns.stv;
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            uictrl = profile.boxing();
            if (item.id == "a1") {
                var mtype = ds.mtype.getUIValue();
                if (!CheckInput(ds, ds.mtype, true, "", "请选择图片类型！", "", "", "")) {
                    return
                }
                var url = "../../../UIServer/CommonFile/UpProductionImg.aspx?sid=" + sid + "&gnum=" + ns.gnum + "&ptype=" + mtype + "";
                UpFile(null, "afile", url, ns.custfun);
                delete ns.gnum;
                delete ns.custfun;
                ds.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
