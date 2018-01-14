<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Table1.aspx.cs" Inherits="Table1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gvData" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="行政區名" HeaderText="行政區" />
            <asp:BoundField DataField="漲幅區間" HeaderText="漲幅區間" />
            <asp:BoundField DataField="土地筆數" HeaderText="土地筆數" DataFormatString="{0:#,##0}" />
        </Columns>
    </asp:GridView>
</asp:Content>

