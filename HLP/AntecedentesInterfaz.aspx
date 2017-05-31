<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AntecedentesInterfaz.aspx.cs" Inherits="HLP.AntecedentesInterfaz" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlConsulta" runat="server">
        <div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Apellido:" ForeColor="Red"></asp:Label>&nbsp;
            <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nombre:" ForeColor="Red"></asp:Label>&nbsp;
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
        <asp:CheckBoxList ID="chkAnt1" runat="server" Width="130px" >
        </asp:CheckBoxList>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
        <asp:Label ID="lblGuardar" runat="server" for="estado" ForeColor="#00CC99" Visible="False">Antecedente registrado con éxito!</asp:Label>


    </asp:Panel>

</asp:Content>


