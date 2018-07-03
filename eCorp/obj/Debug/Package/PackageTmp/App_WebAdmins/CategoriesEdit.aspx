<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="CategoriesEdit.aspx.cs" Inherits="eCorp.App_WebAdmins.CategoriesEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
        <tr>
            <td align="left">
                <asp:Label ID="lbModeMessage" runat="server" Text="Cập nhập thể loại"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="5" style="width: 90%">
                    <tr>
                        <td>
                            <asp:Label ID="lbCateID" runat="server" Text="Mã thể loại"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCateID" runat="server" Width="216px"></asp:TextBox>
                        &nbsp;
                            <asp:TextBox ID="txtID" runat="server" Width="27px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbCateName" runat="server" Text="Tên thể loại"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCateName" runat="server" TabIndex="1" Width="348px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbImageUrl" runat="server" Text="Hình ảnh"></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="imgImageURL" runat="server" TabIndex="2" />
                            <br />
                            <asp:TextBox ID="txtImageURL" runat="server" TabIndex="3" Width="350px"></asp:TextBox>
                            <br />
                            <asp:FileUpload ID="fulImageURL" runat="server" TabIndex="4" Width="350px" />
&nbsp;<asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" TabIndex="5" Text="Tải lên" />
                            <br />
                            <asp:Label ID="lbImageUrlMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 27px">
                            <asp:Label ID="lbCatePos" runat="server" Text="Vị trí"></asp:Label>
                        </td>
                        <td style="height: 27px">
                            <asp:TextBox ID="txtCatePos" runat="server" TabIndex="6" Width="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbLevel" runat="server" Text="Bậc thể loại"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLevel" runat="server" 
                                onselectedindexchanged="ddlLevel_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0" Selected="True">Level 0</asp:ListItem>
                                <asp:ListItem Value="1">Level 1</asp:ListItem>
                                <asp:ListItem Value="2">Level 2</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbParentId" runat="server" Text="Thể loại mẹ"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlParentId" runat="server" Width="216px" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" TabIndex="7" 
                    Text="Lưu" Width="60px" />
&nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" TabIndex="8" 
                    Text="Bỏ qua" Width="60px" />
            </td>
        </tr>
    </table>
</asp:Content>
