<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PainelMyPet.View.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="fixed">
<head runat="server">
    <title></title>

    <!-- Basic -->
    <meta charset="UTF-8"/>

    <meta name="keywords" content="" />
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <!-- Mobile Metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <!-- Web Fonts  -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800|Shadows+Into+Light" rel="stylesheet" type="text/css"/>

    <!-- Vendor CSS -->
    <link rel="stylesheet" href="../../Assets/vendor/bootstrap/css/bootstrap.css" />

    <link rel="stylesheet" href="../../Assets/vendor/font-awesome/css/font-awesome.css" />
    <link rel="stylesheet" href="../../Assets/vendor/magnific-popup/magnific-popup.css" />
    <link rel="stylesheet" href="../../Assets/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.css" />

    <!-- Theme CSS -->
    <link rel="stylesheet" href="../../Assets/stylesheets/theme.css" />

    <!-- Skin CSS -->
    <link rel="stylesheet" href="../../Assets/stylesheets/skins/default.css" />

    <!-- Theme Custom CSS -->
    <link rel="stylesheet" href="../../Assets/stylesheets/theme-custom.css"/>

    <!-- Head Libs -->
    <script src="../../Assets/vendor/modernizr/modernizr.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- start: page -->
        <section class="body-sign">
            <div class="center-sign">
                <a href="/" class="logo pull-left">
                    <img src="../../Assets/images/logo.png" height="54" alt="My Pet" />
                </a>

                <div class="panel panel-sign">
                    <div class="panel-title-sign mt-xl text-right">
                        <h2 class="title text-uppercase text-weight-bold m-none"><i class="fa fa-user mr-xs"></i>Login</h2>
                    </div>
                    <div class="panel-body">

                        <div class="form-group mb-lg">
                            <label>Usuario</label>
                            <div class="input-group input-group-icon">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control input-lg"></asp:TextBox>
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
                                <a href="recoverPassword.aspx" class="pull-right">Esqueceu a Senha?</a>
                            </div>
                            <div class="input-group input-group-icon">
                                <asp:TextBox ID="txtPassword" runat="server" type="password" CssClass="form-control input-lg"></asp:TextBox>
                                <span class="input-group-addon">
                                    <span class="icon icon-lg">
                                        <i class="fa fa-lock"></i>
                                    </span>
                                </span>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-8">
                                <%-- // --%>
                            </div>
                            <div class="col-sm-4 text-right">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary hidden-xs" Text="Sign In" OnClick="btnLogin_Click" />
                                <button type="submit" class="btn btn-primary btn-block btn-lg visible-xs mt-lg">Sign In</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- end: page -->

        <!-- Vendor -->
        <script src="../../Assets/vendor/jquery/jquery.js"></script>
        <script src="../../Assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js"></script>
        <script src="../../Assets/vendor/bootstrap/js/bootstrap.js"></script>
        <script src="../../Assets/vendor/nanoscroller/nanoscroller.js"></script>
        <script src="../../Assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
        <script src="../../Assets/vendor/magnific-popup/jquery.magnific-popup.js"></script>
        <script src="../../Assets/vendor/jquery-placeholder/jquery-placeholder.js"></script>

        <!-- Theme Base, Components and Settings -->
        <script src="../../Assets/javascripts/theme.js"></script>

        <!-- Theme Custom -->
        <script src="../../Assets/javascripts/theme.custom.js"></script>

        <!-- Theme Initialization Files -->
        <script src="../../Assets/javascripts/theme.init.js"></script>
    </form>
</body>
</html>

