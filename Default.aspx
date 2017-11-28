<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">
        <div class="col-md-2 ">
            <label for="pwd">查詢土地資料:</label>
        </div>
        <div class="col-md-10 form-inline">
            <div class="form-group">
                <label for="email">行政區:</label>
                <asp:DropDownList runat="server" ID="ddlArea" AutoPostBack="true" DataTextField="行政區名" DataValueField="ID"
                    OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="pwd">地段:</label>
                <asp:DropDownList runat="server" ID="ddlLot" AutoPostBack="true" DataTextField="地段名稱" DataValueField="地段號"
                    OnSelectedIndexChanged="ddlLot_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="pwd">地號:</label>
                <asp:DropDownList runat="server" ID="ddlAreaNumb" DataTextField="地號" DataValueField="地號" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnQuery" Text="查詢!!" OnClick="btnQuery_Click" CssClass="form-control btn btn-primary"></asp:Button>
            </div>
        </div>
    </div>
    <div class="panel panel-info">
        <div class="panel-heading">辦理機關</div>
        <div class="panel-body">
            <asp:GridView ID="gvOrgan" runat="server" CssClass="table table-hover  ">
            </asp:GridView>
        </div>
    </div>

    <div class="panel panel-info">
        <div class="panel-heading">歷年公告現值</div>
        <div class="panel-body">
            <asp:GridView ID="gvValues" runat="server" CssClass="table table-hover  ">
            </asp:GridView>
            <asp:Label runat="server" ID="lblResult"></asp:Label>
        </div>
    </div>


</asp:Content>
