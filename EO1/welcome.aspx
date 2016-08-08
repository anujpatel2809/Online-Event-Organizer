<%@ Page Title="" Language="C#" MasterPageFile="~/pagemaster.Master" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="EO1.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="page-head-line">DASHBOARD</h1>


                </div>
            </div>
           
            <div class="row">
                <div class="col-md-4">
                    <div class="main-box mb-red">
                        <a href="#">
                            <i class="fa fa-bolt fa-5x"></i>
                            <h5>Zero Issues</h5>
                        </a>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="main-box mb-dull">
                        <a href="#">
                            <i class="fa fa-clock-o fa-5x"></i>
                            <h5>Always on Time</h5>
                        </a>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="main-box mb-pink">
                        <a href="#">
                            <i class="fa fa-users fa-5x"></i>
                            <h5>Unity in Strength</h5>
                        </a>
                    </div>
                </div>

            </div>


            <div class="alert" style="background-color: lightpink">
                <br />
                <a class="a" href="addEvent.aspx" style="font-size: x-large">Let us Create a New Event...</a>
                <br />
                <br />
            </div>

            <div class="alert" style="background-color: deepskyblue">
                <br />

                <a class="a" href="progressbar.aspx" style="font-size: x-large">Let's See your Task progress...</a>
                <br />
                <br />

            </div>


            <div class="alert" style="background-color: orange">
                <br />
                <a class="a" href="viewEvent.aspx" style="font-size: x-large">Review your Events...</a>
                <br />
                <br />

            </div>

            <div class="alert" style="background-color: lightgreen">
                <br />
                <a class="a" href="invite.aspx" style="font-size: x-large">Wanna Invite Someone On your Team...</a>
                <br />
                <br />

            </div>

        </div>
    </div>

</asp:Content>
