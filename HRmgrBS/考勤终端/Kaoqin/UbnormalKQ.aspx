<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UbnormalKQ.aspx.cs" Inherits="Kaoqin_UbnormalKQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>异常处理</title>
    <style type="text/css">
        .infodiv{
            padding:10px 10px 10px 10px;
            
        }
    </style>
    <script type="text/javascript">
        function promptandforward(msg, pageforward) {
            alert(msg);
            if (pageforward != null) {
                location.href = pageforward;
            }
        }
        function closeWin() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 13px;">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="infodiv" style="font-size: 15px; font-weight: bold; color: #333333;">
            考勤记录详情
        </div>
        <div class="infodiv" style="text-align: center; background-color: #FFFFCC;">
            部门：<asp:Label ID="empDepart" runat="server" Width="200px"></asp:Label>
            员工：<asp:Label ID="empName" runat="server" Width="150px"></asp:Label>
            职位：<asp:Label ID="empPosition" runat="server" Width="150px"></asp:Label>
            出勤天数：<asp:Label ID="empAttn" runat="server" Width="100px"></asp:Label>
        </div>
        <div class="infodiv">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rep" runat="server" OnItemDataBound="rep_ItemDataBound">

                        <HeaderTemplate>
                            <table border="1" style="border-collapse: collapse; width: 100%;">
                                <tr style="background-image: url('/pic/bluetitle.gif'); color: white; text-align: center; height: 32px; font-size: 12px;">
                                    <td>日期</td>
                                    <td>星期</td>
                                    <td>班别</td>
                                    <td>卡1</td>
                                    <td>卡2</td>
                                    <td>卡3</td>
                                    <td>卡4</td>
                                    <td>卡5</td>
                                    <td>卡6</td>
                                    <td>卡7</td>
                                    <td>卡8</td>
                                    <td>异常</td>
                                    <td>异常类型</td>
                                    <td>异常说明</td>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 25px" onclick="this.style.backgroundColor='#FFCC99'" onmouseover="this.style.backgroundColor='#beddfe'" onmouseout="this.style.backgroundColor=''">
                                <td><%#Eval("fingerdate").ToString().Substring(0,10) %></td>
                                <td><%#Eval("wkday") %></td>
                                <td><%#Eval("empClass") %></td>
                                <td><%#Eval("c1") %></td>
                                <td><%#Eval("c2") %></td>
                                <td><%#Eval("c3") %></td>
                                <td><%#Eval("c4") %></td>
                                <td><%#Eval("c5") %></td>
                                <td><%#Eval("c6") %></td>
                                <td><%#Eval("c7") %></td>
                                <td><%#Eval("c8") %></td>
                                <td style="color: red;">
                                    <asp:Label ID="lblAbr" runat="server" Text='<%#Eval("abnormal") %>'></asp:Label></td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>

                                    <asp:RadioButton ID="optQJ" Checked='<%#Eval("AbQJ") %>' GroupName="a" Text="放假/请假" runat="server" />
                                    <asp:RadioButton ID="optMDK" Checked='<%#Eval("Abmdk") %>' runat="server" GroupName="a" Text="未打卡" />
                                    <asp:RadioButton ID="optKG" Checked='<%#Eval("Abkg") %>' runat="server" GroupName="a" Text="旷工" />
                                    <asp:RadioButton ID="optOther" Checked='<%#Eval("Abother") %>' runat="server" GroupName="a" Text="其它" />

                                </td>
                                <td style="width: 20%; text-align: center;">
                                    <asp:Label ID="lblExplain" runat="server" Text='<%#Eval("AbnormalExplain") %>' Width="98%"></asp:Label>

                                    <asp:TextBox ID="txtExplain" runat="server" Text='<%#Eval("AbnormalExplain") %>' Width="98%" Visible="false"></asp:TextBox></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="infodiv" style="text-align: right; background-color: #FFFF99;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblInfo" runat="server" Text="" ForeColor="Red" ></asp:Label>
                    &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存全部" OnClick="btnSave_Click" />
                    <asp:Button ID="btnClose" runat="server" Text="关闭页面" OnClientClick="closeWin()" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
