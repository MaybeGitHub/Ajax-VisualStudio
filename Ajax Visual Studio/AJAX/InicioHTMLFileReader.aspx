<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioHTMLFileReader.aspx.cs" Inherits="AJAX.InicioHTMLFileReader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FileReader</title>
</head>
<body>
    <input type="file" accept="image/*" id="selector" />
    <div id="respuestaServer"></div>
    <script>
        var petAjax = new XMLHttpRequest();
        function hacerPeticionAjax() {
            var fichero = document.getElementById("selector").files[0];
            var lector = new FileReader(fichero);
            var datos = new FormData();
            datos.append("selector", fichero, fichero.name);
            petAjax.onreadystatechange = function () {
                if (this.readystate == 4 && this.status == 200) {
                    var respuesta = JSON.parse(this.responseText);
                    if (respuesta.codigo == 0) {
                        document.getElementById("respuestaServer").appendChild(document.createTextNode(respuesta.mensaje));
                    }
                }
            }
            petAjax.open("post", "http://localhost:2068/servidor.aspx", true);
            petAjax.send(datos);
        }
        document.getElementById("selector").addEventListener("change", hacerPeticionAjax, false);

    </script>
</body>
</html>
