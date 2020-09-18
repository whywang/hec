Class('App.AfterProductionImgDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "sdlg")
                .setDock("center")
                .setTop(170)
                .setWidth(690)
                .setCaption("返修产品图")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.sdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pfj")
                .setDock("width")
                .setTop(0)
                .setHeight(120)
                .setCustomStyle({ "KEY": "background:#ffffff; border-bottom:5px solid #f2f2f2" })
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "upbox")
                .setLeft(150)
                .setTop(20)
                .setWidth(100)
                .setHeight(100)
                .setHtml("<div  style='background:url(../../../Image/opeimage/addimg.png); width:83px; height:83px'><a href='javascript:;' ></a><input type='file' name='ifile' id='ifile' multiple accept='image/*'  style='opacity: 0;z-index: 10;position: absolute;top: 0;left: 0;height: 80px;width: 100%;'/></div>")
            );

            host.pfj.append(
                (new linb.UI.Pane)
                .setHost(host, "pbj")
                .setLeft(20)
                .setTop(20)
                .setWidth(110)
                .setHeight(90)
                .setCustomStyle({ "KEY": "background:#f2f2f2;border-radius:10px" })
            );

            host.pbj.append(
                (new linb.UI.SLabel)
                .setHost(host, "sl1")
                .setDock("center")
                .setLeft(20)
                .setTop(40)
                .setCaption("<span style='font-size:16px;font-weight:bolder;color:#666666'>返修产品图</span>")
            );

            host.sdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "pml")
                .setDock("bottom")
                .setHeight(119)
                .setCustomStyle({ "KEY": "list-style:none" })
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.sdlg.show();
            ds = this;
            QueryAfterProductionImgList()
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});

function QueryAfterProductionImgList() {
    var o = { "sid": sid,"gnum":agnum }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/QueryAfterProductionImgHtm';
    var b = AjaxExb(url, o);
    ds.pml.setHtml(b)
}
$("#ifile").live('change', function () {
    var url = "../../../UIServer/CommonFile/UpAfterProductionImg.aspx?sid=" + sid + "&gnum=" + agnum + "";
    UpFile(null, "ifile", url, "QueryAfterProductionImgList()");
})

function DelImg(id) {
    var o = { "id": id }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/DelAfterProductionImg';
    var b = AjaxExb(url, o);
    BackVad(b, "QueryAfterProductionImgList()", false)
}