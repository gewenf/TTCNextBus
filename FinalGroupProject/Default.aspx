<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalGroupProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
         <h3>Group Project</h3>
        <ul>
            <li>Course: PROG 37721– Web Services Using .NET and C# Programming</li>
            <li>Submitted to: Professor Paolo Treves</li>
            <li>Student: Jinhao Zhang / 991457994  </li>
            <li>Student: Wenfeng Ge / 991507972</li>            
        </ul>
        <h3>Instructions</h3>
        <ul>
            <li>On the "Next Bus" page, enter a ttc stop ID, click "Next Bus Arrival Time", the real-time predictions for that stop will be displayed in the table. </li>
            <li>You can find stop ID(stop number) on ttc poles or google map. We have set "246" as a default stopID for test.</li>
            <li>After login, you can save stop IDs to database on the "Next Bus" page. </li>
            <li>After login, you can select a stop ID from your saved list to check bus arrival time or delete it on the "My Next Bus" page. </li>
            <li><a href="./NextBus">Get Started!</a></li>
        </ul>
            

    </div>     

</asp:Content>
