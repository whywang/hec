function Show(id, title, contents,pid) {
    CreateDiv(id, title, contents, pid);
    $(".showdiv").css("display", "block")
    $("#mask").css("display", "block")
}
function CreateDiv(id, t, c,pid) {
    var divstr = "<div id=\"" + id + "\" class=\"showdiv\"\> <div class=\"model-head\"><span class=\"close\" style='display:none' onclick=\"HidDiv('" + id + "')\">&times;</span><h4 class=\"modal-title\">新闻/通知</h4></div>";
    divstr = divstr + "<div style='text-align:center'><h4>"+t+"</h4></div> ";
    divstr =divstr +"<div class=\"model-content\"> ";
    divstr = divstr + " " + c + " ";
    divstr = divstr + " <div><input type='checkbox' value='1' name='js' id='js' onchange=\"CheckSeleted('"+id+"')\">我已经详细阅读本文件，同意并接受以上通知内容。</div> ";
	divstr = divstr + "<div style='width:100%;'><img id='readbtn' src='../../Image/System/uyrd.png'/> </div></div></div><div id=\"mask\"></div>";
	$("#"+pid).append(divstr);
}
 function HidDiv(id) {
     $("#"+id).remove();
     $("#mask").remove();
 }
 function CheckSeleted(id) {
     if ($("#js").attr("checked")) {
         $("#readbtn").attr("src", "../../Image/System/yrd.png");
         $("#readbtn").attr("style", " cursor:pointer");
         $("#readbtn").click(function (){
             ReadOver(id)
         })
     }
     else {
         $("#readbtn").attr("src", "../../Image/System/uyrd.png");
         $("#readbtn").attr("style", " cursor:");
         $("#readbtn").unbind()
     }
 }