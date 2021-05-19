<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="centuDY.Views.Pages.Profile.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_update_profile" runat="server" Text="Update Profile" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>
        <table>
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
