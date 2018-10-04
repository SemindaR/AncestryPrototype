<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="keywordTextBox" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        </div>
        
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Gender"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div class="col-md-4">
           
        </div>
        
    </div>
</asp:Content>
