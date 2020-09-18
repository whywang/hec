//产品属性设置
function ShowSetDlg() {
    var n = SetFlag;
    var dtitle = "";
    var svc = ns.lbtreebar.getUIValue();
    if (svc == null || svc == "") {
        svc = "";
    }
    ns.streegrid.removeAllRows();
    switch (n) {
        case 0:
            ns.streegrid.setHeader([{ "caption": "减尺名称", "width": 140 }, { "caption": "减尺编码", "width": 120 }, { "caption": "减尺类型", "width": 100}])
            IJcTable(ns.streegrid);
            dtitle = "减尺设置";
            IinvItems(svc, ns.sitreebar)
            break;
        case 1:
            dtitle = "标准尺寸设置";
            ns.streegrid.setHeader([{ "caption": "名称", "width": 140 }, { "caption": "编码", "width": 120 }, { "caption": "类型", "width": 100}])
            IinvItems(svc, ns.sitreebar)
            InomalsizeList(ns.streegrid)
            break;
        case 2:
            dtitle = "备注设置";
            ns.streegrid.setHeader([{ "caption": "名称", "width": 140 }, { "caption": "内容", "width": 120 }, { "caption": "类型", "width": 100}])
            IinvItems(svc, ns.sitreebar)
            Iremarkslist(ns.streegrid)
            break;
        case 3:
            dtitle = "计算公式设置";
            ns.streegrid.setHeader([{ "caption": "名称", "width": 140 }, { "caption": "体系", "width": 120 }, { "caption": "类型", "width": 100}])
            IinvItems(svc, ns.sitreebar)
            Icmlist(ns.streegrid)
            break;
        case 4:
            ns.streegrid.setHeader([{ "caption": "名称", "width": 140 }, { "caption": "体系", "width": 120 }, { "caption": "类型", "width": 100}])
            IinvItems(svc, ns.sitreebar)
            Iocm(ns.streegrid)
            dtitle = "超标公式设置";
            break;
        case 5:
            ns.streegrid.setHeader([{ "caption": "名称", "width": 140 }, { "caption": "图片", "width": 120}])
            IinvItems(svc, ns.sitreebar)
            dtitle = "图片设置";
            Iimglist(ns.streegrid)
            break;
        case 6:
            ns.sdlg.setDisplay("none")
            ns.bzdlg.setDisplay("block")
            dtitle = "包装设置";
            IPackageItems(ns.bztreebar)
            IinvItems(svc, ns.bzitreebar)
            break;
        case 7:
            SetFlag = 0;
            ns.bzdlg.setDisplay("none")
            break;
    }
    ns.sdlg.setCaption(dtitle)
    ns.bzdlg.setCaption(dtitle)
}
//-----------
//产品属性设置
function ProductionAttrSet() {
    var svp= ns.sitreebar.getUIValue();
    var sav = ns.streegrid.getUIValue();
    var bsvp = ns.bzitreebar.getUIValue();
    var bsav = ns.bztreebar.getUIValue();
    var bsvpp = ns.bzitreegrid.getUIValue();
    var n = SetFlag;
    switch (n) {
        case 0:
            if (CheckVal(svp, sav, "选择减尺")) {
                SetProductionJc(svp, sav);
            }
            break;
        case 1:
            if (CheckVal(svp, sav, "选择标准尺寸")) {
                SetProductionNs(svp, sav);
            }
            break;
        case 2:
            if (CheckVal(svp, sav, "选择备注")) {
                SetProductionRemark(svp, sav);
            }
            break;
        case 3:
            if (CheckVal(svp, sav, "选择计算公式")) {
                SetProductionCm(svp, sav);
            }
            break;
        case 4:
            if (CheckVal(svp, sav, "选择超标计算公式")) {
                SetProductionOcm(svp, sav);
            }
            break;
        case 5:
            if (CheckVal(svp, sav, "选择产品图片")) {
                SetProductionImg(svp, sav);
            }
            break;
        case 6:
            if (CheckVal(bsvp, bsav, "选择包装规则")) {
                SetPackProduction(bsav, bsvp, bsvpp);
            }
            break;
    }
}
function CheckVal(pcv,atrv, tipv) {
 
    if (atrv == "" || atrv == null) {
        linb.message(tipv)
        return false;
    }
    if (pcv == "" || pcv == null) {
        linb.message("选择产品")
        return false;
    }
    return true;
}
function ReCheckVal(pcv ) {
    if (pcv == "" || pcv == null) {
        linb.message("选择产品")
        return false;
    }
    return true;
}
//产品属性重置
function ProductionAttrReSet() {
    var svp = ns.sitreebar.getUIValue();
    var bsvp = ns.bzitreebar.getUIValue();
    var bsav = ns.bztreebar.getUIValue();
    var n = SetFlag;
    switch (n) {
        case 0:
            if (ReCheckVal(svp)) {
                ReSetProductionJc(svp);
            }
            break;
        case 1:
            if (ReCheckVal(svp)) {
                ReSetProductionNs(svp);
            }
            break;
        case 2:
            if (ReCheckVal(svp)) {
                ReSetProductionRemark(svp);
            }
            break;
        case 3:
            if (ReCheckVal(svp)) {
                ReSetProductionCm(svp);
            }
            break;
        case 4:
            if (ReCheckVal(svp)) {
                ReSetProductionOcm(svp);
            }
            break;
        case 5:
            if (ReCheckVal(svp)) {
                ReSetProductionImg(svp);
            }
            break;
        case 6:
            if (ReCheckVal(bsvp)) {
                ReSetPackProduction(bsav, bsvp);
            }
            break;
    }
}
//获取产品属性
function ProductionAttrGet() {
    var svp = ns.sitreebar.getUIValue();
    var sav = ns.streegrid.getUIValue();
    var bsvp = ns.bzitreebar.getUIValue();
    var bsav = ns.bztreebar.getUIValue();
    var n = SetFlag;
    switch (n) {
        case 0:
            GetProductionJc(svp, ns.streegrid);
            break;
        case 1:
            GetProductionNs(svp, ns.streegrid);
            break;
        case 2:
            GetProductionRemark(svp, ns.streegrid);
            break;
        case 3:
            GetProductionCm(svp, ns.streegrid);
            break;
        case 4:
            GetProductionOcm(svp, ns.streegrid);
            break;
        case 5:
            GetProductionImg(svp, ns.streegrid);
            break;
        case 6:
            GetPackProduction(bsav, bsvp, ns.bzitreegrid);
            break;
    }
}

