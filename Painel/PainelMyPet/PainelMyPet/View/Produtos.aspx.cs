using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PainelMyPet.View
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FixedContent content = new FixedContent();
            topo.Text = content.topoHtml;
            menuEsq.Text = content.menuHtml;
            listarProdutos((int)HttpContext.Current.Session["idPrestador"]);
        }

        public void listarProdutos(int id)
        {
            DataTable dt;
            MyPetWS.MyPetWS ws = new MyPetWS.MyPetWS();
            dt = ws.ListarProdutos(id);

            ltrTabela.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltrTabela.Text += "<tr><td>" + dt.Rows[i][0] + "</td> " +
                    "<td>" + dt.Rows[i][1] + "</td> " +
                    "<td>" + dt.Rows[i][2] + "</td> " +
                    "<td>R$ " + dt.Rows[i][3] + "</td> " +
                    "<td>R$ " + dt.Rows[i][4] + "</td> " +
                    "<td class='actions'><asp:LinkButton runat='server' class='mb-xs mt-xs mr-xs modal-with-zoom-anim btn btn-default' href='#modalEdit" + dt.Rows[i][0] + "' OnClick='editarItem(" + dt.Rows[i][0] + ")'/><i class='fa fa-pencil'></i></a></td></tr>" +
                    "<!-- Modal Animation -->" +
                    "<div id=\"modalEdit"+ dt.Rows[i][0] + "\" class=\"zoom-anim-dialog modal-block modal-block-primary mfp-hide\">" +
                        "<section class=\"panel\">" +
                            "<header class=\"panel-heading\">" +
                                "<h2 class=\"panel-title\">" + dt.Rows[i][1] + "</h2>" +
                            "</header>" +
                            "<div class=\"panel-body\">" +
                                "<div class=\"modal-wrapper\">" +
                                            
                                "</div>" +
                            "</div>" +
                            "<footer class=\"panel-footer\">" +
                                "<div class=\"row\">" +
                                    "<div class=\"col-md-12 text-right\">" +
                                        "<button class=\"btn btn-primary modal-confirm\">Salvar</button>" +
                                        "<button class=\"btn btn-default modal-dismiss\">Cancelar</button>" +
                                    "</div>" +
                                "</div>" +
                            "</footer>" +
                        "</section>" +
                    "</div>";
            }
        }

        protected void salvarProduto(object sender, EventArgs e) {
            MyPetWS.MyPetWS ws = new MyPetWS.MyPetWS();
            ws.GravarProduto(descricao.Text, Convert.ToInt32(lstTipo.SelectedValue), Convert.ToDecimal(valor.Text), chkEntrega.Text, (int)HttpContext.Current.Session["idPrestador"]);
        }
    }
}