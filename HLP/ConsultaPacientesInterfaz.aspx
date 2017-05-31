<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaPacientesInterfaz.aspx.cs" Inherits="HLP.ConsultaPacientesInterfaz" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <link href="Content/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>


      <div>
        <asp:Panel ID="pnlConsulta" runat="server" HorizontalAlign="Center">

            <h3>CONSULTA DE PACIENTES</h3>

        </asp:Panel>
    </div>


    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:GridView ID="dgvPaciente" class="table" runat="server" AllowSorting="true" OnSorting="ordenar" Width="564px" HorizontalAlign="Center">
        </asp:GridView>
    </asp:Panel>
</asp:Content>
