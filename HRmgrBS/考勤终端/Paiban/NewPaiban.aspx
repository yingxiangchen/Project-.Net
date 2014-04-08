<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewPaiban.aspx.cs" Inherits="NewPaiban" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增排班</title>
    <script src="JS.js"></script>
    <style type="text/css">

        input
        {
         border-bottom:1px solid #808080;
         border-top:none;
         border-left:none;
         border-right:none;

        }

        .auto-style1 {
            height: 22px;
        }

    </style>
    <script src="../cal/DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="font-size:12px; ">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
    <div style="width:100%;margin:auto auto auto auto;">
        <table>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:UpdatePanel runat="server" >
                        <ContentTemplate>
                            
                            排班范围：
                            <asp:TextBox ID="txtDateF" CssClass="Wdate" onclick="WdatePicker()" runat="server" Width="100px" style="text-align:center;" TextMode="Date" OnTextChanged="txtDateF_TextChanged"  ></asp:TextBox>
                            &nbsp; 至：
                            <asp:TextBox ID="txtDateT" CssClass="Wdate" onclick="WdatePicker()"  runat="server" style="text-align:center;" Width="100px" TextMode="Date" OnTextChanged="txtDateT_TextChanged" ></asp:TextBox>
                            &nbsp; 部门：<asp:DropDownList ID="cboDepart" runat="server" Width="150px" OnSelectedIndexChanged="cboDepart_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                            <asp:Button ID="btnRefreshEmp" runat="server" Text="刷新员工列表" OnClick="btnRefreshEmp_Click" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="cboDepart" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                
            </tr>
            <tr>
                <td colspan="20" style="text-align:center;">
                    <asp:UpdatePanel runat="server" >
                        <ContentTemplate>
                            <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red" ></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>                                        
                </td>
                <td style="color: #808080">
                            
                            如果不能显示员工，请查看下面的日期段是否已排过班了</td>
            </tr>
        </table>
    </div>

        <div style="text-align:center;">
            <div style="width:100%;margin:auto auto auto auto;">
            <asp:UpdatePanel runat="server" >
                <ContentTemplate>
                    <asp:Repeater ID="repNewPB" runat="server" OnItemCommand="repNewPB_ItemCommand">
                        <HeaderTemplate>
                            <table border="1"  style="width:100%; border-collapse:collapse;font-size:12px;text-align:center;">
                                <tr style="height:32px;background-image:url('/pic/bluetitle.gif'); background-color:#FF9933;font-weight:bold;font-size:15px">
                                    <td style="width:150px;">部门</td>
                                    <td style="width:100px;">工号</td>
                                    <td style="width:100px;">姓名</td>
                                    <td style="width:150px;">职位</td>
                                    <td>班次</td>                                    
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height:25px;" onmouseover="this.style.backgroundColor='#FFFF99'" onmouseout="this.style.backgroundColor=''">
                                <td><asp:Label ID="lblempDepart" runat="server" Text='<%#Eval("emp_depart") %>'></asp:Label></td>
                                <td><asp:Label ID="lblempNo" runat="server" Text='<%#Eval("emp_No") %>'></asp:Label></td>
                                <td><asp:Label ID="lblempName" runat="server" Text='<%#Eval("emp_name") %>'></asp:Label></td>
                                <td><asp:Label ID="lblempPosition" runat="server" Text='<%#Eval("emp_position") %>'></asp:Label></td>
                                <td>
                                    <asp:RadioButton ID="rbZaoban" runat="server" Text="早班" GroupName="a"  /> 
                                    <asp:RadioButton ID="rbZhongban" runat="server" Text="中班" GroupName="a" />
                                    <asp:RadioButton ID="rbWanban" runat="server" Text="晚班" GroupName="a" />                                    
                                </td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
                <div>
                    <table style="width:100%;border-collapse:collapse;">
                        <tr style="background-image:url('/pic/bluetabletitle.gif');text-align:right;">
                            <td colspan="2" style="text-align:left;" class="auto-style1">
                                <asp:UpdatePanel runat="server" >
                                    <ContentTemplate>
                                        <asp:Label ID="lblCountEmp" runat="server" ></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>                                
                            </td>
                            
                            <td style="text-align:left;">                                
                                <asp:Button ID="btnSave" runat="server" Width="100px" Text="保存" OnClick="btnSave_Click" />                                                                
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
