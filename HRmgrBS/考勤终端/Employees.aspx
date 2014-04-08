<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employees.aspx.cs" Inherits="Employees" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        input{
            border-bottom:1px solid #808080;
         border-top:none;
         border-left:none;
         border-right:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 12px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="height: 35px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 200px;">部门：<asp:DropDownList ID="cboDepart" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 200px;">员工编号：<asp:TextBox ID="txtNum" runat="server" Width="100px" Style="text-align: center;"></asp:TextBox>
                    </td>
                    <td style="height: 35px; font-size: 12px; width: 200px;">员工姓名：<asp:TextBox ID="txtName" runat="server" Width="100px" Style="text-align: center;"></asp:TextBox>
                    </td>

                    <td style="width: 120px;">
                        <asp:CheckBox ID="chkIncludLeave" runat="server" Text="包括离职职工" />
                    </td>
                    <td style="width: 100px;">
                        <asp:Button ID="btnRefresh" runat="server" Text="查询" OnClick="btnRefresh_Click" Width="80px" />
                    </td>
                    <td style="width: 100px;">
                        <asp:Button ID="btnNewEmp" runat="server" Text="新增员工" OnClick="btnNewEmp_Click" Width="80px" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <table border="1" style="width: 100%; border-collapse: collapse; border-color: #C0C0C0; color: #333333">
                                <tr style="background-image: url('/Pic/blueTitle.gif'); height: 32px; width: 80px; font-family: YouYuan; color: white; font-weight: bold; font-size: 14px; background-repeat: repeat-x; text-align: center;">

                                    <td>所属部门</td>
                                    <td>姓名</td>
                                    <td>性别</td>
                                    <td>学历</td>
                                    <td>联系方式</td>
                                    <td>身份证号</td>
                                    <td>身份证地址</td>
                                    <td>入职时间</td>
                                    <td>员工编号</td>
                                    <td>职位</td>

                                    <td>基本薪水</td>
                                    <td>银行帐号（中行）</td>
                                    <td>员工状态</td>
                                    <td>档案号</td>
                                    <td>申请离职时间</td>
                                    <td>正式离职时间</td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 25px;" onmouseover="this.style.backgroundColor='#C1E0FF'"
                                onmouseout="this.style.backgroundColor=''" onclick="this.style.backgroundColor='#A5B9DE'">
                                <td>
                                    <asp:Label ID="lbldepart" runat="server" Text='<%#Eval("emp_depart") %>'></asp:Label>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("emp_name") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblsex" runat="server" Text='<%#Eval("emp_sex") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbleducation" runat="server" Text='<%#Eval("emp_education") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbltel" runat="server" Text='<%#Eval("emp_tel") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblempID" runat="server" Text='<%#Eval("emp_id_no") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("emp_address") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblintime" runat="server" Text='<%#Convert.ToDateTime( Eval("emp_intime")).ToString("yyyy-MM-dd") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblempNum" runat="server" Text='<%#Eval("emp_no") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblempposition" runat="server" Text='<%#Eval("emp_position") %>'></asp:Label></td>

                                <td>
                                    <asp:Label ID="lblempsalary" runat="server" Text='<%#Eval("emp_salary") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblempbankcard" runat="server" Text='<%#Eval("emp_bank_card") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblempstate" runat="server" Text='<%#Eval("emp_state") %>'></asp:Label></td>
                                <td><%#Eval("documentno") %></td>
                                <td>
                                    <asp:Label ID="lblrequleavedate" runat="server" Text='<%# Eval("emp_requleavedate") %>'></asp:Label></td>
                                
                                <td>
                                    <asp:Label ID="lblleavedate" runat="server" Text='<%# Eval("emp_leavedate") %>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div style="background-image: url('/pic/bluetitle.gif'); height: 32px; vertical-align: middle">
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 70%;">
                                    <asp:Label ID="lblCountemp" runat="server" ForeColor="#205171"></asp:Label></td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnRevise" runat="server" Text="修改" Width="100px" />
                                    <asp:Button ID="btnChuanZheng" runat="server" Text="转正" Width="100px" />
                                    <asp:Button ID="btnRequestLeave" runat="server" Text="申请离职" Width="100px" />
                                    <asp:Button ID="btnLeave" runat="server" Text="正式离职" Width="100px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Repeater1" EventName="ItemCommand" />
                </Triggers>
            </asp:UpdatePanel>


        </div>
    </form>
</body>
</html>
