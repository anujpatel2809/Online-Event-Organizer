<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="EO1.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Organizer</title>
    <link rel="stylesheet" type="text/css" href="css/popup.css" />

    <link href="css/main.css" rel="stylesheet" />
    <link href="css/tooplate_style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/nivo-slider.css" type="text/css" />
    <script src="js/pace.js"></script>
    <script src="js/modernizr-2.6.2.min.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,600' rel='stylesheet' type='text/css'>
</head>
<body>
    <form id="form1" runat="server">
        <main id="top" class="masthead" role="main">
        <div class="container">
        <div class="logo"> <a href="index.html#"><img src="/Image/logo.png" alt="logo"></a>
			</div>
        <div class="container">
        <h1 style="color:white">Make Your Event<br /><b><strong>Stand Out</strong></b> <br>
			From The Rest</h1><br /><br /><br />
           <div class="box">
            <a class="button1" href="login.aspx">Login</a>
            <a class="button1" href="signup.aspx">Signup</a>
        </div>
        <a href="home.aspx#explore" class="scrollto">
				<p>SCROLL DOWN TO EXPLORE</p>
				<p class="scrollto--arrow"><img src="/Image/scroll_down.png" alt="scroll down arrow"></p>
				</a>
        </div>
            </div>
        </main>
        <div class="container" id="explore">
            <div class="section-title">
                <h2>Get Some Exclusive Features</h2>
            </div>
            <section class="row features">
                <div class="col-sm-6 col-md-3">
                    <div class="thumbnail">
                        <img src="/Image/service_01.png" alt="analytics-icon">
                        <div class="caption">
                            <h3>Plan Multiple Events</h3>
                            <p>An event manager can handle more then one events parallel,increasing his efficiency.</p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3">
                    <div class="thumbnail">
                        <img src="/Image/service_02.png" alt="analytics-icon">
                        <div class="caption">
                            <h3>Always Stay Updates</h3>
                            <p>Check on to your event progress easily by getting instant notifications and email alerts. </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3">
                    <div class="thumbnail">
                        <img src="/Image/service_04.png" alt="analytics-icon">
                        <div class="caption">
                            <h3>Remainders to stay Focused</h3>
                            <p>Get Regular alerts and notifications.</p>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <div id="tooplate_footer_wrapper" style="float: inherit">
            <div id="tooplate_footer">
                <div class="col_4">
                    <h5>Why Use this Product?</h5>
                    <ul class="footer_list">
                        <li></li>
                        <p>Plan and schedule you important events by creating your team and asigning task to them. Get their work updates regularly.</p>
                    </ul>
                </div>
                <div class="col_4 col_1">
                    <h5>About Us</h5>
                    <p>
                        This what we do best...<br />
                        Web Design<br />
                        Mobile Apps<br />
                        Devlopment<br />
                        And to help people
                    </p>
                </div>
                <div class="col_4">
                    <h5>Contact Us</h5>

                    <ul class="twitter_post">
                        <li></li>
                        <li><a href="#feedbackpop">Give Your Feedback</a></li>
                        <li>You can reach us at<br />
                            devlopers.eventorganizer@gmail.com</li>
                        <p>Follow us at</p>
                        <div class="footer_social_button">
                            <a href="#">
                                <img alt="Facebook" src="image/facebook-32x32.png" title="facebook" /></a>
                            <a href="#">
                                <img alt="Twitter" src="image/twitter-32x32.png" title="twitter" /></a>
                            <a href="#">
                                <img alt="Youtube" src="image/youtube-32x32.png" title="youtube" /></a>

                        </div>
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

    </form>
</body>
</html>
