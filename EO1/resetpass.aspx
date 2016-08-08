<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetpass.aspx.cs" Inherits="EO1.resetpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/custom.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <div class="col-md-6">
            <div class="panel-body" runat="server" id="panel">
           <label>Enter New Password</label>
            <asp:TextBox ID="pass" runat="server" CssClass="form-control"></asp:TextBox>
            <label>ReEnter New Password</label>
            <asp:TextBox ID="rpass" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="rpass" ControlToCompare="pass" Type="String" ErrorMessage="*Password dosen't match" CssClass="validator"></asp:CompareValidator>
                <br />
            <asp:Button ID="Button1" runat="server" Text="Change Password" CssClass="btn btn-success" OnClick="Button1_Click" />
                <br />
                <br />
                
                </div>
        </div>
            </center>
    </form>
</body>
</html>
