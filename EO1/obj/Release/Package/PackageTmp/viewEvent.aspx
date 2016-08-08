<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="viewEvent.aspx.cs" Inherits="EO1.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">
            </div>
            <!--    Hover Rows  -->
            <div class="panel panel-default">
                <div class="panel-heading">
                   Your Events
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:Table ID="eventTable" runat="server" CssClass="table table-striped table-bordered table-hover">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>#</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Event Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Starting Date</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Ending Date</asp:TableHeaderCell>
                                 <asp:TableHeaderCell></asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                           
                        </asp:Table>
                        
                    </div>

                </div>
                <!-- End  Hover Rows  -->
            </div>
            
        </div>
    </div>
</asp:Content>
