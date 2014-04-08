<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="/pic/269.ico" />
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>企事业单位员工指纹考勤系统  
    </title>
    <meta name="keywords" content="企事业单位员工指纹考勤系统" />
    <meta name="description" content="企业考勤系统哪种好, 员工指纹考勤管理系统" />
    <script type="text/javascript" >
        function scroll() {
            //alert(typeof document.getElementById('bodycenter').style.height);
            document.getElementById('bodycenter').style.height = document.documentElement.clientHeight - 95 + "px";
            //document.getElementById('tbMain').style.height = document.documentElement.clientHeight - 165 + "px";
            document.getElementById('ifrm').style.height = document.documentElement.clientHeight - 95 + "px";
        }
        window.onload = scroll;
        window.onresize = scroll;

        function showorhide(sControl, boolShow) {
            document.getElementById(sControl, boolShow).style.visibility = "visible";  // .style.visibility=boolShow;
        }
    </script>
    <style type="text/css">
        .ul{
            margin:5px 5px 5px 5px;
            padding:10px 15px 10px 15px;
            background-image:url('/pic/bluetitle.gif');
        }
        .li{
            float:left;
            margin:0 5px 0 0;
            
        }
        .li:hover{
            color:red;
            background-color:#eee;
        }
    </style>
    </head>

<body>
    <form id="form1" runat="server" style="font-size:12px;">
    <asp:scriptmanager runat="server"></asp:scriptmanager>
        <div id="divtitle" style="height:40px;">
            <table style="width:100%;height:100%;">
                <tr style="font-size:25px;font-family:Tahoma;text-align:center;color:#3366FF; font-weight:bold;">
                    <td style="color: #0033CC">人事管理系统</td>
                </tr>
            </table>
        </div>
        <div style="background-color:Background;height:5px;"></div>
        <div id="divfunction" style="background-image:url('/pic/bluetitle.gif'); background-repeat: repeat-x;padding:8px 8px 8px 8px;">
            <asp:Menu ID="mnu" StaticEnableDefaultPopOutImage="false" runat="server" Height="22px"  
                Width="100%" Orientation="Horizontal" StaticSubMenuIndent="10px"  DynamicHorizontalOffset="2" Font-Names="Verdana" 
                Font-Size="10pt" ForeColor="Black"  OnMenuItemClick="mnu_MenuItemClick" >
                <DynamicHoverStyle BackColor="#FF0066" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="Silver" BorderColor="#3333CC" BorderWidth="1" />
                <DynamicSelectedStyle BackColor="#FF6600" />
                <Items>
                    <asp:MenuItem Text="班组管理" Value="class">
                        <asp:MenuItem Text="员工排班 / 转班" Value="turnclass"></asp:MenuItem>
                        <asp:MenuItem Text="班次及时间设置" Value="classTime"></asp:MenuItem>
                        <asp:MenuItem Text="New Paiban" Value="newpaiban" Enabled="False"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="考勤管理" Value="新建项">
                        <asp:MenuItem Text="考勤记录管理" Value="kqrrdmgr"></asp:MenuItem>
                        <asp:MenuItem Text="考勤异常处理" Value="abrkqrrdmgr"></asp:MenuItem>
                        <asp:MenuItem Text="异常结果跟踪" Value="abrkqresults"></asp:MenuItem>
                        <asp:MenuItem Text="手动签卡员工管理" Value="manualfinger"></asp:MenuItem>
                        <asp:MenuItem Text="考勤天数汇总" Value="KQSummary"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="职员管理" Value="职员管理">
                        <asp:MenuItem Text="职员档案管理" Value="empdata"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#FF0066" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FF0066" />
            </asp:Menu>
            <ul class="ul" style="visibility:hidden;">
                <li class="li" >考勤管理</li>
                <li class="li">人员管理</li>
            </ul>
        </div>
    <div style="background-image:url('/pic/bkjb.gif'); background-repeat: repeat-x;">
        <div id="bodycenter" runat="server"  style="width:100%;margin:auto auto auto auto;">                            
            <iframe runat="server"  id="ifrm" frameborder="no" style="width:100%;" src="~/Kaoqin/MainKQ.aspx">
            </iframe>      
        </div>
        <div id="divfoot" style="height:25px;background-color:#3366FF;width:100%;margin:auto auto auto auto;text-align:right;color:white;">
            <table  style="width:100%;height:100%">
                <tr>
                    <td>copyright @2013  yingxiangchen</td>
                </tr>
            </table>
            
        </div>
    </div>
        
    </form>
</body>
</html>
