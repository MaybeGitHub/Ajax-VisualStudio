using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace AJAX
{
    public partial class autentificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Autentificador recibido = new JavaScriptSerializer().Deserialize<Autentificador>(Request.Params["datos"]);
            Response.Write(recibido.ToString());
            Response.ContentType = "application/json";
            Response.End();            
        }
    }
}