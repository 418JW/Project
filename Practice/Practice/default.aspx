<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Practice._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="row login" >
        <form id="form1" runat="server">
            <div class="input">
                <label>Username: </label>
                <asp:TextBox ID="tb_username" runat="server"></asp:TextBox><br />
            </div>
            
            <div class="input">
                <label>Password: </label>
                <asp:TextBox ID="tb_password" runat="server"></asp:TextBox><br />
            </div>
            

            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"/>
            <br />
            <asp:Label ID="lb_msg" runat="server" Text="" ForeColor="Red" ></asp:Label><br />
        </form>
    </div>
</body>
</html>
