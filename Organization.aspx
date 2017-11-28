<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Organization.aspx.cs" Inherits="Organization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            <%= (this.DetailsView1.DefaultMode== DetailsViewMode.ReadOnly ? "": " $('#myModal').modal();" )           
        %>
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button runat="server" ID="btnAdd" Text="新增機關資料" CssClass=" btn btn-primary" Visible="false" OnClick="btnAdd_Click"></asp:Button>
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    
    <asp:GridView ID="gvData" runat="server" CssClass="table table-hover" DataSourceID="ObjectDataSource1" 
        AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvData_SelectedIndexChanging">
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="Organ"
        SelectMethod="GetDatas"></asp:ObjectDataSource>



    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">機關資料</h4>
                </div>
                <div class="modal-body">
                    <asp:DetailsView ID="DetailsView1" runat="server" Visible="false" CssClass="table"
                        AutoGenerateEditButton="True"
                        AutoGenerateRows="False" AutoGenerateInsertButton="True" 
                            OnItemInserting="DetailsView1_ItemInserting" OnModeChanging="DetailsView1_ModeChanging">
                        <Fields>
                            <asp:BoundField DataField="機關ID" HeaderText="機關ID"  ReadOnly="True"  InsertVisible="False" />
                            <asp:BoundField DataField="名稱" HeaderText="名稱" />
                            <asp:BoundField DataField="類別" HeaderText="類別" />
                            <asp:BoundField DataField="地址" HeaderText="地址" />
                            <asp:BoundField DataField="聯絡資訊" HeaderText="聯絡資訊" />
                        </Fields>
                    </asp:DetailsView>
                    <asp:GridView ID="GridView1" runat="server" CssClass="table" >
                        <EmptyDataTemplate>無資料</EmptyDataTemplate>
    </asp:GridView>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

