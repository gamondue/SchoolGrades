<%@ Page Title="SchoolGrades_Web" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolGrades_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Anno <asp:DropDownList ID="CmbSchoolYear" type="text" value="School years" runat="server" OnClick=""/>
            Tipo di valutazione <asp:DropDownList ID="cmbGradeType" type="text" value="Type of grade" runat="server" OnClick=""/>
            Materia <asp:DropDownList ID="cmbSchoolSubject" type="text" value="School subject" runat="server" OnClick="" />  
        </div>
    </form>
</body>
</html>
