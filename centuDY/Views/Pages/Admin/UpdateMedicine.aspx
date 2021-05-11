<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateMedicine.aspx.cs" Inherits="centuDY.Views.Pages.Admin.UpdateMedicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_update" runat="server" Text="Update Medicine" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>Medicine Name </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Medicine Description </td>
                <td>
                    <asp:TextBox ID="txt_description" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Medicine Stock </td>
                <td>
                    <asp:TextBox ID="txt_stock" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Medicine Price </td>
                <td>
                    <asp:TextBox ID="txt_price" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_update" runat="server" Text="Update Medicine" OnClick="btn_update_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
