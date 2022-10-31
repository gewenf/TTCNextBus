<%@ Page Title="Next Bus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NextBus.aspx.cs" Inherits="FinalGroupProject.NextBus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>. <span class="Note">Please wait 20 seconds between each query. Too frequent queries may cause IP being blocked.</span></h2>     
    <div class ="gridArea">
        <div class ="map"> 
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d858.3459729147385!2d-79.379176453525!3d43.64566733177987!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89d4cb2cc1cf406b%3A0xdffb7291834411c4!2sBay%20St%20at%20Front%20St%20West%20South%20Side%20-%20Union%20Station!5e0!3m2!1sen!2sca!4v1667175202887!5m2!1sen!2sca" width="800" height="400" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        <div class ="nextBus">            
            <asp:Label ID="lblTest" runat="server"></asp:Label>
            <hr />
             <asp:Label ID="Label1" runat="server" Text="Enter Stop ID"></asp:Label>    
             <asp:TextBox ID="txtStopID" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStopID"
                ErrorMessage="please enter a valid stop ID!" /> <br />
            <asp:RangeValidator runat="server" Type="Integer" 
                 MinimumValue="0" MaximumValue="100000" ControlToValidate="txtStopID" 
                 ErrorMessage="please enter a valid stop ID!" /><br />
            
             <asp:Button ID="btnSave" runat="server" Text="Save Stop ID" visible="false" OnClick="btnSave_Clicked" />
            <asp:Button ID="btnCheckBus" runat="server" Text="Next Bus Arrival Time" OnClick="btnCheckBus_Clicked" />
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>    <br />
            <asp:Label ID="lblStopTitle" runat="server" Text=""></asp:Label>    <br />
            <asp:Table ID="BusTable" runat="server" Width="90%" GridLines="Both" HorizontalAlign="Right"> 
                <asp:TableRow>
                    <asp:TableCell>Time(min)</asp:TableCell>
                    <asp:TableCell>Bus Route</asp:TableCell>                   
                </asp:TableRow>
            </asp:Table>                    
        </div>
    </div>
</asp:Content>
