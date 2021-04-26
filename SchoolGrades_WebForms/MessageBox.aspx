<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.aspx.cs" Inherits="SchoolGrades_WebForms.MessageBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MessageBoxPage" runat="server">
        <div>
            <asp:Label id="lblMessage" Text="" runat="server"/>
            <asp:Button ID="btnOk" Text="OK" runat="server" />
        </div>
    </form>
</body>
</html>
<%--<a href="MessageBox.aspx.cs">MessageBox.aspx.cs</a>--%>