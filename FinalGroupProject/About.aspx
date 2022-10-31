<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FinalGroupProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>TTC Next Bus Service Application</h3>
    <p>In this project, we created an application to consume the "next bus" web service provided by <a href="https://www.ttc.ca/Customer_Service/Customer_Information_Initiatives/Next_vehicle_information_system/index.jsp">TTC</a> and  <a href="https://www.nextbus.com/">NextBus Inc.</a> </p>
    <p>We mainly used web forms, System.Xml.XmlTextReader, ASP.NET Identity membership system, Entity Framework and SQL Server Express LocalDB.</p>
  
</asp:Content>
