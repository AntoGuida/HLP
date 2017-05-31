<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HistoriaClinica.aspx.cs" Inherits="HLP.HistoriaClinica" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="pnlConsulta" runat="server">

            <h3>HISTORIA CLINICA</h3>

        </asp:Panel>

    </div>
    <asp:Panel ID="pnlEdicion" runat="server">
        <table class="table table-bordered">
            <tr>
                <th>
                    <div>

                        <label runat="server" class="control-label col-sm-2" for="TipoDoc">Tipo Documento:</label><br />
                        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoDoc_SelectedIndexChanged" Width="200px" />
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="NroDoc">Número Documento:</label><br />
                        <asp:TextBox ID="txtNroDoc" runat="server" AutoCompleteType="Enabled" ClientIDMode="Static" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvNroDoc" runat="server" ControlToValidate="txtNroDoc" />
                        <asp:RegularExpressionValidator ID="revNroDoc" runat="server" ControlToValidate="txtNroDoc" Display="Dynamic" CssClass="Validador" ValidationExpression="(\d)+" ErrorMessage="Número de documento no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnconsultaPaciente" runat="server" CssClass="btn btn-primary" OnClick="butConsultaPaciente_Click" Text="Existe" ValidationGroup="A" /><br />
                        <asp:Label ID="lblExiste" runat="server" ForeColor="Red" Visible="False">Paciente no encontrado.</asp:Label>
                    </div>

                </th>
            </tr>
        </table>
        <label runat="server" class="control-label col-sm-2" for="Nombre">Nombre:</label>
        <asp:TextBox ID="txtNombrePac" runat="server"></asp:TextBox>
        <br />
        <label runat="server" class="control-label col-sm-2" for="TipoDoc">Antecedentes:</label>

        <div id="mostrar">
            <asp:TextBox ID="txtAntecedentes" runat="server" Height="48px" Width="529px"></asp:TextBox>

        </div>



        <br />


        <asp:GridView ID="dgvDetallesHC" runat="server"></asp:GridView>

        <asp:Button ID="btnAgregarDHC" runat="server" Text="Nueva Atención" OnClick="btnAgregarDHC_Click" />


        <asp:Panel ID="pnNuevoDetalle" Visible="false" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Fecha:"></asp:Label>
            <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Especialidad:"></asp:Label>
            <asp:TextBox ID="txtEsp" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Médico:"></asp:Label>
            <asp:TextBox ID="txMed" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Práctica:"></asp:Label>
            <asp:TextBox ID="txtPra" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="txtDes" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>

            <asp:Button ID="btnAceptar" runat="server" Text="Agregar" />
        </asp:Panel>
    </asp:Panel>

    <script type="text/javascript">  
        $(function () {
            $("#MainContent_txtEsp").autocomplete({
                source: function (request, response) {
                    var param = { cityname: $('#MainContent_txtEsp').val() };
                    $.ajax({
                        url: "HistoriaClinica.aspx/GetEsp",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(errorThrown);
                        }
                    });
                },
                minLength: 2//minLength as 2, it means when ever user enter 2 character in TextBox the AutoComplete method will fire and get its source data. 
            });
        });

        $(function () {
            $("#MainContent_txtMed").autocomplete({
                source: function (request, response) {
                    var param = { cityname: $('#MainContent_txtMed').val() };
                    $.ajax({
                        url: "HistoriaClinica.aspx/GetMed",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(errorThrown);
                        }
                    });
                },
                minLength: 2//minLength as 2, it means when ever user enter 2 character in TextBox the AutoComplete method will fire and get its source data. 
            });
        });

        $(function () {
            $("#MainContent_txtPra").autocomplete({
                source: function (request, response) {
                    var param = { cityname: $('#MainContent_txtPra').val() };
                    $.ajax({
                        url: "HistoriaClinica.aspx/GetPra",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(errorThrown);
                        }
                    });
                },
                minLength: 2//minLength as 2, it means when ever user enter 2 character in TextBox the AutoComplete method will fire and get its source data. 
            });
        });



        $(document).ready(function () {


        })








    </script>

</asp:Content>
