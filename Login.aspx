<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.cs" Inherits="_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="col-md-3"></div>
    <div class="panel panel-info col-md-5">
        <div class="panel-heading">登入

        </div>
        <div class="panel-body  form">
        <asp:Label runat="server" ID="lblResult"  ForeColor="Red"></asp:Label>
            <div class="form-group">
                <label for="email">帳號:</label>
                <asp:TextBox runat="server" ID="txtAccount" CssClass="form-control"></asp:TextBox>

            </div>
            <div class="form-group">
                <label for="pwd">密碼:</label>
                <asp:TextBox runat="server" ID="txtPwd" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="登入管理介面" CssClass="form-control btn btn-primary"></asp:Button>
            </div>
        </div>
    </div>
</asp:Content>
