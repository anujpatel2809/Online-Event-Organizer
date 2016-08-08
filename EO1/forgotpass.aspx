<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpass.aspx.cs" Inherits="EO1.forgotpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/main.css" rel="stylesheet" />
    <link id="link1" rel="stylesheet" runat="server" href="css/login1.css" />
    <link id="link2" rel="stylesheet" runat="server" href="css/login2.css" />
</head>
<body>
    <main id="top" class="masthead" role="main">
        <div class="container">
    <section class="section">
        <asp:Image CssClass="span" ID="Image1" runat="server" ImageUrl="~/Image/Letter-E-blue-icon.png" />
        <h1 class="h1">Forgot Password</h1>
        <form class="form" id="form1" runat="server">
            <div id="panel" runat="server">
            <asp:TextBox CssClass="input" ID="email" runat="server" Font-Overline="False" ToolTip="Enter Email" placeholder="Email"></asp:TextBox>
            <br /><br />
                    <asp:Button CssClass="button" ID="reset" runat="server" Text="Reset Password" OnClick="reset_Click"  />
                <br /><br /><br /><br /><br />
                <br /><br /><br /><br /><br />
           </div>
        </form>
    </section>
            </div>
         </main>
</body>
</html>
