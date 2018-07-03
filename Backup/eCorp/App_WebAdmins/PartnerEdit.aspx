<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="PartnerEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.PartnerEdit" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
    <tr>
        <td>
            <asp:Label ID="lbModeMessage" runat="server" Text="Cập nhập khách hàng"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="5" style="width: 100%">
                <tr>
                    <td width="80">
                        <asp:Label ID="lbPartnerID" runat="server" Text="Mã"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPartnerID" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPartnerName" runat="server" Text="Tên khách"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPartnerName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbImageURL" runat="server" Text="Hình ảnh"></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="imgImageURL" runat="server" />
                        <br />
                        <asp:TextBox ID="txtImageURL" runat="server" Width="300px"></asp:TextBox>
                        <br />
                        <asp:FileUpload ID="fulImageURL" runat="server" Width="300px" />

                        <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
                            Text="Tải lên" />
                        <br />
                        <asp:Label ID="lbImageUrlMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbWebsite" runat="server" Text="Website"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWebsite" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
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
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Lưu" 
                Width="60px" />

            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Bỏ qua" Width="60px" />
        </td>
    </tr>
</table>
</asp:Content>
