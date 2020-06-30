<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PainelMyPet.View.Dashboard" %>

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
								<li><span>Tables</span></li>
								<li><span>Basic</span></li>
							</ol>
						</div>
					</header>

					<!-- start: page -->
					
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
		
		<!-- Theme Base, Components and Settings -->
		<script src="../Assets/javascripts/theme.js"></script>
		
		<!-- Theme Custom -->
		<script src="../Assets/javascripts/theme.custom.js"></script>
		
		<!-- Theme Initialization Files -->
		<script src="../Assets/javascripts/theme.init.js"></script>

		<!-- Examples -->
		<script src="../Assets/javascripts/dashboard/examples.landing.dashboard.js"></script>
	</body>
</html>