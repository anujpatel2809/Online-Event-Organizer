<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="pendingTask.aspx.cs" Inherits="EO1.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">

            </div>
            <div class="row">
                <div id="divpanel" class="col-md-12">
                   <!-- <div id="divpanel" class="panel panel-primary" runat="server">
                        <!-- Default panel contents ->
                        <div class="panel-heading"># TO DO LIST - TASK YOU HAVE TO DO</div>
                        <div class="table-responsive">
                        <asp:Table ID="taskTable" runat="server" CssClass="table table-striped table-bordered table-hover">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>#</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Event Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Task Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Deadline</asp:TableHeaderCell>
                                 <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                          
                        </asp:Table>
                        
                    </div>-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
