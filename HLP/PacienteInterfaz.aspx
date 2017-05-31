﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PacienteInterfaz.aspx.cs" Inherits="HLP.PacienteInterfaz" EnableEventValidation="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <link href="Content/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>

    <div>
        <asp:Panel ID="pnlConsulta" runat="server">

            <h3>PACIENTE</h3>

        </asp:Panel>
    </div>

    <asp:Panel ID="pnlEdicion" runat="server">
        <table class="table table-bordered">

            <tr>
                <th>
                    <div>

                        <label runat="server" class="control-label col-sm-2" for="TipoDoc">Tipo Doc:</label><br />
                        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoDoc_SelectedIndexChanged" Width="200px" />
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="NroDoc">Número Doc:</label><br />
                        <asp:TextBox ID="txtNroDoc" runat="server" AutoCompleteType="Enabled" ClientIDMode="Static" CssClass="form-control"/>
                       <asp:RequiredFieldValidator ID="rfvNroDoc" runat="server" ControlToValidate="txtNroDoc" />
                        <asp:RegularExpressionValidator ID="revNroDoc" runat="server" ControlToValidate="txtNroDoc" Display="Dynamic" CssClass="Validador" ValidationExpression="(\d)+" ErrorMessage="Número de documento no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div> <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnconsultaPaciente" runat="server" CssClass="btn btn-primary" OnClick="butConsultaPaciente_Click" Text="Existe" ValidationGroup="A" /><br />
                        <asp:Label ID="lblExiste" runat="server" ForeColor="Red" Visible="False">Paciente no encontrado.</asp:Label>
                    </div>

                </th>
            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="Apellido">Apellido:</label><br />
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido"
                            Display="Dynamic" CssClass="Validador" ValidationExpression="[^<^>^%]+" ErrorMessage="Apellido no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="Nombre">Nombre:</label><br />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic" CssClass="Validador" ValidationExpression="[^<^>^%]+" ErrorMessage="Nombre no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="Sexo">Sexo:</label><br />
                        <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSexo_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>
            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="txtFechaNacimiento">Fecha de Nacimiento:</label><br />
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:CompareValidator ID="revfecha_nacimiento" runat="server" ControlToValidate="txtFechaNacimiento" Operator="DataTypeCheck" Display="Dynamic" Type="Date" ErrorMessage="Fecha no válida" ForeColor="Red"></asp:CompareValidator>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="txtDomicilio">Domicilio:</label><br />
                        <asp:TextBox ID="txtDomicilio" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="txtTelefono">Teléfono:</label><br />
                        <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" CssClass="Validador" ValidationExpression="(\d)+" ErrorMessage="Teléfono no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>

                </th>

            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="Provincia">Provincia:</label><br />
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>
                <th>


                    <div>
                        <label class="control-label col-sm-2" for="Localidad">Localidad:</label><br />
                        <asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>
                <th>

                    <div>
                        <label class="control-label col-sm-2" for="Barrio">Barrio:</label><br />
                        <asp:DropDownList ID="ddlBarrio" runat="server" class="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>

            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" for="Provincia">Obra Social:</label><br />
                        <asp:TextBox ID="txtCity" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>
                    </div>

                </th>
                <th>

                    <div>
                        <label class="control-label col-sm-2" for="NroObraSocial">Nº Obra Social:</label><br />
                        <asp:TextBox ID="txtNroObraSocial" runat="server" class="form-control"></asp:TextBox>
                    </div>

                </th>
                <th>
                    <div>
                    <label class="control-label col-sm-2" for="Email">Email:</label><br />
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" CssClass="Validador" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Email no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>

                </th>

            </tr>
        </table>

        <div class="form-group">
            <div class="col-sm-10 col-sm-offset-9">
                <asp:Button ID="butGrabar" runat="server" BackColor="#00CC99" class="btn btn-danger" ForeColor="Black" OnClick="butGrabar_Click" Text="Guardar" CausesValidation="True" />
                <asp:Label ID="lblGuardar" runat="server" for="estado" ForeColor="#00CC95" Visible="False">Paciente registrado con éxito!</asp:Label>
                <asp:Button ID="butEliminarConfirmar" runat="server" BackColor="#CC3300" class="btn btn-primary" OnClick="butEliminarCofirmar_Click" Text="Registrar Antecedentes" Visible="True" />

            </div>
        </div>



    </asp:Panel>



    <script type="text/javascript">  
        $(function () {
            $("#MainContent_txtCity").autocomplete({
                source: function (request, response) {
                    var param = { cityname: $('#MainContent_txtCity').val() };
                    $.ajax({
                        url: "PacienteInterfaz.aspx/GetCities",
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

    </script>
</asp:Content>


