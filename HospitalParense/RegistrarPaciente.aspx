<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="HospitalParense.About" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:Panel ID="pnlConsulta" runat="server">
        <div>
            <h3>Clientes</h3>
            <hr />
            <div class="form-group">
                <label class="control-label col-sm-2" for="txtNombreBuscar">Paciente a buscar:</label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" ID="txtNombreBuscar" />
                </div>
                <div class="col-sm-2">
                    <asp:Button class="btn btn-default" ID="butBuscar" runat="server" Text="Buscar" OnClick="butBuscar_Click" />
                </div>
            </div>
          <asp:GridView CssClass="table table-striped table-bordered table-condensed"
                ID="gvDatos" runat="server" DataKeyNames="IdCliente" EmptyDataText="Sin registros..." AllowPaging="True">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                </Columns>
                <SelectedRowStyle CssClass="gvSelectedRowStyle" />
                <PagerStyle CssClass="gvPagerStyle" />
            </asp:GridView>
            <br />
            <asp:Button class="btn btn-default" ID="butAgregar" runat="server" OnClick="butAgregar_Click" Text="Agregar" />
            <asp:Button class="btn btn-default" ID="butConsultar" runat="server" OnClick="butConsultar_Click" Text="Consultar" />
            <asp:Button class="btn btn-default" ID="butEliminar" runat="server" Text="Eliminar" OnClick="butEliminar_Click" />
            <asp:Button class="btn btn-default" ID="butEditar" runat="server" Text="Editar" OnClick="butEditar_Click" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlEdicion" runat="server" Visible="False">

        <div class="form-horizontal">
            <h3>Clientes
                <asp:Label CssClass="warning" ID="lblAccion" runat="server" Text="Agregando..."></asp:Label></h3>
            <hr />

            <div class="form-group">
                <label class="control-label col-sm-2" for="Apellido">Apellido:</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" Apellido="Static" class="form-control" ID="txtApellido"  placeholder="Ingrese apellido"  />
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2" for="Nombre">Nombre:</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" ID="txtNombre" placeholder="Ingrese nombre" />
                    <%--<input type="text" class="form-control" id="ApellidoNombre" placeholder="ingrese apellido y nombre" required="required"/>--%>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2" for="TipoDoc">Tipo Doc:</label>
                <div class="col-sm-10">
                    <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%>
                    <asp:DropDownList class="form-control" ID="ddlTipoDoc" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2" for="NroDoc">Número Doc:</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" ID="txtNroDoc" />
                    <%--<input type="text" class="form-control" id="ApellidoNombre" placeholder="ingrese apellido y nombre" required="required"/>--%>
                </div>
            </div>
           

            <div class="form-group">
                <label class="control-label col-sm-2" for="txtFechaNacimiento">Fecha de nacimiento:</label>
                <div class="col-sm-10">
                    <%--<input class="form-control" type='date' id='FechaNacimiento' />--%>
                    <asp:TextBox CssClass="form-control tipoFecha" ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                </div>
            </div>

             <div class="form-group">
                <label class="control-label col-sm-2" for="sexo">Sexo:</label>
                <div class="controls radio col-sm-10">
                    <label class="radio-inline">
                        <asp:RadioButtonList ID="radSexo" runat="server">
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                        </asp:RadioButtonList>
                    </label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2" for="txtDomicilio">Domicilio:</label>
                <div class="col-sm-10">
                    <%--<input class="form-control" type='number' id='cuit' />--%>
                    <asp:TextBox class="form-control" ID="txtDomicilio" runat="server"></asp:TextBox>
                </div>
            </div>

                  


            <div class="form-group">
                <label class="control-label col-sm-2" for="Provincia">Provincia:</label>
                <div class="col-sm-10">
                    <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%>
                    <asp:DropDownList class="form-control" ID="ddlProvincia" runat="server" />
                </div>
            </div>

             <div class="form-group">
                <label class="control-label col-sm-2" for="Localidad">Localidad:</label>
                <div class="col-sm-10">
                    <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%>
                    <br />
                    <asp:DropDownList class="form-control" ID="ddlLocalidad" runat="server" />
                </div>
            </div>

             <div class="form-group">
                <label class="control-label col-sm-2" for="Barrio">Barrio:</label>
                <div class="col-sm-10">
                    <%--<select class="form-control" name="Provincia">
                        <option selected="selected" value="X">CORDOBA</option>
                        <option value="B">BUENOS AIRES</option>
                        <option value="S">SANTA FE</option>
                        <option value="P">LA PAMPA</option>
                    </select>--%>
                    <asp:DropDownList class="form-control" ID="ddlBarrio" runat="server" />
                </div>
            </div>

              <div class="form-group">
                <label class="control-label col-sm-2" for="txtTelefono">Teléfono:</label>
                <div class="col-sm-10">
                    <%--<input class="form-control" type='number' id='cuit' />--%>
                    <asp:TextBox class="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10 col-sm-offset-2">
                    <asp:Button class="btn btn-primary" ID="butGrabar" runat="server" OnClick="butGrabar_Click" Text="Grabar" />
                    <asp:Button class="btn btn-primary" ID="butEliminarConfirmar" runat="server"
                        OnClick="butEliminarConfirmar_Click" Text="Confirmar Eliminacion"
                        Visible="False" />
                    <asp:Button class="btn btn-danger" ID="butCancelar" runat="server" OnClick="butCancelar_Click"
                        Text="Cancelar/Volver" CausesValidation="False" />
                    <%--<input class="btn btn-primary" type='submit' value='Grabar' />--%>
                    <%--<input class="btn btn-danger"  type="cancel" value='Cancelar' />--%>
                </div>
            </div>

        </div>
    </asp:Panel>
    <br />
    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-warning help-block"></asp:Label>
</asp:Content>

