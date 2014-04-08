<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManualFingerList.aspx.cs" Inherits="ManualFinger_ManualFingerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../cal/DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="font-size:12px;">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
    <div>
        这里列出的是所有目前正在签纸卡的员工，如果某员工停止签纸卡改用指纹卡，请从此列表中删除<br />
        
                <table style="grid-row-span:15;">
                    <tr>
                        <td colspan="8"f style="height:50px;"></td>
                    </tr>
                    <tr style="height:40px;">
                        
                        <td>新增签卡员工姓名：</td>
                        <td>
                            <asp:UpdatePanel runat="server" >
                                <ContentTemplate>
                                    <asp:TextBox ID="txtName" runat="server"  Width="150px" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                                
                        工号：
                            
                                    <asp:TextBox ID="txtNum" runat="server"  Width="80px" AutoPostBack="True" OnTextChanged="txtNum_TextChanged"></asp:TextBox>
                                
                        部门:
                           
                            <asp:Label ID="lblDepart" runat="server" ></asp:Label>
                            </ContentTemplate>        
                        </asp:UpdatePanel>
                        </td>
                            
                        <td style="width:100px;"></td>
                        <td>
                            <asp:UpdatePanel runat="server" >
                                <ContentTemplate>
                                    <asp:Button ID="btnSave" runat="server" Text="添加到签纸卡列表" OnClick="btnSave_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    
                    <tr style="height:35px;">
                        <td colspan="8" style="text-align:center;">
                            <asp:UpdatePanel runat="server" >
                                <ContentTemplate>
                                    <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red"  ></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            
    </div>
        <div>签卡列表：
            <table style="width:100%">
                <tr>
                    
                    <td>
                        <asp:UpdatePanel runat="server" >
                            <ContentTemplate>
                    <asp:Button ID="btnRefreshData" runat="server" Text="刷新列表" OnClick="btnRefreshData_Click" Width="100px"/>
                        共有：<asp:Label ID="lblCount" runat="server" ></asp:Label>人
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            
        </div>
        <div>
            <asp:UpdatePanel runat="server" >
                <ContentTemplate>
            <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand" >
                <HeaderTemplate>
                    <table border="1" style="border-collapse:collapse;">
                        <tr style="background-image:url('/pic/bluetitle.gif');height:32px;font-size:16px;font-weight:bold;color:white;">
                            
                            <td style="width:150px;">部门</td>
                            <td style="width:100px;">姓名</td>
                            <td style="width:100px;">工号</td>
                            
                            <td style="width:150px;">最后更新者</td>
                            <td style="width:200px;">更新时间</td>
                            <td style="width:150px;">操作</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr style="height:25px;" onclick="this.style.backgroundColor='#FFCC99'"  onmouseover="this.style.backgroundColor='#beddfe'" onmouseout="this.style.backgroundColor=''">
                            
                            <td><%#Eval("mfdepart") %></td>
                            <td><%#Eval("mfname") %></td>
                            <td><%#Eval("mfnum") %></td>
                            
                            <td><%#Eval("updateby") %></td>
                            <td><%#Eval("updatetime") %></td>
                            <td><asp:Button ID="btnDel" runat="server" Text="从列表中移除" CommandArgument='<%#Eval("id") %>' CommandName="del" /></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                        <tr style="background-image:url('/pic/bluetabletitle.gif');height:22px;">
                            <td colspan="70"></td>
                        </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
