<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Practice._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Username: <asp:TextBox ID="tb_username" runat="server"></asp:TextBox><br />
            Password: <asp:TextBox ID="tb_password" runat="server"></asp:TextBox><br />
            <asp:Label ID="lb_msg" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"/>
        </div>
    </form>
</body>
</html>
