<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="BranchEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.BranchEdit" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
    <tr>
        <td>
            <asp:Label ID="lbModeMessage" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="5" style="width: 100%">
                <tr>
                    <td width="80">
                        <asp:Label ID="lbBranchID" runat="server" Text="Mã"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBranchID" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbBranchName" runat="server" Text="Tên CN"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" Width="500px" TabIndex="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                            <asp:Label ID="lbImageUrl" runat="server" Text="Hình ảnh"></asp:Label>
                    </td>
                    <td>
                            <asp:Image ID="imgImageURL" runat="server" TabIndex="2" />
                            <br />
                            <asp:TextBox ID="txtImageURL" runat="server" TabIndex="2" Width="350px"></asp:TextBox>
                            <asp:FileUpload ID="fulImageURL" runat="server" TabIndex="3" 
                            Width="350px" />
                        <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
                            TabIndex="4" Text="Tải lên" />
                            <br />
                            <asp:Label ID="lbImageUrlMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbAddress" runat="server" Text="Địa chỉ"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Width="500px" TabIndex="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPhone" runat="server" Text="Điện thoại"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Width="100px" TabIndex="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPhone0" runat="server" Text="Di động"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" Width="100px" TabIndex="7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPhone1" runat="server" Text="Fax"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server" Width="100px" TabIndex="8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbEmail" runat="server" Text="Mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="300px" TabIndex="9"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbEmail0" runat="server" Text="Web site"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWebSite" runat="server" Width="300px" TabIndex="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbContents" runat="server" Text="Nội dung"></asp:Label>
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckEditor" runat="server" TabIndex="11"></CKEditor:CKEditorControl>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Lưu" 
                Width="60px" TabIndex="12" />
&nbsp;
            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Bỏ qua" Width="60px" TabIndex="13" />
        </td>
    </tr>
</table>
</asp:Content>
