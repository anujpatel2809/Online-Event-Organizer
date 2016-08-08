<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EO1.css.login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="html">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" runat="server" href="css/login1.css" />
    <link id="link2" rel="stylesheet" runat="server" href="css/login2.css" />
    <link href="css/main.css" rel="stylesheet" />
    <script src="js/pace.js"></script>
</head>
<body>
    <main id="top" class="masthead" role="main">
        <div class="container">
    <section class="section">
        <asp:Image CssClass="span" ID="Image1" runat="server" ImageUrl="~/Image/Letter-E-blue-icon.png" />
        <h1 class="h1">Member Login</h1>
        <form class="form" id="form1" runat="server">
            <div id="panel" runat="server">
            <asp:TextBox CssClass="input" ID="email" runat="server" Font-Overline="False" ToolTip="Enter Email" placeholder="Email"></asp:TextBox>
            <br /><br />
            <asp:TextBox CssClass="input" ID="pass" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br /><br />
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
            <h2 class="h2">
                          <a class="a" href="forgotpass.aspx">Forgot Password?</a>
                <br />
                 <a class="a" href="signup.aspx">Don't have account</a>
            </h2>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
        </form>
    </section>
            </div>
         </main>
</body>
</html>
