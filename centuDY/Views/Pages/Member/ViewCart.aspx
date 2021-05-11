<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="centuDY.Views.Pages.Member.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_view_cart" runat="server" Text="View Cart" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="grv_user_carts" runat="server" AutoGenerateColumns="False" OnRowDeleting="grv_user_carts_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Medicine.MedicineId" HeaderText="Id" SortExpression="Medicine.MedicineId" />
                <asp:BoundField DataField="Medicine.Name" HeaderText="Medicine Name" SortExpression="Medicine.Name" />
                <asp:BoundField DataField="Medicine.Price" HeaderText="Price" SortExpression="Medicine.Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" SortExpression="SubTotal" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div>    
        <table>
            <tr>
                <td>
                     <asp:Label ID="lbl_grand_total" runat="server" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btn_checkout" runat="server" Text="Checkout" OnClick="btn_checkout_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div>
        <asp:Label ID="lbl_delete_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>

</asp:Content>
