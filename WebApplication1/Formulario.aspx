<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Segundo Laboratorio</title>
    <script type = "text/javascript">
        function limpiar_contenido() {
            var vacio = '';
            document.getElementById('InputNombre').value = vacio;
            document.getElementById('InputApellido').value = vacio;
            document.getElementById('InputRadioM').checked = false;
            document.getElementById('InputRadioF').checked = false;
            document.getElementById('InputEmail').value = vacio;
            document.getElementById('InputDireccion').value = vacio;
            document.getElementById('OpcionesCiudad').value = " ";
            document.getElementById('TextAreaRequerimientos').value = vacio;
            return false;
        }
        function enviar_contenido() {
            var nombre = document.getElementById("<%= InputNombre.ClientID %>").value;
            var apellido = document.getElementById("<%= InputApellido.ClientID %>").value;
            var generoM = document.getElementById("<%= InputSexo.ClientID %>_0").checked;
            var generoF = document.getElementById("<%= InputSexo.ClientID %>_1").checked;
            var ciudad = document.getElementById("<%= OpcionesCiudad.ClientID %>").value;
            var correo = document.getElementById("<%= InputEmail.ClientID %>").value;
            var direccion = document.getElementById("<%= InputDireccion.ClientID %>").value;
            var requerimientos = document.getElementById("<%= TextAreaRequerimientos.ClientID %>").value;
            var validarLetrasNombre = /^([a-zA-Z]+\s+)?[a-zA-Z]+$/;
            var validarLetrasApellido = /^[a-zA-Z]+\s+[a-zA-Z]+$/;
            var validarCorreo = /^[a-z]+@unsa.edu.pe$/;
            var mensajeError = "";

            if (!validarLetrasNombre.test(nombre)) {
                mensajeError += "El nombre debe contener solo letras de la A a la Z, tanto mayúsculas como minúsculas.\n";
            }
            if (!validarLetrasApellido.test(apellido)) {
                mensajeError += "El apellido debe contener solo letras de la A a la Z, tanto mayúsculas como minúsculas.\n";
            }
            if (!validarCorreo.test(correo)) {
                mensajeError += "El correo electrónico no es válido o no utiliza el dominio @unsa.edu.pe\n";
            }
            if (!(generoM || generoF)) {
                mensajeError += "Debe seleccionar un género.\n";
            }
            if (ciudad === "") {
                mensajeError += "Debe seleccionar una ciudad.\n";
            }
            if (direccion === "") {
                mensajeError += "Debe ingresar una dirección.\n";
            }
            if (mensajeError !== "") {
                alert("Error:\n" + mensajeError);
                return false;
            }
            var fechaActual = new Date();
            alert("Registro exitoso.\nFecha de registro: " + fechaActual);
            
            return true;
        }
    </script>
    <style>
        h1{
            color: white;
            margin-left: 16px;
        }
        body{
            font-family: 'Times New Roman';
        }
        input[type="text"]{
            border-radius: 2px;
            border: none;
            border-bottom: 1px solid #7BC6ED;
        }
        input[type="radio"] {
            -webkit-appearance: none; 
            -moz-appearance: none;
            appearance: none;
            width: 12px; 
            height: 12px; 
            border-radius: 5px; 
            border: 1px solid #7BC6ED; 
            outline: none; 
            background-color: transparent; 
        }
        input[type="radio"]:checked {
            background-color: #1671A0; 
        }
        #Encabezado {
            background-color: #1671A0; 
            padding: 10px;
        }
        #OpcionesCiudad{
            border-radius: 10px;
            border: 1px solid #7BC6ED;
        }
        #TextAreaRequerimientos{
            border-radius: 10px;
            border: 1px solid #7BC6ED;
        }
        .BoxNombre,
        .BoxApellido,
        .BoxSexo,
        .BoxEmail,
        .BoxDireccionCiudad,
        .BoxRequerimientos,
        .BoxBotones {
            margin-left:16px;
            padding: 8px;
            display:flex;
            
        }
        .BoxTextNombre,
        .BoxTextApellido,
        .BoxTextSexo,
        .BoxTextEmail,
        .BoxTextDireccion,
        .BoxTextRequerimientos{
            width: 134px;
            height: 32px;
            font-size: 120%;
        }
        .BoxInputNombre,
        .BoxInputApellido,
        .BoxInputSexo,
        .BoxInputEmail,
        .BoxInputDireccion,
        .BoxInputRequerimientos{
            width: 172px;
            height: 32px;
        }
        .BoxTextCiudades{
            margin-left:8px;
            width: 80px;
            height: 32px;
            font-size: 120%;
        }

        .ButtonLimpiar,
        .ButtonEnviar{
            background-color: #1671A0;
            color: white;
            border:none;           
            padding: 10px;
            margin:4px;
            font-family: 'Times New Roman';
            width:128px;
            border-radius:10px;
            font-size: 110%;
        }
    </style>
</head>
<body>
    <div id="Encabezado">
        <h1>Registro de Alumnos:</h1>
    </div>
    <form id="ButtonsEnviarLimpiar" runat="server">
        <section class="BoxNombre">
            <div class="BoxTextNombre">
                <label for="InputNombre">Nombre:</label>
            </div>
            <div class="BoxInputNombre">
                <asp:TextBox runat="server" ID="InputNombre" title="Ingrese su nombre" />
            </div>
        </section>
        <section class="BoxApellido">
            <div class="BoxTextApellido">
                <label for="InputApellido">Apellidos:</label>
            </div>
            <div class="BoxInputApellido">
                <asp:TextBox runat="server"  ID="InputApellido" title="Ingrese sus apellidos" />
            </div>
        </section>
        <section class="BoxSexo">
            <div class="BoxTextSexo">
                <label>Sexo:</label>
            </div>
            <div class="BoxInputSexo">
                <asp:RadioButtonList ID="InputSexo" runat="server">
                    <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                </asp:RadioButtonList>       
            </div>
        </section>
        <section class="BoxEmail">
            <div class="BoxTextEmail">
                <label for="InputEmail">Email:</label>
            </div>
            <div class="BoxInputEmail">
                <asp:TextBox runat="server"  ID="InputEmail" title="Ingrese su dirección de correo electrónico" />
            </div>
        </section>
        <section id="Direccion" class="BoxDireccionCiudad">
            <div class="BoxTextDireccion">
                <label for="InputDireccion">Dirección:</label>
            </div>
            <div class="BoxInputDireccion">
                <asp:TextBox runat="server"  ID="InputDireccion" title="Ingrese su dirección" />
            </div>
            <div class="BoxTextCiudades">
                <label for="OpcionesCiudad">Ciudad:</label>        
            </div>
            <div class="BoxInputCiudades">
                <asp:DropDownList ID="OpcionesCiudad" runat="server"></asp:DropDownList>
            </div>
        </section>
        <section id="Requirimientos" class="BoxRequerimientos">
            <div class="BoxTextRequerimientos">
                <label for="TextAreaRequerimientos">Requerimientos: </label>
            </div>
            <div class="BoxInputRequerimientos">
                <asp:TextBox ID="TextAreaRequerimientos" runat="server" TextMode="MultiLine" Rows="2" Columns="47" Wrap="true" title="Ingrese su requerimiento"></asp:TextBox>
            </div>
        </section>
        <section id="BotonesRequerimientos" class="BoxBotones">
            <div>
                <input type="button" class="ButtonLimpiar" id="ButtonLimpiar" value="Limpiar" onclick="return limpiar_contenido()" />
            </div>
            <div>
                <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar" OnClientClick="var a = enviar_contenido(); return a;" class="ButtonEnviar" OnClick="ButtonEnviar_Click" />
            </div>
        </section>
        <asp:TextBox ID="MostrarContenido" runat="server" TextMode="MultiLine" Rows="8" Columns="72" Wrap="true" Visible="false" ></asp:TextBox>
    </form>
    
</body>
</html>

