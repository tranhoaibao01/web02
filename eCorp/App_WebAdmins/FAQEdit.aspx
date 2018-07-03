<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="FAQEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.FAQEdit" %>
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
                    <td width="60">
                        <asp:Label ID="lbFaqId" runat="server" Text="Mã"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFaqId" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbTitle" runat="server" Text="Tiêu đề"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbDescription" runat="server" Text="Mô tả"></asp:Label>
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
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Luu" 
                Width="60px" />
&nbsp;
            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Bỏ qua" />
        </td>
    </tr>
</table>
</asp:Content>
