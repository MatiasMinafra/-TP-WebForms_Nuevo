<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="Tp_WebForms_Nuevo.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-4 text-center">Datos del Cliente</h2>

    <div class="row justify-content-center">
        <div class="col-md-6">

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-info mb-3 d-block"></asp:Label>

            <asp:Label runat="server" Text="DNI" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control mb-3" />

            <asp:Button ID="btnBuscar" runat="server"
                Text="Buscar DNI"
                CssClass="btn btn-secondary w-100 mb-4"
                OnClick="btnBuscar_Click" />

            <asp:Label runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mb-3" />

            <asp:Label runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control mb-3" />

            <asp:Label runat="server" Text="Email" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" />

            <asp:Label runat="server" Text="Dirección" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control mb-3" />

            <asp:Label runat="server" Text="Ciudad" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control mb-3" />

            <asp:Label runat="server" Text="Código Postal" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control mb-3" />

            <asp:Button ID="btnParticipar" runat="server"
                Text="¡Participar!"
                CssClass="btn btn-primary w-100 mt-3"
                OnClick="btnParticipar_Click" />

            <asp:Label ID="lblError" runat="server" CssClass="text-danger d-block mt-3"></asp:Label>

        </div>
    </div>

</asp:Content>
