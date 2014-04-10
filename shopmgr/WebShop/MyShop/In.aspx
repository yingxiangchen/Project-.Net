<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In.aspx.cs" Inherits="MyShop_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="shopCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="toolbar">
                    <asp:Button ID="btnAddForm" runat="server" Text="采购入库" OnClick="btnAddForm_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="divmain">

        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="popdiv" class="divpop" runat="server" visible="false">
                    <div class="divpoptitle">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div>fdsafdasfd</div>
                    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
