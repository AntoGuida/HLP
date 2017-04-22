<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PacienteInterfaz.aspx.cs" Inherits="HLP.PacienteInterfaz" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type"  content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlConsulta" runat="server">
                <h3>PACIENTE</h3>
                
            </asp:Panel>
        </div>
  
     <asp:Panel ID="pnlEdicion" runat="server">
        <div class="form-horizontal">
            <hr />

            <div class="form-group">                
                <div class="col-sm-10">    
                    <label class="control-label col-sm-2" for="TipoDoc">Tipo Doc:</label>
                    <asp:DropDownList Cssclass="form-control" ID="ddlTipoDoc" runat="server" />
                     <label class="control-label col-sm-2" for="NroDoc">Número Doc:</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" ID="txtNroDoc" />
                      <asp:RequiredFieldValidator ID="rfvNroDoc"
                            runat="server"
                            ControlToValidate="txtNroDoc"
                            ErrorMessage="Ingrese número de documento..."
                            ForeColor="Red"
                            Text="*" ValidationGroup="A" />
                    <br />
                </div>
            </div>
           
            <asp:Button class="btn btn-primary" ID="btnconsultaPaciente" runat="server" OnClick="butConsultaPaciente_Click" Text="Existe" ValidationGroup="A" />
             <asp:label runat="server" for="estado"  visible="False" ID="lblExiste" ForeColor="Red">Paciente no encontrado.</asp:label>

            <div class="form-group">
                  <div class="col-sm-10">
                       <label class="control-label col-sm-2" for="Apellido">Apellido:</label>
                    <asp:TextBox runat="server" Apellido="Static" Cssclass="form-control" ID="txtApellido"  placeholder="Ingrese apellido"  />
                      <label class="control-label col-sm-2" for="Nombre">Nombre:</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" ID="txtNombre" placeholder="Ingrese nombre" Width="223px" />
                       <br />
                </div>
            </div>

            <div class="form-group">
                
                <div class="col-sm-10">
                    
                    <%--<input type="text" class="form-control" id="ApellidoNombre" placeholder="ingrese apellido y nombre" required="required"/>--%>
                </div>
                <label class="control-label col-sm-2" for="Sexo">
                Sexo:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="True" class="form-control" />
                    <label class="control-label col-sm-2" for="txtFechaNacimiento">
                    Fecha de nacimiento:</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" type="date" Width="165px"></asp:TextBox>
                    <br />
                </div>
            </div>


           
            <div class="form-group">
                
                <div class="col-sm-10">
                    <%--<input class="form-control" type='date' id='FechaNacimiento' />--%>
                   
                </div>
                <label class="control-label col-sm-2" for="txtDomicilio">
                Domicilio:</label>
                <asp:TextBox ID="txtDomicilio" runat="server" class="form-control"></asp:TextBox>
                <br />
            </div>




            <div class="form-group">
                <label class="control-label col-sm-2" for="Provincia">Provincia:</label>
                <asp:DropDownList class="form-control" ID="ddlProvincia" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="True" />
                <label class="control-label col-sm-2" for="Localidad">Localidad:</label>
                <asp:DropDownList class="form-control" ID="ddlLocalidad" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="True" />
                <label class="control-label col-sm-2" for="Barrio">Barrio:</label>
                <asp:DropDownList class="form-control" ID="ddlBarrio" runat="server" AutoPostBack="True" />
                <br />
                <div class="col-sm-10">
                </div>
                <label class="control-label col-sm-2" for="txtTelefono">
                Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
                <label class="control-label col-sm-2" for="Email">
                Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                <br />
                <div class="col-sm-10">
                    <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%>
                    

                    <%--<input class="form-control" type='number' id='cuit' />--%>
                    

                </div>
                <label class="control-label col-sm-2" for="ObraSocial">
                Obra Social:</label>
                <asp:DropDownList ID="ddlObraSocial" runat="server" class="form-control" />
                <label class="control-label col-sm-2" for="NroObraSocial">
                Nº Obra Social:</label>
                <asp:TextBox ID="txtNroObraSocial" runat="server" class="form-control"></asp:TextBox>
                <br />
                <div class="col-sm-10">
                    <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%><%--<input class="form-control" type='number' id='cuit' />--%>
                </div>
                <label class="control-label col-sm-2" for="Antecedentes">
                Antecedentes:</label>
                <asp:TextBox ID="txtAntecedentes" runat="server" class="form-control" Height="46px" Width="351px"></asp:TextBox>
                <div class="col-sm-10">
                    <%--<input class="form-control" type='number' id='cuit' />--%>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10 col-sm-offset-2">
                    <asp:Button class="btn btn-primary" ID="butGrabar" runat="server" OnClick="butGrabar_Click" Text="Guardar" />
                    <asp:label runat="server" for="estado"  visible="False" ID="lblGuardar" ForeColor="Red">Paciente registrado con éxito!</asp:label>
                    <%--<asp:Button class="btn btn-primary" ID="butEliminarConfirmar" runat="server"
                        OnClick="butEliminarConfirmar_Click" Text="Confirmar Eliminacion"
                        Visible="False" />
                    <asp:Button class="btn btn-danger" ID="butCancelar" runat="server" OnClick="butCancelar_Click"
                        Text="Cancelar/Volver" CausesValidation="False" />--%>


                    <%--<input class="btn btn-primary" type='submit' value='Grabar' />--%>
                    <%--<input class="btn btn-danger"  type="cancel" value='Cancelar' />--%>
                </div>
            </div>

        </div>
    </asp:Panel>
        </div>
    </form>
</body>
</html>
