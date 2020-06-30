using System;

namespace PainelMyPet.View
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FixedContent content = new FixedContent();
            topo.Text = content.topoHtml;
            menuEsq.Text = content.menuHtml;
        }
    }
}