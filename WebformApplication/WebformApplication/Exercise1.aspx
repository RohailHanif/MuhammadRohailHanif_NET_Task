<%@ Page Title="Exercise 1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise1.aspx.cs" Inherits="WebformApplication.Exercise1" %>
<asp:Content ID ="CssContent" ContentPlaceHolderID="CssContent" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h2><%: Title %>.</h2>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="input-group">
                    <asp:FileUpload ID="fileUploadControl" CssClass="form-control" runat="server" onchange="return validateFileSize();" />
                    <asp:Button ID="btnUpload" CssClass="btn btn-outline-secondary" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="vgfileUploadControl" />
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="rfvfileUploadControl" ForeColor="Red" runat="server" SetFocusOnError="true"
                        ValidationGroup="vgfileUploadControl" ControlToValidate="fileUploadControl">pdf File Required</asp:RequiredFieldValidator>
                </div>
            <div>
                <asp:RegularExpressionValidator ID="rgxfileUploadControl" ForeColor="Red" runat="server" causeva="true" ValidationGroup="vgfileUploadControl"
                    ControlToValidate="fileUploadControl" ValidationExpression="^([a-zA-Z].*|[1-9].*)\.(((p|P)(d|D)(f|F)))$">Only Accept pdf </asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label Text="" ID="lblMessage" runat="server" />
            </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID ="JavascriptContent" ContentPlaceHolderID="JavascriptContent" runat="server">
    <script type="text/javascript">
        function validateFileSize() {
            var fileUpload = document.getElementById("<%= fileUploadControl.ClientID %>");
            var files = fileUpload.files;
            var maxSize = 1 * 1024 * 1024; // 1 MB
            for (var i = 0; i < files.length; i++) {
                if (files[i].size > maxSize) {
                    var lblMessage = document.getElementById("<%= lblMessage.ClientID %>");
                    lblMessage.innerText = "File size exceed the limit of 1 MB."
                    lblMessage.style.color = "Red";
                    //  alert("File size exceeds the limit of 1 MB.");
                    fileUpload.value = ""; // Clear the FileUpload control
                    return false;
                }
            }
            return true;
        }
    </script>
</asp:Content>
