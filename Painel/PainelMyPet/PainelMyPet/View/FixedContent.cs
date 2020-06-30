using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainelMyPet.View
{
    public class FixedContent
    {
        public string topoHtml = "<!-- start: header -->" +
                                "<header class=\"header\">" +
                                "	<div class=\"logo-container\">" +
                                "		<a href=\"Dashboard.aspx\" class=\"logo\">" +
                                "			<img src=\"../Assets/images/logo.png\" width=\"50\" height=\"50\" alt=\"Porto Admin\" />" +
                                "		</a>" +
                                "		<div class=\"visible-xs toggle-sidebar-left\" data-toggle-class=\"sidebar-left-opened\" data-target=\"html\" data-fire-event=\"sidebar-left-opened\">" +
                                "			<i class=\"fa fa-bars\" aria-label=\"Toggle sidebar\"></i>" +
                                "		</div>" +
                                "	</div>" +
                                "			" +
                                "	<!-- start: search & user box -->" +
                                "	<div class=\"header-right\">" + 
                                "		<span class=\"separator\"></span>" +
                                "			" +
                                "		<div id=\"userbox\" class=\"userbox\">" +
                                "			<a href=\"#\" data-toggle=\"dropdown\">" +
                                "				<figure class=\"profile-picture\">" +
                                "					<img src=\"../Assets/images/!logged-user.jpg\" alt=" + HttpContext.Current.Session["nomePrestador"] + " class=\"img-circle\" data-lock-picture=\"assets/images/!logged-user.jpg\" />" +
                                "				</figure>" +
                                "				<div class=\"profile-info\" data-lock-name=" + HttpContext.Current.Session["nomePrestador"] + " data-lock-email=" + HttpContext.Current.Session["emailPrestador"] + ">" +
                                "					<span class=\"name\">" + HttpContext.Current.Session["nomePrestador"] + "</span>" +
                                "					<span class=\"role\">" + HttpContext.Current.Session["emailPrestador"] + "</span>" +
                                "				</div>" +
                                "			" +
                                "				<i class=\"fa custom-caret\"></i>" +
                                "			</a>" +
                                "			" +
                                "			<div class=\"dropdown-menu\">" +
                                "				<ul class=\"list-unstyled\">" +
                                "					<li class=\"divider\"></li>" +
                                "					<li>" +
                                "						<a role=\"menuitem\" tabindex=\"-1\" href=\"pages-user-profile.html\"><i class=\"fa fa-user\"></i> Meu Perfil</a>" +
                                "					</li>" +
                                "					<li>" +
                                "						<a role=\"menuitem\" tabindex=\"-1\" href=\"pages-signin.html\"><i class=\"fa fa-power-off\"></i> Sair</a>" +
                                "					</li>" +
                                "				</ul>" +
                                "			</div>" +
                                "		</div>" +
                                "	</div>" +
                                "	<!-- end: search & user box -->" +
                                "</header>" +
                                "<!-- end: header -->";

        public string menuHtml = "<aside id=\"sidebar-left\" class=\"sidebar-left\">" +
"				    <div class=\"sidebar-header\">" +
"				        <div class=\"sidebar-title\">" +
"				            Menu" +
"				        </div>" +
"				        <div class=\"sidebar-toggle hidden-xs\" data-toggle-class=\"sidebar-left-collapsed\" data-target=\"html\" data-fire-event=\"sidebar-left-toggle\">" +
"				            <i class=\"fa fa-bars\" aria-label=\"Toggle sidebar\"></i>" +
"				        </div>" +
"				    </div>" +
"				    <div class=\"nano has-scrollbar\">" +
"				        <div class=\"nano-content\">" +
"				            <nav id=\"menu\" class=\"nav-main\" role=\"navigation\">" +
"				            " +
"				                <ul class=\"nav nav-main\">" +
"				                    <li>" +
"				                        <a href=\"Dashboard.aspx\">" +
"				                            <i class=\"fa fa-home\" aria-hidden=\"true\"></i>" +
"				                            <span>Resumo</span>" +
"				                        </a>                        " +
"									</li>" +
"									<li>" +
"				                        <a href=\"Produtos.aspx\">" +
"				                            <i class=\"fa fa-home\" aria-hidden=\"true\"></i>" +
"				                            <span>Produtos</span>" +
"				                        </a>                        " +
"									</li>" +
"									<li>" +
"				                        <a href=\"Servicos.aspx\">" +
"				                            <i class=\"fa fa-home\" aria-hidden=\"true\"></i>" +
"				                            <span>Serviços</span>" +
"				                        </a>                        " +
"									</li>" +
"									<li>" +
"				                        <a href=\"Promocoes.aspx\">" +
"				                            <i class=\"fa fa-home\" aria-hidden=\"true\"></i>" +
"				                            <span>Promoções</span>" +
"				                        </a>                        " +
"				                    </li>" +
"				                </ul>" +
"				            </nav>" +
"				        </div>" +
"				        <script>" +
"				            // Maintain Scroll Position" +
"				            if (typeof localStorage !== 'undefined') {" +
"				                if (localStorage.getItem('sidebar-left-position') !== null) {" +
"				                    var initialPosition = localStorage.getItem('sidebar-left-position')," +
"				                        sidebarLeft = document.querySelector('#sidebar-left .nano-content');" +
"				                    " +
"				                    sidebarLeft.scrollTop = initialPosition;" +
"				                }" +
"				            }" +
"				        </script>" +
"				    </div>" +
"				</aside>";
    }
}