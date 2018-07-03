<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="ContactEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.ContactEdit" %>
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
                        <asp:Label ID="lbContactID" runat="server" Text="Mã"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactID" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbContactName" runat="server" Text="Tên liên hệ"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbAddress" runat="server" Text="Địa chỉ"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPhone" runat="server" Text="Điện thoại"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbEmail" runat="server" Text="Mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbSubject" runat="server" Text="Chủ đề"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbIPClient" runat="server" Text="Địa chỉ IP"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIpClient" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbContents" runat="server" Text="Nội dung"></asp:Label>
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckEditor" runat="server">
                        </CKEditor:CKEditorControl>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Lưu" 
                Width="60px" />
&nbsp;
            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Bỏ qua" Width="60px" />
        </td>
    </tr>
</table>
</asp:Content>
