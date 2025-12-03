<%@ Page Title="Error" Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="ErrorVoucher.aspx.cs"
    Inherits="Tp_WebForms_Nuevo.ErrorVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center mt-5">

        <asp:Label ID="lblMensaje" runat="server" 
            CssClass="text-danger h4 d-block mb-4"></asp:Label>

        <asp:Button 
            ID="btnVolver" 
            runat="server" 
            Text="Volver al inicio" 
            CssClass="btn btn-primary"
            OnClick="btnVolver_Click" />
    </div>

</asp:Content>