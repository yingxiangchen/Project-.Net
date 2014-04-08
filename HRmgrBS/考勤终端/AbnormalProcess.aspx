<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AbnormalProcess.aspx.cs" Inherits="Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 64px;
        }
        .auto-style3 {
            height: 40px;
        }
        .auto-style4 {
            height: 18px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server" style="background-color:#FFFFFF;font-size:12px;">
        <div>
            <table style="height:100%;">
                <tr>
                    <td style="text-align:right;">年份：</td>
                    <td><asp:DropDownlist ID="cboYear" runat="server" Width="80px" ></asp:DropDownlist> </td>
                    <td style="text-align:right;">月份：</td>
                    <td><asp:DropDownlist ID="cboMonth" runat="server" Width="50px" ></asp:DropDownlist> </td>
                </tr>
                
            </table>
            
        </div>
        <div>
            <br />
            <br />
            <asp:Button ID="btnProcessQJ" runat="server" Text="处理请假、放假" OnClick="btnProcessQJ_Click"  Width="150px"/>
            <asp:Button ID="btnManualFinger" runat="server" Text="处理手动签卡" OnClick="btnManualFinger_Click" Width="150px" />
            <asp:Button ID="btnComment" runat="server" Text="获得注释" Width="150px" OnClick="btnComment_Click"/>
        </div>
        
    </form>
</body>
</html>
