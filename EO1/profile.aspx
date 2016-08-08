<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="EO1.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Profile
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label>Enter Name</label>
                                <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name" ErrorMessage="*Name Is Mandetory" CssClass="validator"></asp:RequiredFieldValidator><br />
                            </div>
                            <div class="form-group">
                                <label>Phone No</label>
                                <asp:TextBox ID="phone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Country</label>
                                <asp:DropDownList ID="country" runat="server" CssClass="form-control">
                                    <asp:ListItem>India</asp:ListItem>
                                    <asp:ListItem>United Kingdom</asp:ListItem>
                                    <asp:ListItem>USA</asp:ListItem>
                                    <asp:ListItem>Canada</asp:ListItem>
                                    <asp:ListItem>Pakistan</asp:ListItem>
                                    <asp:ListItem>China</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            
                                    <div class="form-group">
                                        <label>Profile pic</label>
                                        <div class="fileupload-new thumbnail" style="max-width: 200px; max-height: 150px;">
                                            <asp:Image ID="dp" runat="server" ImageUrl="~/Image/demoUpload.jpg" />
                                        </div>
                                        <br /><br /><br />
                                        <asp:FileUpload ID="imgUpload" runat="server" /><br />
                                        <asp:Button ID="upload" runat="server" Text="Preview Image" CssClass="btn btn-success" OnClick="upload_Click" />
                                        <asp:Button ID="remove" runat="server" Text="Remove" CssClass="btn btn-danger" OnClick="remove_Click" />
                                    </div>
                             <div class="form-group">
                            <asp:Button ID="save" runat="server" Text="Save Profile" CssClass="btn btn-success" OnClick="save_Click"/>
                                 </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
