<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="Tp_WebForms_Nuevo.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row justify-content-center mt-5">
        <div class="col-md-6 text-center">

            <h2 class="mb-4 text-success">¡Participación exitosa!</h2>

            <p class="lead">
                ¡Gracias por participar en nuestra promoción!  
                Tu registro y selección del premio fueron completados correctamente.
            </p>

            <asp:Button 
                ID="btnVolver" 
                runat="server" 
                Text="Volver al inicio" 
                CssClass="btn btn-primary mt-4"
                OnClick="btnVolver_Click" />
        </div>
    </div>

</asp:Content>
