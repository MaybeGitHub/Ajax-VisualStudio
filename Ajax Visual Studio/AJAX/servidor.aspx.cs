using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace AJAX
{
    public partial class servidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string patron = Request.Params["patron"].ToLower();
            int valor = int.Parse(Request.Params["valor"]);

            XmlDocument miDoc = new XmlDocument();
            miDoc.Load(Server.MapPath("libreria.xml"));

            List<XmlNode> listaLibros = miDoc.GetElementsByTagName("Libro").Cast<XmlNode>().ToList();
            List<XmlNode> cribaLibros = listaLibros.Where(libro => libro.ChildNodes[valor].ChildNodes[0].Value.ToLower().StartsWith(patron)).ToList();

            string salida = "<Libreria>";
            cribaLibros.ForEach(nodo => salida += nodo.OuterXml);
            salida += "</Libreria>";
            Response.ContentType = "text/Xml";
            Response.Write(salida);
            Response.Flush();
            Response.End();
        }
    }
}