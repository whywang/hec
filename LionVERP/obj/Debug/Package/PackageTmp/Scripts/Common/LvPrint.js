var LODOP;
function Print(id) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("预览");
    var strBodyStyle = "<style> Table{border-collapse:collapse;border:2px solid #666666;}   td{border:1px solid #333333;height:25px;}</style>";
    var strFormHtml = strBodyStyle + "<body>" + document.getElementById(id).innerHTML + "</body>";
    LODOP.SET_PRINT_PAGESIZE(2, 0, 0, "");
    LODOP.SET_PRINT_MODE("POS_BASEON_PAPER", true);
    LODOP.ADD_PRINT_TABLE("20px", "20px", "100%", "100%", strFormHtml);
    LODOP.SET_PRINT_STYLEA(0, "TableHeightScope", 1);
    LODOP.ADD_PRINT_HTM(705, 500, 100, 100, "<font style='font-size:20px;font-weight:bolder'  ><span tdata='pageNO'>第##页</span>/<span tdata='pageCount'>共##页</span></font>");
    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
    LODOP.PREVIEW();
}
function PrintEx(id, pheiht, pwidth, hv, wv) {
    var ph = "100%";
    var pw = "700";
    var h = 745;
    var w = 600;
    LODOP = getLodop();
    LODOP.PRINT_INIT("预览");
    if (pheiht != 0) {
        ph = pheiht+"px"
    }
    if (pwidth != 0) {
        pw= pwidth + "px"
    }
    if (hv != 0) {
        h = hv
    }
    if (wv != 0) {
        w = wv
    }
    var strBodyStyle = "<style> Table{border-collapse:collapse;border:2px solid #666666; width:750px}   td{border:1px solid #333333;height:25px;}</style>";
    var strFormHtml = strBodyStyle + "<body ><table>" + document.getElementById(id).innerHTML + "</table></body>";
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "");
    LODOP.SET_PRINT_MODE("POS_BASEON_PAPER", true);
    LODOP.ADD_PRINT_TABLE("20px", "20px", ph, pw, strFormHtml);
    LODOP.SET_PRINT_STYLEA(0, "TableHeightScope", 1);
    LODOP.ADD_PRINT_HTM(h, w, 100, 100, "<font style='font-size:20px;font-weight:bolder'  ><span tdata='pageNO'>第##页</span>/<span tdata='pageCount'>共##页</span></font>");
    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
    LODOP.PREVIEW();
};
function HPrintEx(id, pheiht, pwidth, hv, wv) {
    var ph = "100%";
    var pw = "500";
    var h = 1020;
    var w = 350;
    LODOP = getLodop();
    LODOP.PRINT_INIT("预览");
    var strBodyStyle = "<style> Table{border-collapse:collapse;border:2px solid #666666; width:100%}   td{border:1px solid #333333;font-size:12px}</style>";
    var strFormHtml = strBodyStyle + "<body ><table>" + document.getElementById(id).innerHTML + "</table></body>";
    LODOP.SET_PRINT_PAGESIZE(2, 0, 0, "");
    LODOP.SET_PRINT_MODE("POS_BASEON_PAPER", true);
    LODOP.ADD_PRINT_TABLE("20px", "20px", ph, pw, strFormHtml);
    LODOP.SET_PRINT_STYLEA(2,"LANDSCAPE_DEFROTATED", 1);
    LODOP.ADD_PRINT_HTM(ph, 1000, 100, 100, "<font style='font-size:14px;font-weight:bolder'  ><span tdata='pageNO'>第##页</span>/<span tdata='pageCount'>共##页</span></font>");
    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
    LODOP.PREVIEW();
};

function PrintDiv(id) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("预览");
    var strBodyStyle = "<style>Table{border-collapse:collapse;border:2px solid #666666;}   td{border:1px solid #333333;height:25px;}</style>";
    var headstr = strBodyStyle+"<html><head></head><body> <center>";
    var footstr = "</center></body>";    
    var printData = document.getElementById(id).innerHTML;  
    var oldstr = document.body.innerHTML;    
    var data = headstr+printData+footstr;    
    LODOP.ADD_PRINT_HTM(20,32,"92%","94%",data);  
    LODOP.SET_PRINT_STYLEA(0,"HOrient",3);
    LODOP.SET_PRINT_STYLEA(0, "VOrient", 3);              
    LODOP.PREVIEW();
}
function PrintStr(str) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("预览");
    var strBodyStyle = "<style> .fy {page-break-after: always;} Table{border-collapse:collapse;border:2px solid #666666;}   td{border:1px solid #333333;height:25px;}</style>";
    var headstr = strBodyStyle + "<html><head></head><body> <center>";
    var footstr = "</center></body>";
    var data = headstr + str + footstr;
    LODOP.ADD_PRINT_HTM(20, 32, "92%", "94%", data);
    LODOP.SET_PRINT_STYLEA(0, "HOrient", 3);
    LODOP.SET_PRINT_STYLEA(0, "VOrient", 3);
    LODOP.PREVIEW();
}
function HPrintStr(str) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("预览");
    var strBodyStyle = "<style> Table{border-collapse:collapse;border:none solid #666666;}   td{border:1px solid #333333;}</style>";
    var headstr = strBodyStyle + "<html><head></head><body> <center>";
    var footstr = "</center></body>";
    var data = headstr + str + footstr;
    LODOP.SET_PRINT_PAGESIZE(2, 0, 0, "");
    LODOP.ADD_PRINT_HTM(20, 32, "92%", "94%", data);
    LODOP.SET_PRINT_STYLEA(0, "HOrient", 3);
    LODOP.SET_PRINT_STYLEA(0, "VOrient", 3);    
    LODOP.PREVIEW();
}
function createNewTable() {
    LODOP = getLodop();
 //因为引用外部的css不能直接显示效果，所以把打印的样式写在这里面
    var pStyle = "<style> table{ border-collapse:collapse ; border:1px solid #68957f; border-radius:10px;}td{  border:1px solid #68957f; height:25px; font-size:14px}</style>";
 
  var reqTable = $("#pageone").html();
  var html =pStyle+reqTable;
  LODOP.PRINT_INIT("打印借款借据");
  LODOP.SET_PRINT_PAGESIZE(1,0,0,"A4");
  LODOP.ADD_PRINT_HTM(20,20,"100%",1100,html);
  LODOP.SET_PRINT_STYLEA(2,"ReadOnly",0);
 //关键：分页
  LODOP.NewPage();
  reqTable = $("#pagetwo").html();
  html =pStyle+reqTable;
  LODOP.ADD_PRINT_HTM(20, 20, "100%", "100%", html);
  LODOP.SET_PRINT_STYLEA(2,"ReadOnly",0);
  LODOP.NewPage();
  reqTable = $("#pagethree").html();
  html =pStyle+reqTable;
  LODOP.ADD_PRINT_HTM(20, 20, "100%", "100%", html);
  LODOP.SET_PRINT_STYLEA(2,"ReadOnly",0);
  LODOP.NewPage();
  reqTable = $("#pagefour").html();
  html =pStyle+reqTable;
  LODOP.ADD_PRINT_HTM(20, 20, "100%", "100%", html);
  LODOP.SET_PRINT_STYLEA(2,"ReadOnly",0);
  LODOP.NewPage();
  reqTable = $("#pagefive").html();
  html = pStyle + reqTable;
  LODOP.ADD_PRINT_HTM(20, 20, "100%", "100%", html);
  LODOP.SET_PRINT_STYLEA(2, "ReadOnly", 0);
  LODOP.NewPage();
  LODOP.PREVIEW();
 } 