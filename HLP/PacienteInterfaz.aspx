<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PacienteInterfaz.aspx.cs" Inherits="HLP.PacienteInterfaz" EnableEventValidation="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <link href="Content/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>

    <div>
        <asp:Panel ID="pnlConsulta" runat="server" HorizontalAlign="Center">

            <h3>REGISTRO DE PACIENTES</h3>

        </asp:Panel>
    </div>

    <asp:Panel ID="pnlEdicion" runat="server">
        <table class="table table-bordered">

            <tr>
                <th>
                    <div>

                        <label runat="server" class="control-label col-sm-2" style="text-align:  start;" for="TipoDoc;">Tipo Documento:</label><br /><br />
                        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoDoc_SelectedIndexChanged" Width="200px" />
                        <asp:RequiredFieldValidator ID="reqTipoDoc" runat="server" ControlToValidate="ddlTipoDoc" ErrorMessage="Dato obligatorio" />
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align: start;"  for="NroDoc">N° Documento:</label><br /><br />
                        <asp:TextBox ID="txtNroDoc" runat="server" AutoCompleteType="Enabled" ClientIDMode="Static" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="reqtxtNroDoc" runat="server" ControlToValidate="txtNroDoc" ErrorMessage="Dato obligatorio"  Font-Italic="true" ForeColor="red" />
                        <asp:RegularExpressionValidator ID="revNroDoc" runat="server" ControlToValidate="txtNroDoc" Display="Dynamic" CssClass="Validador" ValidationExpression="(\d)+" ErrorMessage="Número de documento no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div> <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnconsultaPaciente" runat="server" CssClass="btn btn-primary" OnClick="butConsultaPaciente_Click" Text="Validar Existencia" ValidationGroup="A" /><br />
                        <asp:Label ID="lblExiste" runat="server" ForeColor="Red" Visible="False">Paciente no encontrado.</asp:Label>
                    </div>

                </th>
            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Apellido">Apellido:</label><br />
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                         <asp:RequiredFieldValidator ID="reqtxtApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Dato obligatorio"  Font-Italic="true" ForeColor="red" />
                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido"
                            Display="Dynamic" CssClass="Validador" ValidationExpression="[^<^>^%]+" ErrorMessage="Apellido no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Nombre">Nombre:</label><br />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="reqtxtNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Dato obligatorio"  Font-Italic="true" ForeColor="red" />
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic" CssClass="Validador" ValidationExpression="[^<^>^%]+" ErrorMessage="Nombre no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Sexo">Sexo:</label><br />
                        <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSexo_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>
            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="txtFechaNacimiento">Fecha Nacimiento:</label><br /><br />
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:CompareValidator ID="reqtxtFecha" runat="server" ControlToValidate="txtFechaNacimiento" Operator="DataTypeCheck" Display="Dynamic" Type="String" ErrorMessage="Fecha no válida" ForeColor="Red"></asp:CompareValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Dato obligatorio"  Font-Italic="true" ForeColor="red" />
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="txtDomicilio">Domicilio:</label><br />
                        <asp:TextBox ID="txtDomicilio" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </th>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="txtTelefono">Teléfono:</label><br />
                        <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" CssClass="Validador" ValidationExpression="(\d)+" ErrorMessage="Teléfono no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>

                </th>

            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Provincia">Provincia:</label><br />
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>
                <th>


                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Localidad">Localidad:</label><br />
                        <asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>
                <th>

                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Barrio">Barrio:</label><br />
                        <asp:DropDownList ID="ddlBarrio" runat="server" class="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" Width="200px"  />
                    </div>
                </th>

            </tr>

            <tr>
                <th>
                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="Provincia">Obra Social:</label><br /><br />
                        <asp:TextBox ID="txtCity" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Dato obligatorio" Font-Italic="true" ForeColor="red" />
                    </div>

                </th>
                <th>

                    <div>
                        <label class="control-label col-sm-2" style="text-align:  start;" for="NroObraSocial">NºObra Social:</label><br /><br />
                        <asp:TextBox ID="txtNroObraSocial" runat="server" class="form-control"></asp:TextBox>
                    </div>

                </th>
                <th>
                    <div>
                    <label class="control-label col-sm-2" style="text-align:  start;" for="Email">Correo electrónico:</label><br /><br />
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" CssClass="Validador" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Email no válido" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>

                </th>

            </tr>
        </table>

        <div class="form-group">
           <%-- <div class="col-sm-10 col-sm-offset-9">--%>
                <asp:Button ID="butGrabar"  runat="server"  BackColor="#00CC99" class="btn btn-danger" ForeColor="Black" OnClick="butGrabar_Click" Text="Guardar" CausesValidation="True" />
                <asp:Label ID="lblGuardar" runat="server" for="estado"  ForeColor="#00CC95" Visible="False">Paciente registrado con éxito!</asp:Label>
                <asp:Button ID="butEliminarConfirmar" runat="server" BackColor="#CC3300" class="btn btn-primary" OnClick="butEliminarCofirmar_Click" Text="Registrar Antecedentes" Visible="True" />
                <asp:Button ID="btnConsultar"  runat="server"  BackColor="#CC3366" class="btn btn-primary" Text="Consultar Pacientes" Visible="True" OnClick="btnConsultar_Click1"  />

       <%--     </div>--%>
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


