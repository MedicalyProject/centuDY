<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="centuDY.Views.Pages.Member.AddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_add_to_cart" runat="server" Text="Adding Item To Cart" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>Medicine Name </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description </td>
                <td>
                    <asp:TextBox ID="txt_description" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Medicine Stock </td>
                <td>
                    <asp:TextBox ID="txt_stock" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Price </td>
                <td>
                    <asp:TextBox ID="txt_price" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Insert quantity </td>
                <td>
                    <asp:TextBox ID="txt_qty" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_add_to_cart" runat="server" Text="Add to Cart" OnClick="btn_add_to_cart_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
