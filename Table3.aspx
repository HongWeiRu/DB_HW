<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Table3.aspx.cs" Inherits="Table3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gvData" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
             <asp:BoundField DataField="類別" HeaderText="機關類別" />
            <asp:BoundField DataField="名稱" HeaderText="機關名稱" />
            <asp:BoundField DataField="行政區名" HeaderText="管轄行政區" />
            <asp:BoundField DataField="土地筆數" HeaderText="土地筆數" DataFormatString="{0:#,##0}" />
        </Columns>
    </asp:GridView>
</asp:Content>

