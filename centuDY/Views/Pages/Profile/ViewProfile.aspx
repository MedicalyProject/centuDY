<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="centuDY.Views.Pages.Profile.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_view_profile" runat="server" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>Username </td>
                <td>
                    <asp:TextBox ID="txt_username" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Name </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender </td>
                <td>
                    <asp:TextBox ID="txt_gender" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone Number </td>
                <td>
                    <asp:TextBox ID="txt_phone_number" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address </td>
                <td>
                    <asp:TextBox ID="txt_address" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td>
                    <asp:Button ID="btn_update" runat="server" Text="Update Profile" OnClick="btn_update_Click"/>
                </td>
                <td>
                    <asp:Button ID="btn_change_password" runat="server" Text="Change Password" OnClick="btn_change_password_Click"/>
                </td> 
            </tr>
        </table>
    </div>
</asp:Content>
