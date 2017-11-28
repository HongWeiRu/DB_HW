<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:GridView ID="gvData" runat="server"  CssClass="table" AutoGenerateColumns="false">
          <Columns>
              <asp:BoundField DataField="行政區" HeaderText="行政區" />
              <asp:BoundField DataField="土地筆數" HeaderText="土地筆數" DataFormatString="{0:#,##0}" />
          </Columns>
        </asp:GridView>
</asp:Content>

