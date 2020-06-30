using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PainelMyPet.View
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FixedContent content = new FixedContent();
            topo.Text = content.topoHtml;
            menuEsq.Text = content.menuHtml;
        }
    }
}