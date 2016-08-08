<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="assignTask.aspx.cs" Inherits="EO1.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
        <div id="page-inner">
            <div id="message" runat="server">

            </div>
            <br />
            <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Event
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label>Select Event</label>
                            <asp:DropDownList ID="eventlist" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="eventlist_SelectedIndexChanged" ></asp:DropDownList>
                            
                        </div>
                        <div class="form-group">
                            <label>Select Member</label>
                           <asp:DropDownList ID="memberlist" runat="server" CssClass="form-control"></asp:DropDownList>
                            
                        </div>
                        <div class="form-group">
                            <label>Task Name</label>
                            <asp:TextBox ID="taskname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="taskname" ErrorMessage="*Task Name Is required" CssClass="validator"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Task Description</label>
                            <asp:TextBox ID="task" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Task Deadline</label>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <asp:Button ID="ddate" runat="server"  CssClass="form-control datebutton" OnClick="ddate_Click" />
                            
                         
                            <asp:Calendar ID="Calendar1" runat="server"
                                DayNameFormat="FirstLetter"
                                 Font-Names="Arial"
                                Font-Size="11px"
                                 NextMonthText="»"
                                PrevMonthText="«"
                                SelectionMode="DayWeekMonth"
                                SelectMonthText="»"
                                SelectWeekText="›"
                                CssClass="myCalendar"
                                CellPadding="1"
                                 Visible="False"
                                 BorderStyle="None"
                                OnSelectionChanged="Calendar1_SelectionChanged">
                                 <OtherMonthDayStyle ForeColor="Gray" />
                                <DayStyle CssClass="myCalendarDay" />
                                 <SelectedDayStyle Font-Bold="True" Font-Size="12px" />
                                <SelectorStyle CssClass="myCalendarSelector" />
                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                <TitleStyle CssClass="myCalendarTitle" />
                            </asp:Calendar>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <asp:Button ID="taskbutton" runat="server" Text="Assign task" CssClass="btn btn-info" OnClick="taskbutton_Click"  />
                         

                       
                    </div>
                </div>
                
            </div>
        </div>

    </div>
</asp:Content>
