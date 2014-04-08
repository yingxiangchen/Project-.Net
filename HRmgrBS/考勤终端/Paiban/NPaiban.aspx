<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NPaiban.aspx.cs" Inherits="Paiban_NPaiban" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../cal/DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="font-size:12px;">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
        <table style="width:100%;height:500px;">
            <tr>
                <td id="tdOuterLeft" style="vertical-align:top;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>                        
                            排班日期：<asp:TextBox ID="txtDateF" runat="server" CssClass="Wdate" onclick="WdatePicker()" ></asp:TextBox>
                            到:<asp:TextBox ID="txtDateT" runat="server" CssClass="Wdate" onclick="WdatePicker()" ></asp:TextBox>
                                部门：<asp:DropDownList ID="cboDepart" runat="server" OnSelectedIndexChanged="cboDepart_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList><br />
                            <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red"  ></asp:Label>
                        
                        <asp:Repeater ID="repAllEmpForDepart" runat="server">
                            <HeaderTemplate>
                                <table style="width:100%;border-collapse:collapse">
                                    <tr style="background-image:url('/Pic/blueTitle.gif'); background-repeat: repeat-x;height:32px;font-size:14px;">
                                        <td>编号</td>
                                        <td>员工姓名</td>
                                        
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tr onmouseover="this.style.backgroundColor='yellow'" onmouseout="this.style.backgroundColor=''">
                                        <td><asp:Label ID="empAllNum" runat="server" Text='<%#Eval("emp_no") %>'></asp:Label></td>
                                        <td><asp:Label ID="empAllName" runat="server" Text='<%#Eval("emp_name") %>'></asp:Label></td>
                                        
                                    </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    <tr>
                                        <td colspan="2" style="text-align:center;background-image:url('/Pic/blueTableTitle.gif'); background-repeat: repeat-x;height:22px;">
                                            
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div>
                        <asp:Label ID="lblCountEmp" runat="server" ></asp:Label>
                    </div>
                </td>
                <td id="tdOuterRight" style="width:50%;vertical-align:top;">
                    
                        <table id="Banci" style="width:100%; height:100%;">
                            <tr id="Zaoban">
                                早班：
                                <asp:ListBox ID="lstZaoban" runat="server" Width="100%" Height="150px" ></asp:ListBox>
                            </tr>
                            <tr id="Zhongban">
                                中班：
                                <asp:ListBox ID="lstZhongban" runat="server" Width="100%" Height="150px" ></asp:ListBox>
                            </tr>
                            <tr id="Wanban">
                                晚班：
                                <asp:ListBox ID="lstWanban" runat="server" Width="100%" Height="150px" ></asp:ListBox>
                            </tr>
                        </table>
                    
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
