<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="centuDY.Views.Pages.Admin.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_view_member" runat="server" Text="View Members" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="grv_members" runat="server" AutoGenerateColumns="False" OnRowDeleting="grv_members_RowDeleting">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="Id" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Name" HeaderText="Nama" SortExpression="Name" />
                <asp:BoundField DataField="Role.RoleName" HeaderText="Role" SortExpression="Role.RoleName" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="lbl_delete_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
