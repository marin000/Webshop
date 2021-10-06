<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
</p>
<p>
    User Name:</p>
<p>
    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
</p>
<p>
    Password:</p>
<p>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
</p>
<p>
    Confirm Password:</p>
<p>
    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
</p>
    <p>
        First Name:</p>
    <p>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputs"></asp:TextBox>
</p>
    <p>
        Last Name:</p>
    <p>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputs"></asp:TextBox>
</p>
    <p>
        Email:</p>
    <p>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs"></asp:TextBox>
</p>
    <p>
        Credit card number:</p>
    <p>
        <asp:TextBox ID="txtCreditCard" runat="server" CssClass="inputs"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Button" />
</p>
</asp:Content>

