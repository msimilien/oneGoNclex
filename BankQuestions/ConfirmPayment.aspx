<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmPayment.aspx.cs" Inherits="oneGoNclex.ConfirmPayment" %>

<!DOCTYPE html>

<html lang="en-US">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="format-detection" content="telephone=no">
    <!--  -->
    <!--    Document Title-->
    <!-- =============================================-->
    <title>On Go | NCLEX REVIEW LLC</title>
    <!--  -->
    <!--    Favicons-->
    <!--    =============================================-->
    <!--<link rel="apple-touch-icon" sizes="180x180" href="assets/images/favicons/apple-touch-icon.png">
    <link rel="icon" type="image/png" sizes="32x32" href="assets/images/favicons/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="assets/images/favicons/favicon-16x16.png">
    <link rel="shortcut icon" type="image/x-icon" href="">
    <link rel="manifest" href="assets/images/favicons/manifest.json">
    <link rel="mask-icon" href="assets/images/favicons/safari-pinned-tab.svg" color="#5bbad5">
    <meta name="msapplication-TileImage" content="assets/images/favicons/mstile-150x150.png">-->
    <link rel="icon" type="image/png" sizes="32x32" href="../assets/images/logoOficialOneGo.jpg">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/logoOficialOneGo.jpg">
    <meta name="theme-color" content="#ffffff">
    <!--  -->
    <!--    Stylesheets-->
    <!--    =============================================-->
    <!-- Default stylesheets-->
    <link href="../assets/lib/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Template specific stylesheets-->
    <link href="../assets/lib/loaders.css/loaders.min.css" rel="stylesheet">
    <link href="//fonts.googleapis.com/css?family=Nunito:300,400,600" rel="stylesheet">
    <link href="../assets/lib/iconsmind/iconsmind.css" rel="stylesheet">
    <link href="//code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" rel="stylesheet">
    <link href="../assets/lib/hamburgers/dist/hamburgers.min.css" rel="stylesheet">
    <link href="../assets/lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- Main stylesheet and color file-->
    <link href="../assets/css/style.css" rel="stylesheet">
    <link href="../assets/css/custom.css" rel="stylesheet">
</head>
<body data-spy="scroll" data-target=".inner-link" data-offset="60">
    <main>
        <div class="loading" id="preloader">
            <div class="h-100 d-flex align-items-center justify-content-center">
                <div class="loader-box">
                    <div class="loader"></div>
                </div>
            </div>
        </div>
        <div class="znav-container znav-white znav-freya znav-fixed" id="znav-container">
            <div class="container">
                <nav class="navbar navbar-expand-lg">
                    <a class="navbar-brand overflow-hidden pr-3" href="#">
                        <img src="../assets/images/logo/LogoOficialOneGo1.png" width="145" alt="" class="navbar-brand">
                    </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <div class="hamburger hamburger--emphatic">
                            <div class="hamburger-box">
                                <div class="hamburger-inner"></div>
                            </div>
                        </div>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <ul class="navbar-nav fs-0">
                            <li>
                                <a href="/Index.html">Home</a>

                            </li>
                            <li>
                                <a href="/About.html">About</a>

                            </li>
                            <li>
                                <a href="/Programs.html">Our programs</a>

                            </li>
                            <li>
                                <a href="/banks">Questions Bank</a>

                            </li>
                            <li>
                                <a href="/Contact.aspx">Contact</a>

                            </li>

                        </ul>
                        <ul class="navbar-nav fs-0 ml-lg-auto">
                            <li class="text-center">
                                <a class="pl-3 pl-lg-1 d-inline-block" href="#">
                                    <span class="fa fa-facebook"></span>
                                </a>
                                <a class="pl-3 pl-lg-1 d-inline-block" href="#">
                                    <span class="fa fa-twitter"></span>
                                </a>
                                <a class="pl-3 pl-lg-1 d-inline-block" href="#">
                                    <span class="fa fa-instagram"></span>
                                </a>
                                <a class="pl-3 pl-lg-1 d-inline-block" href="#">
                                    <span class="fa fa-dribbble"></span>
                                </a>
                                <a id="loginAction" 
                                    class="pl-3 pl-lg-1 d-inline-block pr-0" 
                                    href="javascript:void();"
                                    runat="server"
                                    onclick="collapse()"
                                    style="display:none !important;">
                                    <i class="fa fa-user"></i>
                                </a>
                                <div class="row">
                                    <div class="col">
                                        <div class="collapse multi-collapse pos-fixed ml-6" id="collapseOptions">
                                            <div class="card card-body">
                                                <a href="javascript:void();" onclick="logoff();">Logout</a>
                                                <a href="javascript:void();" onclick="goSettings();">Upgrade Subscription</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
        <section class="background-11 py-0 text-center">
            <div class="container">
                <div class="row">
                    <div class="col-3"></div>
                    <div class="col-12 col-sm-6">
                        <form id="frmSubscription" runat="server" class="text-center mt-10">
                            <p>Please verify the upload information</p>
                            <div class="row">
                                <div class="card card-outline-twitter" style="width: 100%;">
                                    <div class="card-header">
                                        <h5>Payment information</h5>
                                    </div>
                                    <div class="card-body">
                                        <div class="row text-left mb-4">
                                            <div class="col-sm-4" runat="server" id="lblRegistrationTitleContainer">
                                                <b runat="server" id="lblRegistrationTitle">Registration ID: </b>
                                            </div>
                                            <div class="col-sm-8" runat="server" id="lblRegistrationContainer">
                                                <asp:Label ID="lblRegistration" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-sm-4">
                                                <b runat="server" id="lblEmailTitle">Email: </b>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-sm-4">
                                                <b runat="server" id="lblPremiumTitle">Premium: </b>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label ID="lblPremium" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-sm-4">
                                                <b runat="server" id="lblCostTitle">Cost: </b>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label ID="lblCost" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-sm-4">
                                                <b runat="server" id="B1">End date: </b>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-sm-4 paypal-data" style="display: none;">
                                                <b>Ticket ID: </b>
                                            </div>
                                            <div class="col-sm-8 paypal-data" style="display: none;">
                                                <asp:Label ID="lblTicketID" runat="server" Style="display: none;"></asp:Label>
                                            </div>
                                            <div class="col-sm-4 paypal-data" style="display: none;">
                                                <b>Ticket date: </b>
                                            </div>
                                            <div class="col-sm-8 paypal-data" style="display: none;">
                                                <asp:Label ID="lblPaymentDate" runat="server" Style="display: none;"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtID" Style="display: none;"></asp:TextBox>
                                            <asp:TextBox runat="server" ID="txtDate" Style="display: none;"></asp:TextBox>
                                        </div>
                                        <div id="paypal-button-container" style="margin: 0 30%;"></div>
                                    </div>
                                </div>
                                <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Continue" CssClass="btn btn-success mt-3" Style="display: none; margin: 0 auto;" />
                                <br />
                                <asp:Button ID="btnBackToPayment" runat="server" OnClick="btnBackToPayment_Click" Text="Back" CssClass="btn btn-link mt-3" Style="margin: 0 auto;" />
                            </div>
                        </form>
                    </div>
                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
            <!-- Modal -->

            <div class="modal fade"
                id="modalPayment"
                tabindex="-1"
                role="dialog"
                aria-labelledby="modalPayment"
                aria-hidden="true"
                data-backdrop="false"
                data-keyboard="false"
                style="z-index: 9;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content mt-8">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Transaction successfully</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p class="text-justify">
                                The payment subscription to the selected bank was procesed successfully!!
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" 
                                    class="btn btn-outline-info" 
                                    data-dismiss="modal"
                                    onclick="ConfirmTransaction()">Ok</button>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="modal fade"
                id="modalPaymentError"
                tabindex="-1"
                role="dialog"
                aria-labelledby="modalPaymentError"
                aria-hidden="true"
                data-backdrop="false"
                data-keyboard="false"
                style="z-index: 9;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content mt-8">
                        <div class="modal-header">
                            <h5 class="modal-title">Transaction Error</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p class="text-justify">
                                Unexpected error occurred when trying to confirm your PayPal transaction. Please try again.
                            </p>
                            <p id="errorDetail">

                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" 
                                    class="btn btn-outline-info" 
                                    data-dismiss="modal">Ok</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade"
                id="modalPaymentCancel"
                tabindex="-1"
                role="dialog"
                aria-labelledby="modalPayment"
                aria-hidden="true"
                data-backdrop="false"
                data-keyboard="false"
                style="z-index: 9;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content mt-8">
                        <div class="modal-header">
                            <h5 class="modal-title">Transaction Cancelled</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p class="text-justify">
                                The transaction was cancelled. If you want to get a valid subscription for an exam, please try again.
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" 
                                    class="btn btn-outline-info" 
                                    data-dismiss="modal">Ok</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal -->
        </section>
        <section class="py-4 fs-1 text-center background-9">
            <div class="container">
                <div class="row">
                    <div class="col">
                        <a class="d-inline-block px-2 color-3" href="#">
                            <span class="fa fa-facebook"></span>
                        </a>
                        <a class="d-inline-block px-2 color-3" href="#">
                            <span class="fa fa-twitter"></span>
                        </a>
                        <a class="d-inline-block px-2 color-3" href="#">
                            <span class="fa fa-instagram"></span>
                        </a>
                    </div>
                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
        </section>
        <section class="background-primary text-center py-6">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col">
                        <p class="text-uppercase color-9 ls mb-3">One Go NCLEX Review LLC, 1111 Route 110 , Suite 330 Farmingdale, New York 11735.Tel: 631-984-0231</p>
                        <p class="color-5 mb-0">
                            info@onegonclexreview.com
                        </p>
                    </div>
                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
        </section>
    </main>
    <!--  -->
    <!--    JavaScripts-->
    <!--    =============================================-->
    <script src="//cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js"></script>
    <script src="../assets/lib/jquery/dist/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="../assets/lib/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../assets/lib/imagesloaded/imagesloaded.pkgd.min.js"></script>
    <script src="../assets/lib/jquery-menu-aim/jquery.menu-aim.js"></script>
    <script src="../assets/lib/gsap/src/minified/TweenMax.min.js"></script>
    <script src="../assets/lib/gsap/src/minified/plugins/ScrollToPlugin.min.js"></script>
    <script src="../assets/lib/CustomEase.min.js"></script>
    <script src="../assets/js/config.js"></script>
    <script src="../assets/lib/rellax/rellax.min.js"></script>
    <script src="../assets/js/zanimation.js"></script>
    <script src="../assets/js/inertia.js"></script>
    <script src="../assets/js/core.js"></script>
    <script src="../assets/js/main.js"></script>
    <script src="https://www.paypal.com/sdk/js?client-id=AdGQftApUjI_fGj3wyg1bhb4eperr-9jC9LYo5IsiiotW3EcgJ_BfITqeZXOrPbw28lijz9AQqrmsjub"></script>
    <script>
        paypal.Buttons({
            createOrder: function (data, actions) {
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: $.trim($("#lblCost").text()),
                            currency: 'USD'
                        }
                    }]
                });
            },
            onApprove: function (data, actions) {
                return actions.order.capture().then(function (details) {
                    $("#modalPayment").modal("show");
                    $("#lblTicketID").text($(details).attr("id")).fadeIn();
                    $("#lblPaymentDate").text($(details).attr("create_time")).fadeIn();
                    $(".paypal-data").fadeIn();
                    $("#txtID").val($(details).attr("id"));
                    $("#txtDate").val($(details).attr("create_time"));
                    $('#paypal-button-container').fadeOut();
                });
            }
        }).render('#paypal-button-container');

        function ConfirmTransaction() {
            $("#btnConfirm").trigger("click");
        }
    </script>
</body>
</html>
