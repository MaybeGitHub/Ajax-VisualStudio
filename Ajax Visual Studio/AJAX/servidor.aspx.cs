using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace AJAX
{
    public partial class servidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["patron"] != null)
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

            if ( Request.Files.Count != 0 )
            {                
                string objetoJSON;
                try {
                    HttpPostedFile fichero = Request.Files[0];
                    byte[] contenido = new byte[fichero.ContentLength];
                    fichero.InputStream.Read(contenido, 0, fichero.ContentLength);
                    File.WriteAllBytes("~/AppData/uploads/" + fichero.FileName, contenido);
                    objetoJSON = "{ 'codigo':0, 'mensaje':'Ha funcionado la subida del fichero'}";
                } catch
                {
                    objetoJSON = "{ 'codigo':1, 'mensaje':'Ha fallado la subida del fichero'}";
                }
                Response.Write(objetoJSON.ToString());
                Response.ContentType = "application/json";
                Response.End();
            }
        }
    }
}