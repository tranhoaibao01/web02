<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AboutUsEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.AboutUsEdit" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
    <tr>
        <td align="left">
            <asp:Label ID="lbModeMessage" runat="server" Text="Cập nhập"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lbIntroID" runat="server" Text="Mã"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtIntroID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lbDescription" runat="server" Text="Nội dung"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <CKEditor:CKEditorControl ID="ckeDescription" runat="server">
            </CKEditor:CKEditorControl>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:CheckBox ID="chkActive" runat="server" Text="Kích hoạt" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Lưu" 
                Width="60px" />
&nbsp;
            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Bỏ qua" Width="60px" />
        </td>
    </tr>
</table>
</asp:Content>
