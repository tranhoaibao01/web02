<%@ Page Title="Cập nhập sản phẩm" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.ProductEdit" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left">
                <asp:Label ID="lbModeMessage" runat="server" Text="Cập nhập sản phẩm"></asp:Label>
            </td>
            <td width="15">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="5" cellspacing="5" style="width: 100%">
                    <tr>
                        <td width="100">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Mã sản phẩm"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbProductTitle" runat="server" Text="Tên sản phẩm"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtProductTitle" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbCategories" runat="server" Text="Chọn thể loại"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCategories" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbImageURL" runat="server" Text="Hình ảnh"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Image ID="imgImageURL" runat="server" />
                            <br />
                            <asp:TextBox ID="txtImageURL" runat="server" Width="346px"></asp:TextBox>
                            <br />
                            <asp:FileUpload ID="fulImageURL" runat="server" Width="350px" />
                            <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
                                Text="Tải lên" />
                            <br />
                            <asp:Label ID="lbImageUrlMess" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbDescription" runat="server" Text="Mô tả"></asp:Label>
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="ckeDescription" runat="server">
                            </CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Lưu" 
                                Width="60px" />
                            <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
                                Text="Làm lại" Width="60px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
