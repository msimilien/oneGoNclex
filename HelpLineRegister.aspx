﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpLineRegister.aspx.cs" Inherits="oneGoNclex.HelpLineRegister" %>

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
    <link rel="icon" type="image/png" sizes="32x32" href="assets/images/logoOficialOneGo.jpg">
    <link rel="icon" type="image/png" sizes="16x16" href="assets/images/logoOficialOneGo.jpg">
    <meta name="theme-color" content="#ffffff">
    <!--  -->
    <!--    Stylesheets-->
    <!--    =============================================-->
    <!-- Default stylesheets-->
    <link href="assets/lib/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Template specific stylesheets-->
    <link href="assets/lib/loaders.css/loaders.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Nunito:300,400,600" rel="stylesheet">
    <link href="assets/lib/iconsmind/iconsmind.css" rel="stylesheet">
    <link href="http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" rel="stylesheet">
    <link href="assets/lib/hamburgers/dist/hamburgers.min.css" rel="stylesheet">
    <link href="assets/lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- Main stylesheet and color file-->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/custom.css" rel="stylesheet">
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
                    <a class="navbar-brand overflow-hidden pr-3" href="">
                        <!--<div class="background-1 radius-br-0 radius-secondary lh-1 color-white fs-0" style="padding: 7px 10px 7px 13px;">TEST</div>-->
                        <!-- Incase you are using image-->
                        <!--<img class="background-1 radius-br-0 radius-secondary lh-1" src="assets/images/logoOficialOneGo.jpg" alt="" width="150" />-->
                        <!--<img src="assets/images/logoOficialOneGo.jpg" width="145" alt="" class="d-inline-block align-middle mr-2">-->
                        <img src="assets/images/logo/LogoOficialOneGo1.png" width="145" alt="" class="navbar-brand">
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
                                <a href="Index.html">Home</a>

                            </li>
                            <li>
                                <a href="About.html">About</a>

                            </li>
                            <li>
                                <a href="Programs.html">Our programs</a>

                            </li>
                            <li>
                                <a href="banks">Questions Bank</a>

                            </li>
                            <li>
                                <a href="Contact.aspx">Contact</a>

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
                                <a class="pl-3 pl-lg-1 d-inline-block pr-0" href="#">
                                    <span class="fa fa-dribbble"></span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
        <%-- <section class="py-9 overflow-hidden text-center">
            <div class="background-holder overlay overlay-1 parallax" style="background-image:url(assets/images/image1.jpg);"> </div>
            <!--/.background-holder-->
            <div class="container">
                <div class="row" data-zanim-timeline="{}" data-zanim-trigger="scroll">
                    <div class="col">
                        <div class="overflow-hidden">
                            <h1 class="fs-5 fs-sm-6 color-danger" data-zanim='{"delay":0}'>One Go NCLEX Review LLC</h1>
                        </div>
                        <div class="overflow-hidden">
                            <p class="fs-2 fw-300 ls color-8 text-uppercase" data-zanim='{"delay":0.1}'>New York, USA</p>
                        </div>
                    </div>
                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
        </section>--%>

        <section class=" background-11 py-0 text-center">
            <div class="container">
                <div class="row h-full align-items-center">
                    <div class="col-12 px-0">
                        <div class="text-center">
                            <p>
                                <br />
                                <asp:Label ID="LblregisterForm" runat="server" Text="Registration Form" class="bg-success text-white" Font-Bold="True" Font-Overline="True" Font-Size="Large" Font-Strikeout="False" ForeColor="Red"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblIdregistration" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="container">
                            <div style="margin-top: 20px;" class="row-fluid">
                                <div class="offset4 span4 well">

                                    <div class="col">
                                        <form id="form1" runat="server">
                                            <input name="TextFname" type="text" required="required" placeholder="First Name" />
                                            <input name="TextMdleName" type="text" placeholder="Midle Name " />
                                            <input name="TexLast" type="text" required="required" placeholder="Last name " />
                                            <input name="TxtSocialSecurity" type="text" required="required" placeholder="Social Security Number" /><br />
                                            <input name="TextAddress" type="text" required="required" placeholder="Addres" />
                                            <input name="TextState" type="text" required="required" placeholder="State" />
                                            <input name="TextCity" type="text" required="required" placeholder="City" />
                                            <input name="Zip" type="text" required="required" placeholder="Zip" /><br />
                                            <input name="TextPhone" type="tel" required="required" placeholder="Phone Number" />
                                            <input name="TextResidenceCountry" type="text" required="required" placeholder="Country of Residence" />
                                            <input name="TextMail" type="email" required="required" placeholder="Email" />
                                            <input name="TextEmergencyMail" type="email" placeholder="Emergency Contact Email" /><br />
                                            <input name="TextEmergencyName" type="text" placeholder="Emergency Contact Name" />
                                            <input name="TextEmergencyPhone" type="tel" placeholder="Emergency Contact Phone" />
                                            <hr />
                                            <asp:Label ID="Label1" runat="server" Text="Birth Date"></asp:Label>
                                            <input name="TextBirthDate" type="date" required="required" />
                                            <asp:Label ID="Label2" runat="server" Text="Gender"></asp:Label>
                                            <select name="SelectGender" required="required">
                                                <option>Male</option>
                                                <option>Female</option>

                                            </select>
                                            <br />
                                            <input name="CheckboxHighSchool" type="checkbox" title="High School Diploma/GED" />
                                            <asp:Label ID="Label3" runat="server" Text="High School Diploma/GED" Font-Bold="True"></asp:Label>
                                            <br />
                                            <input name="CheckboxLPN" type="checkbox" title="LPN" />
                                            <asp:Label ID="Label4" runat="server" Text="LPN" Font-Bold="True"></asp:Label>
                                            <br />
                                            <br />

                                            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" class="btn btn-md-lg btn-primary" OnClick="BtnSubmit_Click" />
                                        </form>


                                    </div>


                                </div>
                            </div>
                        </div>




                        <br />
                        <br />
                        <br />
                    </div>
                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js"></script>
    <script src="assets/lib/jquery/dist/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/lib/imagesloaded/imagesloaded.pkgd.min.js"></script>
    <script src="assets/lib/jquery-menu-aim/jquery.menu-aim.js"></script>
    <script src="assets/lib/gsap/src/minified/TweenMax.min.js"></script>
    <script src="assets/lib/gsap/src/minified/plugins/ScrollToPlugin.min.js"></script>
    <script src="assets/lib/CustomEase.min.js"></script>
    <script src="assets/js/config.js"></script>
    <script src="assets/lib/rellax/rellax.min.js"></script>
    <script src="assets/js/zanimation.js"></script>
    <script src="assets/js/inertia.js"></script>
    <script src="assets/js/googlemap.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCoK8GIrOHzHwnzHCyqrdtmTpUWcdrTTD8&callback=initMap" async></script>
    <script src="assets/js/core.js"></script>
    <script src="assets/js/main.js"></script>
</body>
</html>
