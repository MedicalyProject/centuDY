<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewTransactionsReport.aspx.cs" Inherits="centuDY.Views.Pages.Admin.ViewTransactionsReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_content" runat="server">
    <CR:CrystalReportViewer ID="crv_centuDY" runat="server" AutoDataBind="true" />
</asp:Content>
