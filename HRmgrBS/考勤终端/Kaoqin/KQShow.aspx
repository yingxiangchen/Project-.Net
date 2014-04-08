<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KQShow.aspx.cs" Inherits="Kaoqin_KQShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn" runat="server" Text="查询" OnClick="btn_Click" />
        </div>
        <div>
            <!--outer repeater-->
            <asp:Repeater ID="rptEmp" runat="server" OnItemCommand="rptEmp_ItemCommand" OnItemDataBound="rptEmp_ItemDataBound">
                <HeaderTemplate>
                    <table border="1" style="width:100%;border-collapse:collapse;">
                </HeaderTemplate>
                <ItemTemplate>                    
                    <tr style="background-color:#bbb;font-size:12px;">
                        <th style="width:250px;">部门：<%# DataBinder.Eval(Container.DataItem, "department") %></th>
                        <th style="width:250px;">职员姓名：<%# DataBinder.Eval(Container.DataItem, "emp_name") %></th>
                        <th style="width:250px;">职位：<%# DataBinder.Eval(Container.DataItem, "empposition") %></th>
                        <th></th>
                    </tr>
                    <!--inner repeater-->
                    <asp:Repeater ID="rep" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# DataBinder.Eval(Container.DataItem, "fingerdate") %><%# DataBinder.Eval(Container.DataItem, "wkday") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <FooterTemplate>
                    </table> 
                </FooterTemplate>
            </asp:Repeater>


        </div>
    </form>
</body>
</html>
