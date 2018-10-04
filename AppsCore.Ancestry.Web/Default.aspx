<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Async="true"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <br/>
    <br/>
    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="searchName" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  />
        </div>
       
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Gender"></asp:Label>
            <asp:CheckBoxList ID="genderSelection" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div class="col-md-4">
         
        </div>
       
    </div>
    <br/>
    <br/>
    <div class="row">

        <div class="col-md-8">
            <asp:GridView ID="displayGrid" runat="server"></asp:GridView>
        </div>
        
       
    </div>

</asp:Content>
