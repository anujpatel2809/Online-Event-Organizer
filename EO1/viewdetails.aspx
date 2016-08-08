<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="viewdetails.aspx.cs" Inherits="EO1.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">
            </div>

            <div class="panel panel-info">
                <div class="panel-heading">
                    Event Details
                </div>
                <div class="panel-body">
                    <b>
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Event Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="event_name" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Starting Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="sdate" runat="server"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Ending Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="edate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Venue"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="venue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 20px; text-align: match-parent">
                                        <asp:Label ID="Label5" runat="server" Text="Description"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="description" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </b>
                </div>
            </div>
           

        </div>
</asp:Content>
