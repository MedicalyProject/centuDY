<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertMedicine.aspx.cs" Inherits="centuDY.Views.Pages.Admin.InsertMedicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_insert" runat="server" Text="Insert New Medicine" Font-Bold="True" Font-Size="X-Large"></asp:Label>
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
                    <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
