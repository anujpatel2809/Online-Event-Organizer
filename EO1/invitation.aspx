<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="invitation.aspx.cs" Inherits="EO1.WebForm8" %>
<%@ MasterType VirtualPath="~/pagemaster.Master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Invitetions</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">

            </div>
            <div class="row">
                <div class="col-md-full">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Invitations
                        </div>
                        <div id="invpanel" class="panel-body" runat="server">
                            <div id="invitationMessage">
                                                         </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>

