<%@ Page Title="SchoolGrades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolGrades_WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>SchoolGrades_Web</h1>
        <p class="lead"></p>
        <%--<a runat="server" href="~/">Home</a>--%>
<%--        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            Anno <SELECT id="CmbSchoolYear" type="text" value="School years" runat=server />
            Tipo valutazione <SELECT id="cmbGradeType" type="text" value="Type of grade" runat=server />
            Materia <SELECT id="cmbSchoolSubject" type="text" value="School subject" runat=server />
        </div>  
        <asp:Button ID="btnTest" runat="server" Text="Test" BackColor="Red" ForeColor="Yellow"/>
    </div>
</asp:Content>
