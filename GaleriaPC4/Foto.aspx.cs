using GaleriaPC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaleriaPC4
{
    public partial class Foto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLikes_Click(object sender, EventArgs e)
        {
            AccesoDB datos = new AccesoDB();
            var idFoto = Convert.ToInt32(Request.QueryString["codFoto"]);
            datos.DarLike(idFoto);
            Response.Redirect("Foto.aspx?codFoto=" + idFoto+"#");


        }

        protected void btnDislikes_Click(object sender, EventArgs e)
        {
            AccesoDB datos = new AccesoDB();
            var idFoto = Convert.ToInt32(Request.QueryString["codFoto"]);
            datos.DarDislike(idFoto);
            Response.Redirect("Foto.aspx?codFoto=" + idFoto + "#");
        }

        protected void hlRegresar_DataBinding(object sender, EventArgs e)
        {
            AccesoDB datos = new AccesoDB();
            var idFoto = Convert.ToInt32(Request.QueryString["codFoto"]);
            Response.Redirect("Default.aspx?codCat=");
        }
    }
}