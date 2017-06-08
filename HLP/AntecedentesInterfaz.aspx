<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AntecedentesInterfaz.aspx.cs" Inherits="HLP.AntecedentesInterfaz" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <div>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">

            <h3>REGISTRO DE ANTECEDENTES</h3>

        </asp:Panel>
    </div>

    <asp:Panel ID="pnlConsulta" runat="server">
        <div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Apellido:" HorizontalAlign="Center" ForeColor="Red"></asp:Label>&nbsp;
            <asp:Label ID="lblApellido" runat="server" HorizontalAlign="Center" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3"  runat="server" HorizontalAlign="Center" Text="Nombre:" ForeColor="Red"></asp:Label>&nbsp;
            <asp:Label ID="lblNombre"  runat="server" HorizontalAlign="Center" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
        <asp:CheckBoxList ID="chkAnt1" runat="server" Width="130px" >
        </asp:CheckBoxList>

        <asp:Button ID="Button1" runat="server"  BackColor="#CC3366" class="btn btn-primary" OnClick="Button1_Click" Text="Guardar" />
        <asp:Label ID="lblGuardar" runat="server"  for="estado" ForeColor="#00CC95" Visible="False">Antecedente registrado con éxito!</asp:Label>


    </asp:Panel>

</asp:Content>


