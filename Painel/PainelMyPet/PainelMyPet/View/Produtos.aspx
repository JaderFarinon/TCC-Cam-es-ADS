<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="PainelMyPet.View.Produtos" %>

<!doctype html>
<html>
	<head>

		<!-- Basic -->
		<meta charset="UTF-8">

		<title>MyPet - Resumo</title>

		<!-- Mobile Metas -->
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

		<!-- Web Fonts  -->
		<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800|Shadows+Into+Light" rel="stylesheet" type="text/css"/>

		<!-- Vendor CSS -->
		<link rel="stylesheet" href="../Assets/vendor/bootstrap/css/bootstrap.css" />

		<link rel="stylesheet" href="../Assets/vendor/font-awesome/css/font-awesome.css" />
		<link rel="stylesheet" href="../Assets/vendor/magnific-popup/magnific-popup.css" />
		<link rel="stylesheet" href="../Assets/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.css" />

		<!-- Specific Page Vendor CSS -->
		<link rel="stylesheet" href="../Assets/vendor/owl.carousel/assets/owl.carousel.css" />
		<link rel="stylesheet" href="../Assets/vendor/owl.carousel/assets/owl.theme.default.css" />
		<link rel="stylesheet" href="../Assets/vendor/select2/css/select2.css" />
		<link rel="stylesheet" href="../Assets/vendor/select2-bootstrap-theme/select2-bootstrap.min.css" />
		<link rel="stylesheet" href="../Assets/vendor/pnotify/pnotify.custom.css" />

		<!-- Theme CSS -->
		<link rel="stylesheet" href="../Assets/stylesheets/theme.css" />

		<!-- Skin CSS -->
		<link rel="stylesheet" href="../Assets/stylesheets/skins/default.css" />

		<!-- Theme Custom CSS -->
		<link rel="stylesheet" href="../Assets/stylesheets/theme-custom.css"/>

		<!-- Head Libs -->
		<script src="../Assets/vendor/modernizr/modernizr.js"></script>

	</head>
	<body>
				<section class="body">	
			<!-- start: header -->
			<asp:Literal ID="topo" runat="server"></asp:Literal>
			<!-- end: header -->

			<div class="inner-wrapper">
				<!-- start: Menu Esquerdo -->
				<asp:Literal ID="menuEsq" runat="server"></asp:Literal>
				<!-- end: Menu Esquerdo -->
				
				<section role="main" class="content-body">
					<header class="page-header">
						<h2>Basic Tables</h2>
					
						<div class="right-wrapper pull-right">
							<ol class="breadcrumbs">
								<li>
									<a href="index.html">
										<i class="fa fa-home"></i>
									</a>
								</li>
								<li><span>Produtos</span></li>
							</ol>
						</div>
					</header>

					<!-- start: page -->
					<a class="mb-xs mt-xs mr-xs modal-with-zoom-anim btn btn-primary" href="#novoProduto">Novo Produto</a>
					<br>
					<br>
					<div class="row">
						<section class="panel">
                            <header class="panel-heading">
                                <div class="panel-actions">
                                    <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                    <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss></a>
                                </div>
                                <h2 class="panel-title">Produtos</h2>
                            </header>
                            <div class="panel-body">
                                <table class="table table-bordered table-striped mb-none" id="datatable-default">
                                    <thead>
                                        <tr>
                                            <th>Id</th>
                                            <th>Nome</th>
                                            <th>Tipo</th>
											<th>Valor</th>
											<th>Valor Promocional</th>
                                            <th class="hidden-xs">Ações</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Literal ID="ltrTabela" runat="server"></asp:Literal>
                                    </tbody>
                                </table>
                            </div>
                        </section>
					</div>
					<!-- Modal Animation -->
					<div id="novoProduto" class="zoom-anim-dialog modal-block modal-block-primary mfp-hide">
						<section class="panel">
							<header class="panel-heading">
								<h2 class="panel-title">Novo Produto</h2>
							</header>
							<div class="panel-body">
								<div class="modal-wrapper">
									<div class="panel-body">
										<form id="addProduto" runat="server">
											<label class="col-md-3 control-label" for="inputDefault">Descrição</label>
											<div class="col-md-9">
												<asp:TextBox runat="server" type="text" class="form-control" id="descricao" placeholder="Descrição do produto"></asp:TextBox>
											</div>
											<br/>
											<br/>
											<label class="col-md-3 control-label" for="inputSuccess">Tipo</label>
											<div class="col-md-9">
												<asp:DropDownList runat="server" ID="lstTipo" class="form-control mb-md">
													<asp:ListItem value="1">Alimento</asp:ListItem>
													<asp:ListItem value="2">Farmácia</asp:ListItem>
													<asp:ListItem value="3">Higiene e Beleza</asp:ListItem>
													<asp:ListItem value="4">Acessórios</asp:ListItem>
												</asp:DropDownList>
											</div>
											<label class="col-md-3 control-label" for="inputDefault">Valor</label>
											<div class="col-md-9">
												<asp:TextBox runat="server" type="text" class="form-control" id="valor" placeholder="Valor cobrado"></asp:TextBox>
											</div>
											<label class="col-md-3 control-label" for="inputDefault">Permite Entrega?</label>
											<div class="col-md-9">
												<asp:Checkbox runat="server" class="form-control" id="chkEntrega" value="S"></asp:Checkbox>
											</div>
											<div class="row">
												<div class="col-md-12 text-right">
													<asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="salvarProduto"/>
													<button class="btn btn-default modal-dismiss">Cancelar</button>
												</div>
											</div>
										</form>
									</div>
								</div>
							</div>
						</section>
					</div>
					<!-- end: page -->
				</section>
			</div>
		</section>

		<!-- Vendor -->
		<script src="../Assets/vendor/jquery/jquery.js"></script>
		<script src="../Assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js"></script>
		<script src="../Assets/vendor/bootstrap/js/bootstrap.js"></script>
		<script src="../Assets/vendor/nanoscroller/nanoscroller.js"></script>
		<script src="../Assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
		<script src="../Assets/vendor/magnific-popup/jquery.magnific-popup.js"></script>
		<script src="../Assets/vendor/jquery-placeholder/jquery-placeholder.js"></script>
		
		<!-- Specific Page Vendor -->
		<script src="../Assets/vendor/jquery-appear/jquery-appear.js"></script>
		<script src="../Assets/vendor/owl.carousel/owl.carousel.js"></script>
		<script src="../Assets/vendor/isotope/isotope.js"></script>
		<script src="../Assets/vendor/select2/js/select2.js"></script>
		<script src="../Assets/vendor/pnotify/pnotify.custom.js"></script>
		
		<!-- Theme Base, Components and Settings -->
		<script src="../Assets/javascripts/theme.js"></script>
		
		<!-- Theme Custom -->
		<script src="../Assets/javascripts/theme.custom.js"></script>
		
		<!-- Theme Initialization Files -->
		<script src="../Assets/javascripts/theme.init.js"></script>

		<!-- Examples -->
		<script src="../Assets/javascripts/dashboard/examples.landing.dashboard.js"></script>
		<script src="../Assets/javascripts/ui-elements/examples.modals.js"></script>
	</body>
</html>
