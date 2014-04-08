<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Paiban.aspx.cs" Inherits="CQ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>排班</title>
    
    
    <style type="text/css">

        input
        {
         border-bottom:1px solid gray;
            height: 18px;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
        }        
    </style>
    <script type="text/javascript" src="../JS.js"></script>
    <script  type="text/javascript" src="../cal/DatePicker/WdatePicker.js" ></script>
</head>
<body>
    <form id="form1" runat="server" style="font-size:12px;">
        <asp:ScriptManager runat="server" ></asp:ScriptManager>
        

    <div>
        <table>
            <tr>
                <td>排班范围：<asp:TextBox ID="txtDateF" CssClass="Wdate" onclick="WdatePicker()" runat="server" Width="120px" style="text-align:center;" TextMode="Date"  ></asp:TextBox>
                    &nbsp;</td>
                <td>&nbsp;至：&nbsp; <asp:TextBox ID="txtDateT" CssClass="Wdate" onclick="WdatePicker()" runat="server" style="text-align:center;" Width="120px" TextMode="Date" ></asp:TextBox>
                    &nbsp;</td>
                <td>
                    <asp:UpdatePanel runat="server" >
                        <ContentTemplate>
                            部门：<asp:DropDownList ID="cboDepart" runat="server" Width="150px" OnSelectedIndexChanged="cboDepart_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                            员工姓名：<asp:TextBox ID="txtEmpName" runat="server" Width="100px" ></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnRefresh" runat="server" Text="查询已排班数据" OnClick="btnRefresh_Click" />
                            <asp:Button ID="btnNewPb" runat="server" Text="新增排班" OnClientClick="showsubpage('NewPaiban.aspx',1000,500)" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="cboDepart" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnRefresh" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td> </td>
            </tr>
        </table>
    </div>
        <div style="color: #000099">
            <br />
           <table style="width:100%;">
               <tr>
                   <td style="width:50%;">以下为已排班列表</td>
                   <td style="color:red;">注意：本页的修改并非转班功能，只是修改当前已排班次。转班请到新增排班页安排！</td>
               </tr>
           </table>
                    
                
                    
             
        </div>
        <%--<asp:UpdatePanel runat="server" >
            <ContentTemplate>--%>
                <div id="divbg" runat="server"  style="opacity:0.5; position:absolute;left:100px; top:100px;width:800px;height:300px; background-color:#999999; z-index: 99998;display:none;" >
            
                </div>        
                <div id="divpop" runat="server"  style="position:absolute;left:200px;top:200px;height:200px;width:300px;background-color:#FF6699; z-index:99999;display:none;">
                    <br />

                    <asp:Button ID="btnfull" Text="full" runat="server" ClientIDMode="Static" tesx="Pop" OnClientClick="PopDivWin()" />
            
                </div>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        
        <div>
            <asp:UpdatePanel runat="server" >
                <ContentTemplate>
                    <asp:Repeater ID="repPB" runat="server" OnItemCommand="repPB_ItemCommand" >
                        <HeaderTemplate>
                            <table border="1" style="width:100%;border-collapse:collapse;">
                                <tr style="height:32px;background-image:url('/pic/bluetitle.gif'); background-color:#FF9933; text-align:center;font-size:16px;font-weight:bold; background-repeat: repeat-x;">
                                    
                                    <td>部门</td>
                                    <td>工号</td>
                                    <td>姓名</td>
                                    <td style="width:150px;">起始时间</td>
                                    <td style="width:150px;">截止时间</td>
                                    <td style="width:200px;">班次</td>
                                    <td style="width:120px;">操作</td>
                                    <td>分班者</td>
                                    <td>分班时间</td>
                                    
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height:25px;font-size:12px;" onmouseover="this.style.backgroundColor='#FFFF99'" onmouseout="this.style.backgroundColor=''" >
                                
                                <td><%#Eval("empDepart") %></td>
                                <td><%#Eval("empNum") %></td>
                                <td><%#Eval("empName") %></td>
                                <td>
                                    <asp:Label ID="lblDF" runat="server" Text='<%# Convert.ToDateTime( Eval("dateFrom")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                    <asp:TextBox ID="txtDF" Width="97%" runat="server" CssClass="Wdate" onclick="WdatePicker()" Text='<%# Convert.ToDateTime( Eval("dateFrom")).ToString("yyyy-MM-dd") %>' Visible="false" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblDT" runat="server" Text='<%# Convert.ToDateTime( Eval("dateTo")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                    <asp:TextBox ID="txtDT" Width="97%" runat="server" CssClass="Wdate" onclick="WdatePicker()" Text='<%# Convert.ToDateTime( Eval("dateto")).ToString("yyyy-MM-dd") %>' Visible="false" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblClass" runat="server" Text='<%#Eval("empClass") %>'></asp:Label>&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbZaoban" runat="server" Text="早班" GroupName="a" Visible="false" /> 
                                    <asp:RadioButton ID="rbZhongban" runat="server" Text="中班" GroupName="a" Visible="false" />
                                    <asp:RadioButton ID="rbWanban" runat="server" Text="晚班" GroupName="a"  Visible="false" />  
                                </td>                                
                                <td style="text-align:center;">
                                    <asp:Button ID="btnAdj" runat="server" style="text-decoration:none;" Text="修改" CommandArgument='<%#Eval("id") %>'
                                         CommandName="Adjust" />                                    
                                    <asp:Button ID="btnSave" runat="server" style="text-decoration:none;" Text="保存" CommandArgument='<%#Eval("id") %>'
                                         CommandName="Save" Visible="false" ></asp:Button>
                                    <asp:Button ID="btnCancel" runat="server" style="text-decoration:none;" Text="取消" CommandArgument='<%#Eval("id") %>'
                                         CommandName="Cancel" Visible="false" ></asp:Button>
                                </td>
                                <td><%#Eval("updateBy") %></td>
                                <td><%#Eval("updateTime") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="background-image:url('/Pic/blueTableTitle.gif'); background-repeat: repeat-x;height:22px;">                                
                                <td colspan="9">
                                    <asp:UpdatePanel runat="server" >
                                        <ContentTemplate>
                                            <asp:Label ID="lblCountRrd" runat="server" ></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </td>
                            </tr>
                            </table>
                        </FooterTemplate>
                
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    
                </Triggers>
            </asp:UpdatePanel>
            
        </div>
        <div>
            
        </div>
    </form>
</body>
</html>
