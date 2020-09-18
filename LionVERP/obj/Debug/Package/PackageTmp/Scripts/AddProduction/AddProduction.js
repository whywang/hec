function InitProductionShow() {
    ns.D01.setDisplay("none");
    ns.D02.setDisplay("none");
    ns.D03.setDisplay("none");
    ns.D04.setDisplay("none");
    ns.D05.setDisplay("none");
    ns.D06.setDisplay("none");
    ns.D07.setDisplay("none");
    ns.D08.setDisplay("none");
    ns.D09.setDisplay("none");
    ns.D10.setDisplay("none");
    ns.D11.setDisplay("none");
    ns.D12.setDisplay("none");
    ns.D13.setDisplay("none");
    ns.D14.setDisplay("none");
    ns.D15.setDisplay("none");
    ns.D16.setDisplay("none");
    ns.D17.setDisplay("none");
    ns.D18.setDisplay("none");
}

///产品空键显示
function ShowDiv(v) {
    ns.D01.setDisplay("none");
    ns.D02.setDisplay("none");
    ns.D03.setDisplay("none");
    ns.D04.setDisplay("none");
    ns.D05.setDisplay("none");
    ns.D06.setDisplay("none");
    ns.D07.setDisplay("none");
    ns.D08.setDisplay("none");
    ns.D09.setDisplay("none");
    ns.D10.setDisplay("none");
    ns.D11.setDisplay("none");
    ns.D12.setDisplay("none");
    ns.D13.setDisplay("none");
    ns.D14.setDisplay("none")
    ns.D15.setDisplay("none");
    ns.D16.setDisplay("none");
    ns.D17.setDisplay("none");
    ns.D18.setDisplay("none");
    ns.palist.clearItems();
    switch (v) {
        case "10":
            ns.D01.setDisplay("block");
            ns.D02.setDisplay("block");
            ns.D08.setDisplay("none");
            ns.D09.setDisplay("none");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("方");
            ns.plength.setLabelCaption("套外径高");
            ns.pwidth.setLabelCaption("套外径宽");
            ns.pdeep.setLabelCaption("套外径厚");
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            var jypj = ns.isjc.getUIValue();
            if (jypj == "静音配件孔") {
                ns.D17.setDisplay("block");
            }
            var smscode = ns.mscode.getUIValue();
            var smstode = ns.mtcode.getUIValue();
            if (smscode != "") {
                IinvCheckBoxList(smscode, ns.palist);
                if (IinvCheckBox(smscode, ns.palist)) {
                    ns.D18.setDisplay("block");
                }
            }
            if (smstode != "") {
                IinvCheckBoxList(smstode, ns.palist);
                if (IinvCheckBox(smtcode, ns.palist)) {
                    ns.D18.setDisplay("block");
                }
            }
            break;
        case "01":
            ns.D01.setDisplay("block");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("方")
            ns.plength.setLabelCaption("门扇高度");
            ns.pwidth.setLabelCaption("门扇宽度");
            ns.pdeep.setLabelCaption("门扇厚度");
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            var smscode = ns.mscode.getUIValue();
            if (smscode != "") {
                IinvCheckBoxList(smscode, ns.palist);
                if (IinvCheckBox(smscode, ns.palist)) {
                    ns.D18.setDisplay("block");
                }
            }
            break;
        case "02":
            ns.D02.setDisplay("block");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.plength.setLabelCaption("套外径高");
            ns.pwidth.setLabelCaption("套外径宽");
            ns.pdeep.setLabelCaption("套外径厚");
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            var smtcode = ns.mtcode.getUIValue();
            if (smtcode != "") {
                IinvCheckBoxList(smtcode, ns.palist);
                if (IinvCheckBox(smtcode, ns.palist)) {
                    ns.D18.setDisplay("block");
                }
            }
            break;
        case "06":
            ns.D03.setDisplay("block");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.plength.setLabelCaption("套外径高");
            ns.pwidth.setLabelCaption("套外径宽");
            ns.pdeep.setLabelCaption("套外径厚");
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            var sctcode = ns.ctcode.getUIValue();
            if (sctcode != "") {
                IinvCheckBoxList(sctcode, ns.palist);
                if (IinvCheckBox(sctcode, ns.palist)) {
                    ns.D18.setDisplay("block");
                }
            }
            break;
        case "07":
            ns.D04.setDisplay("block");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.plength.setLabelCaption("套外径高");
            ns.pwidth.setLabelCaption("套外径宽");
            ns.pdeep.setLabelCaption("套外径厚");
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            var sykcode = ns.ykcode.getUIValue();
            if (sykcode != "") {
                IinvCheckBoxList(sykcode, ns.palist);
                if (IinvCheckBox(sykcode, ns.palist)) {
                    ns.D18.setDisplay("block");
                }
            }
            break;
        case "04":
            ns.D05.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            break;
        case "05":
            ns.D06.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.mscode.setValue();
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            break;
        case "09":
            ns.D10.setDisplay("block");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            break;
        case "08":
            ns.D13.setDisplay("block");
            ns.D11.setDisplay("block");
            ns.D12.setDisplay("block");
            ns.locktype.setValue("无")
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            break;
    }
}
///校验产品材质
function CheckCz() {
    var r = true;
    switch (selinv) {
        case "msname":
            r = CheckInput(ns, ns.mscz, true, "", "选择产品材质", "", "", "");
            selczv = ns.mscz.getUIValue()
            break;
        case "mtname":
            r = CheckInput(ns, ns.mtcz, true, "", "选择产品材质", "", "", "");
            selczv = ns.mtcz.getUIValue()
            break;
        case "mtbname":
            r = CheckInput(ns, ns.mtbcz, true, "", "选择产品材质", "", "", "");
            selczv = ns.mtbcz.getUIValue()
            break;
        case "ctname":
            r = CheckInput(ns, ns.ctcz, true, "", "选择产品材质", "", "", "");
            selczv = ns.ctcz.getUIValue()
            break;
        case "ykname":
            r = CheckInput(ns, ns.ykcz, true, "", "选择产品材质", "", "", "");
            selczv = ns.ykcz.getUIValue()
            break;
        case "hjname":
            r = CheckInput(ns, ns.hjcz, true, "", "选择产品材质", "", "", "");
            selczv = ns.hjcz.getUIValue()
            break;
        case "qtname":
           // r = CheckInput(ns, ns.qtcz, true, "", "选择产品材质", "", "", "");
            selczv = ns.qtcz.getUIValue()
            break;
        default :
            selczv = ""
            break;
    }
    return r;
}
///设置选中产品
function InvSetValue(r) {
    var splv = ns.invcate.getUIValue();
    var rname = r.cells[0].value;
    var rcode = r.cells[1].value;
    var rcz = r.cells[2].value;
    var locks=ns.locks.getUIValue();
    var zjtype = "";
    RefProductionSize(rcode)
    var remarks = InvRemarkCheck(rcode) 
    switch (selinv) {
        case "msname":
            ns.msname.setValue(rname)
            ns.mscode.setValue(rcode)
            if (sinvclass == "10") {
                RefMt(rcode, rcz)
            }
            zjtype = InvComponentCheck(rcode)
            if (zjtype == "b") {
                ns.D06.setDisplay("block")
            }
            else {
                ns.D06.setDisplay("none")
                ns.blcode.setValue("");
                ns.blname.setValue(""); 
            }
            break;
        case "mtname":
            ns.mtname.setValue(rname)
            ns.mtcode.setValue(rcode)
            zjtype = InvComponentCheck(rcode)
            ns.slblname.setValue("");
            ns.slblcode.setValue("");
            ns.D07.setDisplay("none");
            ns.D14.setDisplay("none")
            ns.psize.setDisplay("none");
            ns.zsize.setDisplay("none");
            ns.slblname.setValue("");
            ns.slblcode.setValue("");
            ns.mtbname.setValue("");
            ns.mtbcode.setValue("");
            ns.mtbcz.setValue("");
            ns.psize.setValue(0);
            ns.zsize.setValue(0);
            ns.psize.setLabelCaption("外径1高");
            if (zjtype == "s") {
                ns.D07.setDisplay("block");
                ns.psize.setDisplay("block");
                ns.psize.setLabelCaption("门高");
            }
            if (zjtype == "m") {
                ns.D14.setDisplay("block");
                ns.psize.setDisplay("block");
                ns.plength.setLabelCaption("门高");
            }
            if (zjtype == "y") {
                ns.D14.setDisplay("block");
                ns.psize.setDisplay("block");
                ns.zsize.setDisplay("block");
                ns.plength.setLabelCaption("门洞高");
            }
            //推拉门套时显示轨道和吊轮
            if (splv == "10") {
                if (rcode.substr(0, 4) == "0204" || rcode.substr(0, 4) == "0205") {
                    ns.D15.setDisplay("block");
                    ns.D16.setDisplay("block");
                    ns.D08.setDisplay("none");
                    ns.D09.setDisplay("none");
                }
                else {
                    ns.D15.setDisplay("none");
                    ns.D16.setDisplay("none");
                    if (locks.toString() == "开快递锁孔-锁体随货返回" || locks.toString() == "自备不开锁孔") {
                        ns.D08.setDisplay("none");
                    }
                    else {
                        ns.D08.setDisplay("none");
                    }
                    ns.D09.setDisplay("none");
                    ns.gdname.setValue("")
                    ns.gdcode.setValue("")
                    ns.dlname.setValue("")
                    ns.dlcode.setValue("")
                    ns.hynum.setValue(3)
                }
            }
            break;
        case "ctname":
            ns.ctname.setValue(rname)
            ns.ctcode.setValue(rcode)
            break;
        case "ykname":
            ns.ykname.setValue(rname)
            ns.ykcode.setValue(rcode)
            break;
        case "hjname":
            ns.hjname.setValue(rname)
            ns.hjcode.setValue(rcode);
            ns.plength.setLabelCaption("高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
            ns.pwidth.setLabelCaption("宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度")
            ns.pdeep.setLabelCaption("厚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
            break;
        case "qtname":
            ns.qtname.setValue(rname)
            ns.qtcode.setValue(rcode)
            if (rcode.substr(0, 4) == "0925") {
                ns.plength.setLabelCaption("高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
                ns.pwidth.setLabelCaption("宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度")
                ns.pdeep.setDisplay("none");
            }
            else {
                ns.plength.setLabelCaption("高&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
                ns.pwidth.setLabelCaption("宽&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度")
                ns.pdeep.setLabelCaption("厚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度");
                ns.pdeep.setDisplay("block");
            }
            break;
        case "wjname":
            ns.wjname.setValue(rname)
            ns.wjcode.setValue(rcode)
            break;
        case "hyname":
            ns.hyname.setValue(rname)
            ns.hycode.setValue(rcode)
            break;
        case "sjname":
            ns.sjname.setValue(rname)
            ns.sjcode.setValue(rcode)
            break;
        case "jyname":
            ns.jyname.setValue(rname)
            ns.jycode.setValue(rcode)
            break;
        case "blname":
            ns.blname.setValue(rname)
            ns.blcode.setValue(rcode)
            break;
        case "slblname":
            ns.slblname.setValue(rname)
            ns.slblcode.setValue(rcode)
            break;
        case "mtbname":
            ns.mtbname.setValue(rname)
            ns.mtbcode.setValue(rcode)
            break;
        case "gdname":
            ns.gdname.setValue(rname)
            ns.gdcode.setValue(rcode)
            break;
        case "dlname":
            ns.dlname.setValue(rname)
            ns.dlcode.setValue(rcode)
            break;
    }
    if (remarks) {
        ns.pbz.setValue(remarks)
    }
    IinvCheckBoxList(rcode, ns.palist);
    if (IinvCheckBox(rcode, ns.palist)) {
        ns.D18.setDisplay("block");
    }
    return r;
}
///获取当前产品类型
function InvSetCate() {
    var smscode = ns.mscode.getUIValue();
    switch (selinv) {
        case "msname":
            ICzinvItems(selczv, invcate+"01", ns.invtreebar)
            break;
        case "mtname":
            ICzinvItems(selczv, invcate + "02", ns.invtreebar)
            break;
        case "ctname":
            ICzinvItems(selczv, invcate + "06", ns.invtreebar)
            break;
        case "ykname":
            ICzinvItems(selczv, invcate + "07", ns.invtreebar)
            break;
        case "qtname":
            ICzinvItems(selczv, invcate + "09", ns.invtreebar)
            break;
        case "wjname":
            ICzinvItems("", invcate + "04", ns.invtreebar)
            break;
        case "hyname":
            ICzinvItems("", invcate + "0407", ns.invtreebar)
            break;
        case "sjname":
            ICzinvItems("", invcate + "0401", ns.invtreebar)
            break;
        case "jyname":
            ICzinvItems("", invcate + "0423", ns.invtreebar)
            break;
        case "blname":
            if (smscode != "" && smscode != null) {
                IMsinvCzItems(smscode, invcate + "05", ns.invtreebar)
            }
            else {
                ICzinvItems("", invcate + "05", ns.invtreebar)
            }
            break;
        case "slblname":
            ICzinvItems("", invcate + "0911", ns.invtreebar)
            break;
        case "mtbname":
            ICzinvItems(selczv, invcate + "0906", ns.invtreebar)
            break;
        case "hjname":
            ICzinvItems(selczv, invcate + "08", ns.invtreebar)
            break;
        case "gdname":
            ICzinvItems("", invcate + "0419", ns.invtreebar)
            break;
        case "dlname":
            ICzinvItems("", invcate + "0420", ns.invtreebar)
            break;
    }
}
///获取组件类别
//function InvSetZj() {
//    switch (selinv) {
//        case "mtbname":
//           var mtcode=ns.mtcode.getUIValue();
//            ICzZjItems(selczv,mtcode, ns.zjtreegrid)
//            break;
//        case "slblname":
//            var mtcode = ns.mtcode.getUIValue();
//            ICzZjItems(selczv, mtcode, ns.zjtreegrid)
//            break;
//    }
//}
///加载订单属性 材质
function LoadOrderAttr(sid) {
    var url = '../../../UIServer/SalesBusiness/DistributorOrder/SaleOrder.aspx/LoadSaleOrder'
    var o = { "sid": sid };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        if (r.sid != "") {
            //材质
            ns.mscz.setValue(r.mname)
            ns.mtcz.setValue(r.mname)
            ns.ctcz.setValue(r.mname)
            ns.ykcz.setValue(r.mname)
            ns.mtbcz.setValue(r.mname)
            ns.hjcz.setValue(r.mname)

            //楼层
            ns.floor.setValue(r.floor)
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
            ns.mscz.setValue(r.mname)
            ns.mtcz.setValue(r.mname)
            ns.ctcz.setValue(r.mname)
            ns.ykcz.setValue(r.mname)
            //ns.qtcz.setValue(r.mname)
            ns.hjcz.setValue(r.mname)
            //楼层
            ns.floor.setValue(r.floor)
        }
        else {
        }
    }
}
///获取选中门扇管理联门套
function RefMt(msv, czv) {
    var o = { "invcode": msv,"mname":czv }
    var url = "../../../UIServer/ProductionSet/AssortManage/Assorts.aspx/GetRefInv"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ns.mtname.setValue(r.icname);
        ns.mtcode.setValue(r.icode);
    }
}
///保存产品是进行校验
function SaveProductionCheck() {
    //获取尺寸进行尺寸限制检测
    var hv=ns.plength.getUIValue();
    var wv=ns.pwidth.getUIValue();
    var dv=ns.pdeep.getUIValue();
    var fv = ns.psize.getUIValue();
    if (!CheckInput(ns, ns.invcate, true, "", "请选择类别", "", "", "")) {
        return false;
    }
    if (!CheckInput(ns, ns.place, true, "", "请输入位置", "", "", "")) {
        return false;
    }
    if (!CheckInput(ns, ns.pnum, true, "number", "请输入产品数量", "正确输入产品数量", "0", "9999")) {
        return false;
    }
    if (sinvclass == "10") {
        if (!CheckInput(ns, ns.direction, true, "", "请选择开向", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.locktype, true, "", "请选择锁具类型", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.msname, true, "", "请选择门扇", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.mtname, true, "", "请选择门套", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.locks, true, "", "请选择锁孔", "", "", "")) {
            return false;
        }
//        if (!CheckInput(ns, ns.hyname, true, "", "请选择合页", "", "", "")) {
//            return false;
//        }
        if (ns.D06.getDisplay() == "block") {
            if (!CheckInput(ns, ns.blname, true, "", "请选择玻璃", "", "", "")) {
                return false;
            }
        }
        var mtv = ns.mtcode.getUIValue();
        if (!CheckLimited(mtv, hv, wv, dv, fv)) {
            return false;
        }
    }
    if (sinvclass == "01") {
        if (!CheckInput(ns, ns.direction, true, "", "请选择开向", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.locktype, true, "", "请选择合页", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.msname, true, "", "请选择门扇", "", "", "")) {
            return false;
        }
        if (!CheckInput(ns, ns.locks, true, "", "请选择锁孔", "", "", "")) {
            return false;
        }
        if (ns.D06.getDisplay() == "block") {
            if (!CheckInput(ns, ns.blname, true, "", "请选择玻璃", "", "", "")) {
                return false;
            }
        }
        
    }
    if (sinvclass == "02") {
        if (!CheckInput(ns, ns.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }

        if (!CheckInput(ns, ns.mtname, true, "", "请选择门套", "", "", "")) {
            return false;
        }
        var mtv = ns.mtcode.getUIValue();
        if (!CheckLimited(mtv, hv, wv, dv, fv)) {
            return false;
        }
    }
    if (sinvclass == "06") {
        if (!CheckInput(ns, ns.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }

        if (!CheckInput(ns, ns.ctname, true, "", "请选择窗套", "", "", "")) {
            return false;
        }
    }
    if (sinvclass == "07") {
        if (!CheckInput(ns, ns.fixed, true, "", "请选择安装方式", "", "", "")) {
            return false;
        }

        if (!CheckInput(ns, ns.ykname, true, "", "请选择垭口", "", "", "")) {
            return false;
        }
    }
    return true;
}
///保存产品
function SaveProduction() {
    if (SaveProductionCheck()) {
        var isend = ns.isend.getUIValue();
        var arg1 = { "sid": sid, "gnum": gnum }
        var db = linb.DataBinder.getFromName("binder");
        var arg2 = db.updateDataFromUI().getData();
        var o = $.extend(arg1, arg2);
        var url = preurl + '/SaveProduction';
        var b = AjaxExb(url, o);
        if (isNum(b)) {
            alert("操作成功");
            window.location.href = "AddSaleProdutionCheckSize.htm?Sid=" + sid + "&Gnum=" + b + "&End=" + isend;
        }
        else {
            alert("操作失败")
        }
    }
    else {
        return;
    }

}
///获取产品固定尺寸
function RefProductionSize(v) {
    var o = { "icode": v}
    var url = "../../../UIServer/CommonFile/RefNomalSize.aspx/RefNSize"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        ns.plength.setValue(r.ng);
        ns.pwidth.setValue(r.nk);
        ns.pdeep.setValue(r.nh);
        ns.psize.setValue(r.nf);
    }
}
//检测产品属性
function CheckInvAttr(v,msv,mtv,ctv,ykv) {
    
    switch (v) {
        case "10":
            IinvCheckBoxList(msv, ns.palist);
            if (IinvCheckBox(msv, ns.palist)) {
                ns.D18.setDisplay("block");
            }
            IinvCheckBoxList(mtv, ns.palist);
            if (IinvCheckBox(mtv, ns.palist)) {
                ns.D18.setDisplay("block");
            }
            break;
        case "01":
            IinvCheckBoxList(msv, ns.palist);
            if (IinvCheckBox(msv, ns.palist)) {
                ns.D18.setDisplay("block");
            }
            break;
        case "02":
            IinvCheckBoxList(mtv, ns.palist);
            if (IinvCheckBox(mtv, ns.palist)) {
                ns.D18.setDisplay("block");
            }
            break;
        case "06":
            IinvCheckBoxList(ctv, ns.palist);
            if (IinvCheckBox(ctv, ns.palist)) {
                ns.D18.setDisplay("block");
            }
            break;
        case "07":
            IinvCheckBoxList(ytv, ns.palist);
            if (IinvCheckBox(ytv, ns.palist)) {
                ns.D18.setDisplay("block");
            }
            break;
    }
}