<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verifyemail.aspx.cs" Inherits="EO1.verifyemail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- FONTAWESOME STYLES-->
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="css/icon-awesome.css" rel="stylesheet" type="text/css" />
    <!--CUSTOM BASIC STYLES-->
    <link href="css/basic.css" rel="stylesheet" type="text/css" />
    <!--CUSTOM MAIN STYLES-->
    <link href="css/custom.css" rel="stylesheet" type="text/css" />
    <link href="css/tooplate_style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/nivo-slider.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <header style="display: block">
            <div id="wrapper">
                <nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Event Organizer</a>
                    </div>

                    <div class="header-right">

                        <asp:ImageButton ID="udp" runat="server" data-toggle="dropdown" class="image" />
                        <!-- <button data-toggle="dropdown" class="btn  dropdown-toggle">
                            
                                <asp:Image ID="Image1" runat="server" alt="" class="image" />
                           
                        </button>-->
                        <ul class="dropdown-menu">

                            <li>
                                <center><asp:ImageButton ID="disp" runat="server" CssClass="image1" ></asp:ImageButton></center>

                                <br />
                            </li>
                            <li>
                                <center><asp:Label ID="buname"  runat="server"  CssClass="mylab" ></asp:Label></center>
                            </li>
                            <li>
                                <center><asp:Label ID="email" runat="server" Text="Label" CssClass="mylab"></asp:Label></center>
                                <br />
                            </li>
                            <li>

                                <center> <asp:Button ID="logout" runat="server" Text="Logout" CssClass="btn btn-success" OnClick="Logout_Click"/></center>
                            </li>
                        </ul>
                    </div>


                </nav>

                <!-- /. NAV TOP  -->
                <nav class="navbar-default navbar-side" role="navigation">
                    <div class="sidebar-collapse">
                        <ul class="nav" id="main-menu">
                            <li>
                                <div class="user-img-div">
                                    <asp:Image ID="dp" runat="server" CssClass="img-thumbnail" />
                                    <div class="inner-text">
                                        <asp:Label ID="name" runat="server"></asp:Label>
                                        <br />
                                        <small>Last Login : 2 Weeks Ago </small>
                                    </div>
                                </div>

                            </li>


                        </ul>
                    </div>
                </nav>
                <!-- /. WRAPPER  -->
                <div id="page-wrapper">
                    <div id="page-inner">
                        <h2>Please Verify Your Email Address...<h2>
                            <asp:Button ID="resendmail" runat="server" CssClass=" btn btn-default" Text="Click Here if you can't find mail" OnClick="resendmail_Click" />
                    </div>
                </div>
            </div>
             <div id="tooplate_footer_wrapper" style="float: inherit">
            <div id="tooplate_footer">
                <!--<div class="col_4">
                    <h5>Partner Links</h5>
                    <ul class="footer_list">
                        <li><a href="#">Flash Gallery</a></li>
                        <li><a href="#">CSS Templates</a></li>
                        <li><a href="#">Web Design</a></li>
                        <li><a href="#">Premium Themes</a></li>
                        <li><a href="#m">Web Development</a></li>
                    </ul>
                </div>-->
                <div class="col_4">
                    <h5>Recent Posts</h5>
                    <ul class="footer_list">
                        <li><a href="#">Donec sit amet gravida quam lacinia at luctus felis luctus.</a></li>
                        <li><a href="#">Nam a aliquam justo. Duis nec dui quis elit faucibus gravida non in dolor.</a></li>
                        <li><a href="#">Cras ornare ornare nulla, et dictum eros malesuada ac.</a></li>
                    </ul>
                </div>
                <div class="col_4 col_1">
                    <h5>About</h5>
                    <p>Mauris eu elit tortor. Mauris pretium ullamcorper orci sed tempor. Donec facilisis sodales justo ut ornare. Vestibulum porta semper justo, non adipiscing lacus sodales eu. </p>
                    <div class="footer_social_button">
                        <a href="#">
                            <img alt="Facebook" src="image/facebook-32x32.png" title="facebook" /></a>
                       <!-- <a href="#">
                            <img alt="Flickr" src="images/flickr-32x32.png" title="flickr" /></a>-->
                        <a href="#">
                            <img alt="Twitter" src="image/twitter-32x32.png" title="twitter" /></a>
                        <a href="#">
                            <img alt="Youtube" src="image/youtube-32x32.png" title="youtube" /></a>
                        <!--<a href="#">
                            <img alt="RSS" src="images/rss-32x32.png" title="rss" /></a>-->
                    </div>
                </div>
                <div class="col_4">
                    <h5>Twitter</h5>
                    <ul class="twitter_post">
                        <li>Mauris enim ipsum, hendrerit quis fringilla <a href="#">http://bit.ly/13IwZO</a></li>
                        <li>Donec non leo vitae turpis lacinia placerat <a href="#">http://bit.ly/13IweP</a></li>
                        <li>Etiam sit amet augue eget justo pharetra <a href="#">http://bit.ly/13IwZOl</a></li>
                    </ul>
                </div>

                <div class="cleaner"></div>
            </div>
        </div>
        <div id="tooplate_cr_bar_wrapper">
            <div id="tooplate_cr_bar">
                Copyright © 2016 <a href="#">Event Organizer</a>
            </div>
        </div>
        </header>
        <script src="js/jquery-1.10.2.js"></script>
        <!-- BOOTSTRAP SCRIPTS -->
        <script src="js/bootstrap.js"></script>
        <!-- METISMENU SCRIPTS -->
        <script src="js/jquery.metisMenu.js"></script>
    </form>
</body>
</html>
