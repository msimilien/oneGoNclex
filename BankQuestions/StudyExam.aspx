<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudyExam.aspx.cs" Inherits="oneGoNclex.StudyExam" %>

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
        <section class=" background-11 py-0 text-center">
            <div class="container">
                <div class="row h-full align-items-center">
                    <div class="col-12 px-0">
                        <div class="text-center">
                            <form runat="server" class="text-left">

                                <asp:ScriptManager ID="scripManager1" runat="server" />

                                <div class="container-fluid">
                                    <p style="margin-bottom: 9rem;">
                                        <asp:UpdatePanel runat="server" ID="updPanelQuestions" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <b style="position: relative; width:150px; top: 1.5rem;">Questions: </b>
                                                <label runat="server" id="lblQuestionsAmount" style="position: relative; top: 1.5rem;">Loading...</label>
                                                <br />
                                                <br />
                                                <br />
                                                <div>
                                                    <label>
                                                        Go to question number: 
                                                    </label>
                                                    <asp:TextBox runat="server"
                                                        type="number"
                                                        step="1"
                                                        min="1"
                                                        ID="txtNumberQuestion">
                                                    </asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="goToQuestion" Style="background-color: darkgreen; color: white; font-weight: bold;" Text="Go" runat="server" OnClick="goToQuestion_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </p>
                                    <p style="margin-bottom: 40px;">
                                        <asp:UpdatePanel runat="server" ID="updPanelQuestion" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label runat="server" ID="lblQuestions">Loading...</asp:Label>
                                                <br />
                                                <br />
                                                <div runat="server" id="divContentVideoImage" class="text-center">
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        <asp:UpdatePanel runat="server" ID="updAnswers" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButtonList runat="server" ID="Answers"></asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:TextBox runat="server"
                                            Style="display: none;"
                                            ID="txtQuestionsAnswered"
                                            OnTextChanged="txtQuestionsAnswered_TextChanged">
                                        </asp:TextBox>
                                    </p>

                                    <p>
                                        <asp:UpdatePanel runat="server" ID="updPanelMessage" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label runat="server" ID="lblCorrect" ForeColor="#006600" Style="display: none;">CORRECT!!</asp:Label>
                                                <asp:Label runat="server" ID="lblIncorrect" ForeColor="#cc0000" Style="display: none;">INCORRECT!!</asp:Label>
                                                <br />
                                                <p runat="server" id="lblAnswerExplanation" style="display: none;"></p>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        <br />
                                    </p>

                                    <p>
                                        <asp:UpdatePanel runat="server" ID="updButtons" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="row text-center">
                                                    <div class="col-xs-12 col-sm-4">
                                                        <asp:Button Text="Previous" disabled="true" runat="server" ID="btnPrev" OnClick="btnPrev_Click" CssClass="btn btn-danger" Width="250px" />
                                                        <br />
                                                        <br />
                                                    </div>
                                                    <div class="col-xs-12 col-sm-4">
                                                        <asp:Button Text="Next" runat="server" ID="btnNext" OnClick="btnNext_Click" CssClass="btn btn-success" Width="250px" />
                                                        <asp:Button Text="Finish" runat="server" ID="btnFinish" OnClick="btnFinish_Click" CssClass="btn btn-success" Width="250px" Style="display: none; margin: auto auto;" />
                                                        <br />
                                                        <br />
                                                    </div>
                                                    <div class="col-xs-12 col-sm-4">
                                                        <asp:Button Text="Show response" runat="server" ID="btnShowResponse" OnClick="btnShowResponse_Click" CssClass="btn btn-info" Width="250px" />
                                                        <br />
                                                        <br />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </p>
                                </div>

                            </form>
                        </div>
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
    <script src="../assets/js/StudyExam.js"></script>
    <script src="../assets/js/UpgradePayment.js"></script>
</body>
</html>
