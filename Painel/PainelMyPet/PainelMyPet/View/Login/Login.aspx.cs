using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PainelMyPet.View.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MyPetWS.MyPetWS ws = new MyPetWS.MyPetWS();

            if (ws.Login(txtUsername.Text,txtPassword.Text) == "true")
            {
                //Response.Redirect("~/View/Dashboard.aspx");
                lblResult.Text = "<i class=\"fa fa-user mr - xs\"></i>Válido";
            }
            else 
            {
                lblResult.Text = "<i class=\"fa fa-user mr - xs\"></i>Inválido";
                //Response.Redirect("~/View/Dashboard.aspx");
            }
            
            //ws.TesteConexao
            //Response.Redirect("~/View/Dashboard.aspx");
        }
    }
}