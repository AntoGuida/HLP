<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PacienteInterfaz.aspx.cs" Inherits="HLP.PacienteInterfaz" EnableEventValidation="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" type="text/css" />  
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>

     <div>
            <asp:Panel ID="pnlConsulta" runat="server">
                
                <h3>PACIENTE</h3>
                
            </asp:Panel>
     </div>
  
  <asp:Panel ID="pnlEdicion" runat="server">

      
      <table style="width:100%">
          <tr>
              <th>
                  <div class="form-horizontal">
                      <hr />
                      <div class="form-group">
                          <div class="col-sm-10">
                              <label class="control-label col-sm-2" for="TipoDoc">
                              Tipo Doc:</label>
                              <asp:DropDownList ID="ddlTipoDoc" runat="server" Cssclass="form-control" OnSelectedIndexChanged="ddlTipoDoc_SelectedIndexChanged" />
                              <br />
                              <label class="control-label col-sm-2" for="NroDoc">
                              Número Doc:</label>
                              <asp:TextBox ID="txtNroDoc" runat="server" AutoCompleteType="Enabled" ClientIDMode="Static" CssClass="textbox" />
                              &nbsp;<asp:RequiredFieldValidator ID="rfvNroDoc" runat="server" ControlToValidate="txtNroDoc" ErrorMessage="Ingrese número de documento..." ForeColor="Red" Text="*" ValidationGroup="A" />
                              <br />
                          </div>
                      </div>
                      <asp:Button ID="btnconsultaPaciente" runat="server" CssClass="btn btn-primary" OnClick="butConsultaPaciente_Click" Text="Existe" ValidationGroup="A" />
                      <asp:Label ID="lblExiste" runat="server" ForeColor="Red" visible="False">Paciente no encontrado.</asp:Label>
                      <div class="form-group">
                          <div class="col-sm-10">
                              <label class="control-label col-sm-2" for="Apellido">
                              Apellido:</label>
                              <br />
                              <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" PlaceHolder="Ingrese apellido" />
                              <br />
                              <label class="control-label col-sm-2" for="Nombre">
                              Nombre:</label>
                              <br />
                              <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese nombre" Width="120px" />
                              <br />
                          </div>
                      </div>
                      <div class="form-group">
                          <div class="col-sm-10">
                              <%--<input type="text" class="form-control" id="ApellidoNombre" placeholder="ingrese apellido y nombre" required="required"/>--%>
                          </div>
                          <label class="control-label col-sm-2" for="Sexo">
                          Sexo:</label>
                          <br />
                          <div class="col-sm-10">
                              <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="True" CssClass="form-control" />
                              <label class="control-label col-sm-2" for="txtFechaNacimiento">
                              Fecha de nacimiento:</label>
                              <br />
                              <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="165px"></asp:TextBox>
                              <br />
                          </div>
                      </div>
                  </div>
              </th>
              <th>
                  <div class="form-group">
                      <div class="col-sm-20">
                          <label class="control-label col-sm-2" for="txtDomicilio">
                          Domicilio:</label>
                          <br />
                          <asp:TextBox ID="txtDomicilio" runat="server" class="form-control"></asp:TextBox>
                          <br />
                      </div>
                  </div>
                  <div class="form-group">
                      <label class="control-label col-sm-2" for="Provincia">
                      Provincia:</label>
                      <br />
                      <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />
                      <br />
                      <label class="control-label col-sm-2" for="Localidad">
                      Localidad:</label>
                      <br />
                      <asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" />
                      <br />
                      <br />
                      <label class="control-label col-sm-2" for="Barrio">
                      Barrio:</label>
                      <br />
                      <asp:DropDownList ID="ddlBarrio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" />
                      <br />
                      <label class="control-label col-sm-2" for="txtTelefono">
                      Teléfono:</label>
                      <br />
                      <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
                      <br />
                      <label class="control-label col-sm-2" for="Email">
                      Email:</label>
                      <br />
                      <asp:TextBox ID="txtEmail" runat="server" class="form-control" Height="20px" Width="140px"></asp:TextBox>
                      <br />
                      <div class="col-sm-20">
                          <label class="control-label col-sm-2" for="ObraSocial">
                          Obra Social:</label>
                          <br />
                          <asp:DropDownList ID="ddlObraSocial" runat="server" class="form-control" />
                          <br />
                          <asp:TextBox ID="txtCity" runat="server" AutoCompleteType="Enabled" class="form-control"></asp:TextBox>
                          <br />
                          <label class="control-label col-sm-2" for="NroObraSocial">
                          Nº Obra Social:</label>
                          <br />
                          <asp:TextBox ID="txtNroObraSocial" runat="server" class="form-control"></asp:TextBox>
                          <br />
                          <div/>
                          <div class="col-sm-10">
                              <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%><%--<input class="form-control" type='number' id='cuit' />--%>
                          </div>
                          <%--<label class="control-label col-sm-2" for="Antecedentes">
                Antecedentes:</label>--%>
                          <br />
                          <%--<asp:TextBox ID="txtAntecedentes" runat="server" class="form-control" Height="46px" Width="351px"></asp:TextBox>
                <div class="col-sm-10">--%><%--<input class="form-control" type='number' id='cuit' />--%>
                      </div>
                  </div>
                  <div class="form-group">
                      <div class="col-sm-10 col-sm-offset-2">
                          <asp:Button ID="butGrabar" runat="server" BackColor="#00CC99" class="btn btn-danger" ForeColor="Black" OnClick="butGrabar_Click" Text="Guardar" />
                          <asp:Label ID="lblGuardar" runat="server" for="estado" ForeColor="#00CC99" visible="False">Paciente registrado con éxito!</asp:Label>
                          <asp:Button ID="butEliminarConfirmar" runat="server" BackColor="#CC3300" class="btn btn-primary" OnClick="butEliminarCofirmar_Click" Text="Registrar Antecedentes" Visible="True" />
                          <%--<asp:Button class="btn btn-danger" ID="butCancelar" runat="server" OnClick="butCancelar_Click"
                        Text="Cancelar/Volver" CausesValidation="False" />--%><%--<input class="btn btn-primary" type='submit' value='Grabar' />--%><%--<input class="btn btn-danger"  type="cancel" value='Cancelar' />--%>
                      </div>
                  </div>
              </th>
          </tr>
      </table>


  </asp:Panel>
  

	
<script type="text/javascript">  
        $(function () {
            $("#txtCity").autocomplete({
                source: function (request, response) {
                    var param = { cityname: $('#txtCity').val() };
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


