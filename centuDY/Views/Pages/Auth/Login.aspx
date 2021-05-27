<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="centuDY.Views.Pages.Auth.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_login" runat="server" Text="CentuDY Login" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>  
    <div>
        <table>
            <tr>
                <td>Email </td>
                <td>
                    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password </td>
                <td>
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chk_remember" runat="server" Text="Remember me" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:HyperLink ID="hpr_register" runat="server">Register</asp:HyperLink>
        <asp:Label ID="lbl_error" runat="server" Text="Invalid username and password combination!" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
