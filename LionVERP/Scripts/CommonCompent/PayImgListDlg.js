Class('App.PayImgListDlg', 'linb.Com', {
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
                    .setWidth(780)
                    .setHeight(450)
                    .setCaption("付款凭证")
                    .setMinBtn(false)
                    .setMaxBtn(false)
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
                    .setDock("top")
                    .setHeight(47)
                    .setCustomStyle({ "KEY": "background:#ffffff" })
            );

            host.pfj.append(
                (new linb.UI.Label)
                    .setHost(host, "s1")
                    .setLeft(20)
                    .setTop(10)
                    .setWidth(100)
                    .setCaption("支付凭证")
                    .setFontSize("20px")
                    .setFontWeight("bolder")
                    .setCustomStyle({ "KEY": "color:#666666" })
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                    .setHost(host, "pml")
                    .setDock("top")
                    .setHeight("auto")
                    .setCustomStyle({ "KEY": "background:#ffffff" })
                    .setCustomClass({ "KEY": "ils" })
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            cn = this;
            QueryListImg();
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});


function QueryListImg() {
    var showhtm = "";
    var o = { "sid": sid ,'ptype':"dd"}
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryPayImgList';
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false);
    if (r) {
        showhtm = showhtm + "<table id='ilist'>";
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            showhtm = showhtm + "<tr><td width='40' height='30' align='center'>序号</td><td width='50' align='center'>"+i+"</td>"
            showhtm = showhtm + "<td width='40' align='center'>说明</td><td width='220' align='left'>"+cel[2]+"</td></tr>";
            showhtm = showhtm +"<tr><td height='100' colspan='4'>"+cel[1]+"</td></tr>";
        }
        showhtm = showhtm + "</table>";
        cn.pml.setHtml(showhtm);
    }
}
