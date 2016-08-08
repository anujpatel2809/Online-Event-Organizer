<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="EO1.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Organizer</title>
    <link rel="stylesheet" type="text/css" href="css/popup.css" />
    <link type="text/css" rel="stylesheet" href="css/signup.css" />
    <link id="link1" rel="stylesheet" runat="server" href="css/login1.css" />
    <link id="link2" rel="stylesheet" runat="server" href="css/login2.css" />
    <link href="css/main.css" rel="stylesheet"/>
    <script src="js/pace.js"></script>
    <script src="js/modernizr-2.6.2.min.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,600' rel='stylesheet' type='text/css'>
</head>
<body >
    
    <main id="top" class="masthead" role="main" >
        <div class="logo"> <a href="index.html#"><img src="/Image/Untitled.png" alt="logo"></a>
			</div>
        <div class="container">
        <h1>Make Your Event<br /><b><strong>Stand Out</strong></b> <br>
			From The Rest</h1><br /><br /><br />
    <form id="form1" runat="server">
        <div class="box">
            <a class="button1" href="login.aspx">Login</a>
            <a class="button1" href="signup.aspx">Signup</a>
        </div>
         <div id="loginpopup" class="overlay">
            <div class="popup">
                 
                                <section class="section" style="background-color:orange">
                                    <a class="close" href="#">&times;</a>
                <asp:Image CssClass="span" ID="Image7" runat="server" ImageUrl="~/Image/login.jpg" />
        <h1 class="h1">Member Login</h1>
       
            <asp:TextBox CssClass="input" ID="email" runat="server" Font-Overline="False" ToolTip="Enter Email" placeholder="Email"></asp:TextBox>
            <asp:TextBox CssClass="input" ID="pass" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:Button CssClass="button" ID="Button2" runat="server" Text="Login" OnClick="Button1_Click" />
            <h2 class="h2">
                <a class="a" href='#'>Forgot Password?</a>
            </h2>
        </section>
                </div>
             </div>
        <div id="signuppop" class="overlay">
            <div class="popup">



                <h1 class="h1">Registration</h1>
                <a class="close" href="#">&times;</a>
                <hr class="hr" />
                <asp:Image CssClass="icon" ID="Image1" runat="server" ImageUrl="~/Image/Screenshot (2).png" />
                <asp:TextBox CssClass="textbox" ID="tname" runat="server" ToolTip="Name" placeholder="Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tname" ErrorMessage="*" CssClass="validator"></asp:RequiredFieldValidator><br />

                <asp:Image CssClass="icon" ID="Image2" runat="server" ImageUrl="~/Image/Screenshot (2).png" />
                <asp:TextBox CssClass="textbox" ID="temail" runat="server" ToolTip="Email" placeholder="Email"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="temail" runat="server" CssClass="validator" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />

                <asp:Image CssClass="icon" ID="Image3" runat="server" ImageUrl="~/Image/Screenshot (2).png" />
                <asp:TextBox CssClass="textbox" ID="tpass" runat="server" ToolTip="Password" placeholder="Password"></asp:TextBox><br />



                <asp:Image CssClass="icon" ID="Image4" runat="server" ImageUrl="~/Image/Screenshot (2).png" />
                <asp:TextBox CssClass="textbox" ID="tcpass" runat="server" ToolTip="Confirm Password" placeholder="Confirm Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tcpass" ControlToCompare="tpass" CssClass="validator" Type="String" ErrorMessage="*"></asp:CompareValidator><br />

                <asp:Image CssClass="icon" ID="Image5" runat="server" ImageUrl="~/Image/Screenshot (2).png" />
                <asp:TextBox CssClass="textbox" ID="tphone" runat="server" ToolTip="Phone No." placeholder="Phone No"></asp:TextBox><br />

                <asp:Image CssClass="icon" ID="Image6" runat="server" ImageUrl="~/Image/Screenshot (2).png" />
                <asp:DropDownList ID="country" runat="server" CssClass="textbox">
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>United Kingdom</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>Canada</asp:ListItem>
                    <asp:ListItem>Pakistan</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                </asp:DropDownList><br />
                <br />



                <input type="radio" value="None" id="male" name="gender" checked runat="server" />
                <label for="male" class="radio" checked>Male</label>
                <input type="radio" value="None" id="female" name="gender" runat="server" />
                <label for="female" class="radio">Female</label>
                <hr class="hr" />
                <asp:Label ID="status" runat="server" Text=""></asp:Label><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tname" ErrorMessage="*Name is required" CssClass="validator1"></asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="temail" ErrorMessage="*Enter Valid Email" CssClass="validator1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tcpass" ControlToCompare="tpass" Type="String" ErrorMessage="*Password Does not Match" CssClass="validator1"></asp:CompareValidator><br />

                <p class="p">By clicking Register, you agree on our <a href="#">terms and condition</a>.</p>
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Register"  OnClick="Button1_Click" />



            </div>


        </div>
    </form>
            </div>
        </main>
    
</body>
</html>
