<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="centuDY.Views.Pages.Profile.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_update_profile" runat="server" Text="Update Profile" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>Old Password </td>
                <td>
                    <asp:TextBox ID="txt_old_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>New Password </td>
                <td>
                    <asp:TextBox ID="txt_new_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Confirm Password </td>
                <td>
                    <asp:TextBox ID="txt_confirm_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td>
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
