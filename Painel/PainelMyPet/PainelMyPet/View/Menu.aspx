<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PainelMyPet.View.Menu" %>
<!doctype html>
<html class="fixed">
	<head>

		<!-- Basic -->
		<meta charset="UTF-8">

		<meta name="keywords" content="HTML5 Admin Template" />
		<meta name="description" content="Porto Admin - Responsive HTML5 Template">
		<meta name="author" content="okler.net">

		<!-- Mobile Metas -->
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

		<!-- Web Fonts  -->
		<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800|Shadows+Into+Light" rel="stylesheet" type="text/css">

		<!-- Vendor CSS -->
		<link rel="stylesheet" href="~/Assets/vendor/bootstrap/css/bootstrap.css" />
		<link rel="stylesheet" href="~/Assets/vendor/font-awesome/css/font-awesome.css" />
		<link rel="stylesheet" href="~/Assets/vendor/magnific-popup/magnific-popup.css" />
		<link rel="stylesheet" href="~/Assets/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.css" />

		<!-- Theme CSS -->
		<link rel="stylesheet" href="~/Assets/stylesheets/theme.css" />

		<!-- Skin CSS -->
		<link rel="stylesheet" href="~/Assets/stylesheets/skins/default.css" />

		<!-- Theme Custom CSS -->
		<link rel="stylesheet" href="~/Assets/stylesheets/theme-custom.css">

		<!-- Head Libs -->
		<script src="~/Assets/vendor/modernizr/modernizr.js"></script>

	</head>
	<body>
		<!-- start: page -->
		<section class="body-sign">
			<div class="center-sign">
				<a href="/Index.aspx" class="logo pull-left">
					<img src="../../Assets/images/logo.png" height="90" alt="My Pet" />
				</a>
				<br>
				<div class="panel panel-sign">
					<div class="panel-title-sign mt-xl text-right">
						<h2 class="title text-uppercase text-weight-bold m-none"><i class="fa fa-user mr-xs"></i> Login</h2>
					</div>
					<div class="panel-body">
						<form action="index.html" method="post">
							<div class="form-group mb-lg">
								<label>Usuário</label>
								<div class="input-group input-group-icon">
									<input name="username" type="text" class="form-control input-lg" />
									<span class="input-group-addon">
										<span class="icon icon-lg">
											<i class="fa fa-user"></i>
										</span>
									</span>
								</div>
							</div>

							<div class="form-group mb-lg">
								<div class="clearfix">
									<label class="pull-left">Senha</label>
									<a href="pages-recover-password.html" class="pull-right">Esqueceu a Senha?</a>
								</div>
								<div class="input-group input-group-icon">
									<input name="pwd" type="password" class="form-control input-lg" />
									<span class="input-group-addon">
										<span class="icon icon-lg">
											<i class="fa fa-lock"></i>
										</span>
									</span>
								</div>
							</div>

							<div class="row">
								<div class="col-sm-8">
									<div class="checkbox-custom checkbox-default">
										<input id="RememberMe" name="rememberme" type="checkbox"/>
										<label for="RememberMe">Lembrar Usuário</label>
									</div>
								</div>
								<div class="col-sm-4 text-right">
									<button type="submit" class="btn btn-primary hidden-xs">Acessar</button>
									<button type="submit" class="btn btn-primary btn-block btn-lg visible-xs mt-lg">Acessar</button>
								</div>
							</div>
							<p class="text-center">Ainda não tem conta? <a href="pages-signup.html">Cadastrar!</a></p>

						</form>
					</div>
				</div>
			</div>
		</section>
		<!-- end: page -->

		<!-- Vendor -->
		<script src="~/Assets/vendor/jquery/jquery.js"></script>
		<script src="~/Assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js"></script>
		<script src="~/Assets/vendor/bootstrap/js/bootstrap.js"></script>
		<script src="~/Assets/vendor/nanoscroller/nanoscroller.js"></script>
		<script src="~/Assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
		<script src="~/Assets/vendor/magnific-popup/jquery.magnific-popup.js"></script>
		<script src="~/Assets/vendor/jquery-placeholder/jquery-placeholder.js"></script>
		
		<!-- Theme Base, Components and Settings -->
		<script src="~/Assets/javascripts/theme.js"></script>
		
		<!-- Theme Custom -->
		<script src="~/Assets/javascripts/theme.custom.js"></script>
		
		<!-- Theme Initialization Files -->
		<script src="~/Assets/javascripts/theme.init.js"></script>

	</body>
</html>