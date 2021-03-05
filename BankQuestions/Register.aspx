<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="oneGoNclex.Register" %>

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
    <link href="https://fonts.googleapis.com/css?family=Nunito:300,400,600" rel="stylesheet">
    <link href="../assets/lib/iconsmind/iconsmind.css" rel="stylesheet">
    <link href="http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" rel="stylesheet">
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
                                <a href="/Index.html">Home</a>

                            </li>
                            <li>
                                <a href="/About.html">About</a>

                            </li>
                            <li>
                                <a href="/Programs.html">Our programs</a>

                            </li>
                            <li>
                                <a href="/Banks.html">Questions Bank</a>

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
                                <a class="pl-3 pl-lg-1 d-inline-block pr-0" href="#">
                                    <span class="fa fa-dribbble"></span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
        <section class=" background-11 py-0 text-center">
            <div class="container">
                <div class="row h-full align-items-center">
                    <div class="col-12 px-0">
                        <div class="text-center">
                            <form id="frmRegister" class="container-fluid" runat="server">
                                <div class="imgcontainer">
                                    <h3>Register new user</h3>
                                </div>

                                <div class="imgcontainer text-left">
                                    <h5>Personal Information</h5>
                                </div>

                                <hr />

                                <div class="container row">
                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Firstname</b></label>
                                            <asp:TextBox ID="txtFirstname"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Firstname"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtFirstname"
                                                ErrorMessage=" Firstname is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Middlename</b></label>
                                            <asp:TextBox ID="txtMiddlename"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Middlename"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Lastname</b></label>
                                            <asp:TextBox ID="txtLastname"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Lastname"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="txtLastname"
                                                ErrorMessage=" Lastname is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Email</b></label>
                                            <asp:TextBox ID="txtEmail"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Email"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="txtEmail"
                                                ErrorMessage=" Email is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Date of Birth</b></label>
                                            <asp:TextBox ID="txtDateOfBirth"
                                                class="form-control"
                                                type="date"
                                                runat="server"
                                                placeholder="Your Date of Birth"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                ControlToValidate="txtDateOfBirth"
                                                ErrorMessage=" Date of Birth is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Phone number</b></label>
                                            <asp:TextBox ID="txtPhonenumber"
                                                class="form-control"
                                                runat="server"
                                                type="number"
                                                placeholder="Your Phone number"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="txtPhonenumber"
                                                ErrorMessage=" Phone number is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Address</b></label>
                                            <asp:TextBox ID="txtAddress"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Address"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                ControlToValidate="txtAddress"
                                                ErrorMessage=" Address is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>State</b></label>
                                            <asp:TextBox ID="txtState"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your State"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                ControlToValidate="txtState"
                                                ErrorMessage=" State is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>City</b></label>
                                            <asp:TextBox ID="txtCity"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your City"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                ControlToValidate="txtCity"
                                                ErrorMessage=" City is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>
                                    
                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Zip Code</b></label>
                                            <asp:TextBox ID="txtZip"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Zip Code"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                ControlToValidate="txtZip"
                                                ErrorMessage=" Zip code is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>
                                    
                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Social Security</b></label>
                                            <asp:TextBox ID="txtSocialSecurity"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Social Security"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                ControlToValidate="txtSocialSecurity"
                                                ErrorMessage=" Social Security is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Residence Country</b></label>
                                            <asp:TextBox ID="txtResidenceCountry"
                                                class="form-control"
                                                runat="server"
                                                placeholder="Your Residence Country"
                                                TextMode="SingleLine"
                                                Font-Size="Medium">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                ControlToValidate="txtResidenceCountry"
                                                ErrorMessage=" Residence Country is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>Gender</b></label>
                                            <asp:RadioButtonList runat="server" ID="rdbGender">
                                                <asp:ListItem Text="&nbsp;Male" />
                                                <asp:ListItem Text="&nbsp;Female" />
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                ControlToValidate="rdbGender"
                                                ErrorMessage=" Gender is a required."
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>High School Diploma/GED</b></label>
                                            <asp:CheckBox ID="chkHighSchool" Text="text" runat="server" />
                                            <br />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-6">
                                        <div class="form-group text-left">
                                            <label for="uname"><b>LPN</b></label>
                                            <asp:CheckBox ID="chkLPN" Text="text" runat="server" />
                                            <br />
                                        </div>
                                    </div>
                                </div>

                                <div class="imgcontainer text-left">
                                    <h5>Emergency Information</h5>
                                </div>

                                <hr />

                                <div class="container row">
                                <div class="col-xs-12 col-sm-6">
                                    <div class="form-group text-left">
                                        <label for="uname"><b>Emergency Phone</b></label>
                                        <asp:TextBox ID="txtEmergencyPhone"
                                            class="form-control"
                                            runat="server"
                                            type="number"
                                            placeholder="Your Emergency phone"
                                            TextMode="SingleLine"
                                            Font-Size="Medium">
                                        </asp:TextBox>
                                        <br />
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-6">
                                    <div class="form-group text-left">
                                        <label for="uname"><b>Emergency Email</b></label>
                                        <asp:TextBox ID="txtEmergencyEmail"
                                            class="form-control"
                                            runat="server"
                                            type="number"
                                            placeholder="Your Emergency Email"
                                            TextMode="SingleLine"
                                            Font-Size="Medium">
                                        </asp:TextBox>
                                        <br />
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-6">
                                    <div class="form-group text-left">
                                        <label for="uname"><b>Emergency Name</b></label>
                                        <asp:TextBox ID="txtEmergencyName"
                                            class="form-control"
                                            runat="server"
                                            type="number"
                                            placeholder="Your Emergency Name"
                                            TextMode="SingleLine"
                                            Font-Size="Medium">
                                        </asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12 col-sm-4">
                                        &nbsp;
                                    </div>
                                    <div class="col-xs-12 col-sm-4">
                                        <asp:Button class="btn btn-md-lg btn-primary"
                                            ID="btnSave"
                                            runat="server"
                                            BackColor="#4CAF50"
                                            BorderStyle="None"
                                            Text="Save"
                                            OnClick="btnSave_Click"></asp:Button>
                                        <br />
                                        <a href="/bankquestions/login">Back</a>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="container">
                            <div style="margin-top: 20px;" class="row-fluid">
                                <div class="offset4 span4 well">
                                    <div class="col">
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
    <script src="../assets/lib/jquery/dist/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
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
    <script src="../assets/js/googlemap.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCoK8GIrOHzHwnzHCyqrdtmTpUWcdrTTD8&callback=initMap" async></script>
    <script src="../assets/js/core.js"></script>
    <script src="../assets/js/main.js"></script>
</body>
</html>
