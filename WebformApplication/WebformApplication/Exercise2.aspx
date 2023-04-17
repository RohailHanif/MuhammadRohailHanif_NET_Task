<%@ Page Title="Exercise 2" MaintainScrollPositionOnPostBack="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise2.aspx.cs" Inherits="WebformApplication.Exercise2" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CssContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12 pt-20">
        <div class="form-group">
            <h2>Exercise No2</h2>
            <asp:Label ID="lblMessage" runat="server" />
        </div>
    </div>
    <div class="col-sm-6">
        <div class="form-group mt-0">
            <asp:Label ID="lblName" CssClass="font-weight-bold"  runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" placeholder="Name" TabIndex="1" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="nameRequired" runat="server"
                ControlToValidate="txtName" ForeColor="Red"
                ErrorMessage="Please enter your name" ValidationGroup="vgUserinformation">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group mt-0">
            <asp:Label ID="lblEmail" CssClass="font-weight-bold"  runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" placeholder="Email" TabIndex="2" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="emailRequired" runat="server" ValidationGroup="vgUserinformation"
                ControlToValidate="txtEmail" ForeColor="Red"
                ErrorMessage="Please enter your email">
            </asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="emailRegex" runat="server" ValidationGroup="vgUserinformation"
                ControlToValidate="txtEmail" ForeColor="Red"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="Please enter a valid email address">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group mt-0">
            <asp:Label ID="lblPhone" CssClass="font-weight-bold"  runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" placeholder="Phone" TabIndex="3" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="phoneRequired" runat="server" ValidationGroup="vgUserinformation"
                ControlToValidate="txtPhone" ForeColor="Red"
                ErrorMessage="Please enter your phone number">
            </asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="phoneRegex" runat="server" ValidationGroup="vgUserinformation"
                ControlToValidate="txtPhone" ForeColor="Red"
                ValidationExpression="^\d{10}$"
                ErrorMessage="Please enter a valid 10-digit phone number">
            </asp:RegularExpressionValidator>
        </div>
       

       
    </div>
    <div class="col-sm-6">
        
         <div class="form-group">
            <asp:Label ID="lblTravelMethod" CssClass="font-weight-bold" runat="server" Text="Preferred Travel Method"></asp:Label>
            <asp:DropDownList ID="ddlTravelMethod" TabIndex="4" CssClass="form-control" Width="100%" runat="server" onchange="displayingUserTravelLocationDetails(this.id)">
                <asp:ListItem Value="Sea">By Sea</asp:ListItem>
                <asp:ListItem Value="Land">By Land</asp:ListItem>
                <asp:ListItem Value="Air">By Air</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group mt-0  pt-20">
            <asp:Label ID="lblTravelLocationDetails" CssClass="font-weight-bold"  runat="server" Text="Port Name / Location"></asp:Label>
            <asp:TextBox ID="txtTravelLocationDetails" placeholder="Preferred Travel Method Description" TabIndex="5"  MaxLength="100"  CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqTravelLocationDetails" runat="server"
                ControlToValidate="txtTravelLocationDetails" ForeColor="Red"
                ErrorMessage="Please enter your Preferred Travel Method Description" ValidationGroup="vgUserinformation">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-default pull-left" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgUserinformation" />

        </div>
    </div>
    <div class="col-sm-12 pt-50">
         <asp:GridView ID="gvUserData" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Travel Method" DataField="TravelMethod" />
                <asp:BoundField HeaderText="Travel Location Details" DataField="TravelLocationDetails" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContent" runat="server">
    <script type="text/javascript">    
        
        function displayingUserTravelLocationDetails(travelMethod) {
            var travelMethodItem = document.getElementById(travelMethod);
            var value = travelMethodItem.value;
            var lblTravelLocationDetails = document.getElementById("<%= lblTravelLocationDetails.ClientID %>");
            var txtTravelLocationDetails = document.getElementById("<%= txtTravelLocationDetails.ClientID %>");

            switch (value) {
                case "Sea":
                    lblTravelLocationDetails.innerText = "Port name / location";
                    txtTravelLocationDetails.value = "";
                    break;
                case "Land":
                    lblTravelLocationDetails.innerText = "City";
                    txtTravelLocationDetails.value = "";
                    break;
                case "Air":
                    lblTravelLocationDetails.innerText = "Airport name";
                    txtTravelLocationDetails.value = "";
                    break;
            }
        }

    </script>
</asp:Content>
