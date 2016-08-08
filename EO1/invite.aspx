<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="invite.aspx.cs" Inherits="EO1.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">
            </div>
            <div class="col-md-9 col-sm-6 col-xs-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Invite Volentears
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:DropDownList ID="event_list" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Email Id</label>
                            <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="validator" ControlToValidate="email" ErrorMessage="Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>Description</label>
                            <asp:TextBox ID="desc" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <asp:Button ID="invite" runat="server" Text="Invite" CssClass="btn btn-success" OnClick="invite_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
