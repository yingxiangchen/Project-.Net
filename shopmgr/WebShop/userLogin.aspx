<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userLogin.aspx.cs" Inherits="userLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册用户</title>
    <link href="CSS/NavBar.css" rel="stylesheet" />
    <link href="CSS/StyleUser.css" rel="stylesheet" />
    <script src="JS/pub.js"></script>
    <style type="text/css">
        .divtitle {
            width:980px;
            margin:auto;
            text-align:center;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom: 1px solid #ddd;
            border-left: 1px solid #ddd;
            border-right: 1px solid #ddd;           
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 13px;">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
        <div class="divheader"></div>
        <div class="divtitle">
            <div class="divnav" style="border-top-left-radius: 5px; border-top-right-radius: 5px; text-align: left; color: white; font-size: 16px;">&nbsp;&nbsp; 欢迎注册易达旺铺 店铺管理得心应手</div>
            
            
            <div style="text-align: left;padding:45px 30px 30px 30px;">
                <asp:Label ID="Label1" runat="server" Text="用户名：" CssClass="lbl" Width="100px"></asp:Label>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" Width="180px"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="用户密码：" CssClass="lbl" Width="100px"></asp:Label>
                <asp:TextBox ID="txtUserPwd" runat="server" CssClass="txt" Width="180px" TextMode="Password"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="确认密码：" CssClass="lbl" Width="100px"></asp:Label>
                <asp:TextBox ID="txtUserPwdConfirm" runat="server" CssClass="txt" Width="180px" TextMode="Password"></asp:TextBox><br />
                <asp:Label ID="Label4" runat="server" Text="手机号码：" CssClass="lbl" Width="100px"></asp:Label>
                <asp:TextBox ID="txtMTel" runat="server" CssClass="txt" Width="180px" MaxLength="11"></asp:TextBox><br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label5" runat="server" Text="所在地区：" CssClass="lbl" Width="100px"></asp:Label>
                        <asp:DropDownList ID="cboProvince" runat="server" CssClass="cbo" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cboProvince_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="cboCity" runat="server" CssClass="cbo" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cboCity_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="cboDistrict" runat="server" CssClass="cbo" Width="150px"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:CheckBox ID="chkAgree" runat="server" Text="我已认真阅读并同意" /><a href="servers.html" target="_blank" class="a">《易达旺铺服务条款》</a>
                <br /><br />
                <asp:Label ID="lblInfo" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                <br />
                <asp:Button ID="btnOK" runat="server" Text="免费注册" CssClass="btn" Width="200px" OnClick="btnOK_Click" />
                &nbsp;&nbsp;
                已有用户？请<a class="a" href="userLogon.aspx">直接登录</a>
                <br />
                <br />

            </div>
        </div>
    </form>
</body>
</html>
