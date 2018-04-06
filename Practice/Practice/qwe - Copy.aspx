<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qwe.aspx.cs" Inherits="Practice.qwe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 139px;
        }
    </style>
</head>
<body style="height: 447px">
    <form id="form1" runat="server">
        <asp:TextBox ID="search" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute">Search</asp:TextBox>
        <asp:Button ID="enter" runat="server" style="z-index: 1; left: 13px; top: 52px; position: absolute" Text="Enter" />
        <asp:Button ID="filter" runat="server" style="z-index: 1; left: 76px; top: 52px; position: absolute" Text="Filter" />
        <div style="z-index: 1; left: 464px; top: 53px; position: absolute; height: 372px; width: 247px; margin-left: 0px">
            <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 0px; top: 0px; position: absolute" Text="Change" />
            <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 68px; top: 2px; position: absolute; width: 76px; right: 128px; margin-top: 0px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 167px; top: 4px; position: absolute; bottom: 199px" Text="First Name"></asp:Label>
            <asp:Button ID="add" runat="server" style="z-index: 1; left: -2px; top: 42px; position: absolute; margin-top: 0px" Text="Add" />
        </div>
        <div style="z-index: 1; left: 792px; top: 350px; position: absolute; height: 38px; width: 151px">
            <asp:Button ID="Button3" runat="server" style="z-index: 1; left: 97px; top: 5px; position: absolute; margin-top: 0px" Text="Next" />
            <asp:Button ID="Button4" runat="server" style="z-index: 1; left: 14px; top: 5px; position: absolute" Text="Previous" />
        </div>
        <div style="z-index: 1; left: 895px; top: 426px; position: absolute; height: 26px; width: 128px">
            <asp:Button ID="Button5" runat="server" style="z-index: 1; left: 0px; top: 0px; position: absolute" Text="Export" />
            <asp:Button ID="Button6" runat="server" style="z-index: 1; left: 71px; top: 0px; position: absolute; right: 149px" Text="Save" />
        </div>
    <div style="z-index: 1; left: 736px; top: 123px; position: absolute; height: 198px; width: 279px">
    </div>
        <div style="z-index: 1; left: 975px; top: 24px; position: absolute; height: 29px; width: 58px">
            <asp:Button ID="Button7" runat="server" style="z-index: 1; left: 12px; top: 0px; position: absolute" Text="Login" />
        </div>
        <div style="z-index: 1; left: 21px; top: 126px; position: absolute; height: 291px; width: 402px">
            <asp:ListBox ID="ListBox1" runat="server" style="z-index: 1; left: 0px; top: 0px; position: absolute; height: 275px; width: 390px"></asp:ListBox>
        </div>
    </form>
    </body>
</html>
