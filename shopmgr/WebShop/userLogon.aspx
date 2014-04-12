<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userLogon.aspx.cs" Inherits="userLogon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <link href="CSS/Body/Public.css" rel="stylesheet" />
    <script src="JS/pub.js"></script>
    
    <style type="text/css">        
        .divlogon{
            position:absolute;
            width:350px;            
            text-align:center;
            background-color:white;            
            left:60%;
            top:15%;
            border:1px solid red;
            border-radius:5px 5px 0 0;
            z-index:2;
        }
        .divbg{
            position:absolute;
            top:20%;
            left:0;
            right:0;
            z-index:1;
            background-color:azure;
            background-image:url('/img/logonbg.jpg');
           height:500px;
        }
    </style>
    <link href="CSS/Login/Login.css" rel="stylesheet" />
    <link href="CSS/HeaderNav/CssHeader.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="font-size: 13px;">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
        <div class="divheader">
            
        </div>
        <div class="divbg">
            <div class="divlogon ">
                <div class="divLogontitle">欢迎您登录易达旺铺</div>
                <br />
                <asp:Label ID="Label1" runat="server" Text="用户名：" Width="270px" CssClass="lblBig"></asp:Label>
                <asp:TextBox ID="txtuserName" runat="server" Width="250px" CssClass="txtBig"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="用户密码：" Width="270px" CssClass="lblBig"></asp:Label>
                <asp:TextBox ID="txtUserPwd" runat="server" Width="250px" CssClass="txtBig" TextMode="Password"></asp:TextBox><br />
                <div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblInfo" runat="server" ForeColor="Red"></asp:Label><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnOK" runat="server" Text="登录" Width="270px" CssClass="btnBig" OnClick="btnOK_Click" /><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div>
                    还没有用户？<a class="a" href="userLogin.aspx">免费注册</a>
                </div>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
