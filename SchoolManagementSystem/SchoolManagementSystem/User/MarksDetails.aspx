<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="MarksDetails.aspx.cs" Inherits="SchoolManagementSystem.User.MarksDetails" %>

<%@ Register Src="~/MarksDetailUserControl.ascx" TagPrefix="uc" TagName="MarksDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<h1>New Marks Details</h1>--%>
    <uc:MarksDetail runat="server"  ID="MarksDetail1" />


</asp:Content>
