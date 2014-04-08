<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KQSummary.aspx.cs" Inherits="Kaoqin_KQSummary" %>

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
            日期：<asp:TextBox ID="txtDF" runat="server" Width="100px" CssClass="Wdate" onclick="WdatePicker()"></asp:TextBox>
            到：<asp:TextBox ID="txtDT" runat="server" Width="100px" CssClass="Wdate" onclick="WdatePicker()"></asp:TextBox>
        </div>
        <br />
        <div>
            部门：<asp:DropDownList ID="cboDepart" runat="server" Width="150px" ></asp:DropDownList>
            姓名：<asp:TextBox ID="txtName" runat="server" Width="100px"></asp:TextBox>
            <asp:Button ID="btnQuery" runat="server" Text="查询" Width="100px" OnClick="btnQuery_Click"/>
            <asp:Button ID="btnRefreshDayoff" runat="server" Text="刷新请假/旷工数据" OnClick="btnRefreshDayoff_Click" />
            <br />
            <asp:UpdatePanel runat="server" >
                <ContentTemplate>
                    <asp:Label ID="lblInfo" runat="server" ></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand" >
                <HeaderTemplate>
                    <table border="1" style="border-collapse:collapse;">
                        <tr style="height:32px;background-image:url('/Pic/blueTitle.gif'); background-repeat: repeat-x;font-size:14px;font-weight:bold;color:white;">
                            <td style="width:150px;">部门</td>
                            <td style="width:100px;">员工姓名</td>
                            <td style="width:100px;">员工编号</td>
                            <td style="width:150px;">职位</td>
                            <td style="width:150px;">指纹考勤天数</td>
                            <td style="width:250px;">实际出勤天数
                                <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandName="edit" /> 
                                <asp:Button ID="btnSave" runat="server" Text="保存" CommandName="saveall"/>
                                <asp:Button ID="btnCancel" runat="server" Text="取消" CommandName="cancel"  />
                            </td>
                            <td style="width:100px;">休假天数</td>
                            <td style="width:100px;">旷工天数</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr style="height:25px;"  onclick="this.style.backgroundColor='#FFCC99'"  onmouseover="this.style.backgroundColor='#beddfe'" onmouseout="this.style.backgroundColor=''">
                            <td><%#Eval("depart") %></td>
                            <td><%#Eval("empname") %></td>
                            <td><asp:Label ID="lblempNum" runat="server" Text='<%#Eval("empnum") %>'></asp:Label></td>
                            <td><asp:Label ID="lblPosition" runat="server" Text='<%#Eval("empposition") %>'></asp:Label></td>
                            <td><%#Eval("empsysattn") %></td>
                            <td>
                                <asp:Label ID="lblEmpAtualAttn" runat="server" Text='<%#Eval("atualattn") %>'></asp:Label>
                                <asp:TextBox ID="txtEmpAtualAttn" runat="server"   Text='<%#Eval("atualattn") %>' Visible="false"  ></asp:TextBox>
                                <asp:Button ID="btnSave" runat="server" Text="保存" CommandArgument='<%#Eval("empnum") %>' CommandName="save" Visible="false"  />
                            </td>
                            <td><asp:Label ID="lblDayoff" runat="server" Text='<%#Eval("DayoffDays") %>'></asp:Label></td>
                            <td><asp:Label ID="lblKuangGong" runat="server" Text='<%#Eval("Kuanggongdays") %>'></asp:Label></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr style="height:22px;">
                        <td><asp:Label ID="lblCountEmp" runat="server" ></asp:Label></td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div>
                <table style="width:100%;border-collapse:collapse;">
                    <tr style="background-repeat: repeat-x;background-image:url('/pic/bluetitle.gif')">
                        <td><asp:Button ID="btnSaveAll" runat="server" Text="全部保存" OnClick="btnSaveAll_Click" /></td>
                        <td>
                            <asp:UpdatePanel runat="server" >
                                <ContentTemplate>
                                    <asp:Label ID="lblCount" runat="server" ></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
