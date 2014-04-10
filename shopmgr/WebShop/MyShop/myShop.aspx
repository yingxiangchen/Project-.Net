<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myShop.aspx.cs" Inherits="MyShop_myShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的易达旺铺</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
    <link href="../CSS/StyleUser.css" rel="stylesheet" />
    <link href="shopCss.css" rel="stylesheet" />
</head>
<body style="font-size:13px;">
    <form id="form1" runat="server">
        <div class="divuser">
            <asp:Label ID="lblUserName" runat="server" ></asp:Label>
            &nbsp;
            <asp:Button ID="btnLogout" runat="server" Text="退出" CssClass="btnloginlogon" OnClick="btnLogout_Click" />
        </div>
        <div class="divheaderfullwidth"></div>
        <div class="divnav">
            <div class="div980">
                <asp:BulletedList ID="BulletedList1" runat="server" CssClass="navul" DisplayMode="HyperLink">
                    <asp:ListItem Value="../Default.aspx">首页</asp:ListItem>
                    <asp:ListItem Value="In.aspx">进货管理</asp:ListItem>
                    <asp:ListItem>销售管理</asp:ListItem>
                    <asp:ListItem>存货管理</asp:ListItem>
                    <asp:ListItem>给我们提意见</asp:ListItem>
                </asp:BulletedList>
            </div>
        </div>
        <iframe class="mainframe" runat="server" id="mainframe" src="~/MyShop/In.aspx">

        </iframe>
        <div class="div980">
            <div style="background-image:url('/img/logonbg.jpg');height:1000px;" ></div>
        </div>
    </form>
</body>
</html>
