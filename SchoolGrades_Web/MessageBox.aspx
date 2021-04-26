<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.aspx.cs" Inherits="SchoolGrades_Web.MessageBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label id="lblMessage" Text="" runat="server"/>
            <br />
            <asp:Button ID="btnOk" Text="OK" runat="server" />
        </div>
    </form>
</body>
</html>
