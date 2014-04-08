<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userLogon.aspx.cs" Inherits="userLogon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <link href="CSS/StyleUser.css" rel="stylesheet" />
    <script src="JS/pub.js"></script>
    <link href="CSS/NavBar.css" rel="stylesheet" />
    <style type="text/css">        
        .divlogon{
            position:absolute;
            width:350px;            
            text-align:center;
            background-color:white;            
            left:60%;
            top:20%;
            border:1px solid gray;
        }
        .divbg{
            background-color:azure;
            background-image:url('/img/logonbg.jpg');
           height:500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 13px;">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
        <div class="divheader">
            
        </div>
        <div class="divbg">
            <div class="divlogon ">
                <div style="background-color:cadetblue; color: white; font-weight: bold; font-size: 18px; padding: 18px 12px 18px 12px; text-align: center; font-family: YouYuan;">欢迎您登录易达旺铺</div>
                <br />
                <asp:Label ID="Label1" runat="server" Text="用户名：" Width="270px" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtuserName" runat="server" Width="250px" CssClass="txt"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="用户密码：" Width="270px" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtUserPwd" runat="server" Width="250px" CssClass="txt" TextMode="Password"></asp:TextBox><br />
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
                            <asp:Button ID="btnOK" runat="server" Text="登录" Width="250px" CssClass="btn" OnClick="btnOK_Click" /><br />
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
