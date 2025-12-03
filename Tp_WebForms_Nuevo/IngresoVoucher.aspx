<%@ Page Title="Ingresar Voucher" Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="IngresoVoucher.aspx.cs"
    Inherits="Tp_WebForms_Nuevo.IngresoVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-4 text-center">Ingresá tu código de voucher</h2>

    <asp:TextBox ID="txtCodigo" runat="server" 
        CssClass="form-control mb-3"
        placeholder="Ej: ABC123XYZ"></asp:TextBox>

    <asp:Button ID="btnValidar" runat="server"
        Text="Validar Código"
        CssClass="btn btn-primary w-100"
        OnClick="btnValidar_Click" />

    <asp:Label ID="lblError" runat="server"
        CssClass="text-danger d-block mt-3"></asp:Label>

</asp:Content>