<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="Kaoqin_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>上传考勤数据</title>
    <script src="../cal/DatePicker/WdatePicker.js"></script>
    <script src="../JS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="日期："></asp:Label>
            <asp:TextBox ID="txtDateF" Width="100px" runat="server" CssClass="Wdate" onclick="WdatePicker()"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="至："></asp:Label>
            <asp:TextBox ID="txtDateT" Width="100px" runat="server" CssClass="Wdate" onclick="WdatePicker()"></asp:TextBox><br /><br />
            <asp:FileUpload ID="FileUpload1" runat="server" Width="500px" />
            <asp:Button ID="btnUpload" runat="server" OnClick="Button1_Click" Text="开始上传" />
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
            
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            
        </div><br /><br />
        <div>
            <asp:Repeater ID="rep" runat="server" >
                <HeaderTemplate>
                    <table border="1" style="width:100%;border-collapse:collapse;">
                        <tr style="background-color:ActiveBorder">
                            <td>日期</td>
                            <td>指纹号</td>
                            <td>打卡时间</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("fdate") %></td>
                        <td><%#Eval("fnum") %></td>
                        <td><%#Eval("ftime") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Repeater ID="rpt" runat="server">
                <HeaderTemplate>
                    <table style="width:100%">
                        <tr style="background-color:blue;border-collapse:collapse;color:white;">
                            <td>员工编号</td>
                            <td>日期</td>
                            <td>指纹号</td>
                            <td>c1</td>
                            <td>c2</td>
                            <td>c3</td>
                            <td>c4</td>
                            <td>c5</td>
                            <td>c6</td>
                            <td>c7</td>
                            <td>c8</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("empnum") %></td>
                        <td><%#Eval("fdate") %></td>
                        <td><%#Eval("fnum") %></td>
                        <td><%#Eval("c1") %></td>
                        <td><%#Eval("c2") %></td>
                        <td><%#Eval("c3") %></td>
                        <td><%#Eval("c4") %></td>
                        <td><%#Eval("c5") %></td>
                        <td><%#Eval("c6") %></td>
                        <td><%#Eval("c7") %></td>
                        <td><%#Eval("c8") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
