<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="centuDY.Views.Pages.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_welcome" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>

    <div>
        <asp:GridView ID="grv_medicines" runat="server" AutoGenerateColumns="False" OnRowCommand="grv_medicines_RowCommand">
            <Columns>
                <asp:BoundField DataField="MedicineId" HeaderText="Id" SortExpression="MedicineId" />
                <asp:BoundField DataField="Name" HeaderText="Medicine Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                
               
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Action" ShowHeader="True" Text="Add to cart" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
