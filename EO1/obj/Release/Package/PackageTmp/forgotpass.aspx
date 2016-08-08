<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpass.aspx.cs" Inherits="EO1.forgotpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <main id="top" class="masthead" role="main">
        <div class="container">
    <section class="section">
        <asp:Image CssClass="span" ID="Image1" runat="server" ImageUrl="~/Image/Letter-E-blue-icon.png" />
        <h1 class="h1">Forgot Password</h1>
        <form class="form" id="form1" runat="server">
            <asp:Label ID="status" runat="server" ></asp:Label><br />
            <asp:TextBox CssClass="input" ID="email" runat="server" Font-Overline="False" ToolTip="Enter Email" placeholder="Email"></asp:TextBox>
            <br /><br />
            
            <asp:Button CssClass="button" ID="reset" runat="server" Text="Resrt Password" OnClick="reset_Click"  />
           
        </form>
    </section>
            </div>
         </main>
</body>
</html>
