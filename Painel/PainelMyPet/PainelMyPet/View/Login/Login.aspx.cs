using System;
using System.Data;
using System.Web;

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

            if (ws.Login(txtUsername.Text, txtPassword.Text) == "true")
            {
                lblResult.Text = "<i class=\"fa fa-user mr - xs\"></i> Válido";
              
                DataTable dt = ws.DadosUsuario(txtUsername.Text, txtPassword.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HttpContext.Current.Session["idPrestador"] = dt.Rows[i][0];
                    HttpContext.Current.Session["usrLogado"] = dt.Rows[i][1];
                    HttpContext.Current.Session["nomePrestador"] = dt.Rows[i][9];
                    HttpContext.Current.Session["emailPrestador"] = dt.Rows[i][11];
                }

                Response.Redirect("~/View/Dashboard.aspx");

            }
            else
            {
                lblResult.Text = "<i class=\"fa fa-user mr - xs\"></i> Inválido";
                //Response.Redirect("~/View/Dashboard.aspx");
            }

            //ws.TesteConexao
            //Response.Redirect("~/View/Dashboard.aspx");
        }
    }
}