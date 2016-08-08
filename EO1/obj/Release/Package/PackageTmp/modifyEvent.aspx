<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="modifyEvent.aspx.cs" Inherits="EO1.WebForm5" %>

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
                            <label>Event Name</label>
                            <asp:TextBox ID="event_name" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <label>Event Starting Date</label>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                     <div class="form-group">
                                    <asp:Button ID="sdate" runat="server" CssClass="form-control datebutton" OnClick="sdate_Click" />


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
                                        OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender">
                                        <OtherMonthDayStyle ForeColor="Gray" />
                                        <DayStyle CssClass="myCalendarDay" />
                                        <SelectedDayStyle Font-Bold="True" Font-Size="12px" />
                                        <SelectorStyle CssClass="myCalendarSelector" />
                                        <NextPrevStyle CssClass="myCalendarNextPrev" />
                                        <TitleStyle CssClass="myCalendarTitle" />
                                    </asp:Calendar>

                                    </div>
                          <div class="form-group">
                              <label>Event Ending Date</label>

                              <asp:Button ID="edate" runat="server" CssClass="form-control datebutton" OnClick="edate_Click" />


                              <asp:Calendar ID="Calendar2" runat="server"
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
                                  OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender">
                                  <OtherMonthDayStyle ForeColor="Gray" />
                                  <DayStyle CssClass="myCalendarDay" />
                                  <SelectedDayStyle Font-Bold="True" Font-Size="12px" />
                                  <SelectorStyle CssClass="myCalendarSelector" />
                                  <NextPrevStyle CssClass="myCalendarNextPrev" />
                                  <TitleStyle CssClass="myCalendarTitle" />
                              </asp:Calendar>
                          </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="form-group">
                                <label>Venue</label>
                                <asp:TextBox ID="venue" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>Description</label>
                                <asp:TextBox ID="description" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            </div>


                            <asp:Button ID="ModifyEveB" runat="server" Text="Modify Event" CssClass="btn btn-info" OnClick="ModifyEveB_Click" />



                        </div>
                    </div>

                </div>
            </div>

        </div>
</asp:Content>
