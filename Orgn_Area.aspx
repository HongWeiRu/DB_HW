<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orgn_Area.aspx.cs" Inherits="Orgn_Area" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        行政區名：
     <asp:DropDownList runat="server" ID="ddlOrgn" DataTextField="名稱" DataValueField="機關ID"></asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlArea" DataTextField="行政區名" DataValueField="ID"></asp:DropDownList>
        <asp:Button runat="server" ID="btnAdd" Text="增加" OnClick="btnAdd_Click"></asp:Button><br />
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    </form>
</body>
</html>
