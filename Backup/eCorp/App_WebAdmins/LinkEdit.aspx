<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="LinkEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.LinkEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
    <tr>
        <td>
            <asp:Label ID="lbModeMessage" runat="server" Text="Quản lý liên kết"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="5" style="width: 100%">
                <tr>
                    <td width="80">
                        <asp:Label ID="lbLinkID" runat="server" Text="Mã"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLinkID" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLinkName" runat="server" Text="Tên liên kết"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLinkName" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbURL" runat="server" Text="URL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtURL" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPos" runat="server" Text="Vị trí"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPos" runat="server" Width="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLogo" runat="server" Text="Logo"></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="imgLogo" runat="server" />
                        <br />
                        <asp:TextBox ID="txtLogo" runat="server" Width="400px"></asp:TextBox>
                        <br />
                        <asp:FileUpload ID="fulLogo" runat="server" Width="400px" />
&nbsp;<asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" Text="Tải lên" />
                        <br />
                        <asp:Label ID="lbLogoMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Lưu" 
                Width="60px" />
&nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="Bỏ qua" 
                Width="60px" />
        </td>
    </tr>
</table>
</asp:Content>
