<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="notification.aspx.cs" Inherits="EO1.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div class="row">
                <div class="col-md-6">

                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <asp:Label ID="istatus" runat="server" Text="Invitation Status"></asp:Label>
                        </div>
                        <div class="panel-body" style="padding: 0px;">
                            <div id="invitationnoti" class="chat-widget-main" runat="server">

                            </div>

                        </div>
                    </div>
                </div>
                
                <div class="col-md-6">

                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <asp:Label ID="notificationhead" runat="server" Text="Notification"></asp:Label>
                        </div>
                        <div class="panel-body" style="padding: 0px;">
                            <div id="notification" class="chat-widget-main" runat="server">

                            </div>

                        </div>
                    </div>
                </div>
                
            </div>
            
        </div>
    </div>
</asp:Content>
