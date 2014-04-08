<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KQRrdUpdate.aspx.cs" Inherits="Kaoqin_KQRrdUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        input
        {
         border-bottom:1px solid #808080;
         border-top:none;
         border-left:none;
         border-right:none;

        }
        #divbg
        {
            width: 100%;
            height: 100%;
            position: absolute;
            z-index: 999;
            top: 0px;
            left: 0px;
            filter: alpha(opacity=20);
            opacity: 0.5;
            background-color: #AAAAAA;
        }
        #diveditcontent
        {
            width: 630px;
            height: 150px;
            position: absolute;
            z-index: 1000;
            background-color: #444444;
        }
        #divheader
        {
            width: 100%;
            height: 25px;
            background-color: #BB5500;
        }
    </style>


    <script type="text/javascript">
        var divheader = document.getElementById("divheader");
        var divbg = document.getElementById("divbg");
        var diveditcontent = document.getElementById("diveditcontent");
        var selects = document.getElementsByTagName("select");
        var divcontent = document.getElementById("divcontent");
        function Showdivform(Key) {

            divbg.style.display = "";
            divbg.style.width = document.body.offsetWidth;  //浏览器宽度(滚动条+clientwidth+边框）
            divbg.style.height = document.body.offsetHeight;

            diveditcontent.style.display = "";
            diveditcontent.style.top = "50px";   //弹出窗口位置
            diveditcontent.style.left = "100px";


            //for (var i = 0; i < selects.length; i++) {
            //    selects[i].style.display = "none";      //遮住下拉框
            //}

            divcontent.innerHTML = "<iframe frameborder=0 scrolling=no src='Cal.aspx?Key=" + Key + "' width='100%' height='100%'></iframe>";
            //嵌入页

        }
        function Hide() {
            //隐藏窗口
            //document.location = location.reload();
            //divbg.style.display = "none";
            //diveditcontent.style.display = "none";
            document.getElementById("divbg").style.display ="hidden";
            document.getElementById("divbg").style.display = "hidden";
            //for (var i = 0; i < selects.length; i++) {
            //    selects[i].style.display = "";
            //}


        }
       
    </script>
    <script src="../cal/DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="font-size:12px;">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
    <div>
        日期：从&nbsp; <asp:TextBox ID="txtDateF" CssClass="Wdate"  runat="server" onclick="WdatePicker()" TextMode="Date" Width="120px" style="text-align:center;" ></asp:TextBox>
        &nbsp;到&nbsp; <asp:TextBox ID="txtDateT" CssClass="Wdate"  runat="server" onclick="WdatePicker()" TextMode="Date" Width="120px" style="text-align:center;" ></asp:TextBox>
        &nbsp;       
       
        <asp:Button ID="btnUpdateKQRrd" runat="server" Text="更新考勤记录" OnClick="btnUpdateKQRrd_Click" />
        <asp:Button ID="btnUpdateClass" runat="server" Text="更新班次" />
         
    </div>
         


        <div>
           
　　</div>
    </form>
</body>
</html>
