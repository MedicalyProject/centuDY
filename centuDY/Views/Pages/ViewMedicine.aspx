<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewMedicine.aspx.cs" Inherits="centuDY.Views.Pages.ViewMedicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <div>
        <asp:Label ID="lbl_view_medicine" runat="server" Text="View Medicine" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div>    
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txt_name" runat="server" placeholder="Filter by name" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_filter" runat="server" Text="Filter" OnClick="btn_filter_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="grv_medicines" runat="server" AutoGenerateColumns="False" OnRowDeleting="grv_medicines_RowDeleting" OnRowEditing="grv_medicines_RowEditing" >
            <Columns>
                <asp:BoundField DataField="MedicineId" HeaderText="Id" SortExpression="MedicineId" />
                <asp:BoundField DataField="Name" HeaderText="Medicine Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CommandField ButtonType="Button" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </div>

    <div>
        <asp:Button ID="btn_insert" runat="server" Text="Insert Medicine" OnClick="btn_insert_Click" />
    </div>

    <div>
        <asp:Label ID="lbl_delete_error" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>


</asp:Content>

