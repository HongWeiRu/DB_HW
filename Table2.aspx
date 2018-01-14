<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Table2.aspx.cs" Inherits="Table2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gvData" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="行政區名" HeaderText="行政區" />
            <asp:BoundField DataField="土地筆數" HeaderText="土地筆數" DataFormatString="{0:#,##0}" />
            <asp:BoundField DataField="平均公告現值105" HeaderText="105年度平均公告現值" DataFormatString="{0:#,##0.##}" />
            <asp:BoundField DataField="平均公告現值106" HeaderText="106年度平均公告現值" DataFormatString="{0:#,##0.##}" />
            <asp:BoundField DataField="調幅比例" HeaderText="調幅比例" DataFormatString="{0:#,##0.##}" />

        </Columns>
    </asp:GridView>
</asp:Content>

