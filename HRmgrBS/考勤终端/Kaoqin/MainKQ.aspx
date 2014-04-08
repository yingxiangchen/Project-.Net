<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainKQ.aspx.cs" Inherits="MainKQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>考勤</title>
    <link href="../PopDIV/popWin.css" rel="stylesheet" />
    <script src="../PopDIV/popWin.js"></script>
    <script type="text/javascript">
        function promptandforward(msg, pageforward) {
            alert(msg);
            if (pageforward != null) {
                location.href = pageforward;
            }
        }
        function goclick(btn) {
            document.getElementById(btn).click();
        }
        function goitemcommand(rpt) {
            document.getElementById(rpt).itemcommand();
        }
        function showempkq(bg, msg) {
            var iWidth = document.documentElement.clientWidth;
            var iHeight = document.documentElement.clientHeight;
            document.getElementById(bg).style.display = '';
            document.getElementById(msg).style.display = '';
            document.getElementById(msg).style.width = 1000 + "px";
            document.getElementById(msg).style.height = 500+"px";
            document.getElementById(msg).style.top = (iHeight - 500) / 2 + "px";
            document.getElementById(msg).style.left = (iWidth - 1000) / 2 + "px";
        }
        function closeempkq(bg, msg) {
            document.getElementById(bg).style.display = none;
            document.getElementById(msg).style.display = none;
        }
        function openw(url) {
            window.opener = null;
            window.open(url, "_blank");
        }
    </script>
    <script type="text/javascript">
        function go(voidname) {
            document.all.FunName.value = voidname;
            document.form[0].submit();
        }
    </script>
    <style type="text/css">
        .input{
            -webkit-border-radius:6px;
            -moz-border-radius: 6px;
        }
        .divx{
            padding:5px 5px 5px 5px;
            
        }
        .divtitle{
            border:1px solid gray;
        }
        .titlelbl{
            font-size:15px;
            font-weight:bold;
            color:gray;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server" style="font-size:12px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="background-color: white; font-size: 12px;">
            <div class="divx" >
                <asp:Label ID="Label1" CssClass="titlelbl" runat="server" Text="考勤管理系统"></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
            <table style="display:none;">
                <tr style="text-align: center;">
                    <td>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:RadioButton ID="optByDepart" runat="server" GroupName="a" Text="按部门" Checked="true" OnCheckedChanged="optByDepart_CheckedChanged" AutoPostBack="True" />
                                &nbsp;
                                <asp:RadioButton ID="optByWorkGroup" runat="server" GroupName="a" Text="按工作组" OnCheckedChanged="optByWorkGroup_CheckedChanged" AutoPostBack="True" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 35px;">
                    <td>
                        &nbsp;</td>
                </tr>

            </table>
            <div class="divtitle" style=" margin: auto auto auto auto; background-image: url('/Pic/FunBarBk.gif'); background-repeat: inherit; background-color: #FFCC66;">
                <div class="divx" style="width: 950px; margin: auto auto auto auto; ">

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            年份：<asp:DropDownList ID="cboYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged"></asp:DropDownList>
                            月份：<asp:DropDownList ID="cboMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboMonth_SelectedIndexChanged"></asp:DropDownList>

                            <asp:Label ID="lbld" runat="server" Text="部门："></asp:Label><asp:DropDownList ID="cboDepart" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cboDepart_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="lblg" runat="server" Text="工作组：" Visible="false"></asp:Label>
                            <asp:Label ID="myName" runat="server" Visible="false"></asp:Label>
                            <asp:Button ID="btnWorkGroup" runat="server" OnClick="btnWorkGroup_Click" Text="我的工作组" Visible="false" />

                            员工姓名：<asp:TextBox CssClass="input" ID="txtName" runat="server" Width="100px"></asp:TextBox>
                            <asp:Button ID="btnRefresh" runat="server" Text="查询" OnClick="btnRefresh_Click" />

                        </ContentTemplate>

                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <div style="width:950px; margin:auto auto auto auto;">
            <table style="width: 100%;">
                <tr>


                    <td style="vertical-align: top;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Repeater runat="server" ID="rptEmp" OnItemCommand="rptEmp_ItemCommand">
                                    <HeaderTemplate>
                                        <table style=" border-collapse: collapse; font-size: 13px;" border="1">
                                            <tr style="background-image:url('../pic/bluetitle.gif'); background-repeat: repeat-x;height:32px;font-size:13px;font-weight:bold;">
                                                <td style="width:200px;">部门</td>
                                                <td style="width:150px">员工编号</td>
                                                <td style="width:150px">姓名</td>
                                                <td style="width:250px;">职位</td>
                                                <td style="width:150px">指纹考勤天数</td>
                                                <td style="width:150px;">实际出勤天数</td>
                                                <td style="width:150px;text-align:center;">操作</td>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr onmouseover="this.style.backgroundColor='#3D4043'" onmouseout="this.style.backgroundColor='black'" style="font-size:13px; padding: 5px 5px 5px 5px; text-align: right;color: white; background-repeat: repeat-x; background-color: black;">
                                            <td><%#Eval("department") %></td>
                                            <td>
                                                <asp:Label Width="100px" runat="server" ID="empNum" Text='<%#Eval("emp_no") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label Width="100px" runat="server" ID="empName" ForeColor="Yellow" Font-Bold="true"  Text='<%#Eval("emp_name") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="empPosition" Text='<%#Eval("empPosition") %>'></asp:Label></td>
                                            <td style="color:yellow;"><asp:Label Width="150px" Font-Bold="true"  runat="server" ID="attn" Text='<%#Eval("atn") %>'></asp:Label></td>
                                            <td><asp:TextBox ID="txtActulAttn" runat="server" Width="98%" Text='<%#Eval("AtualAttn") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:Label ID="lblview" runat="server" Text="=> " ForeColor="Red" Visible="false" ></asp:Label>
                                                <asp:Button ID="btnView" runat="server" Text="查看考勤" CommandName="view" CommandArgument='<%#Eval("emp_name") %>' /></td>
                                        </tr>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>

                                </asp:Repeater>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:AsyncPostBackTrigger ControlID="rptEmp" EventName="ItemCommand" />--%>
                                <asp:PostBackTrigger ControlID ="rptEmp" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div style="padding: 5px 5px 5px 5px; background-image: url('/pic/bluetitle.gif'); text-align: center; background-color: #EEEEF2; font-size: 12px; background-repeat: repeat-x; text-align: right;">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblEmpcount" runat="server" Text="" ></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </td>
                </tr>
            </table>

        </div>
        
        
    </form>
</body>
</html>
