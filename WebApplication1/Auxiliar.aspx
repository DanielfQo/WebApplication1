<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auxiliar.aspx.cs" Inherits="WebApplication1.Auxiliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="./Scripts/jquery-3.4.1.js"></script>
    <script>
        function callAjax() {
            let send = $('#datosCookies').val();
            $.ajax({
            url: 'Auxiliar.aspx/getInformacion',
            type: 'POST',
            async: true,
            data: '{ valor:"' + send + '"}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: exito
            });
            return false;
        }

        function exito(data) {
            var returnS = data.d;
            $('#TextBoxAjax').val(data.d);
            $('#TextBoxAjax').css("visibility", "visible");
            return false;
        }
    </script> 
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelUsuario" runat="server" Text="Enviado por Sesión:"></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelNombre" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelApellido" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelSexo" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelEmail" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelDireccion" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelCiudad" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelRequerimientos" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="MostrarCookies" runat="server" Text="Mostrar cookie" OnClick="loadCookies" />
        </div>
        <div>
            <asp:TextBox ID="datosCookies" runat="server" TextMode="MultiLine" Rows="8" Columns="72" Wrap="true" text="" ></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BotonAjax" runat="server" Text="Ajax" OnClientClick="return callAjax();" />
        </div>
        <div >
            <asp:TextBox ID="TextBoxAjax" runat="server" TextMode="MultiLine" Rows="8" Columns="72" Wrap="true" Style="visibility: hidden"></asp:TextBox>
        </div>

    </form>
</body>
</html>
