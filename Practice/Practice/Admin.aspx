<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Practice.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 508px">
    <form id="form1" runat="server">
        <div style="z-index: 1; left: 20px; top: 27px; position: absolute; height: 24px; width: 152px">
             
            <asp:TextBox ID="searchBox" runat="server" style="z-index: 1; left: 0px; top: 0px; position: absolute"></asp:TextBox>
        </div>
        <asp:Button ID="enterButton" runat="server" style="z-index: 1; left: 25px; top: 66px; position: absolute" Text="Enter" OnClick="enterButton_Click" />
        <div style="z-index: 1; left: 18px; top: 115px; position: absolute; height: 389px; width: 364px">
            <asp:ListBox ID="resultsBox" runat="server" style="z-index: 1; left: 0px; top: 0px; position: absolute; height: 383px; width: 362px;"></asp:ListBox>
        </div>
        <div style="z-index: 1; left: 707px; top: 38px; position: absolute; height: 302px; width: 300px">
            <asp:Image ID="imageBox" runat="server" style="z-index: 1; left: 9px; top: 8px; position: absolute; height: 285px; width: 282px" />
        </div>
        <div style="z-index: 1; left: 769px; top: 356px; position: absolute; height: 31px; width: 182px">
            <asp:Button ID="nextButton" runat="server" OnClick="nextButton_Click" style="z-index: 1; left: 122px; top: 0px; position: absolute; width: 54px" Text="Next" />
            <asp:Button ID="previousButton" runat="server" OnClick="previousButton_Click" style="z-index: 1; left: 0px; top: 0px; position: absolute" Text="Previous" />
        </div>
        <div style="z-index: 1; left: 872px; top: 481px; position: absolute; height: 31px; width: 137px">
            <asp:Button ID="exportButton" runat="server" style="z-index: 1; left: 72px; top: 0px; position: absolute" Text="Export" OnClick="exportButton_Click" />
            <asp:Button ID="saveButton" runat="server" style="z-index: 1; left: 0px; top: 0px; position: absolute; width: 54px" Text="Save" OnClick="saveButton_Click" />
        </div>
        <div style="z-index: 1; left: 407px; top: 53px; position: absolute; height: 451px; width: 282px">
            <asp:Panel ID="panel" runat="server" style="z-index: 1; left: 0px; top: 8px; position: absolute; height: 435px; width: 282px" Visible="False">
                <asp:Button ID="searchButton" runat="server" style="z-index: 1; left: 120px; top: 3px; position: absolute; bottom: 406px;" Text="Search" OnClick="searchButton_Click" />
                <asp:TextBox ID="filterSearchBox3" runat="server" style="z-index: 1; left: 153px; top: 126px; position: absolute; width: 113px"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 14px; top: 44px; position: absolute; width: 91px" Text="fname"></asp:Label>
                <asp:TextBox ID="filterSearchBox1" runat="server" style="z-index: 1; left: 160px; top: 43px; position: absolute; width: 111px"></asp:TextBox>
                <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" style="z-index: 1; left: 216px; top: 4px; position: absolute" Text="Add" />
                <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 21px; top: 169px; position: absolute" Text="position"></asp:Label>
                <asp:Button ID="changeButton" runat="server" OnClick="changeButton_Click" style="z-index: 1; left: 13px; top: 3px; position: absolute" Text="Change" />
                <asp:TextBox ID="filterSearchBox2" runat="server" style="z-index: 1; left: 158px; top: 87px; position: absolute; width: 111px"></asp:TextBox>
                <asp:TextBox ID="filterSearchBox4" runat="server" style="z-index: 1; left: 150px; top: 168px; position: absolute; width: 117px; bottom: 245px"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 17px; top: 88px; position: absolute" Text="lname"></asp:Label>
                <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 20px; top: 129px; position: absolute" Text="address"></asp:Label>
            </asp:Panel>
        </div>
        <asp:Button ID="filterButton" runat="server" OnClick="filterButton_Click" style="z-index: 1; left: 83px; top: 66px; position: absolute" Text="Filter" />
    </form>
</body>
</html>
