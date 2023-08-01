<%@ Page Title="WebGAME." Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gameform.aspx" Inherits="WebGAME.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome to the number Guessing Game!</h1>
    <asp:Label ID="lblFeedback" runat="server" Text="Feedback"></asp:Label>
    <br />
    <asp:TextBox ID="txtGuess" runat="server" OnTextChanged="txtGuess_TextChanged"></asp:TextBox>
    <asp:Button ID="btnSubmit" Text="Submit Guess" OnClick="SubmitButton_Click" runat="server"  />
</asp:Content>
