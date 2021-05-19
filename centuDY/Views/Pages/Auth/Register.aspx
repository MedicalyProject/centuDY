<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="centuDY.Views.Pages.Auth.Register" %>
<asp:Content ID="Content" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <table>
            <tr>
                <td>Username </td>
                <td>
                    <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password </td>
                <td>
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Confirm Password </td>
                <td>
                    <asp:TextBox ID="txt_confirm_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Name </td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender </td>
                <td>
                    <asp:RadioButton ID="rb_male" runat="server" Text="Male" GroupName="gender"/>  
                    <asp:RadioButton ID="rb_female" runat="server" Text="Female" GroupName="gender"/>  
                </td>
            </tr>
            <tr>
                <td>Phone Number </td>
                <td>
                    <asp:TextBox ID="txt_phone_number" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address </td>
                <td>
                    <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:HyperLink ID="hpr_login" runat="server" Visible="false">Login</asp:HyperLink>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>

