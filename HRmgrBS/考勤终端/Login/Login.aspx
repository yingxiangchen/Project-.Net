<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <script src="../JS.js"></script>
    <style type="text/css">
        .hr{
            padding:5px 5px 5px 5px;
            text-align:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width:100%;margin:auto auto auto auto;font-size:12px;text-align:center;">
            <h2 style="background-color:#CFD6E5; color: #666666;" class="hr" >登录</h2>
            <br />
            <br />
            <br />
            <br />  
            
                    <asp:Label ID="Label1" Width="70px" runat="server" Text="用户名:"></asp:Label>
                    <asp:TextBox ID="txtUser" runat="server" Width="200px" ></asp:TextBox><br /><br />
                    <asp:Label ID="Label2" Width="70px" runat="server" Text="密码："></asp:Label>                    
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>              
            <br /><br />
            <div style="text-align:center;">
                <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red" ></asp:Label>
            </div>
            <br />
            <div style="width:300px;margin:auto auto auto auto;text-align:center;">
                <asp:Button ID="btnLogin" runat="server" Text="登录" Width="100px" OnClick="btnLogin_Click" />
                <asp:Button ID="btnClose" runat="server" Text="关闭" Width="100px" OnClientClick="closeWin(this)" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
