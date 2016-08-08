<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="EO1.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link type="text/css" rel="stylesheet" href="css/signup.css" />
    <link type="text/css" rel="stylesheet" href="css/wizard.css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" />
    <script src="js/pace.js"></script>
</head>
<body>
    <main id="top" class="masthead" role="main">
        <div class="container">
            <div class="box">
    <form  id="form1" runat="server" class="form">
       
        
            
             <h1 >Registration</h1>
    <hr class="hr" />
            <label class="icon"><i class="fa fa-user" ></i></label>
            <asp:TextBox CssClass="textbox" ID="tname" runat="server" ToolTip="Name" placeholder="Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tname" ErrorMessage="*" CssClass="validator"></asp:RequiredFieldValidator><br />

             <label class="icon"><i class="fa fa-envelope" ></i></label>
            <asp:TextBox CssClass="textbox" ID="temail" runat="server" ToolTip="Email" placeholder="Email"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="temail" runat="server" CssClass="validator" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />

            <label class="icon"><i class="fa fa-lock" ></i></label>
            <asp:TextBox CssClass="textbox" ID="tpass" runat="server" ToolTip="Password" placeholder="Password" TextMode="Password"></asp:TextBox><br />
           


            <label class="icon"><i class="fa fa-lock" ></i></label>
            <asp:TextBox CssClass="textbox" ID="tcpass" runat="server" ToolTip="Confirm Password" placeholder="Confirm Password" TextMode="Password" ></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tcpass" ControlToCompare="tpass" CssClass="validator" Type="String" ErrorMessage="*" ></asp:CompareValidator><br />

             <label class="icon"><i class="fa fa-phone" ></i></label>
            <asp:TextBox CssClass="textbox" ID="tphone" runat="server" ToolTip="Phone No." placeholder="Phone No"></asp:TextBox><br />

             <label class="icon"><i class="fa fa-flag" ></i></label>
            <asp:DropDownList ID="country" runat="server" CssClass="textbox">
                <asp:ListItem>India</asp:ListItem>
                <asp:ListItem>United Kingdom</asp:ListItem>
                <asp:ListItem>USA</asp:ListItem>
                <asp:ListItem>Canada</asp:ListItem>
                <asp:ListItem>Pakistan</asp:ListItem>
                <asp:ListItem>China</asp:ListItem>
            </asp:DropDownList><br /><br />
           
           
                           
               <input type="radio" value="None" id="male" name="gender" checked runat="server"/>
    <label for="male" class="radio" checked>Male</label>
    <input type="radio" value="None" id="female" name="gender" runat="server"/>
    <label for="female" class="radio">Female</label>
             <hr class="hr"/>
            <asp:Label ID="status" runat="server" Text="" ></asp:Label><br />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tname" ErrorMessage="*Name is required" CssClass="validator1"></asp:RequiredFieldValidator><br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="temail" ErrorMessage="*Enter Valid Email" CssClass="validator1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
             <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tcpass" ControlToCompare="tpass" Type="String" ErrorMessage="*Password Does not Match" CssClass="validator1" ></asp:CompareValidator><br />

            <p class="p">By clicking Register, you agree on our <a href="#" style="color:white">terms and condition</a>.</p>
            <asp:Button ID="Button1" runat="server" CssClass="button" Text="Register" OnClick="Button1_Click" />

         </form>

        </div>
       
                
               
</div>
        
    </main>

</body>
</html>
