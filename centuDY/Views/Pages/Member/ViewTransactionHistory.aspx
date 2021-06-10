<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewTransactionHistory.aspx.cs" Inherits="centuDY.Views.Pages.Member.ViewTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
     <div>
        <asp:Label ID="lbl_view_transaction_history" runat="server" Text="View Transactions History" Font-Bold="True" Font-Size="X-Large"></asp:Label>      
    </div>
    <div>
         <asp:Label ID="lbl_user_name" runat="server" Text="For Member : " Font-Bold="False" Font-Size="Large"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="grv_user_transactions" runat="server" AutoGenerateColumns="False" OnRowCreated="grv_user_transactions_RowCreated" OnRowDataBound="grv_user_transactions_RowDataBound">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" SortExpression="TransactionId" />
                <asp:BoundField DataField="Medicine.Name" HeaderText="Medicine Name" SortExpression="Medicine.Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="HeaderTransaction.TransactionDate" HeaderText="Transaction Date" SortExpression="HeaderTransaction.TransactionDate" />
                <asp:TemplateField HeaderText="Sub Total">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sub_total" runat="server" Text='<%# ((Convert.ToInt32(Eval("Quantity")))*(Convert.ToInt32(Eval("Medicine.Price"))))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>    
        <table>
            <tr>
                <td>
                     <asp:Label ID="lbl_grand" runat="server" Text="Grand Total For All Transactions: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
                     <asp:Label ID="lbl_grand_total" runat="server" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
