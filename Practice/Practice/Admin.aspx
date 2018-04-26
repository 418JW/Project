<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Practice.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" />
    <title></title>
</head>
<body >
    <div class="row">
        <form id="form1" runat="server">
            <div class="row third one">
                <div class="row">    
                    <asp:TextBox ID="searchBox" runat="server" ></asp:TextBox>
                </div>

                <asp:Button ID="enterButton" runat="server" Text="Enter" OnClick="enterButton_Click" />
                <asp:Button ID="filterButton" runat="server" OnClick="filterButton_Click" Text="Filter" />
            
                <div class="row">
                    <asp:ListBox ID="resultsBox" runat="server" class="resultbox"></asp:ListBox>
                </div>
            </div>
 
             <div class="row third two">
                    <asp:Panel ID="panel" runat="server" Visible="False" CssClass="row">
                        <div class="row">
                            <asp:Button ID="searchButton" runat="server"  Text="Search" OnClick="searchButton_Click" />
                            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click"  Text="Add" />
                            <asp:Button ID="changeButton" runat="server" OnClick="changeButton_Click" Text="Change" />
                        </div>

                        <div class ="row label">
                            <div class="row input">
                                <label><asp:Label ID="Label1" runat="server" Text="fname" ></asp:Label></label>
                                <asp:TextBox ID="filterSearchBox1" runat="server" ></asp:TextBox><br />

                            </div>

                            <div class="row input">
                                <label><asp:Label ID="Label2" runat="server"  Text="lname" ></asp:Label></label>
                                <asp:TextBox ID="filterSearchBox2" runat="server" ></asp:TextBox><br />
                            </div>

                            <div class="row input">
                                <label><asp:Label ID="Label3" runat="server"  Text="address"></asp:Label></label>
                                <asp:TextBox ID="filterSearchBox3" runat="server" ></asp:TextBox> <br />
                            </div>

                            <div class="row input">
                                <label><asp:Label ID="Label4" runat="server"  Text="address"></asp:Label></label>
                                <asp:TextBox ID="filterSearchBox4" runat="server" ></asp:TextBox><br />
                            </div>
                            
       
                        </div>        
                    </asp:Panel>
             </div>
              
            <div class="row third three">
                <div class="row">
                    <div class="row">
                        <asp:Image ID="imageBox" runat="server" CssClass="imgbox"/>
                    </div>
                   
                    <div class="row bttn">
                        <asp:Button ID="nextButton" runat="server" OnClick="nextButton_Click" Text="Next" />
                        <asp:Button ID="previousButton" runat="server" OnClick="previousButton_Click" Text="Previous" />
                    </div>
                </div>

                <div class ="row"> 
                    <asp:Button ID="exportButton" runat="server" Text="Export" OnClick="exportButton_Click" />
                    <asp:Button ID="saveButton" runat="server"  Text="Save" OnClick="saveButton_Click" />
                </div>
            </div>       
    
        </form>
    </div>   
            
</body>
</html>
