<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="taskdetails.aspx.cs" Inherits="EO1.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">
            </div>

            <div class="panel panel-info">
                <div class="panel-heading">
                    Task Details
                </div>
                <div class="panel-body">

                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Task Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="task_name" runat="server"></asp:Label>
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
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="status" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Deadline"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="deadline" runat="server"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </div>

                </div>
            </div>
             <div class="row">
                <div class="col-md-5">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Task Status
                        </div>
                        <div class="panel-body">
                            <asp:DropDownList ID="tstatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Not Started</asp:ListItem>
                                <asp:ListItem Value="1">Just Started</asp:ListItem>
                                <asp:ListItem Value="2">Half Complete</asp:ListItem>
                                <asp:ListItem Value="3">Almost Complete</asp:ListItem>
                                <asp:ListItem Value="4">Complete</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:Button ID="update" runat="server" Text="Update Status" CssClass="btn btn-success" OnClick="update_Click"  />
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
