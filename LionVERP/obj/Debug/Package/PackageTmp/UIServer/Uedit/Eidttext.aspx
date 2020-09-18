<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eidttext.aspx.cs" Inherits="LionVERP.UIServer.Uedit.Eidttext" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 
    <title>文本编辑</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <script type="text/javascript" charset="utf-8">
        window.UEDITOR_HOME_URL = "/../../UIClient/TextEditor/"; 
     </script> 
    <script src="../../Scripts/Common/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../UIClient/TextEditor/ueditor.config.js" type="text/javascript" charset="utf-8"></script>
    <script src="../../UIClient/TextEditor/ueditor.all.js" type="text/javascript"></script>
    <style type="text/css">
        .clear { clear: both;}
    </style>
</head>
<body>
     <div><script  id="editor" type="text/plain" style="width:1000px; height:500px" ></script></div>
     <div class="clear"></div>
</body>
<script type="text/javascript">
    var editor = new UE.ui.Editor();
    editor.render("editor");
    function getContent() {
        return UE.getEditor('editor').getContent();
    }
    function setContent(gnt) {
        UE.getEditor('editor').setContent(gnt);
    }
</script>
</html>
