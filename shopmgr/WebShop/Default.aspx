﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>首页</title>
    <link href="CSS/NavBar.css" rel="stylesheet" />
    <link href="CSS/slider.css" rel="stylesheet" />
    <link href="CSS/smalldiv.css" rel="stylesheet" />
    <link href="CSS/StyleUser.css" rel="stylesheet" />
    
</head>
    
<body>
    <form id="form1" runat="server">
        <div class="divuser">
            <div>
                <asp:Label ID="lblUsername" runat="server" Text="" CssClass="lbl"></asp:Label>
                <asp:Button ID="btnLogon" runat="server" Text="登录" CssClass="btnloginlogon" OnClick="btnLogon_Click" />
                <asp:Button ID="btnReg" runat="server" Text="注册" CssClass="btnloginlogon" OnClick="btnReg_Click" />
            </div>
        </div>
        <div>
            <div class="divheader">
            </div>
            <div style="height: 5px;"></div>
            <div class="divnav" style="background-image: url('/img/nav.png'); background-repeat: repeat-x">
                <div class="div980">
                    <ul class="navul">
                        <li style="background-image: url('/img/navhover.png')"><a href="Default.aspx">首页</a> </li>
                        <li><a href="http://www.baidu.com">经验交流</a></li>
                        <li><a href="MyShop/myShop.aspx">我的店铺</a>  </li>
                        <li>给我们提意见</li>
                    </ul>

                </div>
            </div>
            <div style="background-image: url('/img/logonbg.jpg')" class="divslider"></div>
            <div class="div980">
                <div class="divsmall">
                    <div class="divsmalltxt">项目展示</div>
                </div>
                <div class="divsmall">
                    <div class="divsmalltxt">项目展示</div>
                </div>
                <div class="divsmall">
                    <div class="divsmalltxt">项目展示</div>
                </div>
                <div class="divsmall">
                    <div class="divsmalltxt">项目展示</div>
                </div>
                <div class="divsmall">
                    <div class="divsmalltxt">项目展示</div>
                </div>


            </div>
        </div>
        <div class="divfoot">测试页脚内容</div>
    </form>
</body>
</html>